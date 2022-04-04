using System;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public sealed class AttackableValue : ScriptableObjectValueBase<IAttackable>
    {
        public IAwaiter<IAttackable> GetAwaiter()
        {
            throw new NotImplementedException();
        }
    }
}