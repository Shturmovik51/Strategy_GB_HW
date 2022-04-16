using System;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(GameObjectValue), menuName = "Strategy Game/" + nameof(GameObjectValue), order = 0)]
    public sealed class GameObjectValue : StatelessScriptableObjectValueBase<GameObject>
    { 
        
    }
}
