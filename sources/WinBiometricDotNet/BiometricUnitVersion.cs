using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class BiometricUnitVersion
    {

        #region Constructors

        internal BiometricUnitVersion(SafeNativeMethods.WINBIO_VERSION version)
        {
            this.MinorVersion = version.MinorVersion;
            this.MajorVersion = version.MajorVersion;
        }

        #endregion

        #region Properties

        public uint MajorVersion
        {
            get;
            internal set;
        }

        public uint MinorVersion
        {
            get;
            internal set;
        }

        #endregion

    }

}