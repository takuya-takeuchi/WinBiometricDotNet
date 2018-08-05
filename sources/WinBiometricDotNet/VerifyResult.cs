namespace WinBiometricDotNet
{

    public sealed class VerifyResult
    {

        #region Constructors

        internal VerifyResult(bool match, uint unitId, uint rejectDetail)
        {
            this.IsMatch = match;
            this.UnitId = unitId;
            this.RejectDetail = rejectDetail;
        }

        #endregion

        #region Properties

        public bool IsMatch
        {
            get;
        }

        public uint RejectDetail
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