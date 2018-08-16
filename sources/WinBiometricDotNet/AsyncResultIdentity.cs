using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultIdentity : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultIdentity(SafeNativeMethods.WINBIO_ASYNC_RESULT_IDENTITY* identity)
        {
            this.Identity = new BiometricIdentity(&identity->Identity);
            this.FingerPosition = (FingerPosition)identity->SubFactor;
            this.RejectDetail = (RejectDetails)identity->RejectDetail;
        }

        #endregion

        #region Properties

        public BiometricIdentity Identity
        {
            get;
        }

        public FingerPosition FingerPosition
        {
            get;
        }

        public RejectDetails RejectDetail
        {
            get;
        }

        #endregion

    }

}