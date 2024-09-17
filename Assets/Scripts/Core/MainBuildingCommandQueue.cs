using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;
public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
    [Inject] CommandExecutorBase<ISetStackPointCommand> _setStackPointCommandExecutor;

    public void Clear() { }
    public async void EnqueueCommand(object command)
    {
        await _produceUnitCommandExecutor.TryExecuteCommand(command);
        await _setStackPointCommandExecutor.TryExecuteCommand(command);
    }
}

