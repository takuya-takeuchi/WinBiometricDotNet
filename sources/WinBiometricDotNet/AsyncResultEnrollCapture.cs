using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultEnrollCapture : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnrollCapture(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENROLLCAPTURE* enrollCapture)
        {
            this.RejectDetail = (RejectDetails)enrollCapture->RejectDetail;
        }

        #endregion

        #region Properties

        public RejectDetails RejectDetail
        {
            get;
        }

        #endregion

    }

}