namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="UnclaimedIdentifyEvent"/> class contains the event for biometric capture and identification.
    /// </summary>
    public sealed class UnclaimedIdentifyEvent : EventParameter
    {

        #region Constructors

        internal UnclaimedIdentifyEvent(uint unidId, FingerPosition fingerPosition, BiometricIdentity identity, RejectDetail rejectDetail)
        {
            this.UnidId = unidId;
            this.FingerPosition = fingerPosition;
            this.Identity = identity;
            this.RejectDetail = rejectDetail;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that specifies the sub-factor associated with a biometric sample.
        /// </summary>
        public FingerPosition FingerPosition
        {
            get;
        }

        /// <summary>
        /// Gets the data that contains the GUID or SID of the user providing the biometric sample.
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
        /// Gets the biometric unit that generated the sample.
        /// </summary>
        public uint UnidId
        {
            get;
        }

        #endregion

    }

}