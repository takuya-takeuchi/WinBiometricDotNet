using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="BiometricUnitVersion"/> class contains the software version number of a biometric service provider component.
    /// </summary>
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

        /// <summary>
        /// Gets the major version number.
        /// </summary>
        public uint MajorVersion
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the minor version number.
        /// </summary>
        public uint MinorVersion
        {
            get;
            internal set;
        }

        #endregion

    }

}