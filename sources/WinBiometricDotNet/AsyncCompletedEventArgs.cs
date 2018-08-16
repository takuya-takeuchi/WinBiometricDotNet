using System;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.AsyncCompleted"/> event handler.
    /// </summary>
    public sealed class AsyncCompletedEventArgs : EventArgs
    {

        #region Constructors

        internal AsyncCompletedEventArgs(AsyncResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that represents the result of an event.
        /// </summary>
        public AsyncResult Result
        {
            get;
        }

        #endregion

    }

}