using System;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.Identified"/> event handler.
    /// </summary>
    public sealed class IdentifiedEventArgs : EventArgs
    {

        #region Constructors

        internal IdentifiedEventArgs(IdentifyResult result)
        {
            this.Result = result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value that represents the result of an event.
        /// </summary>
        public IdentifyResult Result
        {
            get;
            internal set;
        }

        #endregion

    }

}