using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Specifies the types of actions you take for the antispoofing policy of a user.
    /// </summary>
    public enum AntiSpoofPolicyAction
    {

        /// <summary>
        /// Turns off the detection of spoofing for a biometric factor.
        /// </summary>
        Disable = SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY_ACTION.WINBIO_ANTI_SPOOF_DISABLE,

        /// <summary>
        /// Turns on the detection of spoofing for a biometric factor.
        /// </summary>
        Enable = SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY_ACTION.WINBIO_ANTI_SPOOF_ENABLE,

        /// <summary>
        /// Removes the entire antispoofing policy for the biometric factor from the account.
        /// </summary>
        Remove = SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY_ACTION.WINBIO_ANTI_SPOOF_REMOVE,

    }

}