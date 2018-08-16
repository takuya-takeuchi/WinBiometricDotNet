using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultEnrollBegin : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnrollBegin(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENROLLBEGIN* enrollbegin)
        {
            this.FingerPosition = (FingerPosition)enrollbegin->SubFactor;
        }

        #endregion

        #region Properties

        public FingerPosition FingerPosition
        {
            get;
        }

        #endregion

    }

}