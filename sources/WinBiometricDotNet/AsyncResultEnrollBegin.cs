using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultEnrollBegin"/> class contains the results of an asynchronous call to <see cref="WinBiometric.BeginEnroll"/>.
    /// </summary>
    public sealed class AsyncResultEnrollBegin : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnrollBegin(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENROLLBEGIN* enrollbegin)
        {
            this.FingerPosition = (FingerPosition)enrollbegin->SubFactor;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that provides additional information about the enrollment.
        /// </summary>
        public FingerPosition FingerPosition
        {
            get;
        }

        #endregion

    }

}