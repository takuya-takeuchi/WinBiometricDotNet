using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum CredentialFormat
    {

        Generic = SafeNativeMethods.WINBIO_CREDENTIAL_FORMAT.WINBIO_PASSWORD_GENERIC,

        Packed = SafeNativeMethods.WINBIO_CREDENTIAL_FORMAT.WINBIO_PASSWORD_PACKED,

        Protected = SafeNativeMethods.WINBIO_CREDENTIAL_FORMAT.WINBIO_PASSWORD_PROTECTED

    }

}