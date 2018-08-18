using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WinBiometricDotNet.Helpers;
using WinBiometricDotNet.Interop;
using HRESULT = System.Int32;
using PVOID = System.IntPtr;
using SIZE_T = System.IntPtr;
using UINT = System.UInt32;
using ULONG = System.UInt32;
using ULONGLONG = System.UInt64;

using WINBIO_BIOMETRIC_SENSOR_SUBTYPE = System.UInt32;
using WINBIO_BIOMETRIC_SUBTYPE = System.Byte;
using WINBIO_BIOMETRIC_TYPE = System.UInt32;
using WINBIO_CAPABILITIES = System.UInt32;
using WINBIO_COMPONENT = System.UInt32;
using WINBIO_EVENT_TYPE = System.UInt32;
using WINBIO_FRAMEWORK_CHANGE_TYPE = System.UInt32;
using WINBIO_POOL_TYPE = System.UInt32;
using WINBIO_PROPERTY_ID = System.UInt32;
using WINBIO_PROPERTY_TYPE = System.UInt32;
using WINBIO_REJECT_DETAIL = System.UInt32;
using WINBIO_UNIT_ID = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides functionality to execute interface that Windows Biometric Framework exposes.
    /// </summary>
    public sealed class WinBiometric
    {

        #region Events

        /// <summary>
        /// Occurs when the operation started by using the session handle completes.
        /// </summary>
        public static event AsyncCompletedHandler AsyncCompleted;

        /// <summary>
        /// Occurs when the capture operation succeeds or fails.
        /// </summary>
        public static event EnrollCapturedHandler EnrollCaptured;

        /// <summary>
        /// Occurs when receives the event notifications sent by the Windows Biometric Framework.
        /// </summary>
        public static event EventMonitoredHandler EventMonitored;

        /// <summary>
        /// Occurs when identification succeeds or fails.
        /// </summary>
        public static event IdentifiedHandler Identified;

        /// <summary>
        /// Occurs when the capture operation succeeds or fails.
        /// </summary>
        public static event SampleCapturedHandler SampleCaptured;

        /// <summary>
        /// Occurs when sensor location succeeds or fails.
        /// </summary>
        public static event SensorLocatedHandler SensorLocated;

        /// <summary>
        /// Occurs when verification succeeds or fails.
        /// </summary>
        public static event VerifyHandler Verified;

        #endregion

        #region Fields

        private static readonly SafeNativeMethods.WINBIO_ASYNC_COMPLETION_CALLBACK NativeAsyncCompletionCallback;

        private static readonly SafeNativeMethods.WINBIO_ENROLL_CAPTURE_CALLBACK NativeEnrollCaptureCallback;

        private static readonly SafeNativeMethods.WINBIO_EVENT_CALLBACK NativeEventCallback;

        private static readonly SafeNativeMethods.WINBIO_IDENTIFY_CALLBACK NativeIdentifyCallback;

        private static readonly SafeNativeMethods.WINBIO_CAPTURE_CALLBACK NativeSampleCapturedCallback;

        private static readonly SafeNativeMethods.WINBIO_LOCATE_SENSOR_CALLBACK NativeSensorLocatedCallback;

        private static readonly SafeNativeMethods.WINBIO_VERIFY_CALLBACK NativeVerifyCallback;

        #endregion

        #region Constructors

        static WinBiometric()
        {
            unsafe
            {
                NativeAsyncCompletionCallback = AsyncCompletedCallback;
                NativeEnrollCaptureCallback = CaptureEnrollCallback;
                NativeEventCallback = EventMonitorCallback;
                NativeIdentifyCallback = IdentifyCallback;
                NativeSampleCapturedCallback = CaptureSampleCallback;
                NativeSensorLocatedCallback = LocateSensorCallback;
                NativeVerifyCallback = VerifyCallback;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Acquires window focus.
        /// </summary>
        public static void AcquireFocus()
        {
            var hr = SafeNativeMethods.WinBioAcquireFocus();

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Asynchronously enumerates all attached biometric units that match the input biometric type.
        /// </summary>
        /// <param name="framework">The handle to the biometric framework.</param>
        /// <param name="biometricTypes">The bitmask of <see cref="BiometricTypes"/> flags that specifies the biometric unit types to be enumerated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="framework"/> parameter is null.</exception>
        public static void AsyncEnumBiometricUnits(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncEnumBiometricUnits(framework.Handle,
                                                                     (WINBIO_BIOMETRIC_TYPE)biometricTypes);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Asynchronously enumerates all registered databases that match a specified biometric type.
        /// </summary>
        /// <param name="framework">The handle to the biometric framework.</param>
        /// <param name="biometricTypes">The bitmask of <see cref="BiometricTypes"/> flags that specifies the biometric database types to be enumerated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="framework"/> parameter is null.</exception>
        public static void AsyncEnumDatabases(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncEnumDatabases(framework.Handle,
                                                                (WINBIO_BIOMETRIC_TYPE)biometricTypes);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Asynchronously returns information about installed biometric service providers.
        /// </summary>
        /// <param name="framework">The handle to the biometric framework.</param>
        /// <param name="biometricTypes">The bitmask of <see cref="BiometricTypes"/> flags that specifies the biometric service provider types to be enumerated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="framework"/> parameter is null.</exception>
        public static void AsyncEnumServiceProviders(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncEnumServiceProviders(framework.Handle,
                                                                       (WINBIO_BIOMETRIC_TYPE)biometricTypes);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Starts an asynchronous monitor of changes to the biometric framework.
        /// </summary>
        /// <param name="framework">The handle to the biometric framework.</param>
        /// <param name="changeType">The bitmask of type <see cref="ChangeTypes"/> flags that indicates the types of events that should generate asynchronous notifications.</param>
        /// <exception cref="ArgumentNullException"><paramref name="framework"/> parameter is null.</exception>
        public static void AsyncMonitorFrameworkChanges(Framework framework, ChangeTypes changeType)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncMonitorFrameworkChanges(framework.Handle,
                                                                          (WINBIO_FRAMEWORK_CHANGE_TYPE)changeType);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Asynchronously opens a handle to the biometric framework.
        /// </summary>
        /// <param name="userData">The buffer supplied by the caller.</param>
        public static void AsyncOpenFramework(PVOID userData)
        {
            var hr = SafeNativeMethods.WinBioAsyncOpenFramework(SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK,
                                                                IntPtr.Zero,
                                                                0,
                                                                NativeAsyncCompletionCallback,
                                                                userData,
                                                                SafeNativeMethods.TRUE,
                                                                out _);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Asynchronously opens a handle to the biometric framework.
        /// </summary>
        /// <param name="targetWindow">The handle of the window that will receive the completion notices.</param>
        /// <param name="messageCode">The window message code the framework must send to signify completion notices.</param>
        public static void AsyncOpenFramework(PVOID targetWindow, UINT messageCode)
        {
            var hr = SafeNativeMethods.WinBioAsyncOpenFramework(SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE,
                                                                targetWindow,
                                                                messageCode,
                                                                IntPtr.Zero,
                                                                IntPtr.Zero,
                                                                SafeNativeMethods.TRUE,
                                                                out _);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Asynchronously connects to a biometric service provider and one or more biometric units.
        /// </summary>
        /// <param name="userData">The buffer supplied by the caller.</param>
        public static void AsyncOpenSession(PVOID userData)
        {
            unsafe
            {
                var databaseId = SafeNativeMethods.WINBIO_DB_DEFAULT;
                var hr = SafeNativeMethods.WinBioAsyncOpenSession(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,
                                                                  SafeNativeMethods.WINBIO_POOL_SYSTEM,
                                                                  SafeNativeMethods.WINBIO_FLAG_RAW,
                                                                  null,
                                                                  IntPtr.Zero,
                                                                  databaseId,
                                                                  SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK,
                                                                  IntPtr.Zero,
                                                                  0,
                                                                  NativeAsyncCompletionCallback,
                                                                  userData,
                                                                  SafeNativeMethods.TRUE,
                                                                  out _);

                ThrowWinBiometricException(hr);
            }
        }

        /// <summary>
        /// Asynchronously connects to a biometric service provider and one or more biometric units.
        /// </summary>
        /// <param name="targetWindow">The handle of the window that will receive the completion notices.</param>
        /// <param name="messageCode">The window message code the framework must send to signify completion notices.</param>
        public static void AsyncOpenSession(PVOID targetWindow, UINT messageCode)
        {
            unsafe
            {
                var databaseId = SafeNativeMethods.WINBIO_DB_DEFAULT;
                var hr = SafeNativeMethods.WinBioAsyncOpenSession(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,
                                                                  SafeNativeMethods.WINBIO_POOL_SYSTEM,
                                                                  SafeNativeMethods.WINBIO_FLAG_RAW,
                                                                  null,
                                                                  IntPtr.Zero,
                                                                  databaseId,
                                                                  SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE,
                                                                  targetWindow,
                                                                  messageCode,
                                                                  IntPtr.Zero,
                                                                  IntPtr.Zero,
                                                                  SafeNativeMethods.TRUE,
                                                                  out _);

                ThrowWinBiometricException(hr);
            }
        }

        /// <summary>
        /// Initiates a biometric enrollment sequence and creates an empty biometric template.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="position">A <see cref="FingerPosition"/> that provides additional information about the enrollment.</param>
        /// <param name="unitId">The value that identifies the biometric unit.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void BeginEnroll(Session session, FingerPosition position, uint unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollBegin(session.Handle, (byte)position, unitId);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Cancels all pending biometric operations for a specified session.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void Cancel(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioCancel(session.Handle);
            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Captures a biometric sample and adds it to a template.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <returns><see cref="CaptureEnrollResult"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static CaptureEnrollResult CaptureEnroll(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollCapture(session.Handle, out var rejectDetail);

            switch (hr)
            {
                case SafeNativeMethods.WINBIO_I_MORE_DATA:
                case SafeNativeMethods.WINBIO_E_BAD_CAPTURE:
                    break;
                default:
                    ThrowWinBiometricException(hr);
                    break;
            }

            return new CaptureEnrollResult(SafeNativeMethods.S_OK, (RejectDetail)rejectDetail, hr == SafeNativeMethods.WINBIO_I_MORE_DATA);
        }

        /// <summary>
        /// Asynchronously captures a biometric sample and adds it to a template.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void CaptureEnrollWithCallback(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollCaptureWithCallback(session.Handle,
                                                                       NativeEnrollCaptureCallback,
                                                                       IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Captures a biometric sample and fills a biometric information record (BIR) with the raw or processed data.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <returns><see cref="CaptureSampleResult"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static CaptureSampleResult CaptureSample(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            unsafe
            {
                var hr = SafeNativeMethods.WinBioCaptureSample(session.Handle,
                                                               SafeNativeMethods.WINBIO_NO_PURPOSE_AVAILABLE,
                                                               SafeNativeMethods.WINBIO_DATA_FLAG_RAW,
                                                               out var unitId,
                                                               out var sample,
                                                               out var sampleSize,
                                                               out var rejectDetail);

                ThrowWinBiometricException(hr);

                return CreateCaptureSampleResult(unitId,
                                                 SafeNativeMethods.S_OK,
                                                 (SafeNativeMethods.WINBIO_BIR*)sample,
                                                 sampleSize,
                                                 rejectDetail);
            }
        }

        /// <summary>
        /// Captures a biometric sample asynchronously and returns the raw or processed data in a biometric information record (BIR).
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void CaptureSampleWithCallback(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioCaptureSampleWithCallback(session.Handle,
                                                                       SafeNativeMethods.WINBIO_NO_PURPOSE_AVAILABLE,
                                                                       SafeNativeMethods.WINBIO_DATA_FLAG_RAW,
                                                                       NativeSampleCapturedCallback,
                                                                       IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Closes a framework handle previously opened one.
        /// </summary>
        /// <param name="framework">The handle to the biometric framework.</param>
        /// <exception cref="ArgumentNullException"><paramref name="framework"/> is null.</exception>
        public static void CloseFramework(Framework framework)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioCloseFramework(framework.Handle);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Closes a biometric session and releases associated resources.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void CloseSession(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioCloseSession(session.Handle);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Finalizes a pending biometric template and saves it to the database associated with the biometric unit used for enrollment.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <returns><see cref="BiometricIdentity"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static BiometricIdentity CommitEnroll(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            unsafe
            {
                var hr = SafeNativeMethods.WinBioEnrollCommit(session.Handle,
                                                              out var identity,
                                                              out _);

                ThrowWinBiometricException(hr);

                return new BiometricIdentity(&identity);
            }
        }

        /// <summary>
        /// Allows the caller to perform vendor-defined control operations on a biometric unit.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="unitId">The value that identifies the biometric unit.</param>
        /// <param name="component">The value that specifies the component within the biometric unit that should perform the operation.</param>
        /// <param name="controlCode">The value that specifies the vendor-defined code recognized by the biometric unit.</param>
        /// <param name="sendBuffer">The buffer that contains the control information sent to the adapter by the component.</param>
        /// <param name="receiveBuffer">The buffer that receives information sent by the adapter specified by the <paramref name="component"/> parameter.</param>
        /// <param name="receiveDataSize">A size, in bytes, of the data written to the buffer specified by the <paramref name="receiveBuffer"/> parameter.</param>
        /// <param name="operationStatus">The value that specifies the vendor-defined status code that specifies the outcome of the control operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/>, <paramref name="sendBuffer"/> or <paramref name="receiveBuffer"/> is null.</exception>
        public static void ControlUnit(Session session,
                                       uint unitId,
                                       Component component,
                                       ULONG controlCode,
                                       byte[] sendBuffer,
                                       byte[] receiveBuffer,
                                       out SIZE_T receiveDataSize,
                                       out ULONG operationStatus)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (sendBuffer == null)
                throw new ArgumentNullException(nameof(sendBuffer));
            if (receiveBuffer == null)
                throw new ArgumentNullException(nameof(receiveBuffer));

            unsafe
            {
                fixed (byte* sb = &sendBuffer[0])
                fixed (byte* rb = &receiveBuffer[0])
                {
                    var sbPtr = (IntPtr)sb;
                    var sbSize = (IntPtr)sendBuffer.Length;
                    var rbPtr = (IntPtr)rb;
                    var rbSize = (IntPtr)receiveBuffer.Length;

                    var hr = SafeNativeMethods.WinBioControlUnit(session.Handle,
                                                                 unitId,
                                                                 (WINBIO_COMPONENT)component,
                                                                 controlCode,
                                                                 sbPtr,
                                                                 sbSize,
                                                                 rbPtr,
                                                                 rbSize,
                                                                 out receiveDataSize,
                                                                 out operationStatus);

                    ThrowWinBiometricException(hr);
                }
            }
        }

        /// <summary>
        /// Allows the caller to perform privileged vendor-defined control operations on a biometric unit.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="unitId">The value that identifies the biometric unit.</param>
        /// <param name="component">The value that specifies the component within the biometric unit that should perform the operation.</param>
        /// <param name="controlCode">The value that specifies the vendor-defined code recognized by the biometric unit.</param>
        /// <param name="sendBuffer">The buffer that contains the control information sent to the adapter by the component.</param>
        /// <param name="receiveBuffer">The buffer that receives information sent by the adapter specified by the <paramref name="component"/> parameter.</param>
        /// <param name="receiveDataSize">A size, in bytes, of the data written to the buffer specified by the <paramref name="receiveBuffer"/> parameter.</param>
        /// <param name="operationStatus">The value that specifies the vendor-defined status code that specifies the outcome of the control operation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/>, <paramref name="sendBuffer"/> or <paramref name="receiveBuffer"/> is null.</exception>
        public static void ControlUnitPrivileged(Session session,
                                                 uint unitId,
                                                 Component component,
                                                 ULONG controlCode,
                                                 byte[] sendBuffer,
                                                 byte[] receiveBuffer,
                                                 out SIZE_T receiveDataSize,
                                                 out ULONG operationStatus)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (sendBuffer == null)
                throw new ArgumentNullException(nameof(sendBuffer));
            if (receiveBuffer == null)
                throw new ArgumentNullException(nameof(receiveBuffer));

            unsafe
            {
                fixed (byte* sb = &sendBuffer[0])
                fixed (byte* rb = &receiveBuffer[0])
                {
                    var sbPtr = (IntPtr)sb;
                    var sbSize = (IntPtr)sendBuffer.Length;
                    var rbPtr = (IntPtr)rb;
                    var rbSize = (IntPtr)receiveBuffer.Length;

                    var hr = SafeNativeMethods.WinBioControlUnitPrivileged(session.Handle,
                                                                           unitId,
                                                                           (WINBIO_COMPONENT)component,
                                                                           controlCode,
                                                                           sbPtr,
                                                                           sbSize,
                                                                           rbPtr,
                                                                           rbSize,
                                                                           out receiveDataSize,
                                                                           out operationStatus);

                    ThrowWinBiometricException(hr);
                }
            }
        }

        public static Guid CreateDatabase(BiometricUnit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            var guid = Guid.NewGuid();
            CreateDatabase(unit, guid);
            return guid;
        }

        public static void CreateDatabase(BiometricUnit unit, Guid guid)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            if (IsDatabaseInstalled(guid, out _))
                throw new ArgumentException();

            var unitSchema = new SafeNativeMethods.WINBIO_UNIT_SCHEMA
            {
                Description = unit.Description,
                DeviceInstanceId = unit.DeviceInstanceId,
                Manufacturer = unit.Manufacturer,
                Model = unit.Model,
                SerialNumber = unit.SerialNumber,
                SensorSubType = (WINBIO_BIOMETRIC_SENSOR_SUBTYPE)unit.SensorSubType,
                BiometricFactor = (WINBIO_BIOMETRIC_TYPE)unit.BiometricFactor,
                Capabilities = (WINBIO_CAPABILITIES)unit.Capabilities,
                PoolType = (WINBIO_POOL_TYPE)unit.PoolType,
                UnitId = unit.UnitId,
                FirmwareVersion = new SafeNativeMethods.WINBIO_VERSION
                {
                    MinorVersion = unit.FirmwareVersion.MinorVersion,
                    MajorVersion = unit.FirmwareVersion.MajorVersion
                }
            };

            var hr = CreateCompatibleConfiguration(ref unitSchema, out var configuration);
            if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
                throw Marshal.GetExceptionForHR(hr);

            var storageSchema = new SafeNativeMethods.WINBIO_STORAGE_SCHEMA
            {
                DatabaseId = guid,
                DataFormat = configuration.DataFormat,
                Attributes = configuration.DatabaseAttributes
            };

            hr = RegisterDatabase(storageSchema);
            if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
                throw Marshal.GetExceptionForHR(hr);
        }

        /// <summary>
        /// Deletes a biometric template from the template store.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="unitId">The value that identifies the biometric unit where the template is located.</param>
        /// <param name="identity">The the data that contains the GUID or SID of the template to be deleted.</param>
        /// <param name="position">The value that provides additional information about the template to be deleted.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> or <paramref name="identity"/> is null.</exception>
        public static void DeleteTemplate(Session session, uint unitId, BiometricIdentity identity, FingerPosition position)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            unsafe
            {
                var nativeIdentity = identity.Source;
                var hr = SafeNativeMethods.WinBioDeleteTemplate(session.Handle,
                                                                unitId,
                                                                &nativeIdentity,
                                                                (WINBIO_BIOMETRIC_SUBTYPE)position);

                ThrowWinBiometricException(hr);
            }
        }

        /// <summary>
        /// Ends the enrollment sequence and discards a pending biometric template. 
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void DiscardEnroll(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollDiscard(session.Handle);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Enumerates all registered databases that match a specified biometric type.
        /// </summary>
        /// <param name="biometricTypes">The bitmask of <see cref="BiometricTypes"/> flags that specifies the biometric database types to be enumerated.</param>
        /// <returns>An enumerable collection of the <see cref="BiometricUnit"/>.</returns>
        public static IEnumerable<BiometricDatabase> EnumBiometricDatabases(BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            var databases = new List<BiometricDatabase>();

            var hr = SafeNativeMethods.WinBioEnumDatabases((uint)biometricTypes,
                                                           out var storageArray,
                                                           out var storageCount);

            ThrowWinBiometricException(hr);

            var array = MarshalArray<SafeNativeMethods.WINBIO_STORAGE_SCHEMA>(storageArray, (int)storageCount);
            for (int index = 0, count = (int)storageCount; index < count; ++index)
                databases.Add(new BiometricDatabase(array[index]));

            if (storageArray != IntPtr.Zero)
                SafeNativeMethods.WinBioFree(storageArray);

            return databases;
        }

        /// <summary>
        /// Enumerates all attached biometric units that match the input biometric type.
        /// </summary>
        /// <param name="biometricTypes">The bitmask of <see cref="BiometricTypes"/> flags that specifies the biometric unit types to be enumerated.</param>
        /// <returns>An enumerable collection of the <see cref="BiometricDatabase"/>.</returns>
        public static IEnumerable<BiometricUnit> EnumBiometricUnits(BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            var hr = SafeNativeMethods.WinBioEnumBiometricUnits((uint)biometricTypes,
                                                                out var unitSchemaArray,
                                                                out _);

            ThrowWinBiometricException(hr);

            foreach (var schema in unitSchemaArray)
                yield return new BiometricUnit(schema);
        }

        /// <summary>
        /// Retrieves the biometric sub-factors enrolled for a specified identity and biometric unit.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="unitId">The value that identifies the biometric unit.</param>
        /// <returns>An enumerable collection of the <see cref="FingerPosition"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static IEnumerable<FingerPosition> EnumEnrollments(Session session, uint unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = GetCurrentUserIdentity(out var identity);
            if (hr != 0)
            {
                ThrowWinBiometricException(hr);
            }

            hr = SafeNativeMethods.WinBioEnumEnrollments(session.Handle,
                                                         unitId,
                                                         ref identity,
                                                         out var subFactorArray,
                                                         out var subFactorCount);

            ThrowWinBiometricException(hr);

            var array = new WINBIO_BIOMETRIC_SUBTYPE[(int)subFactorCount];
            Marshal.Copy(subFactorArray, array, 0, (int)subFactorCount);

            SafeNativeMethods.WinBioFree(subFactorArray);

            return array.Select(f => (FingerPosition)f).ToArray();
        }

        /// <summary>
        /// Retrieves information about installed biometric service providers.
        /// </summary>
        /// <param name="biometricTypes">The bitmask of <see cref="BiometricTypes"/> flags that specifies the biometric service provider types to be enumerated.</param>
        /// <returns>An enumerable collection of the <see cref="BiometricServiceProvider"/>.</returns>
        public static IEnumerable<BiometricServiceProvider> EnumServiceProviders(BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            var hr = SafeNativeMethods.WinBioEnumServiceProviders((uint)biometricTypes,
                                                                  out var bspSchemaArray,
                                                                  out _);

            ThrowWinBiometricException(hr);

            foreach (var schema in bspSchemaArray)
                yield return new BiometricServiceProvider(schema);
        }

        /// <summary>
        /// Retrieves a value that specifies whether credentials have been set for the specified user.
        /// </summary>
        /// <param name="identity">The data that contains the SID of the user account for which the credential is being queried.</param>
        /// <param name="credentialType">The value that specifies the credential type.</param>
        /// <returns>The value that specifies whether user credentials have been set.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="identity"/> is null.</exception>
        public static CredentialState GetCredentialState(BiometricIdentity identity, CredentialTypes credentialType)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            var hr = SafeNativeMethods.WinBioGetCredentialState(identity.Source,
                                                                (SafeNativeMethods.WINBIO_CREDENTIAL_TYPE)credentialType,
                                                                out var state);

            ThrowWinBiometricException(hr);

            return (CredentialState)state;
        }

        /// <summary>
        /// Retrieves a value that specifies whether users can log on to a domain by using biometric information.
        /// </summary>
        /// <param name="value">When this method returns, contains value that specifies whether biometric domain logons are enabled.</param>
        /// <param name="source">When this method returns, contains value that specifies the setting source.</param>
        public static void GetDomainLogonSetting(out bool value, out SettingSourceType source)
        {
            var hr = SafeNativeMethods.WinBioGetDomainLogonSetting(out value, out var tmp);

            ThrowWinBiometricException(hr);

            source = (SettingSourceType)tmp;
        }

        /// <summary>
        /// Retrieves a value that specifies whether the Windows Biometric Framework is currently enabled.
        /// </summary>
        /// <param name="value">When this method returns, contains value that specifies whether the Windows Biometric Framework is currently enabled.</param>
        /// <param name="source">When this method returns, contains value that specifies the setting source.</param>
        public static void GetEnabledSetting(out bool value, out SettingSourceType source)
        {
            var hr = SafeNativeMethods.WinBioGetEnabledSetting(out value, out var tmp);

            ThrowWinBiometricException(hr);

            source = (SettingSourceType)tmp;
        }

        /// <summary>
        /// Gets information about the biometric enrollments that the specified user has on the computer.
        /// </summary>
        /// <param name="accountOwner">The data for the user whose biometric enrollments you want to get.</param>
        /// <returns>The flags that indicate the biometric enrollments that the specified user has on the computer.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="accountOwner"/> is null.</exception>
        public static BiometricTypes GetEnrolledFactors(BiometricIdentity accountOwner)
        {
            if (accountOwner == null)
                throw new ArgumentNullException(nameof(accountOwner));

            unsafe
            {
                var nativeIdentity = accountOwner.Source;
                WINBIO_BIOMETRIC_TYPE enrolledFactor;
                var hr = SafeNativeMethods.WinBioGetEnrolledFactors(&nativeIdentity,
                                                                    &enrolledFactor);

                ThrowWinBiometricException(hr);

                return (BiometricTypes)enrolledFactor;
            }
        }

        /// <summary>
        /// Retrieves a value that indicates whether users can log on by using biometric information.
        /// </summary>
        /// <param name="value">When this method returns, contains value that specifies whether biometric logons are enabled.</param>
        /// <param name="source">When this method returns, contains value that specifies the setting source.</param>
        public static void GetLogonSetting(out bool value, out SettingSourceType source)
        {
            var hr = SafeNativeMethods.WinBioGetLogonSetting(out value, out var tmp);

            ThrowWinBiometricException(hr);

            source = (SettingSourceType)tmp;
        }

        public static AntiSpoofPolicy GetAntiSpoofPolicyProperty(Session session,
                                                                 PropertyType propertyType,
                                                                 BiometricIdentity identity)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            unsafe
            {
                var tmp = identity.Source;
                var nativeIdentity = &tmp;

                var hr = SafeNativeMethods.WinBioGetProperty(session.Handle,
                                                             (WINBIO_PROPERTY_TYPE)propertyType,
                                                             SafeNativeMethods.WINBIO_PROPERTY_ANTI_SPOOF_POLICY,
                                                             0,
                                                             nativeIdentity,
                                                             SafeNativeMethods.WINBIO_SUBTYPE_NO_INFORMATION,
                                                             out var pBuffer,
                                                             out _);

                ThrowWinBiometricException(hr);

                AntiSpoofPolicy antiSpoofPolicy = null;
                if (pBuffer != IntPtr.Zero)
                {
                    var asp = Marshal.PtrToStructure<SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY>(pBuffer);
                    antiSpoofPolicy = new AntiSpoofPolicy(&asp);

                    SafeNativeMethods.WinBioFree(pBuffer);
                }

                return antiSpoofPolicy;
            }
        }

        public static ULONG GetSampleHintProperty(Session session,
                                                  PropertyType propertyType,
                                                  uint unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            unsafe
            {
                var hr = SafeNativeMethods.WinBioGetProperty(session.Handle,
                                                             (WINBIO_PROPERTY_TYPE)propertyType,
                                                             SafeNativeMethods.WINBIO_PROPERTY_SAMPLE_HINT,
                                                             unitId,
                                                             (SafeNativeMethods.WINBIO_IDENTITY*)IntPtr.Zero,
                                                             SafeNativeMethods.WINBIO_SUBTYPE_NO_INFORMATION,
                                                             out var pBuffer,
                                                             out _);

                ThrowWinBiometricException(hr);

                ULONG samples = 0;
                if (pBuffer != IntPtr.Zero)
                {
                    var pSample = (ULONG*) pBuffer;
                    samples = *pSample;

                    SafeNativeMethods.WinBioFree(pBuffer);
                }

                return samples;
            }
        }

        /// <summary>
        /// Retrieves a session, unit, or template property.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="propertyType">The value that specifies the source of the property information.</param>
        /// <param name="propertyId">The value that specifies the property that you want to query.</param>
        /// <param name="unitId">The value that identifies the biometric unit.</param>
        /// <param name="identity">The data that provides the SID of the account for which you want to get the antispoofing policy, if you specify <see cref="PropertyId.AntiSpoofPolicy"/> as the value of the <paramref name="propertyId"/> parameter.</param>
        /// <param name="position">Reserved.</param>
        /// <param name="propertyBuffer">When this method returns, contains the property value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> or <paramref name="identity"/> is null.</exception>
        public static void GetProperty(Session session,
                                       PropertyType propertyType,
                                       PropertyId propertyId,
                                       uint unitId,
                                       BiometricIdentity identity,
                                       FingerPosition position,
                                       out byte[] propertyBuffer)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            unsafe
            {
                var tmp = identity?.Source ?? new SafeNativeMethods.WINBIO_IDENTITY();
                SafeNativeMethods.WINBIO_IDENTITY* nativeIdentity;

                WINBIO_PROPERTY_ID id;
                switch (propertyId)
                {
                    case PropertyId.AntiSpoofPolicy:
                        id = SafeNativeMethods.WINBIO_PROPERTY_ANTI_SPOOF_POLICY;
                        unitId = 0;
                        nativeIdentity = &tmp;
                        break;
                    default:
                        id = (WINBIO_PROPERTY_ID)propertyId;
                        nativeIdentity = (SafeNativeMethods.WINBIO_IDENTITY*)IntPtr.Zero;
                        break;
                }

                // NOTE
                // PropertyType
                //      * Currently this must be WINBIO_PROPERTY_TYPE_UNIT or WINBIO_PROPERTY_TYPE_ACCOUNT.
                // UnitId
                //      * If you specify WINBIO_PROPERTY_ANTI_SPOOF_POLICY as the value for the PropertyId
                //        parameter, specify 0 for the UnitId parameter.
                // Identity
                //      * If you specify any other value for the PropertyId parameter, the Identity parameter must be NULL.
                // SubFactor
                //      * Reserved.This must be WINBIO_SUBTYPE_NO_INFORMATION.

                var hr = SafeNativeMethods.WinBioGetProperty(session.Handle,
                                                             (WINBIO_PROPERTY_TYPE)propertyType,
                                                             id,
                                                             unitId,
                                                             nativeIdentity,
                                                             SafeNativeMethods.WINBIO_SUBTYPE_NO_INFORMATION,
                                                             out var pBuffer,
                                                             out var pBufferSize);

                ThrowWinBiometricException(hr);

                if (pBuffer != IntPtr.Zero)
                {
                    var size = (int)pBufferSize;
                    propertyBuffer = new byte[size];
                    Marshal.Copy(pBuffer, propertyBuffer, 0, propertyBuffer.Length);

                    SafeNativeMethods.WinBioFree(pBuffer);
                }
                else
                {
                    propertyBuffer = null;
                }
            }
        }

        /// <summary>
        /// Captures a biometric sample and determines whether it matches an existing biometric template.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <returns><see cref="IdentifyResult"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static IdentifyResult Identify(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            unsafe
            {
                var hr = SafeNativeMethods.WinBioIdentify(session.Handle,
                                                          out var unitId,
                                                          out var identity,
                                                          out var subFactor,
                                                          out var rejectDetail);

                ThrowWinBiometricException(hr);

                return new IdentifyResult(unitId,
                                          SafeNativeMethods.S_OK,
                                          new BiometricIdentity(&identity),
                                          (FingerPosition)subFactor,
                                          (RejectDetail)rejectDetail);
            }
        }

        /// <summary>
        /// Asynchronously captures a biometric sample and determines whether it matches an existing biometric template.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void IdentifyWithCallback(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioIdentifyWithCallback(session.Handle,
                                                                  NativeIdentifyCallback,
                                                                  IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Retrieves the ID number of a biometric unit selected interactively by a user.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <returns>The ID number of a biometric unit selected interactively by a user.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static WINBIO_UNIT_ID LocateSensor(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioLocateSensor(session.Handle, out var unitId);

            ThrowWinBiometricException(hr);

            return unitId;
        }

        /// <summary>
        /// Asynchronously retrieves the ID number of the biometric unit selected interactively by a user.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void LocateSensorWithCallback(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioLocateSensorWithCallback(session.Handle,
                                                                      NativeSensorLocatedCallback,
                                                                      IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Locks a biometric unit for exclusive use by a single session.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="unitId">The value that specifies the biometric unit to be locked.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void LockUnit(Session session, WINBIO_UNIT_ID unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioLockUnit(session.Handle, unitId);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Causes a fast user switch to the account associated with the last successful identification operation performed by the biometric session.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <returns>true if the function has the switched to the account associated with the last successful identification operation performed by the biometric session; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static bool LogonIdentifiedUser(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioLogonIdentifiedUser(session.Handle);
            switch (hr)
            {
                case SafeNativeMethods.S_OK:
                    return true;
                case SafeNativeMethods.S_FALSE:
                    return false;
            }

            ThrowWinBiometricException(hr);

            // Basically, this statement should not be executed
            return false;
        }

        /// <summary>
        /// Turns on the face-recognition or iris-monitoring mechanism for the specified biometric unit.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="unitId">The identifier of the biometric unit for which you want to turn on the face-recognition or iris-monitoring mechanism.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void MonitorPresence(Session session, uint unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioMonitorPresence(session.Handle, unitId);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Opens a handle to the biometric framework.
        /// </summary>
        /// <param name="userData">The buffer supplied by the caller.</param>
        /// <returns><see cref="Framework"/>.</returns>
        public static Framework OpenFramework(PVOID userData)
        {
            var hr = SafeNativeMethods.WinBioAsyncOpenFramework(SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK,
                                                                IntPtr.Zero,
                                                                0,
                                                                NativeAsyncCompletionCallback,
                                                                userData,
                                                                SafeNativeMethods.FALSE,
                                                                out var frameworkHandle);

            ThrowWinBiometricException(hr);

            return new Framework(frameworkHandle);
        }

        /// <summary>
        /// Opens a handle to the biometric framework.
        /// </summary>
        /// <param name="targetWindow">The handle of the window that will receive the completion notices.</param>
        /// <param name="messageCode">The window message code the framework must send to signify completion notices.</param>
        /// <returns><see cref="Framework"/>.</returns>
        public static Framework OpenFramework(IntPtr targetWindow, UINT messageCode)
        {
            var hr = SafeNativeMethods.WinBioAsyncOpenFramework(SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE,
                                                                targetWindow,
                                                                messageCode,
                                                                IntPtr.Zero,
                                                                IntPtr.Zero,
                                                                SafeNativeMethods.FALSE,
                                                                out var frameworkHandle);

            ThrowWinBiometricException(hr);

            return new Framework(frameworkHandle);
        }

        /// <summary>
        /// Connects to a biometric service provider and one or more biometric units.
        /// </summary>
        /// <returns><see cref="Session"/>.</returns>
        public static Session OpenSession()
        {
            unsafe
            {
                var databaseId = SafeNativeMethods.WINBIO_DB_DEFAULT;
                var hr = SafeNativeMethods.WinBioOpenSession(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,
                                                             SafeNativeMethods.WINBIO_POOL_SYSTEM,
                                                             SafeNativeMethods.WINBIO_FLAG_RAW,
                                                             null,
                                                             IntPtr.Zero,
                                                             databaseId,
                                                             out var sessionHandle
                );

                ThrowWinBiometricException(hr);

                return new Session(sessionHandle, false);
            }
        }

        /// <summary>
        /// Connects to a biometric service provider and one or more biometric units.
        /// </summary>
        /// <param name="userData">The buffer supplied by the caller.</param>
        /// <returns><see cref="Session"/>.</returns>
        public static Session OpenSession(PVOID userData)
        {
            unsafe
            {
                var databaseId = SafeNativeMethods.WINBIO_DB_DEFAULT;
                var hr = SafeNativeMethods.WinBioAsyncOpenSession(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,
                                                                  SafeNativeMethods.WINBIO_POOL_SYSTEM,
                                                                  SafeNativeMethods.WINBIO_FLAG_RAW,
                                                                  null,
                                                                  IntPtr.Zero,
                                                                  databaseId,
                                                                  SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK,
                                                                  IntPtr.Zero,
                                                                  0,
                                                                  NativeAsyncCompletionCallback,
                                                                  userData,
                                                                  SafeNativeMethods.FALSE,
                                                                  out var sessionHandle);

                ThrowWinBiometricException(hr);

                return new Session(sessionHandle, true);
            }
        }

        /// <summary>
        /// Connects to a biometric service provider and one or more biometric units.
        /// </summary>
        /// <param name="targetWindow">The handle of the window that will receive the completion notices.</param>
        /// <param name="messageCode">The window message code the framework must send to signify completion notices.</param>
        /// <returns><see cref="Session"/>.</returns>
        public static Session OpenSession(IntPtr targetWindow, UINT messageCode)
        {
            unsafe
            {
                var databaseId = SafeNativeMethods.WINBIO_DB_DEFAULT;
                var hr = SafeNativeMethods.WinBioAsyncOpenSession(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,
                                                                  SafeNativeMethods.WINBIO_POOL_SYSTEM,
                                                                  SafeNativeMethods.WINBIO_FLAG_RAW,
                                                                  null,
                                                                  IntPtr.Zero,
                                                                  databaseId,
                                                                  SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE,
                                                                  targetWindow,
                                                                  messageCode,
                                                                  IntPtr.Zero,
                                                                  IntPtr.Zero,
                                                                  SafeNativeMethods.FALSE,
                                                                  out var sessionHandle);

                ThrowWinBiometricException(hr);

                return new Session(sessionHandle, true);
            }
        }

        /// <summary>
        /// Starts to receive event notifications from the service provider associated with an open session.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="eventType">A value that specifies the types of events to monitor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void RegisterEventMonitor(Session session, EventTypes eventType)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioRegisterEventMonitor(session.Handle,
                                                                  (WINBIO_EVENT_TYPE)eventType,
                                                                  NativeEventCallback,
                                                                  IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Releases window focus.
        /// </summary>
        public static void ReleaseFocus()
        {
            var hr = SafeNativeMethods.WinBioReleaseFocus();
            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Removes all credentials from the store.
        /// </summary>
        public static void RemoveAllCredentials()
        {
            var hr = SafeNativeMethods.WinBioRemoveAllCredentials();

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Removes all user credentials for the current domain from the store.
        /// </summary>
        public static void RemoveAllDomainCredentials()
        {
            var hr = SafeNativeMethods.WinBioRemoveAllDomainCredentials();

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Deletes a biometric logon credential for a specified user.
        /// </summary>
        /// <param name="identity">A <see cref="BiometricIdentity"/> that contains the SID of the user account for which the logon credential will be removed.</param>
        /// <param name="credentialType">A <see cref="CredentialTypes"/> that specifies the credential type.</param>
        /// <exception cref="ArgumentNullException"><paramref name="identity"/> is null.</exception>
        public static void RemoveCredential(BiometricIdentity identity, CredentialTypes credentialType)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            var hr = SafeNativeMethods.WinBioRemoveCredential(identity.Source, (SafeNativeMethods.WINBIO_CREDENTIAL_TYPE)credentialType);

            ThrowWinBiometricException(hr);
        }

        public static void RemoveDatabase(BiometricUnit unit, Guid databaseId)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            if (databaseId == Guid.Empty)
                throw new ArgumentException();

            if (!IsDatabaseInstalled(databaseId, out _))
                throw new ArgumentException();

            var unitSchema = new SafeNativeMethods.WINBIO_UNIT_SCHEMA
            {
                Description = unit.Description,
                DeviceInstanceId = unit.DeviceInstanceId,
                Manufacturer = unit.Manufacturer,
                Model = unit.Model,
                SerialNumber = unit.SerialNumber,
                SensorSubType = (WINBIO_BIOMETRIC_SENSOR_SUBTYPE)unit.SensorSubType,
                BiometricFactor = (WINBIO_BIOMETRIC_TYPE)unit.BiometricFactor,
                Capabilities = (WINBIO_CAPABILITIES)unit.Capabilities,
                PoolType = (WINBIO_POOL_TYPE)unit.PoolType,
                UnitId = unit.UnitId,
                FirmwareVersion = new SafeNativeMethods.WINBIO_VERSION
                {
                    MinorVersion = unit.FirmwareVersion.MinorVersion,
                    MajorVersion = unit.FirmwareVersion.MajorVersion
                }
            };

            var hr = UnregisterPrivateConfiguration(unitSchema, databaseId, out _);
            if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
                throw Marshal.GetExceptionForHR(hr);

            hr = UnregisterDatabase(databaseId);
            if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
                throw Marshal.GetExceptionForHR(hr);
        }

        /// <summary>
        /// Specifies the individual that you want to enroll when data that represents multiple individuals is present in the sample buffer.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="selectorValue">The value that identifies that individual that you want to select for enrollment.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void SelectEnroll(Session session, ULONGLONG selectorValue)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollSelect(session.Handle, selectorValue);

            ThrowWinBiometricException(hr);
        }

        public static void SetAntiSpoofPolicyProperty(Session session,
                                                      PropertyType propertyType,
                                                      BiometricIdentity identity,
                                                      AntiSpoofPolicy antiSpoofPolicy)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));
            if (antiSpoofPolicy == null)
                throw new ArgumentNullException(nameof(antiSpoofPolicy));

            unsafe
            {
                var tmp = identity.Source;
                var nativeIdentity = &tmp;

                var asp = new SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY
                {
                    Source = (SafeNativeMethods.WINBIO_POLICY_SOURCE)antiSpoofPolicy.Source,
                    Action = (SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY_ACTION)antiSpoofPolicy.Action
                };

                var propertyBuffer = (IntPtr)(&asp);
                var propertyBufferSize = (SIZE_T)sizeof(SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY);

                var hr = SafeNativeMethods.WinBioSetProperty(session.Handle,
                                                             (WINBIO_PROPERTY_TYPE)propertyType,
                                                             SafeNativeMethods.WINBIO_PROPERTY_ANTI_SPOOF_POLICY,
                                                             0,
                                                             nativeIdentity,
                                                             SafeNativeMethods.WINBIO_SUBTYPE_NO_INFORMATION,
                                                             propertyBuffer,
                                                             propertyBufferSize);

                ThrowWinBiometricException(hr);
            }
        }

        /// <summary>
        /// Saves a biometric logon credential for the current user.
        /// </summary>
        /// <param name="credentialType">A <see cref="CredentialTypes"/> that specifies the credential type.</param>
        /// <param name="credential">The buffer that contains the credential.</param>
        /// <param name="format">A <see cref="CredentialFormat"/> that specifies the format of the credential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="credential"/> is null.</exception>
        public static void SetCredential(CredentialTypes credentialType,
                                         byte[] credential,
                                         CredentialFormat format)
        {
            if (credential == null)
                throw new ArgumentNullException(nameof(credential));

            unsafe
            {
                fixed (byte* pCredential = &credential[0])
                {
                    var hr = SafeNativeMethods.WinBioSetCredential((SafeNativeMethods.WINBIO_CREDENTIAL_TYPE)credentialType,
                                                                   (IntPtr)pCredential,
                                                                   (SIZE_T)credential.Length,
                                                                   (SafeNativeMethods.WINBIO_CREDENTIAL_FORMAT)format);

                    ThrowWinBiometricException(hr);
                }
            }
        }

        /// <summary>
        /// Releases the session lock on the specified biometric unit.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="unitId">The value that specifies the biometric unit to unlock.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void UnlockUnit(Session session, WINBIO_UNIT_ID unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioUnlockUnit(session.Handle, unitId);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Cancels event notifications from the service provider associated with an open biometric session.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void UnregisterEventMonitor(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioUnregisterEventMonitor(session.Handle);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Captures a biometric sample and determines whether the sample corresponds to the specified user identity.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="position">A <see cref="FingerPosition"/> that specifies the sub-factor associated with the biometric sample.</param>
        /// <returns><see cref="VerifyResult"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static VerifyResult Verify(Session session, FingerPosition position)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = GetCurrentUserIdentity(out var identity);
            if (hr != 0)
                ThrowWinBiometricException(hr);

            hr = SafeNativeMethods.WinBioVerify(session.Handle,
                                                ref identity,
                                                (WINBIO_BIOMETRIC_SUBTYPE)position,
                                                out var unitId,
                                                out var match,
                                                out var rejectDetail);

            switch (hr)
            {
                case SafeNativeMethods.WINBIO_E_BAD_CAPTURE:
                case SafeNativeMethods.WINBIO_E_ENROLLMENT_IN_PROGRESS:
                case SafeNativeMethods.WINBIO_E_NO_MATCH:
                    break;
                default:
                    ThrowWinBiometricException(hr);
                    break;
            }

            return new VerifyResult(match, unitId, hr, (RejectDetail)rejectDetail);
        }

        /// <summary>
        /// Asynchronously captures a biometric sample and determines whether the sample corresponds to the specified user identity.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <param name="position">A <see cref="FingerPosition"/> that specifies the sub-factor associated with the biometric sample.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void VerifyWithCallback(Session session, FingerPosition position)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = GetCurrentUserIdentity(out var identity);
            if (hr != 0)
                ThrowWinBiometricException(hr);

            hr = SafeNativeMethods.WinBioVerifyWithCallback(session.Handle,
                                                            ref identity,
                                                            (WINBIO_BIOMETRIC_SUBTYPE)position,
                                                            NativeVerifyCallback,
                                                            IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        /// <summary>
        /// Blocks caller execution until all pending biometric operations for a session have been completed or canceled.
        /// </summary>
        /// <param name="session">A <see cref="Session"/> that identifies an open biometric session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="session"/> is null.</exception>
        public static void Wait(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioWait(session.Handle);

            ThrowWinBiometricException(hr);
        }

        #region Helpers

        private static bool ConvertUuidToString(Guid uuid, out StringBuilder uuidStringBuffer, [In] bool includeBraces)
        {
            var str = includeBraces ? $"{{{uuid}}}" : uuid.ToString();
            uuidStringBuffer = new StringBuilder(str);
            return true;
        }

        private static unsafe CaptureSampleResult CreateCaptureSampleResult(WINBIO_UNIT_ID unitId,
                                                                            HRESULT status,
                                                                            SafeNativeMethods.WINBIO_BIR* sample,
                                                                            IntPtr sampleSize,
                                                                            WINBIO_REJECT_DETAIL rejectDetail)
        {
            var result = new CaptureSampleResult(unitId, status, (RejectDetail)rejectDetail, (uint)sampleSize);
            if (sample != null)
            {
                var tmp = (UIntPtr)((ulong)sample + sample->StandardDataBlock.Offset);
                var ansiBdbHeader = (SafeNativeMethods.WINBIO_BDB_ANSI_381_HEADER*)tmp;
                var bdbAnsi381Header = sizeof(SafeNativeMethods.WINBIO_BDB_ANSI_381_HEADER);
                var ansiBdbRecord = (SafeNativeMethods.WINBIO_BDB_ANSI_381_RECORD*)((byte*)(ansiBdbHeader) + bdbAnsi381Header);
                var bdbAnsi381Record = sizeof(SafeNativeMethods.WINBIO_BDB_ANSI_381_RECORD);
                var firstPixel = (IntPtr)ansiBdbRecord + bdbAnsi381Record;

                var image = new byte[ansiBdbRecord->BlockLength - bdbAnsi381Record];
                Marshal.Copy(firstPixel, image, 0, image.Length);

                result.Sample = new CaptureSample(ansiBdbRecord->HorizontalLineLength,
                                                  ansiBdbRecord->VerticalLineLength,
                                                  ansiBdbHeader->HorizontalScanResolution,
                                                  ansiBdbHeader->VerticalScanResolution,
                                                  ansiBdbHeader->HorizontalImageResolution,
                                                  ansiBdbHeader->VerticalImageResolution,
                                                  image);
            }

            return result;
        }

        private static HRESULT CreateCompatibleConfiguration(ref SafeNativeMethods.WINBIO_UNIT_SCHEMA unitSchema, out PoolConfiguration configuration)
        {
            configuration = new PoolConfiguration();
            var hr = SafeNativeMethods.WinBioEnumDatabases(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,
                                                           out var storageArray,
                                                           out var storageCount);

            if (SafeNativeMethods.Macros.FAILED(hr))
                return hr;

            var regPath = $"{@"System\CurrentControlSet\\Enum\"}{unitSchema.DeviceInstanceId}{@"\Device Parameters\WinBio\Configurations"}";
            var regStatus = SafeNativeMethods.RegOpenKeyExW(SafeNativeMethods.HKEY_LOCAL_MACHINE,
                                                            regPath,
                                                            0,
                                                            SafeNativeMethods.KEY_READ,
                                                            out var configListKey);

            if (regStatus != SafeNativeMethods.ERROR_SUCCESS)
            {
                if (storageArray != IntPtr.Zero)
                    SafeNativeMethods.WinBioFree((IntPtr)storageArray);

                return SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)regStatus);
            }

            uint subkeyIndex = 0;
            for (; ; )
            {
                string sensorAdapter = null;
                string engineAdapter = null;
                string storageAdapter = null;

                hr = SafeNativeMethods.S_OK;

                var sensorMode = IntPtr.Zero;
                var configFlags = 0u;
                var systemSensor = IntPtr.Zero;
                var dataFormat = Guid.Empty;
                var attributes = 0u;
                var subkeyName = new StringBuilder(SafeNativeMethods.MAX_PATH);
                var lpReserved = IntPtr.Zero;
                var lpcClass = IntPtr.Zero;
                var subkeyNameLength = (uint)SafeNativeMethods.MAX_PATH;

                regStatus = SafeNativeMethods.RegEnumKeyExW(configListKey,
                                                            subkeyIndex,
                                                            subkeyName,
                                                            ref subkeyNameLength,
                                                            lpReserved,
                                                            null,
                                                            lpcClass,
                                                            out _);

                if (regStatus != SafeNativeMethods.ERROR_SUCCESS)
                {
                    hr = regStatus == SafeNativeMethods.ERROR_NO_MORE_ITEMS ?
                                      SafeNativeMethods.S_OK : SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)regStatus);
                    break;
                }

                if (IsKeyNameNumeric(subkeyName, subkeyNameLength))
                {
                    var configKeyPath = $"{regPath}\\{subkeyName}";
                    hr = SafeNativeMethods.RegOpenKeyExW(SafeNativeMethods.HKEY_LOCAL_MACHINE,
                                                         configKeyPath,
                                                         0,
                                                         SafeNativeMethods.KEY_READ,
                                                         out var configKey);

                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                    if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                    {
                        /*
                            Extract values in this configuration
                                SensorMode              - REG_DWORD
                                SystemSensor            - REG_DWORD
                                DatabaseId              - REG_SZ
                                SensorAdapterBinary     - REG_SZ
                                EngineAdapterBinary     - REG_SZ
                                StorageAdapterBinary    - REG_SZ
                        */
                        var dataSize = (UInt32)Marshal.SizeOf(sensorMode);
                        hr = SafeNativeMethods.RegGetValueW(configKey,
                                                            null,
                                                            "SensorMode",
                                                            SafeNativeMethods.RRF_RT_REG_DWORD,
                                                            out var pdwType,
                                                            out sensorMode,
                                                            ref dataSize);

                        hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                        if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                        {
                            switch ((uint)sensorMode)
                            {
                                case SafeNativeMethods.WINBIO_SENSOR_BASIC_MODE:
                                    configFlags = SafeNativeMethods.WINBIO_FLAG_BASIC;
                                    break;
                                case SafeNativeMethods.WINBIO_SENSOR_ADVANCED_MODE:
                                    configFlags = SafeNativeMethods.WINBIO_FLAG_ADVANCED;
                                    break;
                                default:
                                    configFlags = SafeNativeMethods.WINBIO_FLAG_DEFAULT;
                                    break;
                            }
                        }

                        if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                        {
                            dataSize = (UInt32)Marshal.SizeOf(systemSensor);
                            hr = SafeNativeMethods.RegGetValueW(configKey,
                                                                null,
                                                                "SystemSensor",
                                                                SafeNativeMethods.RRF_RT_REG_DWORD,
                                                                out pdwType,
                                                                out systemSensor,
                                                                ref dataSize);

                            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                        }

                        if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                        {
                            dataSize = 40 * 2;
                            var pvData = Marshal.AllocHGlobal((int)dataSize);
                            hr = SafeNativeMethods.RegGetValueW(configKey,
                                                                null,
                                                                "DatabaseId",
                                                                SafeNativeMethods.RRF_RT_REG_SZ,
                                                                out pdwType,
                                                                pvData,
                                                                ref dataSize);

                            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                            if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                            {
                                // convert string to GUID and find that GUID 
                                // in database list; capture corresponding 
                                // data-format GUID
                                var databaseIdString = Marshal.PtrToStringAuto(pvData);
                                var uuidString = new StringBuilder(databaseIdString);
                                var databaseIdGuid = new Guid(uuidString.ToString());

                                if (!FindInstalledDatabase(storageArray, (uint)storageCount, databaseIdGuid, out var tmp))
                                    hr = SafeNativeMethods.WINBIO_E_DATABASE_CANT_FIND;
                            }

                            Marshal.FreeHGlobal(pvData);
                        }

                        if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                        {
                            dataSize = SafeNativeMethods.MAX_PATH * 2;
                            var pvData = Marshal.AllocHGlobal((int)dataSize);
                            hr = SafeNativeMethods.RegGetValueW(configKey,
                                                                null,
                                                                "SensorAdapterBinary",
                                                                SafeNativeMethods.RRF_RT_REG_SZ,
                                                                out pdwType,
                                                                pvData,
                                                                ref dataSize);

                            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                            if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                                sensorAdapter = Marshal.PtrToStringAuto(pvData);

                            Marshal.FreeHGlobal(pvData);
                        }

                        if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                        {
                            dataSize = SafeNativeMethods.MAX_PATH * 2;
                            var pvData = Marshal.AllocHGlobal((int)dataSize);
                            hr = SafeNativeMethods.RegGetValueW(configKey,
                                                                null,
                                                                "EngineAdapterBinary",
                                                                SafeNativeMethods.RRF_RT_REG_SZ,
                                                                out pdwType,
                                                                pvData,
                                                                ref dataSize);

                            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                            if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                                engineAdapter = Marshal.PtrToStringAuto(pvData);

                            Marshal.FreeHGlobal(pvData);
                        }

                        if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                        {
                            dataSize = SafeNativeMethods.MAX_PATH * 2;
                            var pvData = Marshal.AllocHGlobal((int)dataSize);
                            hr = SafeNativeMethods.RegGetValueW(configKey,
                                                                null,
                                                                "StorageAdapterBinary",
                                                                SafeNativeMethods.RRF_RT_REG_SZ,
                                                                out pdwType,
                                                                pvData,
                                                                ref dataSize);

                            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                            if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                                storageAdapter = Marshal.PtrToStringAuto(pvData);

                            Marshal.FreeHGlobal(pvData);
                        }

                        SafeNativeMethods.RegCloseKey(configKey);
                    }
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    if (systemSensor != (IntPtr)SafeNativeMethods.FALSE)
                    {
                        // copy results to output structure - we only want this
                        // one if it's a derived from a system sensor config
                        configuration.ConfigurationFlags = configFlags;
                        configuration.DatabaseAttributes = attributes;
                        configuration.DataFormat = dataFormat;
                        configuration.SensorAdapter = sensorAdapter;
                        configuration.EngineAdapter = engineAdapter;
                        configuration.StorageAdapter = storageAdapter;
                        break;
                    }

                    ++subkeyIndex;
                }
                else
                {
                    break;
                }
            }

            SafeNativeMethods.RegCloseKey(configListKey);

            if (storageArray != IntPtr.Zero)
                SafeNativeMethods.WinBioFree((IntPtr)storageArray);

            return hr;
        }

        private static bool FindInstalledDatabase(IntPtr storageArray, uint storageCount, Guid databaseId, out SafeNativeMethods.WINBIO_STORAGE_SCHEMA result)
        {
            result = default(SafeNativeMethods.WINBIO_STORAGE_SCHEMA);

            var array = MarshalArray<SafeNativeMethods.WINBIO_STORAGE_SCHEMA>(storageArray, (int)storageCount);
            for (int index = 0, count = (int)storageCount; index < count; ++index)
            {
                if (array[index].DatabaseId != databaseId)
                    continue;

                result = array[index];
                return true;
            }

            return false;
        }

        private static HRESULT GetCurrentUserIdentity(out SafeNativeMethods.WINBIO_IDENTITY identity)
        {
            identity = new SafeNativeMethods.WINBIO_IDENTITY();

            var tokenHandle = IntPtr.Zero;

            try
            {
                // Open the access token associated with the
                // current process
                var currentProcess = SafeNativeMethods.GetCurrentProcess();
                var hr = SafeNativeMethods.OpenProcessToken(currentProcess, SafeNativeMethods.TOKEN_READ, out tokenHandle);
                if (hr == 0)
                {
                    var win32Status = Marshal.GetLastWin32Error();
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)win32Status);
                    return hr;
                }

                unsafe
                {
                    var retIdentity = identity;
                    retIdentity.Type = SafeNativeMethods.WINBIO_ID_TYPE_NULL;

                    // Zero the input identity and specify the type.
                    var p = (IntPtr)(&retIdentity);
                    SafeNativeMethods.RtlZeroMemory(p, (IntPtr)sizeof(SafeNativeMethods.WINBIO_IDENTITY));

                    // Get TokenInformationLength and need not to check hr
                    var tokenInfLength = 0U;
                    hr = SafeNativeMethods.GetTokenInformation(tokenHandle,
                                                               SafeNativeMethods.TOKEN_INFORMATION_CLASS.TokenUser,
                                                               IntPtr.Zero,
                                                               tokenInfLength,
                                                               out tokenInfLength);
                    // NOT CHECK RETURN VALUE!!
                    //if (hr == 0)
                    //{
                    //    var win32Status = Marshal.GetLastWin32Error();
                    //    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)win32Status);
                    //    return hr;
                    //}

                    var tokenInformation = Marshal.AllocHGlobal((int)tokenInfLength);
                    hr = SafeNativeMethods.GetTokenInformation(tokenHandle,
                                                               SafeNativeMethods.TOKEN_INFORMATION_CLASS.TokenUser,
                                                               tokenInformation,
                                                               tokenInfLength,
                                                               out tokenInfLength);
                    if (hr == 0)
                    {
                        var win32Status = Marshal.GetLastWin32Error();
                        hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)win32Status);

                        Marshal.FreeHGlobal(tokenInformation);
                        return hr;
                    }

                    var tokenUser = (SafeNativeMethods.TOKEN_USER)Marshal.PtrToStructure(tokenInformation, typeof(SafeNativeMethods.TOKEN_USER));
                    var ptr = (IntPtr)(&retIdentity.Value.AccountSid.Data[0]);
                    hr = SafeNativeMethods.CopySid(SafeNativeMethods.SECURITY_MAX_SID_SIZE, ptr, tokenUser.User.Sid);
                    if (hr == 0)
                    {
                        var win32Status = Marshal.GetLastWin32Error();
                        hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)win32Status);

                        Marshal.FreeHGlobal(tokenInformation);
                        return hr;
                    }

                    // Specify the size of the SID and assign WINBIO_ID_TYPE_SID
                    // to the type member of the WINBIO_IDENTITY structure.
                    retIdentity.Value.AccountSid.Size = SafeNativeMethods.GetLengthSid(ptr);
                    retIdentity.Type = SafeNativeMethods.WINBIO_ID_TYPE_SID;

                    Marshal.FreeHGlobal(tokenInformation);

                    identity = retIdentity;
                    return 0;
                }
            }
            finally
            {
                if (tokenHandle != IntPtr.Zero)
                    SafeNativeMethods.CloseHandle(tokenHandle);
            }
        }

        private static bool IsDatabaseInstalled(Guid databaseId, out Guid dataFormat)
        {
            var storageArray = IntPtr.Zero;

            try
            {
                var hr = SafeNativeMethods.WinBioEnumDatabases(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT,
                                                               out storageArray,
                                                               out var storageCount);

                if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
                    return false;

                var count = (uint)storageCount;
                if (count == 0)
                    return false;

                return IsDatabaseInstalled(storageArray, count, databaseId, out dataFormat);
            }
            finally
            {
                if (storageArray != IntPtr.Zero)
                    SafeNativeMethods.WinBioFree(storageArray);
            }
        }

        private static bool IsDatabaseInstalled(IntPtr storageArray, uint storageCount, Guid databaseId, out Guid dataFormat)
        {
            if (!FindInstalledDatabase(storageArray, storageCount, databaseId, out var result))
                return false;

            dataFormat = result.DataFormat;
            return true;
        }

        private static bool IsKeyNameNumeric(StringBuilder keyName, UInt32 keyNameLength)
        {
            if (keyNameLength == 0)
                return false;

            for (var i = 0; i < keyNameLength; ++i)
                if (!char.IsDigit(keyName[i]))
                    return false;

            return true;
        }

        private static T[] MarshalArray<T>(IntPtr pointer, int count)
        {
            if (pointer == IntPtr.Zero)
                return null;

            var offset = pointer;
            var data = new T[count];
            var type = typeof(T);
            if (type.IsEnum)
                type = type.GetEnumUnderlyingType();

            for (var i = 0; i < count; i++)
            {
                data[i] = (T)Marshal.PtrToStructure(offset, type);
                offset += Marshal.SizeOf(type);
            }

            return data;
        }

        private static unsafe HRESULT RegisterDatabase(SafeNativeMethods.WINBIO_STORAGE_SCHEMA storageSchema)
        {
            /*
                HKLM\System\CurrentControlSet\Services\WbioSrvc\Databases\{guid} -- NOTE THE CURLY BRACES
                    Attributes          - SafeNativeMethods.REG_DWORD
                    AutoCreate          - SafeNativeMethods.REG_DWORD (1)
                    AutoName            - SafeNativeMethods.REG_DWORD (1)     -- this is reset to zero when the service creates the DB
                    BiometricType       - SafeNativeMethods.REG_DWORD (8)     -- WINBIO_TYPE_FINGERPRINT
                    ConnectionString    - REG_SZ ""
                    Filepath            - REG_SZ ""         -- set by service
                    Format              - REG_SZ "guid"     -- NOTE: *NO* CURLY BRACES
                    InitialSize         - SafeNativeMethods.REG_DWORD (32)
            */
            if (!ConvertUuidToString(storageSchema.DatabaseId, out var databaseKeyName, true))
                return SafeNativeMethods.E_INVALIDARG;

            if (!ConvertUuidToString(storageSchema.DataFormat, out var dataFormat, false))
                return SafeNativeMethods.E_INVALIDARG;

            var hr = SafeNativeMethods.RegOpenKeyExW(SafeNativeMethods.HKEY_LOCAL_MACHINE,
                                                     @"System\CurrentControlSet\Services\WbioSrvc\Databases",
                                                     0,
                                                     SafeNativeMethods.KEY_WRITE,
                                                     out var databaseListKey);

            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
            if (SafeNativeMethods.Macros.FAILED(hr))
                return hr;

            hr = SafeNativeMethods.RegCreateKeyExW(databaseListKey,
                                                   databaseKeyName.ToString(),
                                                   0,
                                                   null,
                                                   SafeNativeMethods.REG_OPTION_NON_VOLATILE,
                                                   SafeNativeMethods.KEY_WRITE,
                                                   null,
                                                   out var newDatabaseKey,
                                                   out var keyDisposition);

            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
            if (SafeNativeMethods.Macros.SUCCEEDED(hr))
            {
                if (keyDisposition == SafeNativeMethods.REG_OPENED_EXISTING_KEY)
                {
                    hr = SafeNativeMethods.WINBIO_E_DATABASE_ALREADY_EXISTS;
                }
                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "Attributes",
                                                          0,
                                                          SafeNativeMethods.REG_DWORD,
                                                          (IntPtr)(&storageSchema.Attributes),
                                                          (uint)Marshal.SizeOf(storageSchema.Attributes));
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    UInt32 autoCreate = 1;
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "AutoCreate",
                                                          0,
                                                          SafeNativeMethods.REG_DWORD,
                                                          (IntPtr)(&autoCreate),
                                                          (uint)Marshal.SizeOf(autoCreate));
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    UInt32 autoName = 1;
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "AutoName",
                                                          0,
                                                          SafeNativeMethods.REG_DWORD,
                                                          (IntPtr)(&autoName),
                                                          (uint)Marshal.SizeOf(autoName));
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    UInt32 biometricType = SafeNativeMethods.WINBIO_TYPE_FINGERPRINT;
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "BiometricType",
                                                          0,
                                                          SafeNativeMethods.REG_DWORD,
                                                          (IntPtr)(&biometricType),
                                                          (uint)Marshal.SizeOf(biometricType));
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    var lpData = Marshal.StringToHGlobalAuto("");
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "ConnectionString",
                                                          0,
                                                          SafeNativeMethods.REG_SZ,
                                                          lpData,
                                                          2); // (uint)Marshal.SizeOf(WCHAR)
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);

                    Marshal.FreeHGlobal(lpData);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    var lpData = Marshal.StringToHGlobalAuto("");
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "FilePath",
                                                          0,
                                                          SafeNativeMethods.REG_SZ,
                                                          lpData,
                                                          2); // (uint)Marshal.SizeOf(WCHAR)
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);

                    Marshal.FreeHGlobal(lpData);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    var lpData = Marshal.StringToHGlobalAuto(dataFormat.ToString());
                    var cbData = (uint)(dataFormat.Length + 1) * 2;
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "Format",
                                                          0,
                                                          SafeNativeMethods.REG_SZ,
                                                          lpData,
                                                          cbData);
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);

                    Marshal.FreeHGlobal(lpData);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    var initialSize = 32;
                    hr = SafeNativeMethods.RegSetValueExW(newDatabaseKey,
                                                          "InitialSize",
                                                          0,
                                                          SafeNativeMethods.REG_DWORD,
                                                          (IntPtr)(&initialSize),
                                                          (uint)Marshal.SizeOf(initialSize));
                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                }

                SafeNativeMethods.RegCloseKey(newDatabaseKey);
            }

            SafeNativeMethods.RegCloseKey(databaseListKey);
            return hr;
        }

        private static void ThrowWinBiometricException(int hresult)
        {
            if (!SafeNativeMethods.Macros.FAILED(hresult))
                return;

            throw Runtime.InteropServices.Marshal.GetWinBiometricExceptionFromHR(hresult);
        }

        private static int UnregisterDatabase(Guid databaseId)
        {
            if (!ConvertUuidToString(databaseId, out var databaseKeyName, true))
                return SafeNativeMethods.E_INVALIDARG;

            var hr = SafeNativeMethods.WinBioEnumDatabases(SafeNativeMethods.WINBIO_TYPE_FINGERPRINT, out var storageSchemaArray, out var storageCount);
            if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
                return hr;

            if (!FindInstalledDatabase(storageSchemaArray, (uint)storageCount, databaseId, out var storageSchema))
                return SafeNativeMethods.WINBIO_E_DATABASE_CANT_FIND;

            hr = SafeNativeMethods.RegOpenKeyExW(SafeNativeMethods.HKEY_LOCAL_MACHINE,
                                                 @"System\CurrentControlSet\Services\WbioSrvc\Databases",
                                                 0,
                                                 SafeNativeMethods.KEY_WRITE,
                                                 out var databaseListKey);

            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
            if (SafeNativeMethods.Macros.SUCCEEDED(hr))
            {
                hr = SafeNativeMethods.RegDeleteKeyExW(databaseListKey,
                                                       databaseKeyName.ToString(),
                                                       SafeNativeMethods.KEY_WOW64_64KEY,
                                                       0);

                hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                {
                    var database = new BiometricDatabase(storageSchema);
                    if (File.Exists(database.FilePath))
                    {
                        try
                        {
                            File.Delete(database.FilePath);
                        }
                        catch (Exception e)
                        {
                            hr = e.HResult;
                        }
                    }
                }

                SafeNativeMethods.RegCloseKey(databaseListKey);
            }

            SafeNativeMethods.WinBioFree(storageSchemaArray);

            return hr;
        }

        private static HRESULT UnregisterPrivateConfiguration(SafeNativeMethods.WINBIO_UNIT_SCHEMA unitSchema, Guid databaseId, out bool configurationRemoved)
        {
            configurationRemoved = false;

            var targetDatabaseId = new StringBuilder(40);
            if (!ConvertUuidToString(databaseId, out targetDatabaseId, false))
                return SafeNativeMethods.E_INVALIDARG;

            var regPath = $"{@"System\CurrentControlSet\\Enum\"}{unitSchema.DeviceInstanceId}{@"\Device Parameters\WinBio\Configurations"}";
            var hr = SafeNativeMethods.RegOpenKeyExW(SafeNativeMethods.HKEY_LOCAL_MACHINE,
                                                     regPath,
                                                     0,
                                                     SafeNativeMethods.KEY_READ | SafeNativeMethods.KEY_WRITE,
                                                     out var configListKey);

            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
            if (SafeNativeMethods.Macros.FAILED(hr))
                return hr;

            var removed = false;
            uint subkeyIndex = 0;
            for (; ; )
            {
                hr = SafeNativeMethods.S_OK;

                var configKeyName = new StringBuilder(SafeNativeMethods.MAX_PATH);
                var configKeyNameLength = (uint)configKeyName.Capacity;
                var regStatus = SafeNativeMethods.RegEnumKeyExW(configListKey,
                                                                subkeyIndex,
                                                                configKeyName,
                                                                ref configKeyNameLength,
                                                                IntPtr.Zero,
                                                                null,
                                                                IntPtr.Zero,
                                                                out _);
                if (regStatus != SafeNativeMethods.ERROR_SUCCESS)
                {
                    hr = regStatus == SafeNativeMethods.ERROR_NO_MORE_ITEMS ?
                                      SafeNativeMethods.S_OK : SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)regStatus);
                    break;
                }

                if (IsKeyNameNumeric(configKeyName, configKeyNameLength))
                {
                    var dataSize = (uint)40 * 2;
                    var pvData = Marshal.AllocHGlobal((int)dataSize);
                    hr = SafeNativeMethods.RegGetValueW(configListKey,
                                                        configKeyName.ToString(),
                                                        "DatabaseId",
                                                        SafeNativeMethods.RRF_RT_REG_SZ,
                                                        out _,
                                                        pvData,
                                                        ref dataSize);

                    hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                    if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                    {
                        var configDatabaseId = Marshal.PtrToStringAuto(pvData);
                        if (string.Equals(configDatabaseId, targetDatabaseId.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            hr = SafeNativeMethods.RegDeleteKeyExW(configListKey,
                                                                   configKeyName.ToString(),
                                                                   SafeNativeMethods.KEY_WOW64_64KEY,
                                                                   0);
                            hr = SafeNativeMethods.Macros.HRESULT_FROM_WIN32((uint)hr);
                            if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                                removed = true;
                        }
                    }

                    Marshal.FreeHGlobal(pvData);
                }

                if (SafeNativeMethods.Macros.SUCCEEDED(hr))
                    ++subkeyIndex;
                else
                    break;
            }

            SafeNativeMethods.RegCloseKey(configListKey);
            configurationRemoved = removed;
            return hr;
        }

        #endregion

        #region Event Handlers

        //private static unsafe void AsyncCompletedCallback(SafeNativeMethods.WINBIO_ASYNC_RESULT* asyncResult)
        //{

        //}

        //private static unsafe void AsyncCompletedCallback(ref SafeNativeMethods.WINBIO_ASYNC_RESULT asyncResult)
        //{
        //}

        private static void AsyncCompletedCallback(IntPtr asyncResult)
        {
            if (asyncResult != IntPtr.Zero)
                SafeNativeMethods.WinBioFree(asyncResult);
        }

        private static void CaptureEnrollCallback(IntPtr enrollCallbackContext,
                                                  int operationStatus,
                                                  WINBIO_REJECT_DETAIL rejectDetail)
        {
            var @event = EnrollCaptured;
            if (@event != null)
            {
                var result = new CaptureEnrollResult(operationStatus,
                                                     (RejectDetail)rejectDetail,
                                                     operationStatus == SafeNativeMethods.WINBIO_I_MORE_DATA);
                var args = new EnrollCapturedEventArgs(result);
                @event.Invoke(null, args);
            }
        }

        private static unsafe void CaptureSampleCallback(IntPtr captureCallbackContext,
                                                         int operationStatus,
                                                         WINBIO_UNIT_ID unitId,
                                                         SafeNativeMethods.WINBIO_BIR* sample,
                                                         IntPtr sampleSize,
                                                         WINBIO_REJECT_DETAIL rejectDetail)
        {
            try
            {
                var @event = SampleCaptured;
                if (@event != null)
                {
                    var result = CreateCaptureSampleResult(unitId, operationStatus, sample, sampleSize, rejectDetail);
                    var args = new CaptureSampleEventArgs(result);
                    @event.Invoke(null, args);
                }
            }
            finally
            {
                if (sample != null)
                {
                    SafeNativeMethods.WinBioFree((IntPtr)sample);
                }
            }
        }

        private static unsafe void EventMonitorCallback(IntPtr eventCallbackContext,
                                                        HRESULT operationStatus,
                                                        SafeNativeMethods.WINBIO_EVENT* @event)
        {
            try
            {
                var e = EventMonitored;
                if (e == null)
                    return;

                if (@event == null)
                    return;

                var args = new EventMonitoredEventArgs(@event, operationStatus);
                e.Invoke(null, args);
            }
            finally
            {
                if (@event != null)
                {
                    SafeNativeMethods.WinBioFree((IntPtr)@event);
                }
            }
        }

        private static unsafe void IdentifyCallback(IntPtr identifyCallbackContext,
                                                    HRESULT operationStatus,
                                                    WINBIO_UNIT_ID unitId,
                                                    SafeNativeMethods.WINBIO_IDENTITY* identity,
                                                    WINBIO_BIOMETRIC_SUBTYPE subFactor,
                                                    WINBIO_REJECT_DETAIL rejectDetail)

        {
            var @event = Identified;
            if (@event != null)
            {
                var result = new IdentifyResult(unitId,
                                                operationStatus,
                                                new BiometricIdentity(identity),
                                                (FingerPosition)subFactor,
                                                (RejectDetail)rejectDetail);

                var args = new IdentifiedEventArgs(result);
                @event.Invoke(null, args);
            }
        }

        private static void LocateSensorCallback(IntPtr locateCallbackContext,
                                                 int operationStatus,
                                                 WINBIO_UNIT_ID unitId)
        {
            var @event = SensorLocated;
            if (@event != null)
            {
                var args = new LocateSensorEventArgs(unitId, operationStatus);
                @event.Invoke(null, args);
            }
        }

        private static void VerifyCallback(IntPtr verifyCallbackContext,
                                           HRESULT operationStatus,
                                           WINBIO_UNIT_ID unitId,
                                           bool match,
                                           WINBIO_REJECT_DETAIL rejectDetail)
        {
            var @event = Verified;
            if (@event != null)
            {
                var args = new VerifyEventArgs(new VerifyResult(match, unitId, operationStatus, (RejectDetail)rejectDetail));
                @event.Invoke(null, args);
            }
        }

        #endregion

        #endregion

    }

}
