using WinBiometricDotNet.Interop;
using WINBIO_SENSOR_STATUS = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="SensorStatus"/> enumeration specifies the status of the sensor after the capture has occurred.
    /// </summary>
    public enum SensorStatus : WINBIO_SENSOR_STATUS
    {

        StatusUnknown = SafeNativeMethods.WINBIO_SENSOR_STATUS_UNKNOWN,

        /// <summary>
        /// The sensor just successfully completed a capture operation.
        /// </summary>
        Accept = SafeNativeMethods.WINBIO_SENSOR_ACCEPT,

        /// <summary>
        /// The sensor rejected the previous capture operation.
        /// </summary>
        Reject = SafeNativeMethods.WINBIO_SENSOR_REJECT,

        /// <summary>
        /// The sensor is ready to capture data.
        /// </summary>
        Ready = SafeNativeMethods.WINBIO_SENSOR_READY,

        /// <summary>
        /// The sensor is busy or in a state where it cannot capture data.
        /// </summary>
        Busy = SafeNativeMethods.WINBIO_SENSOR_BUSY,

        /// <summary>
        /// The sensor must be calibrated before it is put into data collection mode.
        /// </summary>
        NotCalibrated = SafeNativeMethods.WINBIO_SENSOR_NOT_CALIBRATED,

        /// <summary>
        /// The sensor device failed.
        /// </summary>
        Failure = SafeNativeMethods.WINBIO_SENSOR_FAILURE,

        Available = SafeNativeMethods.WINBIO_SENSOR_AVAILABLE,

        Unavailable = SafeNativeMethods.WINBIO_SENSOR_UNAVAILABLE,

    }

}