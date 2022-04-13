using System;
using UnityEngine;
using UniRx;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(StatefulScriptableObjectValueBase<T>), menuName = "Strategy Game/" + nameof(StatefulScriptableObjectValueBase<T>), order = 0)]
    public class StatefulScriptableObjectValueBase<T> : ScriptableObject, IObservable<T>, IAwaitable<T>
    {
        public Action<T> OnNewValue { get; set; }

        private ReactiveProperty<T> _currentValue = new ReactiveProperty<T>();
        public ReactiveProperty<T> CurrentValue => _currentValue;

        public void SetValue(T value)
        {
            _currentValue.Value = value;
            OnNewValue?.Invoke(value);
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _currentValue.Subscribe(observer);
            return _currentValue;
        }
        public IAwaiter<T> GetAwaiter()
        {
            return new NewStatefulValueNotifier<T>(this);
        }
    }
}
