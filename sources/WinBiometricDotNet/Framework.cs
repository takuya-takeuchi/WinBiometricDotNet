using WINBIO_FRAMEWORK_HANDLE = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Represent the handle to the biometric framework.
    /// </summary>
    public sealed class Framework
    {

        #region Constructors

        internal Framework(WINBIO_FRAMEWORK_HANDLE handle)
        {
            this.Handle = handle;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the pointer to the handle.
        /// </summary>
        public WINBIO_FRAMEWORK_HANDLE Handle
        {
            get;
        }

        #endregion

    }

}