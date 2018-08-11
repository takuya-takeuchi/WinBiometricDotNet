using System;

namespace WinBiometricDotNet
{

    public sealed class EnrollCapturedEventArgs : EventArgs
    {

        #region Constructors

        internal EnrollCapturedEventArgs(RejectDetails rejectDetail, OperationStatus operationStatus)
        {
            this.RejectDetail = rejectDetail;
            this.OperationStatus = operationStatus;
        }

        #endregion

        #region Properties

        public OperationStatus OperationStatus
        {
            get;
        }

        public RejectDetails RejectDetail
        {
            get;
        }

        #endregion

    }

}