using System;

namespace WinBiometricDotNet
{

    public sealed class CaptureSampleEventArgs : EventArgs
    {

        #region Constructors

        internal CaptureSampleEventArgs(CaptureSampleResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        public CaptureSampleResult Result
        {
            get;
            internal set;
        }

        #endregion

    }

}