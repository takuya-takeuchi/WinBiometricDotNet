using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    [Flags]
    public enum CredentialTypes : uint
    {

        Password = SafeNativeMethods.WINBIO_CREDENTIAL_TYPE.WINBIO_CREDENTIAL_PASSWORD,

        All = SafeNativeMethods.WINBIO_CREDENTIAL_TYPE.WINBIO_CREDENTIAL_ALL

    }

}