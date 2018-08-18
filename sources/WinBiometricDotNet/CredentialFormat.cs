using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="CredentialFormat"/> enumeration specifies the end-user credential format.
    /// </summary>
    public enum CredentialFormat
    {

        /// <summary>
        /// The password is in a generic format.
        /// </summary>
        Generic = SafeNativeMethods.WINBIO_CREDENTIAL_FORMAT.WINBIO_PASSWORD_GENERIC,

        /// <summary>
        /// The password is in a compressed format.
        /// </summary>
        Packed = SafeNativeMethods.WINBIO_CREDENTIAL_FORMAT.WINBIO_PASSWORD_PACKED,

        /// <summary>
        /// The password credential was wrapped with CredProtect.
        /// </summary>
        Protected = SafeNativeMethods.WINBIO_CREDENTIAL_FORMAT.WINBIO_PASSWORD_PROTECTED

    }

}