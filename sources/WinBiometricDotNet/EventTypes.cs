using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum EventTypes : uint
    {

        Unclaimed = SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED,

        UnclaimedIdentify = SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY,

        Error = SafeNativeMethods.WINBIO_EVENT_ERROR

    }

}