using System;
using UniRx;
using Utils;

namespace UserControlSystem
{
    public class NewStatefulValueNotifier<T> : AwaiterBase<T>
    {        
        private readonly StatefulScriptableObjectValueBase<T> _scriptableObjectValueBase;

        public NewStatefulValueNotifier(StatefulScriptableObjectValueBase<T> scriptableObjectValueBase)
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