using System;

namespace WinBiometricDotNet
{

    public sealed class Session
    {

        #region Constructors

        internal Session(UIntPtr handle)
        {
            this.Handle = handle;
        }

        #endregion

        #region Properties

        public UIntPtr Handle
        {
            get;
        }

        #endregion

    }

}