using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public sealed class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{  
    public override void ExecuteSpecificCommand(IPatrolCommand command)
        => Debug.Log(command.Action);   
    
}