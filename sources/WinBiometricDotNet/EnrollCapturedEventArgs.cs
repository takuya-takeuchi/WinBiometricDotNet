using System;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.EnrollCaptured"/> event handler.
    /// </summary>
    public sealed class EnrollCapturedEventArgs : EventArgs
    {

        #region Constructors

        internal EnrollCapturedEventArgs(CaptureEnrollResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that represents the result of an event.
        /// </summary>
        public CaptureEnrollResult Result
        {
            get;
        }

        #endregion

    }

}