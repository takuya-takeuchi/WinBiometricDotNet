using WinBiometricDotNet.Interop;
using WINBIO_PROPERTY_ID = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="PropertyId"/> enumeration specifies the property to be queried.
    /// </summary>
    public enum PropertyId : WINBIO_PROPERTY_ID
    {

        /// <summary>
        /// Estimates the maximum number of good biometric samples that are required to complete an enrollment template.
        /// </summary>
        SampleHint = SafeNativeMethods.WINBIO_PROPERTY_SAMPLE_HINT,

        /// <summary>
        /// Contains extended information about the capabilities and attributes of the sensor component that is connected to a specific biometric unit.
        /// </summary>
        ExtendedSensorInfo = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_SENSOR_INFO,

        /// <summary>
        /// Contains extended information about the capabilities and attributes of the engine component that is connected to a specific biometric unit.
        /// </summary>
        ExtendedEngineInfo = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_ENGINE_INFO,

        /// <summary>
        /// Contains extended information about the capabilities and attributes of the storage component that is connected to a specific biometric unit.
        /// </summary>
        ExtendedStorageInfo = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_STORAGE_INFO,

        /// <summary>
        /// Contains extended information about the status of an in-progress enrollment on a specific biometric unit.
        /// </summary>
        ExtendedEnrollmentStatus = SafeNativeMethods.WINBIO_PROPERTY_EXTENDED_ENROLLMENT_STATUS,

        /// <summary>
        /// Contains the values of the antispoofing policy for a specific user account.
        /// </summary>
        // SafeNativeMethods.WINBIO_PROPERTY_ANTI_SPOOF_POLICY
        AntiSpoofPolicy = 6,

    }

}