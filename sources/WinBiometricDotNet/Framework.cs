using System;

namespace WinBiometricDotNet
{

    public sealed class Framework
    {

        #region Constructors

        internal Framework(UIntPtr handle)
        {
            this.Handle = handle;
        }

        #endregion

        #region Properties

        public UIntPtr Handle
        {
            get;
        }

        #endregion

    }

}