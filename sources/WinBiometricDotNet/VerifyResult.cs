namespace WinBiometricDotNet
{

    public sealed class VerifyResult
    {

        #region Constructors

        internal VerifyResult(bool match, uint unitId, OperationStatus operationStatus, RejectDetails rejectDetail)
        {
            this.IsMatch = match;
            this.UnitId = unitId;
            this.OperationStatus = operationStatus;
            this.RejectDetail = rejectDetail;
        }

        #endregion

        #region Properties

        public bool IsMatch
        {
            get;
        }

        public OperationStatus OperationStatus
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

        #endregion

    }

}