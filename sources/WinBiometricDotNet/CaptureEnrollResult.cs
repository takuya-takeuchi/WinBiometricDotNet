namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="CaptureEnrollResult"/> class contains a result returned from <see cref="WinBiometric.CaptureEnroll"/> or <see cref="WinBiometric.CaptureEnrollWithCallback"/>.
    /// </summary>
    public sealed class CaptureEnrollResult
    {

        #region Constructors

        internal CaptureEnrollResult(OperationStatus operationStatus, RejectDetail rejectDetail):
            this(operationStatus, rejectDetail, false)
        {
        }

        internal CaptureEnrollResult(OperationStatus operationStatus, RejectDetail rejectDetail, bool isRequiredMoreData)
        {
            this.OperationStatus = operationStatus;
            this.RejectDetail = rejectDetail;
            this.IsRequiredMoreData = isRequiredMoreData;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the error code returned by the capture operation.
        /// </summary>
        public OperationStatus OperationStatus
        {
            get;
        }

        /// <summary>
        /// Gets a value that contains additional information about the failure to capture a biometric sample.
        /// </summary>
        public RejectDetail RejectDetail
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether enrollment operation requires more biometrics sample.
        /// </summary>
        public bool IsRequiredMoreData
        {
            get;
        }

        #endregion

    }

}