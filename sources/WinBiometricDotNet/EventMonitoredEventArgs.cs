using System;
using WinBiometricDotNet.Interop;
using HRESULT = System.Int32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.EventMonitored"/> event handler.
    /// </summary>
    public sealed class EventMonitoredEventArgs : EventArgs
    {

        #region Constructors

        internal unsafe EventMonitoredEventArgs(SafeNativeMethods.WINBIO_EVENT* @event,
                                                HRESULT operationStatus)
        {
            switch (@event->Type)
            {
                case SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED:
                    var winbioEventUnclaimed = @event->Parameters.Unclaimed;

                    this.EventParameter = new UnclaimedEvent(winbioEventUnclaimed.UnitId,
                                                             (RejectDetail)winbioEventUnclaimed.RejectDetail);
                    this.EventType = EventTypes.Unclaimed;
                    break;
                case SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY:
                    var winbioEventUnclaimedidentity = @event->Parameters.UnclaimedIdentify;

                    this.EventParameter = new UnclaimedIdentifyEvent(winbioEventUnclaimedidentity.UnitId,
                                                                     (FingerPosition)winbioEventUnclaimedidentity.SubFactor,
                                                                     new BiometricIdentity(&winbioEventUnclaimedidentity.Identity),
                                                                     (RejectDetail)winbioEventUnclaimedidentity.RejectDetail);
                    this.EventType = EventTypes.UnclaimedIdentify;
                    break;
                case SafeNativeMethods.WINBIO_EVENT_ERROR:
                    var winbioEventError = @event->Parameters.Error;

                    this.EventParameter = new ErrorEvent(winbioEventError.ErrorCode);
                    this.EventType = EventTypes.Error;
                    break;
            }

            this.OperationStatus = operationStatus;
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
        /// Gets the error code returned by the capture operation.
        /// </summary>
        public HRESULT OperationStatus
        {
            get;
        }

        /// <summary>
        /// Gets the data that contains status information sent to the callback routine when an event notice is raised.
        /// </summary>
        public EventParameter EventParameter
        {
            get;
        }

        #endregion

    }

}