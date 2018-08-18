using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultGetEvent"/> class contains the results of events to monitor.
    /// </summary>
    /// <remarks>This class is not currently supported.</remarks>
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
                        (RejectDetail)winbioEventUnclaimed.RejectDetail);
                    break;
                case SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY:
                    var winbioEventUnclaimedidentity = @event->Parameters.UnclaimedIdentify;
                    this.Parameter = new UnclaimedIdentifyEvent(winbioEventUnclaimedidentity.UnitId,
                        (FingerPosition)winbioEventUnclaimedidentity.SubFactor,
                        new BiometricIdentity(&winbioEventUnclaimedidentity.Identity),
                        (RejectDetail)winbioEventUnclaimedidentity.RejectDetail);
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

        /// <summary>
        /// Gets a value that specifies the type of service provider event notice raised.
        /// </summary>
        public EventTypes EventType
        {
            get;
        }

        /// <summary>
        /// Gets the data that contains status information sent to the callback routine when an event notice is raised.
        /// </summary>
        public EventParameter Parameter
        {
            get;
        }

        #endregion

    }

}