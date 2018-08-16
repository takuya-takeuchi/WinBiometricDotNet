using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum OperationType : uint
    {

        None = SafeNativeMethods.WINBIO_OPERATION_NONE,

        Open = SafeNativeMethods.WINBIO_OPERATION_OPEN,

        Close = SafeNativeMethods.WINBIO_OPERATION_CLOSE,

        Verify = SafeNativeMethods.WINBIO_OPERATION_VERIFY,

        Identify = SafeNativeMethods.WINBIO_OPERATION_IDENTIFY,

        LocateSensor = SafeNativeMethods.WINBIO_OPERATION_LOCATE_SENSOR,

        EnrollBegin = SafeNativeMethods.WINBIO_OPERATION_ENROLL_BEGIN,

        EnrollCapture = SafeNativeMethods.WINBIO_OPERATION_ENROLL_CAPTURE,

        EnrollCommit = SafeNativeMethods.WINBIO_OPERATION_ENROLL_COMMIT,

        EnrollDiscard = SafeNativeMethods.WINBIO_OPERATION_ENROLL_DISCARD,

        EnumEnrollments = SafeNativeMethods.WINBIO_OPERATION_ENUM_ENROLLMENTS,

        DeleteTemplate = SafeNativeMethods.WINBIO_OPERATION_DELETE_TEMPLATE,

        CaptureSample = SafeNativeMethods.WINBIO_OPERATION_CAPTURE_SAMPLE,

        GetProperty = SafeNativeMethods.WINBIO_OPERATION_GET_PROPERTY,

        SetProperty = SafeNativeMethods.WINBIO_OPERATION_SET_PROPERTY,

        GetEvent = SafeNativeMethods.WINBIO_OPERATION_GET_EVENT,

        LockUnit = SafeNativeMethods.WINBIO_OPERATION_LOCK_UNIT,

        UnlockUnit = SafeNativeMethods.WINBIO_OPERATION_UNLOCK_UNIT,

        ControlUnit = SafeNativeMethods.WINBIO_OPERATION_CONTROL_UNIT,

        ControlUnitPrivileged = SafeNativeMethods.WINBIO_OPERATION_CONTROL_UNIT_PRIVILEGED,

        OpenFramework = SafeNativeMethods.WINBIO_OPERATION_OPEN_FRAMEWORK,

        CloseFramework = SafeNativeMethods.WINBIO_OPERATION_CLOSE_FRAMEWORK,

        EnumServiceProviders = SafeNativeMethods.WINBIO_OPERATION_ENUM_SERVICE_PROVIDERS,

        EnumBiometricUnits = SafeNativeMethods.WINBIO_OPERATION_ENUM_BIOMETRIC_UNITS,

        EnumDatabases = SafeNativeMethods.WINBIO_OPERATION_ENUM_DATABASES,

        UnitArrival = SafeNativeMethods.WINBIO_OPERATION_UNIT_ARRIVAL,

        UnitRemoval = SafeNativeMethods.WINBIO_OPERATION_UNIT_REMOVAL,

    }

}