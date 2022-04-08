using Utils;

namespace UserControlSystem
{
    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly IAwaitable<TAwaited> _scriptableObjectValueBase;
        
        public NewValueNotifier(IAwaitable<TAwaited> scriptableObjectValueBase)
        {
            _scriptableObjectValueBase = scriptableObjectValueBase;
            _scriptableObjectValueBase.OnNewValue += ONNewValue;
        }

        private void ONNewValue(TAwaited obj)
        {
            _scriptableObjectValueBase.OnNewValue -= ONNewValue;
            OnWaitFinish(obj);
        }
    }
}