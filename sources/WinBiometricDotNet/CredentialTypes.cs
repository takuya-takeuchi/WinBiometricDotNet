using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="CredentialTypes"/> enumeration filter on the credential type.
    /// </summary>
    [Flags]
    public enum CredentialTypes : uint
    {

        /// <summary>
        /// Filters password credentials.
        /// </summary>
        Password = SafeNativeMethods.WINBIO_CREDENTIAL_TYPE.WINBIO_CREDENTIAL_PASSWORD,

        /// <summary>
        /// Filters all credentials.
        /// </summary>
        All = SafeNativeMethods.WINBIO_CREDENTIAL_TYPE.WINBIO_CREDENTIAL_ALL

    }

}