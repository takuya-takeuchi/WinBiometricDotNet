using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultEnrollCapture"/> class contains the results of an asynchronous call to <see cref="WinBiometric.CaptureEnroll"/>.
    /// </summary>
    public sealed class AsyncResultEnrollCapture : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnrollCapture(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENROLLCAPTURE* enrollCapture)
        {
            this.RejectDetail = (RejectDetail)enrollCapture->RejectDetail;
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

        #endregion

    }

}