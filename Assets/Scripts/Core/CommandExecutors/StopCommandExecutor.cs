using Abstractions.Commands.CommandsInterfaces;
using Core;
using UnityEngine;

namespace Abstractions.Commands.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            _stop.OnStop?.Invoke();
        }            
    }
}