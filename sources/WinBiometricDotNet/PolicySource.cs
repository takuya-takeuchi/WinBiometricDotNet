using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum PolicySource
    {

        Unknown = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_UNKNOWN,

        Default = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_DEFAULT,

        Local = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_LOCAL,

        Admin = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_ADMIN,

    }

}