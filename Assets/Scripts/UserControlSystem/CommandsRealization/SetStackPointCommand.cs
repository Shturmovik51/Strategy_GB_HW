using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public sealed class SetStackPointCommand : ISetStackPointCommand
    {
        public Vector3 Point { get; }
        
        public SetStackPointCommand(Vector3 point)
        {
            Point = point;
        }
    }
}
