using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Represent the standard biometric types defined by National Institute of Standards and Technology Information (NISTIR) 6529-A.
    /// </summary>
    [Flags]
    public enum BiometricTypes : uint
    {

        /// <summary>
        /// Bitmask that specifies the supported set of biometric factors.
        /// </summary>
        Mask = SafeNativeMethods.WINBIO_STANDARD_TYPE_MASK,

        /// <summary>
        /// No biometric type is available.
        /// </summary>
        NoAvailable = SafeNativeMethods.WINBIO_NO_TYPE_AVAILABLE,

        /// <summary>
        /// Multiple types are specified.
        /// </summary>
        Multiple = SafeNativeMethods.WINBIO_TYPE_MULTIPLE,

        /// <summary>
        /// The biometric sensor captures facial features.
        /// </summary>
        FacialFeatures = SafeNativeMethods.WINBIO_TYPE_FACIAL_FEATURES,

        /// <summary>
        /// The biometric sensor captures voice data.
        /// </summary>
        Voice = SafeNativeMethods.WINBIO_TYPE_VOICE,

        /// <summary>
        /// The biometric sensor captures fingerprint data.
        /// </summary>
        Fingerprint = SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,

        /// <summary>
        /// The biometric sensor captures iris data.
        /// </summary>
        Iris = SafeNativeMethods.WINBIO_TYPE_IRIS,

        /// <summary>
        /// The biometric sensor captures retina data.
        /// </summary>
        Retina = SafeNativeMethods.WINBIO_TYPE_RETINA,

        /// <summary>
        /// The biometric sensor captures hand data.
        /// </summary>
        HandGeometry = SafeNativeMethods.WINBIO_TYPE_HAND_GEOMETRY,

        /// <summary>
        /// The biometric sensor captures signatures.
        /// </summary>
        SignatureDynamics = SafeNativeMethods.WINBIO_TYPE_SIGNATURE_DYNAMICS,

        /// <summary>
        /// The biometric sensor captures keystrokes.
        /// </summary>
        KeystrokeDynamics = SafeNativeMethods.WINBIO_TYPE_KEYSTROKE_DYNAMICS,

        /// <summary>
        /// The biometric sensor captures lip data.
        /// </summary>
        LipMovement = SafeNativeMethods.WINBIO_TYPE_LIP_MOVEMENT,

        /// <summary>
        /// The biometric sensor captures thermal face imaging.
        /// </summary>
        ThermalFaceImage = SafeNativeMethods.WINBIO_TYPE_THERMAL_FACE_IMAGE,

        /// <summary>
        /// The biometric sensor captures thermal hand imaging.
        /// </summary>
        ThermalHandImage = SafeNativeMethods.WINBIO_TYPE_THERMAL_HAND_IMAGE,

        /// <summary>
        /// The biometric sensor captures walking gait data.
        /// </summary>
        Gait = SafeNativeMethods.WINBIO_TYPE_GAIT,

        /// <summary>
        /// The biometric sensor captures scent data.
        /// </summary>
        Scent = SafeNativeMethods.WINBIO_TYPE_SCENT,

        /// <summary>
        /// The biometric sensor captures DNA data.
        /// </summary>
        Dna = SafeNativeMethods.WINBIO_TYPE_DNA,

        /// <summary>
        /// The biometric sensor captures ear information.
        /// </summary>
        EarShape = SafeNativeMethods.WINBIO_TYPE_EAR_SHAPE,

        /// <summary>
        /// The biometric sensor captures finger shape information.
        /// </summary>
        FingerGeometry = SafeNativeMethods.WINBIO_TYPE_FINGER_GEOMETRY,

        /// <summary>
        /// The biometric sensor captures palm prints.
        /// </summary>
        Palmprint = SafeNativeMethods.WINBIO_TYPE_PALM_PRINT,

        /// <summary>
        /// The biometric sensor captures blood vein pattern data.
        /// </summary>
        VeinPattern = SafeNativeMethods.WINBIO_TYPE_VEIN_PATTERN,

        /// <summary>
        /// The biometric sensor captures foot prints.
        /// </summary>
        FootPrint = SafeNativeMethods.WINBIO_TYPE_FOOT_PRINT,

        /// <summary>
        /// The supported biometric data is not defined by the current constants.
        /// </summary>
        Other = SafeNativeMethods.WINBIO_TYPE_OTHER,

        /// <summary>
        /// The biometric sensor captures password data.
        /// </summary>
        Password = SafeNativeMethods.WINBIO_TYPE_PASSWORD,

        /// <summary>
        /// The biometric sensor captures any type of data.
        /// </summary>
        Any = (Mask | Other | Password)

    }

}