using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [Inject] private DiContainer _diContainer;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;
        [SerializeField] private Transform _spawnPoint;

        private Vector3 _stackPoint;
        private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();

        private void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            var innerTask = (UnitProductionTask)_queue[0];
            innerTask.TimeLeft -= Time.deltaTime;
            if (innerTask.TimeLeft <= 0)
            {
                RemoveTaskAtIndex(0);
                var instantiatedObject = 
                    _diContainer.InstantiatePrefab(innerTask.UnitPrefab, _spawnPoint.position, Quaternion.identity, _unitsParent);
                var moveCommandExecutor = instantiatedObject.GetComponent<MoveCommandExecutor>();

                var task = moveCommandExecutor.ExecuteSpecificCommand(
                    new MoveCommand(_stackPoint == Vector3.zero ? _spawnPoint.position : _stackPoint));
            }
        }

        public void SetStackPoint(Vector3 point)
        {
            _stackPoint = point;
        }

        public void Cancel(int index) => RemoveTaskAtIndex(index);

        private void RemoveTaskAtIndex(int index)
        {
            for (int i = index; i < _queue.Count - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }
            _queue.RemoveAt(_queue.Count - 1);
        }

        public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {             
            _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName));
        }
    }
}