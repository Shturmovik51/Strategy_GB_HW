using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface ISetStackPointCommand : ICommand
    {
        public Vector3 Point { get; }
    }
}
