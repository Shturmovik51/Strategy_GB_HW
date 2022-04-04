using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public sealed class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{  
    public override void ExecuteSpecificCommand(IStopCommand command)
        => Debug.Log(command.Action);   
    
}