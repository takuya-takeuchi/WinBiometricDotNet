using WINBIO_PROPERTY_ID = System.UInt32;

namespace WinBiometricDotNet
{

    public enum PropertyId : WINBIO_PROPERTY_ID
    {

        SampleHint = (WINBIO_PROPERTY_ID)1,

        ExtendedSensorInfo = (WINBIO_PROPERTY_ID)2,

        ExtendedEngineInfo = (WINBIO_PROPERTY_ID)3,

        ExtendedStorageInfo = (WINBIO_PROPERTY_ID)4,

        ExtendedEnrollmentStatus = (WINBIO_PROPERTY_ID)5,

        AntiSpoofPolicy = (WINBIO_PROPERTY_ID)6

    }

}