using WINBIO_FRAMEWORK_HANDLE = System.UInt32;

namespace WinBiometricDotNet
{

    public sealed class Framework
    {

        #region Constructors

        internal Framework(WINBIO_FRAMEWORK_HANDLE handle)
        {
            this.Handle = handle;
        }

        #endregion

        #region Properties

        public WINBIO_FRAMEWORK_HANDLE Handle
        {
            get;
        }

        #endregion

    }

}