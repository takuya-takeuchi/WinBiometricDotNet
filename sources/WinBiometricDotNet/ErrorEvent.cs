namespace WinBiometricDotNet
{

    public sealed class ErrorEvent : EventParameter
    {

        #region Constructors

        internal ErrorEvent(int errorCode)
        {
            this.ErrorCode = errorCode;

        }

        #endregion

        #region Properties

        public int ErrorCode
        {
            get;
        }

        #endregion

    }

}