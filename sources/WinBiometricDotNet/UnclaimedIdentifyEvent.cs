namespace WinBiometricDotNet
{

    public sealed class UnclaimedIdentifyEvent : EventParameter
    {

        #region Constructors

        internal UnclaimedIdentifyEvent(uint unidId, FingerPosition fingerPosition, BiometricIdentity identity, RejectDetails rejectDetail)
        {
            this.UnidId = unidId;
            this.FingerPosition = fingerPosition;
            this.Identity = identity;
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

        public uint UnidId
        {
            get;
        }

        #endregion

    }

}