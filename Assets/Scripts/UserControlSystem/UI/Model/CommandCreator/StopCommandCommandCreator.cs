using Abstractions.Commands.CommandsInterfaces;
using System;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public sealed class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            return;
        }
    }
}