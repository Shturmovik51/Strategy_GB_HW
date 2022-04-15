using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Core.CommandExecutors;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class SetStackPointCommandExecutor : CommandExecutorBase<ISetStackPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetStackPointCommand command)
        {
            var produceCommandExecutor = GetComponent<ProduceUnitCommandExecutor>();
            produceCommandExecutor.SetStackPoint(command.Point);
            Debug.Log($"{command.Point} is set as stack position for units!");
        }
    }
}