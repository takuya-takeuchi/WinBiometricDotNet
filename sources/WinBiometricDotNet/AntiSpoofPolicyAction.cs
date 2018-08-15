using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum AntiSpoofPolicyAction
    {

        Disable = SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY_ACTION.WINBIO_ANTI_SPOOF_DISABLE,

        Enable = SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY_ACTION.WINBIO_ANTI_SPOOF_ENABLE,

        Remove = SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY_ACTION.WINBIO_ANTI_SPOOF_REMOVE,

    }

}