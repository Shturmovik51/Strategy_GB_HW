using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace Core
{
    public class HealBuildingCommandQueue: MonoBehaviour, ICommandsQueue
    {
        [Inject] CommandExecutorBase<IHealCommand> _healCommandExecutor;

        public void Clear() { }

        public async void EnqueueCommand(object command)
        {
            await _healCommandExecutor.TryExecuteCommand(command);
        }
    }
}