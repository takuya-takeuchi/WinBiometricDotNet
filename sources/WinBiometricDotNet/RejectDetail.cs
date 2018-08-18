using WinBiometricDotNet.Interop;
using WINBIO_REJECT_DETAIL = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="RejectDetail"/> enumeration specifies the reason a biometric fingerprint capture or identification procedure did not succeed.
    /// </summary>
    public enum RejectDetail : WINBIO_REJECT_DETAIL
    {

        /// <summary>
        /// The finger scan began too high on the finger.
        /// </summary>
        FingerprintTooHigh = SafeNativeMethods.WINBIO_FP_TOO_HIGH,

        /// <summary>
        /// The finger scan began too low on the finger.
        /// </summary>
        FingerprintTooLow = SafeNativeMethods.WINBIO_FP_TOO_LOW,

        /// <summary>
        /// The finger was too far left during scanning.
        /// </summary>
        FingerprintTooLeft = SafeNativeMethods.WINBIO_FP_TOO_LEFT,

        /// <summary>
        /// The finger was too far right during scanning.
        /// </summary>
        FingerprintTooRight = SafeNativeMethods.WINBIO_FP_TOO_RIGHT,

        /// <summary>
        /// The finger was swiped too quickly on the sensor.
        /// </summary>
        FingerprintTooFast = SafeNativeMethods.WINBIO_FP_TOO_FAST,

        /// <summary>
        /// The finger was swiped too slowly on the sensor.
        /// </summary>
        FingerprintTooSlow = SafeNativeMethods.WINBIO_FP_TOO_SLOW,

        /// <summary>
        /// The scan quality was too poor.
        /// </summary>
        FingerprintPoorQuality = SafeNativeMethods.WINBIO_FP_POOR_QUALITY,

        /// <summary>
        /// The finger did not pass straight across the sensor.
        /// </summary>
        FingerprintTooSkewed = SafeNativeMethods.WINBIO_FP_TOO_SKEWED,

        /// <summary>
        /// Not enough of the finger was scanned.
        /// </summary>
        FingerprintTooShort = SafeNativeMethods.WINBIO_FP_TOO_SHORT,

        /// <summary>
        /// The fingerprint captures could not be combined.
        /// </summary>
        FingerprintMergeFailure = SafeNativeMethods.WINBIO_FP_MERGE_FAILURE

    }

}