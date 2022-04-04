using UnityEngine;

namespace Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        GameObject Marker { get; }
        Sprite Icon { get; }
    }
}