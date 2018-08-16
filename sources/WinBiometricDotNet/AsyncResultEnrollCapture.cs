using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultEnrollCapture : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnrollCapture(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENROLLCAPTURE* enrollCapture)
        {
            this.RejectDetail = (RejectDetail)enrollCapture->RejectDetail;
        }

        #endregion

        #region Properties

        public RejectDetail RejectDetail
        {
            get;
        }

        #endregion

    }

}