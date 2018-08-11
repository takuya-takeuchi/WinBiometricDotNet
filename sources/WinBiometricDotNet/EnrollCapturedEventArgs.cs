using System;

namespace WinBiometricDotNet
{

    public sealed class EnrollCapturedEventArgs : EventArgs
    {

        #region Constructors

        internal EnrollCapturedEventArgs(RejectDetails rejectDetails, OperationStatus operationStatus)
        {
            this.RejectDetails = rejectDetails;
            this.OperationStatus = operationStatus;
        }

        #endregion

        #region Properties

        public OperationStatus OperationStatus
        {
            get;
        }

        public RejectDetails RejectDetails
        {
            get;
        }

        #endregion

    }

}