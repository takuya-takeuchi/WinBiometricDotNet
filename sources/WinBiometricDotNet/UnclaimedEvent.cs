namespace WinBiometricDotNet
{

    public sealed class UnclaimedEvent : EventParameter
    {

        #region Constructors

        internal UnclaimedEvent(uint unidId, RejectDetail rejectDetail)
        {
            this.UnidId = unidId;
            this.RejectDetail = rejectDetail;

        }

        #endregion

        #region Properties

        public RejectDetail RejectDetail
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