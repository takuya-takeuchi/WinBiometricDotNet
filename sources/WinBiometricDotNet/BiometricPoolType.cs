using WinBiometricDotNet.Interop;
using WINBIO_POOL_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    public enum BiometricPoolType: WINBIO_POOL_TYPE
    {

        Unknown = SafeNativeMethods.WINBIO_POOL_UNKNOWN,

        System = SafeNativeMethods.WINBIO_POOL_SYSTEM,

        Private  = SafeNativeMethods.WINBIO_POOL_PRIVATE,

        Unassigned = SafeNativeMethods.WINBIO_POOL_UNASSIGNED

    }

}