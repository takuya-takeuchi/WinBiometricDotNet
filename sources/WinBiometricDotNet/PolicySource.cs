using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="PolicySource"/> enumeration specifies the possible sources of policy information for the detection of spoofing for biometric factors.
    /// </summary>
    public enum PolicySource
    {

        /// <summary>
        /// The source of the policy is unknown.
        /// </summary>
        Unknown = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_UNKNOWN,

        /// <summary>
        /// The policy is the default policy that the Windows Biometric Framework provides.
        /// </summary>
        Default = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_DEFAULT,

        /// <summary>
        /// The policy that the individual user set for their account by using the Settings app. This policy overrides the default policy.
        /// </summary>
        Local = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_LOCAL,

        /// <summary>
        /// A group policy that the IT administrator set for the enterprise. Individual users cannot override this policy.
        /// </summary>
        Admin = SafeNativeMethods.WINBIO_POLICY_SOURCE.WINBIO_POLICY_ADMIN,

    }

}