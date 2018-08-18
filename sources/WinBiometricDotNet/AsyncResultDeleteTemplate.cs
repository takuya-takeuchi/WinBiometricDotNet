using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultDeleteTemplate"/> class contains the results of an asynchronous call to <see cref="WinBiometric.DeleteTemplate"/>.
    /// </summary>
    public sealed class AsyncResultDeleteTemplate : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultDeleteTemplate(SafeNativeMethods.WINBIO_ASYNC_RESULT_DELETESAMPLE* deleteSample)
        {
            this.Identity = new BiometricIdentity(&deleteSample->Identity);
            this.FingerPosition = (FingerPosition)deleteSample->SubFactor;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the data that contains the GUID or SID of the template to be deleted.
        /// </summary>
        public BiometricIdentity Identity
        {
            get;
        }

        /// <summary>
        /// Gets a value that provides additional information about the template to be deleted.
        /// </summary>
        public FingerPosition FingerPosition
        {
            get;
        }

        #endregion

    }

}