using System;

namespace Utils
{
    public interface IAwaitable<T>
    {
        public Action<T> OnNewValue { get; set; }
        IAwaiter<T> GetAwaiter();
    }
}