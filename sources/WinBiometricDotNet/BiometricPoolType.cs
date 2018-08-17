using WinBiometricDotNet.Interop;
using WINBIO_POOL_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="BiometricPoolType"/> enumeration specifies the type of biometric unit pool to be used in the session.
    /// </summary>
    public enum BiometricPoolType: WINBIO_POOL_TYPE
    {

        /// <summary>
        /// The pool type is unknown.
        /// </summary>
        Unknown = SafeNativeMethods.WINBIO_POOL_UNKNOWN,

        /// <summary>
        /// Specifies a shared collection of biometric units managed by the service provider.
        /// </summary>
        System = SafeNativeMethods.WINBIO_POOL_SYSTEM,

        /// <summary>
        /// Specifies a collection of biometric units that are managed by the caller.
        /// </summary>
        Private = SafeNativeMethods.WINBIO_POOL_PRIVATE,

        /// <summary>
        /// Reserved.
        /// </summary>
        Unassigned = SafeNativeMethods.WINBIO_POOL_UNASSIGNED

    }

}