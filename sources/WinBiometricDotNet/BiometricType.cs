using System;

namespace WinBiometricDotNet
{

    [Flags]
    public enum BiometricType : uint
    {

        Mask = 0x00FFFFFF,

        NoAvailable = 0x00000000,

        Multiple = 0x00000001,

        FacialFeatures = 0x00000002,

        Voice = 0x00000004,

        Fingerprint = 0x00000008,

        Iris = 0x00000010,

        Retina = 0x00000020,

        HandGeometry = 0x00000040,

        SignatureDynamics = 0x00000080,

        KeystrokeDynamics = 0x00000100,

        LipMovement = 0x00000200,

        ThermalFaceImage = 0x00000400,

        ThermalHandImage = 0x00000800,

        Gait = 0x00001000,

        Scent = 0x00002000,

        Dna = 0x00004000,

        EarShape = 0x00008000,

        FingerGeometry = 0x00010000,

        Palmprint = 0x00020000,

        VeinPattern = 0x00040000,

        FootPrint = 0x00080000,

        Other = 0x40000000,

        Password = 0x80000000,

        Any = (Mask | Other | Password)

    }

}