using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GrenadierBuildingCommandQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] CommandExecutorBase<IProduceGrenadierCommand> _produceGrenadierCommandExecutor;
        [Inject] CommandExecutorBase<ISetStackPointCommand> _setStackPointCommandExecutor;

        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _produceGrenadierCommandExecutor.TryExecuteCommand(command);
            await _setStackPointCommandExecutor.TryExecuteCommand(command);
        }
    }
}