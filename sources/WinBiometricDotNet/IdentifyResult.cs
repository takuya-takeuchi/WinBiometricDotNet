namespace WinBiometricDotNet
{

    public sealed class IdentifyResult
    {

        #region Constructors

        internal IdentifyResult(uint unitId, OperationStatus operationStatus, BiometricIdentity identity, FingerPosition fingerPosition, RejectDetails rejectDetail)
        {
            this.UnitId = unitId;
            this.OperationStatus = operationStatus;
            this.Identity = identity;
            this.FingerPosition = fingerPosition;
            this.RejectDetail = rejectDetail;
        }

        #endregion

        #region Properties

        public FingerPosition FingerPosition
        {
            get;
        }

        public BiometricIdentity Identity
        {
            get;
        }

        public RejectDetails RejectDetail
        {
            get;
        }

        public uint UnitId
        {
            get;
        }

        public OperationStatus OperationStatus
        {
            get;
        }

        #endregion

    }

}