using WINBIO_SESSION_HANDLE = System.UInt32;

namespace WinBiometricDotNet
{

    public sealed class Session
    {

        #region Constructors

        internal Session(WINBIO_SESSION_HANDLE handle)
        {
            this.Handle = handle;
        }

        #endregion

        #region Properties

        public WINBIO_SESSION_HANDLE Handle
        {
            get;
        }

        #endregion

    }

}