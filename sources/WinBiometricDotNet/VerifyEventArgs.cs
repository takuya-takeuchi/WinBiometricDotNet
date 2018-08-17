using System;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.SensorLocated"/> event handler.
    /// </summary>
    public sealed class VerifyEventArgs : EventArgs
    {

        #region Constructors

        internal VerifyEventArgs(VerifyResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that represents the result of an event.
        /// </summary>
        public VerifyResult Result
        {
            get;
            internal set;
        }

        #endregion

    }

}