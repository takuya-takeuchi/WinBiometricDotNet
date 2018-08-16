using System;
using WinBiometricDotNet.Interop;
using WINBIO_SENSOR_STATUS = System.UInt32;

namespace WinBiometricDotNet
{

    public enum SensorStatus : WINBIO_SENSOR_STATUS
    {

        StatusUnknown = SafeNativeMethods.WINBIO_SENSOR_STATUS_UNKNOWN,

        Accept = SafeNativeMethods.WINBIO_SENSOR_ACCEPT,

        Reject = SafeNativeMethods.WINBIO_SENSOR_REJECT,

        Ready = SafeNativeMethods.WINBIO_SENSOR_READY,

        Busy = SafeNativeMethods.WINBIO_SENSOR_BUSY,

        NotCalibrated = SafeNativeMethods.WINBIO_SENSOR_NOT_CALIBRATED,

        Failure = SafeNativeMethods.WINBIO_SENSOR_FAILURE,

        Available = SafeNativeMethods.WINBIO_SENSOR_AVAILABLE,

        Unavailable = SafeNativeMethods.WINBIO_SENSOR_UNAVAILABLE,

    }

}