using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum CredentialState
    {

        NotSet = SafeNativeMethods.WINBIO_CREDENTIAL_STATE.WINBIO_CREDENTIAL_NOT_SET,

        Set = SafeNativeMethods.WINBIO_CREDENTIAL_STATE.WINBIO_CREDENTIAL_SET

    }

}