using Abstractions.Commands.CommandsInterfaces;
using Core;
using UnityEngine;

namespace Abstractions.Commands.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            GetComponent<UnitMovementStop>().OnStop?.Invoke();
        }            
    }
}