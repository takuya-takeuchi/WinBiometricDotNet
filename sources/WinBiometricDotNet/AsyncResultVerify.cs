using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultVerify"/> class contains the results of an asynchronous call to <see cref="WinBiometric.Verify"/>.
    /// </summary>
    public sealed class AsyncResultVerify : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultVerify(SafeNativeMethods.WINBIO_ASYNC_RESULT_VERIFY* verify)
        {
            this.IsMatch = verify->Match;
            this.RejectDetail = (RejectDetail)verify->RejectDetail;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the captured sample matched the user identity specified.
        /// </summary>
        public bool IsMatch
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