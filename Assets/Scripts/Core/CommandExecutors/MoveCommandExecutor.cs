using Abstractions.Commands.CommandsInterfaces;
using Core;
using UnityEngine;
using UnityEngine.AI;

namespace Abstractions.Commands.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        private readonly int Walk = Animator.StringToHash("Walk");
        private readonly int Idle = Animator.StringToHash("Idle");
        private NavMeshAgent _navMeshAgent;

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.destination = command.Target;
            _animator.SetTrigger(Walk);
            await _stop;
            _navMeshAgent.destination = transform.position;
            _animator.SetTrigger(Idle);
        }
    }
}