using System;
using UnityEngine;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(ScriptableObjectValueBase<T>), menuName = "Strategy Game/" + nameof(ScriptableObjectValueBase<T>), order = 0)]
    public class ScriptableObjectValueBase<T> : ScriptableObject, IAwaitable<T>
    {       
        public T CurrentValue { get; private set; }
        public Action<T> OnNewValue { get; set; }
        public void SetValue(T value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }
        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }
}
