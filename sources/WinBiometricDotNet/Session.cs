using System;

namespace WinBiometricDotNet
{

    public sealed class Session
    {

        #region Constructors

        internal Session(IntPtr handle)
        {
            this.Handle = handle;
        }

        #endregion

        #region Properties

        public IntPtr Handle
        {
            get;
        }

        #endregion

    }

}