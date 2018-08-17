namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="IdentifyResult"/> class contains a result returned from <see cref="WinBiometric.Identify"/> or <see cref="WinBiometric.IdentifyWithCallback"/>.
    /// </summary>
    public sealed class IdentifyResult
    {

        #region Constructors

        internal IdentifyResult(uint unitId, OperationStatus operationStatus, BiometricIdentity identity, FingerPosition fingerPosition, RejectDetail rejectDetail)
        {
            this.UnitId = unitId;
            this.OperationStatus = operationStatus;
            this.Identity = identity;
            this.FingerPosition = fingerPosition;
            this.RejectDetail = rejectDetail;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that receives the sub-factor associated with the biometric sample.
        /// </summary>
        public FingerPosition FingerPosition
        {
            get;
        }

        /// <summary>
        /// Gets the data that receives the GUID or SID of the user providing the biometric sample.
        /// </summary>
        public BiometricIdentity Identity
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
        /// Gets a value that specifies the biometric unit used to perform the identification.
        /// </summary>
        public uint UnitId
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

        #endregion

    }

}