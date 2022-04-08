using System;
using UniRx;
using Utils;

namespace UserControlSystem
{
    public class NewStatelessValueNotifier<T> : AwaiterBase<T>
    {
        public NewStatelessValueNotifier(SOStatelessValueBase<T> scriptableObjectValue)
        {
            scriptableObjectValue.CurrentValue.Subscribe(OnWaitFinish);
        }
    }
}
