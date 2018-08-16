using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultGetEvent : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultGetEvent(SafeNativeMethods.WINBIO_ASYNC_RESULT_GETEVENT* getEvent)
        {
            var @event = &getEvent->Event;
            switch (@event->Type)
            {
                case SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED:
                    var winbioEventUnclaimed = @event->Parameters.Unclaimed;
                    this.Parameter = new UnclaimedEvent(winbioEventUnclaimed.UnitId,
                        (RejectDetails)winbioEventUnclaimed.RejectDetail);
                    break;
                case SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY:
                    var winbioEventUnclaimedidentity = @event->Parameters.UnclaimedIdentify;
                    this.Parameter = new UnclaimedIdentifyEvent(winbioEventUnclaimedidentity.UnitId,
                        (FingerPosition)winbioEventUnclaimedidentity.SubFactor,
                        new BiometricIdentity(winbioEventUnclaimedidentity.Identity),
                        (RejectDetails)winbioEventUnclaimedidentity.RejectDetail);
                    break;
                case SafeNativeMethods.WINBIO_EVENT_ERROR:
                    var winbioEventError = @event->Parameters.Error;
                    this.Parameter = new ErrorEvent(winbioEventError.ErrorCode);
                    break;
            }

            this.EventType = (EventTypes)@event->Type;
        }

        #endregion

        #region Properties

        public EventTypes EventType
        {
            get;
        }

        public EventParameter Parameter
        {
            get;
        }

        #endregion

    }

}