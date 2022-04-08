using System;
using UniRx;
using Utils;

namespace UserControlSystem
{
    public class NewStatefulValueNotifier<T> : AwaiterBase<T>
    {
        public NewStatefulValueNotifier(SOStatefulValueBase<T> scriptableObjectValue)
        {
            scriptableObjectValue.CurrentValue.Subscribe(OnWaitFinish);
        }
    }
}