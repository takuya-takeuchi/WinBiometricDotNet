namespace WinBiometricDotNet
{

    public sealed class CaptureEnrollResult
    {

        #region Constructors

        internal CaptureEnrollResult(OperationStatus operationStatus, RejectDetails rejectDetail):
            this(operationStatus, rejectDetail, false)
        {
        }

        internal CaptureEnrollResult(OperationStatus operationStatus, RejectDetails rejectDetail, bool isRequiredMoreData)
        {
            this.OperationStatus = operationStatus;
            this.RejectDetail = rejectDetail;
            this.IsRequiredMoreData = isRequiredMoreData;
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

        public bool IsRequiredMoreData
        {
            get;
        }

        #endregion

    }

}