using System;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.EventMonitored"/> event handler.
    /// </summary>
    public sealed class EventMonitoredEventArgs : EventArgs
    {

        #region Constructors

        internal EventMonitoredEventArgs(EventTypes eventType,
                                         OperationStatus operationStatus,
                                         UnclaimedEvent unclaimed,
                                         UnclaimedIdentifyEvent unclaimedIdentify,
                                         ErrorEvent error)
        {
            this.EventType = eventType;
            this.OperationStatus = operationStatus;
            this.Unclaimed = unclaimed;
            this.UnclaimedIdentify = unclaimedIdentify;
            this.Error = error;
        }

        #endregion

        #region Properties

        public EventTypes EventType
        {
            get;
        }

        /// <summary>
        /// Gets the error code returned by the capture operation.
        /// </summary>
        public OperationStatus OperationStatus
        {
            get;
        }

        public UnclaimedEvent Unclaimed
        {
            get;
        }

        public UnclaimedIdentifyEvent UnclaimedIdentify
        {
            get;
        }

        public ErrorEvent Error
        {
            get;
        }

        #endregion

    }

}