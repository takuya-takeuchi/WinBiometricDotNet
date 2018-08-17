using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="CredentialState"/> enumeration specifies whether a credential has been associated with the biometric data for an end user.
    /// </summary>
    public enum CredentialState
    {

        /// <summary>
        /// A credential has been associated with the end user.
        /// </summary>
        NotSet = SafeNativeMethods.WINBIO_CREDENTIAL_STATE.WINBIO_CREDENTIAL_NOT_SET,

        /// <summary>
        /// A credential has not been associated with the end user.
        /// </summary>
        Set = SafeNativeMethods.WINBIO_CREDENTIAL_STATE.WINBIO_CREDENTIAL_SET

    }

}