namespace WinBiometricDotNet
{

    public sealed class UnclaimedEvent : EventParameter
    {

        #region Constructors

        internal UnclaimedEvent(uint unidId, RejectDetails rejectDetail)
        {
            this.UnidId = unidId;
            this.RejectDetail = rejectDetail;

        }

        #endregion

        #region Properties

        public RejectDetails RejectDetail
        {
            get;
        }

        public uint UnidId
        {
            get;
        }

        #endregion

    }

}