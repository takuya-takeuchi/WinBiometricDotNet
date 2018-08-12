using System;

namespace WinBiometricDotNet
{

    public sealed class IdentifiedEventArgs : EventArgs
    {

        #region Constructors

        internal IdentifiedEventArgs(IdentifyResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        public IdentifyResult Result
        {
            get;
            internal set;
        }

        #endregion

    }

}