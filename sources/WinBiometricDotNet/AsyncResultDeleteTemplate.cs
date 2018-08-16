using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultDeleteTemplate : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultDeleteTemplate(SafeNativeMethods.WINBIO_ASYNC_RESULT_DELETESAMPLE* deleteSample)
        {
            this.Identity = new BiometricIdentity(deleteSample->Identity);
            this.FingerPosition = (FingerPosition)deleteSample->SubFactor;
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

        #endregion

    }

}