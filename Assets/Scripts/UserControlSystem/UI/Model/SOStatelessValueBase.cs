using System;
using UnityEngine;
using UniRx;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SOStatelessValueBase<T>), menuName = "Strategy Game/" + nameof(SOStatelessValueBase<T>), order = 0)]
    public class SOStatelessValueBase<T> : ScriptableObject, IObservable<T>, IAwaitable<T>
    {
        public Action<T> OnNewValue { get; set; }

        private Subject<T> _currentValue = new Subject<T>();
        public Subject<T> CurrentValue => _currentValue;

        public void SetValue(T value)
        {
            _currentValue.OnNext(value);
            OnNewValue?.Invoke(value);
        }
       
        public IDisposable Subscribe(IObserver<T> observer)
        {
            _currentValue.Subscribe(observer);
            return _currentValue;
        }        
        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }
}
