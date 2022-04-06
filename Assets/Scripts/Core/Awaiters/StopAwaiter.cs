using Utils;

namespace Core
{
    public class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
    {
        private readonly UnitMovementStop _unitMovementStop;
       
        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnNewValue += ONStop;
        }

        private void ONStop(AsyncExtensions.Void parameter)
        {
            _unitMovementStop.OnNewValue -= ONStop;
            OnWaitFinish(parameter);
        }        
    }
}