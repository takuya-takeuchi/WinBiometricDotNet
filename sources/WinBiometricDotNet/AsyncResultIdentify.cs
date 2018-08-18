using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultIdentify"/> class contains the results of an asynchronous call to <see cref="WinBiometric.Identify"/>.
    /// </summary>
    public sealed class AsyncResultIdentify : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultIdentify(SafeNativeMethods.WINBIO_ASYNC_RESULT_IDENTITY* identity)
        {
            this.Identity = new BiometricIdentity(&identity->Identity);
            this.FingerPosition = (FingerPosition)identity->SubFactor;
            this.RejectDetail = (RejectDetail)identity->RejectDetail;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the data that receives the GUID or SID of the user providing the biometric sample.
        /// </summary>
        public BiometricIdentity Identity
        {
            get;
        }

        /// <summary>
        /// Gets a value that receives the sub-factor associated with the biometric sample.
        /// </summary>
        public FingerPosition FingerPosition
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

        #endregion

    }

}