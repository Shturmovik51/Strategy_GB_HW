using Abstractions.Commands.CommandsInterfaces;
using System;
using UnityEngine;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public class SetStackPointCommandCommandCreator : CancellableCommandCreatorBase<ISetStackPointCommand, Vector3>
    {
        protected override ISetStackPointCommand CreateCommand(Vector3 argument) => new SetStackPointCommand(argument);
    }
}