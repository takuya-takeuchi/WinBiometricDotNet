namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="ErrorEvent"/> class contains the data that identifies the success or failure of the operation being monitored.
    /// </summary>
    public sealed class ErrorEvent : EventParameter
    {

        #region Constructors

        internal ErrorEvent(int errorCode)
        {
            this.ErrorCode = errorCode;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an error code that resulted from computations performed by the Windows Biometric Framework.
        /// </summary>
        public int ErrorCode
        {
            get;
        }

        #endregion

    }

}