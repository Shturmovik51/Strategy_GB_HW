using System;
using UniRx;
using Utils;

namespace UserControlSystem
{
    public class NewStatelessValueNotifier<T> : AwaiterBase<T>
    {
        private readonly StatelessScriptableObjectValueBase<T> _scriptableObjectValueBase;

        public NewStatelessValueNotifier(StatelessScriptableObjectValueBase<T> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += ONNewValue;
        }

        private void ONNewValue(T obj)
        {
            _scriptableObjectValueBase.OnNewValue -= ONNewValue;
            OnWaitFinish(obj);
        }
    }
}
