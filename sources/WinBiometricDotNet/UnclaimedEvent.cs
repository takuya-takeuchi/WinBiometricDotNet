namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="UnclaimedEvent"/> class contains the event for biometric sample capture.
    /// </summary>
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