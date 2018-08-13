using System;

namespace WinBiometricDotNet
{

    public sealed class EnrollCapturedEventArgs : EventArgs
    {

        #region Constructors

        internal EnrollCapturedEventArgs(CaptureEnrollResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        public CaptureEnrollResult Result
        {
            get;
        }

        #endregion

    }

}