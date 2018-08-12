using System;

namespace WinBiometricDotNet
{

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