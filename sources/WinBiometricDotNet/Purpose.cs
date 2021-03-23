using System;
using WinBiometricDotNet.Interop;
using WINBIO_BIR_PURPOSE = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="Purpose"/> enumeration specifies the intended use of the sample.
    /// </summary>
    [Flags]
    public enum Purpose : WINBIO_BIR_PURPOSE
    {

        /// <summary>
        /// No purpose is specified.
        /// </summary>
        NoPurposeAvailable = SafeNativeMethods.WINBIO_NO_PURPOSE_AVAILABLE,

        /// <summary>
        /// Verify the identity of a user.
        /// </summary>
        Verify = SafeNativeMethods.WINBIO_PURPOSE_VERIFY,

        /// <summary>
        /// Identify a user.
        /// </summary>
        Identify = SafeNativeMethods.WINBIO_PURPOSE_IDENTIFY,

        /// <summary>
        /// Enroll a user.
        /// </summary>
        Enroll = SafeNativeMethods.WINBIO_PURPOSE_ENROLL,

        /// <summary>
        /// Capture a biometric sample and determine whether the sample corresponds to the specified user identity.
        /// </summary>
        EnrollForVerification = SafeNativeMethods.WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION,

        /// <summary>
        /// Capture a biometric sample and determine whether it matches an existing biometric template.
        /// </summary>
        EnrollForIdentification = SafeNativeMethods.WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION,

        /// <summary>
        /// Extra information that can be used for logging or for display.
        /// </summary>
        /// <remarks>This value is ignored on input by all functions. On output, it will only be available if supported by the biometric unit and you specify WINBIO_DATA_FLAG_RAW in the Flags parameter of the <see cref="WinBiometric.CaptureSample"/> function.</remarks>
        Auidit = SafeNativeMethods.WINBIO_PURPOSE_AUDIT

    }

}