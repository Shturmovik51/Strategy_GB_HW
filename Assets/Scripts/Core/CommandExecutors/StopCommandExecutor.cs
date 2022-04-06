using Abstractions.Commands.CommandsInterfaces;
using Core;
using UnityEngine;
using Utils;

namespace Abstractions.Commands.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            GetComponent<UnitMovementStop>().OnNewValue?.Invoke(new AsyncExtensions.Void());
        }            
    }
}