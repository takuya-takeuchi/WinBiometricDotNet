using HRESULT = System.Int32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="VerifyResult"/> class contains a result returned from <see cref="WinBiometric.Verify"/> or <see cref="WinBiometric.VerifyWithCallback"/>.
    /// </summary>
    public sealed class VerifyResult
    {

        #region Constructors

        internal VerifyResult(bool match, uint unitId, HRESULT operationStatus, RejectDetail rejectDetail)
        {
            this.IsMatch = match;
            this.UnitId = unitId;
            this.OperationStatus = operationStatus;
            this.RejectDetail = rejectDetail;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the captured sample matched the user identity specified.
        /// </summary>
        public bool IsMatch
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
        /// Gets a value that contains additional information about the failure to capture a biometric sample.
        /// </summary>
        public RejectDetail RejectDetail
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies the biometric unit that performed the verification.
        /// </summary>
        public uint UnitId
        {
            get;
        }

        #endregion

    }

}