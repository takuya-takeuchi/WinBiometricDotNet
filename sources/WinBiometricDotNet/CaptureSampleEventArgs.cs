using System;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.SampleCaptured"/> event handler.
    /// </summary>
    public sealed class CaptureSampleEventArgs : EventArgs
    {

        #region Constructors

        internal CaptureSampleEventArgs(CaptureSampleResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that represents the result of an event.
        /// </summary>
        public CaptureSampleResult Result
        {
            get;
            internal set;
        }

        #endregion

    }

}