using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Assets.Scripts.Core;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.CommandExecutors
{
    public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
    {
        public IReadOnlyReactiveCollection<IUnitProductionTask> Queue => _queue;

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private int _maximumUnitsInQueue = 6;
        [Inject] private DiContainer _diContainer;  

        private Vector3 _point;
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
                var unit = Instantiate(innerTask.UnitPrefab, transform.position, Quaternion.identity, _unitsParent);
                if(_point != Vector3.zero)
                    _ = unit.GetComponent<MoveCommandExecutor>().ExecuteSpecificCommand(new MoveCommand(_point));
                var healthBarsView = innerTask.HealthBarViewGO.GetComponent<HealthBarsView>();
                healthBarsView.AddBar(unit.transform);
            }
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

        public void SetStackPoint(Vector3 point)
        {
            _point = point;
        }

        public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            //var instance = _diContainer.InstantiatePrefab(command.UnitPrefab, transform.position, Quaternion.identity, _unitsParent);
            //var queue = instance.GetComponent<ICommandsQueue>();
            _queue.Add(new UnitProductionTask(command.ProductionTime, command.Icon, command.UnitPrefab, command.UnitName, command.HealthBarsViewGO));
            //var mainBuilding = GetComponent<MainBuilding>();
            //var factionMember = instance.GetComponent<FactionMember>();
            //factionMember.SetFaction(GetComponent<FactionMember>().FactionId);
            //queue.EnqueueCommand(new MoveCommand(_point));
            await Task.CompletedTask;
        }
    }
}