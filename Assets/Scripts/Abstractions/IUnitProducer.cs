using UniRx;
using UnityEngine;

namespace Abstractions
{
    public interface IUnitProducer
    {
        IReadOnlyReactiveCollection<IUnitProductionTask> Queue { get; }
        public void SetStackPoint(Vector3 point);
        public void Cancel(int index);
    }
}