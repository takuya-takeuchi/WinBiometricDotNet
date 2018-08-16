using WinBiometricDotNet.Interop;
using WINBIO_REJECT_DETAIL = System.UInt32;

namespace WinBiometricDotNet
{

    public enum RejectDetail : WINBIO_REJECT_DETAIL
    {

        TooHigh = SafeNativeMethods.WINBIO_FP_TOO_HIGH,

        TooLow = SafeNativeMethods.WINBIO_FP_TOO_LOW,

        TooLeft = SafeNativeMethods.WINBIO_FP_TOO_LEFT,

        TooRight = SafeNativeMethods.WINBIO_FP_TOO_RIGHT,

        TooFast = SafeNativeMethods.WINBIO_FP_TOO_FAST,

        TooSlow = SafeNativeMethods.WINBIO_FP_TOO_SLOW,

        PoorQuality = SafeNativeMethods.WINBIO_FP_POOR_QUALITY,

        TooSkewed = SafeNativeMethods.WINBIO_FP_TOO_SKEWED,

        TooShort = SafeNativeMethods.WINBIO_FP_TOO_SHORT,

        MergeFailure = SafeNativeMethods.WINBIO_FP_MERGE_FAILURE

    }

}