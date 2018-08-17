using WinBiometricDotNet.Interop;
using WINBIO_BIOMETRIC_SENSOR_SUBTYPE = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="BiometricSensorSubType"/> enumeration specifies the onboard sensor capabilities.
    /// </summary>
    public enum BiometricSensorSubType : WINBIO_BIOMETRIC_SENSOR_SUBTYPE
    {

        /// <summary>
        /// The sensor sub types is not known.
        /// </summary>
        Unknown = SafeNativeMethods.WINBIO_SENSOR_SUBTYPE_UNKNOWN,

        /// <summary>
        /// The sensor supports fingerprint swipes.
        /// </summary>
        Swipe = SafeNativeMethods.WINBIO_FP_SENSOR_SUBTYPE_SWIPE,

        /// <summary>
        /// The sensor supports finger touches.
        /// </summary>
        Touch = SafeNativeMethods.WINBIO_FP_SENSOR_SUBTYPE_TOUCH

    }

}