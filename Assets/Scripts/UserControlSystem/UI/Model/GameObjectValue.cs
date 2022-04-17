using System;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(GameObjectValue), menuName = "Strategy Game/" + nameof(GameObjectValue), order = 0)]
    public sealed class GameObjectValue : StatelessScriptableObjectValueBase<GameObject>
    { 
        
    }
}
