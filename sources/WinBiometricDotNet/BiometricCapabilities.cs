using System;
using WinBiometricDotNet.Interop;
using WINBIO_CAPABILITIES = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Specifies the capabilities of biometric sensor.
    /// </summary>
    [Flags]
    public enum BiometricCapabilities : WINBIO_CAPABILITIES
    {

        /// <summary>
        /// The device can collect biometric data.
        /// </summary>
        Sensor = SafeNativeMethods.WINBIO_CAPABILITY_SENSOR,

        /// <summary>
        /// The device can perform match operations.
        /// </summary>
        Matching = SafeNativeMethods.WINBIO_CAPABILITY_MATCHING,

        /// <summary>
        /// The sensor contains an onboard database.
        /// </summary>
        Database = SafeNativeMethods.WINBIO_CAPABILITY_DATABASE,

        /// <summary>
        /// The device can process samples and turn them into biometric templates.
        /// </summary>
        Proccessing = SafeNativeMethods.WINBIO_CAPABILITY_PROCESSING,

        /// <summary>
        /// The device supports encryption of samples and templates.
        /// </summary>
        Encryption = SafeNativeMethods.WINBIO_CAPABILITY_ENCRYPTION,

        /// <summary>
        /// The device can be used as a navigation device. Some devices and drivers can capture data in a format that can be translated by a user-mode application into navigation events, much like a mouse.
        /// </summary>
        Navigation = SafeNativeMethods.WINBIO_CAPABILITY_NAVIGATION,

        /// <summary>
        /// The device has an indicator that can be turned on or off.
        /// </summary>
        Indicator = SafeNativeMethods.WINBIO_CAPABILITY_INDICATOR,

        /// <summary>
        /// The sensor adapter manages its own connection to the biometric hardware.
        /// </summary>
        VirtualSensor = SafeNativeMethods.WINBIO_CAPABILITY_VIRTUAL_SENSOR,

        ///// <summary>
        ///// The device supports security methods available in the WinBio engine adapter interface version 4.0 or later.
        ///// </summary>
        //SecureSensor = SafeNativeMethods.WINBIO_CAPABILITY_SECURE_SENSOR,

        ///// <summary>
        ///// Secure Connection Protocol (SCP) V1
        ///// </summary>
        //ScpV1 = SafeNativeMethods.WINBIO_CAPABILITY_SCP_V1,

        ///// <summary>
        ///// Modern standby support
        ///// </summary>
        //Wake = SafeNativeMethods.WINBIO_CAPABILITY_WAKE,

}

}