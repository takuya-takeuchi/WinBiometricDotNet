using WinBiometricDotNet.Interop;
using WINBIO_BIOMETRIC_SENSOR_SUBTYPE = System.UInt32;

namespace WinBiometricDotNet
{

    public enum BiometricSensorSubType : WINBIO_BIOMETRIC_SENSOR_SUBTYPE
    {

        Unknown = SafeNativeMethods.WINBIO_SENSOR_SUBTYPE_UNKNOWN,

        Swipe = SafeNativeMethods.WINBIO_FP_SENSOR_SUBTYPE_SWIPE,

        Touch = SafeNativeMethods.WINBIO_FP_SENSOR_SUBTYPE_TOUCH

    }

}