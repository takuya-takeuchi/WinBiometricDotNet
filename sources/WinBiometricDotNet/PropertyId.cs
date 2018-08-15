using WinBiometricDotNet.Interop;
using WINBIO_PROPERTY_ID = System.UInt32;

namespace WinBiometricDotNet
{

    public enum PropertyId : WINBIO_PROPERTY_ID
    {

        SampleHint = SafeNativeMethods.WINBIO_PROPERTY_SAMPLE_HINT,

        ExtendedSensorInfo = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_SENSOR_INFO,

        ExtendedEngineInfo = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_ENGINE_INFO,

        ExtendedStorageInfo = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_STORAGE_INFO,

        ExtendedEnrollmentStatus = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_ENROLLMENT_STATUS,

        // SafeNativeMethods.WINBIO_PROPERTY_ANTI_SPOOF_POLICY
        AntiSpoofPolicy = 6,

    }

}