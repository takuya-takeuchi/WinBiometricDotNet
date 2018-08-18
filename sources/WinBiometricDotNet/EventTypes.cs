using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="EventTypes"/> enumeration specifies the types of service provider event notifications to monitor.
    /// </summary>
    [Flags]
    public enum EventTypes : uint
    {

        /// <summary>
        /// The sensor detected a finger swipe that was not requested by the application or by the window that currently has focus. The Windows Biometric Framework calls into your callback function to indicate that a finger swipe has occurred but does not try to identify the fingerprint.
        /// </summary>
        Unclaimed = SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED,

        /// <summary>
        /// The sensor detected a finger swipe that was not requested by the application or by the window that currently has focus. The Windows Biometric Framework attempts to identify the fingerprint and passes the result of that process to your callback function.
        /// </summary>
        UnclaimedIdentify = SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY,

        Error = SafeNativeMethods.WINBIO_EVENT_ERROR

    }

}