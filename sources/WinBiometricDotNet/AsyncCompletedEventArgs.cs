using System;

namespace WinBiometricDotNet
{

    public sealed class AsyncCompletedEventArgs : EventArgs
    {

        #region Constructors

        internal AsyncCompletedEventArgs(AsyncResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        public AsyncResult Result
        {
            get;
        }

        #endregion

    }

}