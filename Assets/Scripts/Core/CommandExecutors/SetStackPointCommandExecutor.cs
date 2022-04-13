using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Core.CommandExecutors;
using UnityEngine;

public class SetStackPointCommandExecutor : CommandExecutorBase<ISetStackPointCommand>
{
    public override void ExecuteSpecificCommand(ISetStackPointCommand command)
    {
        var produceCommandExecutor = GetComponent<ProduceUnitCommandExecutor>();
        produceCommandExecutor.SetStackPoint(command.Point);
        Debug.Log($"{command.Point} is set as stack position for units!");
    }
}
