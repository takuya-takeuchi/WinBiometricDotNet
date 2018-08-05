using System;

namespace WinBiometricDotNet
{

    public sealed class VerifyEventArgs : EventArgs
    {

        #region Constructors

        internal VerifyEventArgs(VerifyResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        public VerifyResult Result
        {
            get;
            internal set;
        }

        #endregion

    }

}