using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="OperationType"/> enumeration specifies the type of asynchronous operation being performed.
    /// </summary>
    public enum OperationType : uint
    {

        /// <summary>
        /// No operation has been identified.
        /// </summary>
        None = SafeNativeMethods.WINBIO_OPERATION_NONE,

        /// <summary>
        /// A biometric session was opened.
        /// </summary>
        Open = SafeNativeMethods.WINBIO_OPERATION_OPEN,

        /// <summary>
        /// A biometric session was closed.
        /// </summary>
        Close = SafeNativeMethods.WINBIO_OPERATION_CLOSE,

        /// <summary>
        /// A biometric sample was verified against a user identity.
        /// </summary>
        Verify = SafeNativeMethods.WINBIO_OPERATION_VERIFY,

        /// <summary>
        /// A biometric sample was captured and compared to an existing template.
        /// </summary>
        Identify = SafeNativeMethods.WINBIO_OPERATION_IDENTIFY,

        /// <summary>
        /// The ID number of a biometric unit was retrieved.
        /// </summary>
        LocateSensor = SafeNativeMethods.WINBIO_OPERATION_LOCATE_SENSOR,

        /// <summary>
        /// A biometric enrollment sequence was initiated.
        /// </summary>
        EnrollBegin = SafeNativeMethods.WINBIO_OPERATION_ENROLL_BEGIN,

        /// <summary>
        /// A biometric sample was captured and added to the template.
        /// </summary>
        EnrollCapture = SafeNativeMethods.WINBIO_OPERATION_ENROLL_CAPTURE,

        /// <summary>
        /// A pending biometric template was finalized.
        /// </summary>
        EnrollCommit = SafeNativeMethods.WINBIO_OPERATION_ENROLL_COMMIT,

        /// <summary>
        /// A pending biometric template was discarded.
        /// </summary>
        EnrollDiscard = SafeNativeMethods.WINBIO_OPERATION_ENROLL_DISCARD,

        /// <summary>
        /// The sub-factors for a given template were enumerated.
        /// </summary>
        EnumEnrollments = SafeNativeMethods.WINBIO_OPERATION_ENUM_ENROLLMENTS,

        /// <summary>
        /// A biometric template was deleted from the store.
        /// </summary>
        DeleteTemplate = SafeNativeMethods.WINBIO_OPERATION_DELETE_TEMPLATE,

        /// <summary>
        /// A biometric sample was captured.
        /// </summary>
        CaptureSample = SafeNativeMethods.WINBIO_OPERATION_CAPTURE_SAMPLE,

        /// <summary>
        /// A biometric session, unit, or template property was retrieved.
        /// </summary>
        GetProperty = SafeNativeMethods.WINBIO_OPERATION_GET_PROPERTY,

        /// <summary>
        /// A biometric session, unit, template, or account property was set.
        /// </summary>
        SetProperty = SafeNativeMethods.WINBIO_OPERATION_SET_PROPERTY,

        /// <summary>
        /// Not used.
        /// </summary>
        GetEvent = SafeNativeMethods.WINBIO_OPERATION_GET_EVENT,

        /// <summary>
        /// A biometric unit was locked for exclusive use by a session.
        /// </summary>
        LockUnit = SafeNativeMethods.WINBIO_OPERATION_LOCK_UNIT,

        /// <summary>
        /// The session lock on a biometric unit was released.
        /// </summary>
        UnlockUnit = SafeNativeMethods.WINBIO_OPERATION_UNLOCK_UNIT,

        /// <summary>
        /// Vendor defined operations were performed on a control unit.
        /// </summary>
        ControlUnit = SafeNativeMethods.WINBIO_OPERATION_CONTROL_UNIT,

        /// <summary>
        /// Privileged vendor defined operations were performed on a control unit.
        /// </summary>
        ControlUnitPrivileged = SafeNativeMethods.WINBIO_OPERATION_CONTROL_UNIT_PRIVILEGED,

        /// <summary>
        /// A handle to the biometric framework was opened.
        /// </summary>
        OpenFramework = SafeNativeMethods.WINBIO_OPERATION_OPEN_FRAMEWORK,

        /// <summary>
        /// A handle to the biometric framework was closed.
        /// </summary>
        CloseFramework = SafeNativeMethods.WINBIO_OPERATION_CLOSE_FRAMEWORK,

        /// <summary>
        /// The installed biometric service providers were enumerated.
        /// </summary>
        EnumServiceProviders = SafeNativeMethods.WINBIO_OPERATION_ENUM_SERVICE_PROVIDERS,

        /// <summary>
        /// The attached biometric units were enumerated.
        /// </summary>
        EnumBiometricUnits = SafeNativeMethods.WINBIO_OPERATION_ENUM_BIOMETRIC_UNITS,

        /// <summary>
        /// The registered databases were enumerated.
        /// </summary>
        EnumDatabases = SafeNativeMethods.WINBIO_OPERATION_ENUM_DATABASES,

        /// <summary>
        /// A biometric unit was created.
        /// </summary>
        UnitArrival = SafeNativeMethods.WINBIO_OPERATION_UNIT_ARRIVAL,

        /// <summary>
        /// A biometric unit was deleted.
        /// </summary>
        UnitRemoval = SafeNativeMethods.WINBIO_OPERATION_UNIT_REMOVAL,

    }

}