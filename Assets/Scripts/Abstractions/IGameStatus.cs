using System;

namespace Abstractions
{
    public interface IGameStatus
    {
        public IObservable<int> Status { get; }
    }
}