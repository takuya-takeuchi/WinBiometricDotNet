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

    public sealed class WinBiometric
    {

        #region Events

        public static event AsyncCompletedHandler AsyncCompleted;

        public static event EnrollCapturedHandler EnrollCaptured;

        public static event EventMonitoredHandler EventMonitored;

        public static event IdentifiedHandler Identified;

        public static event SampleCapturedHandler SampleCaptured;

        public static event SensorLocatedHandler SensorLocated;

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

        public static void AcquireFocus()
        {
            var hr = SafeNativeMethods.WinBioAcquireFocus();

            ThrowWinBiometricException(hr);
        }

        public static void AsyncEnumBiometricUnits(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncEnumBiometricUnits(framework.Handle,
                                                                     (WINBIO_BIOMETRIC_TYPE)biometricTypes);

            ThrowWinBiometricException(hr);
        }

        public static void AsyncEnumDatabases(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncEnumDatabases(framework.Handle,
                                                                (WINBIO_BIOMETRIC_TYPE)biometricTypes);

            ThrowWinBiometricException(hr);
        }

        public static void AsyncEnumServiceProviders(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncEnumServiceProviders(framework.Handle,
                                                                       (WINBIO_BIOMETRIC_TYPE)biometricTypes);

            ThrowWinBiometricException(hr);
        }

        public static void AsyncMonitorFrameworkChanges(Framework framework, ChangeTypes changeType)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioAsyncMonitorFrameworkChanges(framework.Handle,
                                                                          (WINBIO_FRAMEWORK_CHANGE_TYPE)changeType);

            ThrowWinBiometricException(hr);
        }

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

        public static void BeginEnroll(Session session, FingerPosition position, uint unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollBegin(session.Handle, (byte)position, unitId);

            ThrowWinBiometricException(hr);
        }

        public static void Cancel(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioCancel(session.Handle);
            ThrowWinBiometricException(hr);
        }

        public static CaptureEnrollResult CaptureEnroll(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollCapture(session.Handle, out var rejectDetail);

            OperationStatus status;
            switch (hr)
            {
                case SafeNativeMethods.WINBIO_I_MORE_DATA:
                    status = OperationStatus.MoreData;
                    break;
                case SafeNativeMethods.WINBIO_E_BAD_CAPTURE:
                    status = OperationStatus.BadCapture;
                    break;
                default:
                    ThrowWinBiometricException(hr);
                    status = OperationStatus.OK;
                    break;
            }

            return new CaptureEnrollResult(status, (RejectDetail)rejectDetail, status == OperationStatus.MoreData);
        }

        public static void CaptureEnrollWithCallback(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollCaptureWithCallback(session.Handle,
                                                                       NativeEnrollCaptureCallback,
                                                                       IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

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
                                                 OperationStatus.OK,
                                                 (SafeNativeMethods.WINBIO_BIR*)sample,
                                                 sampleSize,
                                                 rejectDetail);
            }
        }

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

        public static void CloseFramework(Framework framework)
        {
            if (framework == null)
                throw new ArgumentNullException(nameof(framework));

            var hr = SafeNativeMethods.WinBioCloseFramework(framework.Handle);

            ThrowWinBiometricException(hr);
        }

        public static void CloseSession(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioCloseSession(session.Handle);

            ThrowWinBiometricException(hr);
        }

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
            {
                var message = ConvertErrorCodeToString(hr);
                throw new WinBiometricException(message);
            }

            var storageSchema = new SafeNativeMethods.WINBIO_STORAGE_SCHEMA
            {
                DatabaseId = guid,
                DataFormat = configuration.DataFormat,
                Attributes = configuration.DatabaseAttributes
            };

            hr = RegisterDatabase(storageSchema);
            if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
            {
                var message = ConvertErrorCodeToString(hr);
                throw new WinBiometricException(message);
            }
        }

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

        public static void DiscardEnroll(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioEnrollDiscard(session.Handle);

            ThrowWinBiometricException(hr);
        }

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

        public static IEnumerable<BiometricUnit> EnumBiometricUnits(BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            var hr = SafeNativeMethods.WinBioEnumBiometricUnits((uint)biometricTypes,
                                                                out var unitSchemaArray,
                                                                out _);

            ThrowWinBiometricException(hr);

            foreach (var schema in unitSchemaArray)
                yield return new BiometricUnit(schema);
        }

        public static IEnumerable<FingerPosition> EnumEnrollments(Session session, BiometricUnit unit)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            var hr = GetCurrentUserIdentity(out var identity);
            if (hr != 0)
            {
                ThrowWinBiometricException(hr);
            }

            hr = SafeNativeMethods.WinBioEnumEnrollments(session.Handle,
                                                         unit.UnitId,
                                                         ref identity,
                                                         out var subFactorArray,
                                                         out var subFactorCount);

            ThrowWinBiometricException(hr);

            var array = new WINBIO_BIOMETRIC_SUBTYPE[(int)subFactorCount];
            Marshal.Copy(subFactorArray, array, 0, (int)subFactorCount);

            SafeNativeMethods.WinBioFree(subFactorArray);

            return array.Select(f => (FingerPosition)f).ToArray();
        }

        public static IEnumerable<BiometricServiceProvider> EnumServiceProviders(BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            var hr = SafeNativeMethods.WinBioEnumServiceProviders((uint)biometricTypes,
                                                                  out var bspSchemaArray,
                                                                  out _);

            ThrowWinBiometricException(hr);

            foreach (var schema in bspSchemaArray)
                yield return new BiometricServiceProvider(schema);
        }

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

        public static void GetDomainLogonSetting(out bool value, out SettingSourceType source)
        {
            var hr = SafeNativeMethods.WinBioGetDomainLogonSetting(out value, out var tmp);

            ThrowWinBiometricException(hr);

            source = (SettingSourceType)tmp;
        }

        public static void GetEnabledSetting(out bool value, out SettingSourceType source)
        {
            var hr = SafeNativeMethods.WinBioGetEnabledSetting(out value, out var tmp);

            ThrowWinBiometricException(hr);

            source = (SettingSourceType)tmp;
        }

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
                                          OperationStatus.OK,
                                          new BiometricIdentity(&identity),
                                          (FingerPosition)subFactor,
                                          (RejectDetail)rejectDetail);
            }
        }

        public static void IdentifyWithCallback(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioIdentifyWithCallback(session.Handle,
                                                                  NativeIdentifyCallback,
                                                                  IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        public static WINBIO_UNIT_ID LocateSensor(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioLocateSensor(session.Handle, out var unitId);

            ThrowWinBiometricException(hr);

            return unitId;
        }

        public static void LocateSensorWithCallback(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioLocateSensorWithCallback(session.Handle,
                                                                      NativeSensorLocatedCallback,
                                                                      IntPtr.Zero);

            ThrowWinBiometricException(hr);
        }

        public static void LockUnit(Session session, WINBIO_UNIT_ID unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioLockUnit(session.Handle, unitId);

            ThrowWinBiometricException(hr);
        }

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

        public static void MonitorPresence(Session session, uint unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioMonitorPresence(session.Handle, unitId);

            ThrowWinBiometricException(hr);
        }

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

        public static void ReleaseFocus()
        {
            var hr = SafeNativeMethods.WinBioReleaseFocus();
            ThrowWinBiometricException(hr);
        }

        public static void RemoveAllCredentials()
        {
            var hr = SafeNativeMethods.WinBioRemoveAllCredentials();

            ThrowWinBiometricException(hr);
        }

        public static void RemoveAllDomainCredentials()
        {
            var hr = SafeNativeMethods.WinBioRemoveAllDomainCredentials();

            ThrowWinBiometricException(hr);
        }

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
            {
                var message = ConvertErrorCodeToString(hr);
                throw new WinBiometricException(message);
            }

            hr = UnregisterDatabase(databaseId);
            if (!SafeNativeMethods.Macros.SUCCEEDED(hr))
            {
                var message = ConvertErrorCodeToString(hr);
                throw new WinBiometricException(message);
            }
        }

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

        public static void UnlockUnit(Session session, WINBIO_UNIT_ID unitId)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioUnlockUnit(session.Handle, unitId);

            ThrowWinBiometricException(hr);
        }

        public static void UnregisterEventMonitor(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioUnregisterEventMonitor(session.Handle);

            ThrowWinBiometricException(hr);
        }

        public static VerifyResult Verify(Session session, BiometricUnit unit, FingerPosition position)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            var hr = GetCurrentUserIdentity(out var identity);
            if (hr != 0)
                ThrowWinBiometricException(hr);

            hr = SafeNativeMethods.WinBioVerify(session.Handle,
                                                ref identity,
                                                (WINBIO_BIOMETRIC_SUBTYPE)position,
                                                out var unitId,
                                                out var match,
                                                out var rejectDetail);

            var status = OperationStatus.OK;
            switch (hr)
            {
                case SafeNativeMethods.E_HANDLE:
                case SafeNativeMethods.E_INVALIDARG:
                case SafeNativeMethods.E_POINTER:
                    ThrowWinBiometricException(hr);
                    break;
                case SafeNativeMethods.WINBIO_E_BAD_CAPTURE:
                    // retrun unitId and rejectDetail
                    status = OperationStatus.BadCapture;
                    ThrowWinBiometricException(ConvertErrorCodeToString(hr));
                    break;
                case SafeNativeMethods.WINBIO_E_ENROLLMENT_IN_PROGRESS:
                    ThrowWinBiometricException(ConvertErrorCodeToString(hr));
                    break;
                case SafeNativeMethods.WINBIO_E_NO_MATCH:
                    status = OperationStatus.NoMatch;
                    ThrowWinBiometricException(ConvertErrorCodeToString(hr));
                    break;
            }

            return new VerifyResult(match, unitId, status, (RejectDetail)rejectDetail);
        }

        public static void VerifyWithCallback(Session session, BiometricUnit unit, FingerPosition position)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

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

        public static void Wait(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioWait(session.Handle);

            ThrowWinBiometricException(hr);
        }

        #region Helpers

        private static string ConvertErrorCodeToString(int errorCode)
        {
            var lpMsgBuf = IntPtr.Zero;
            var messageLength = 0u;
            var systemPathSize = SafeNativeMethods.GetSystemWindowsDirectory(null, 0);
            var systemPath = new StringBuilder((int)systemPathSize);
            SafeNativeMethods.GetSystemWindowsDirectory(systemPath, systemPathSize);

            var libraryPath = Path.Combine(systemPath.ToString(), @"system32\winbio.dll");

            var winbioLibrary = SafeNativeMethods.LoadLibraryExW(libraryPath,
                                                                 SafeNativeMethods.NULL,
                                                                 SafeNativeMethods.LOAD_LIBRARY_AS_DATAFILE |
                                                                 SafeNativeMethods.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
            if (winbioLibrary != IntPtr.Zero)
            {
                var dwFlag = SafeNativeMethods.FORMAT_MESSAGE_ALLOCATE_BUFFER |
                             SafeNativeMethods.FORMAT_MESSAGE_FROM_HMODULE |
                             SafeNativeMethods.FORMAT_MESSAGE_FROM_SYSTEM;
                messageLength = SafeNativeMethods.FormatMessage(dwFlag,
                                                                winbioLibrary,
                                                                (uint)errorCode,
                                                                0,
                                                                out lpMsgBuf,
                                                                0,
                                                                null);

                SafeNativeMethods.FreeLibrary(winbioLibrary);
            }

            string message = null;
            unsafe
            {
                if (messageLength > 0)
                    message = Encoding.Default.GetString((byte*)lpMsgBuf, (int)messageLength);
            }

            SafeNativeMethods.LocalFree(lpMsgBuf);

            // Caller must release buffer with LocalFree()
            return message;
        }

        private static OperationStatus ConvertToOperationStatus(int operationStatus)
        {
            var status = OperationStatus.OK;
            if (SafeNativeMethods.Macros.FAILED(operationStatus))
            {
                switch (operationStatus)
                {
                    case SafeNativeMethods.WINBIO_E_NO_MATCH:
                        status = OperationStatus.NoMatch;
                        break;
                    case SafeNativeMethods.WINBIO_E_BAD_CAPTURE:
                        status = OperationStatus.BadCapture;
                        break;
                    case SafeNativeMethods.WINBIO_I_MORE_DATA:
                        status = OperationStatus.Canceled;
                        break;
                    case SafeNativeMethods.WINBIO_E_CANCELED:
                        status = OperationStatus.MoreData;
                        break;
                    default:
                        status = OperationStatus.Unknown;
                        break;
                }
            }

            return status;
        }

        private static bool ConvertUuidToString(Guid uuid, out StringBuilder uuidStringBuffer, [In] bool includeBraces)
        {
            var str = includeBraces ? $"{{{uuid}}}" : uuid.ToString();
            uuidStringBuffer = new StringBuilder(str);
            return true;
        }

        private static unsafe CaptureSampleResult CreateCaptureSampleResult(WINBIO_UNIT_ID unitId,
                                                                            OperationStatus status,
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

            switch (hresult)
            {
                case SafeNativeMethods.WINBIO_E_ADAPTER_INTEGRITY_FAILURE:
                case SafeNativeMethods.WINBIO_E_AUTO_LOGON_DISABLED:
                case SafeNativeMethods.WINBIO_E_BAD_CAPTURE:
                case SafeNativeMethods.WINBIO_E_CALIBRATION_BUFFER_INVALID:
                case SafeNativeMethods.WINBIO_E_CALIBRATION_BUFFER_TOO_LARGE:
                case SafeNativeMethods.WINBIO_E_CALIBRATION_BUFFER_TOO_SMALL:
                case SafeNativeMethods.WINBIO_E_CANCELED:
                case SafeNativeMethods.WINBIO_E_CAPTURE_ABORTED:
                case SafeNativeMethods.WINBIO_E_CONFIGURATION_FAILURE:
                case SafeNativeMethods.WINBIO_E_CRED_PROV_DISABLED:
                case SafeNativeMethods.WINBIO_E_CRED_PROV_NO_CREDENTIAL:
                case SafeNativeMethods.WINBIO_E_CRED_PROV_SECURITY_LOCKOUT:
                case SafeNativeMethods.WINBIO_E_DATA_COLLECTION_IN_PROGRESS:
                case SafeNativeMethods.WINBIO_E_DATA_PROTECTION_FAILURE:
                case SafeNativeMethods.WINBIO_E_DATABASE_ALREADY_EXISTS:
                case SafeNativeMethods.WINBIO_E_DATABASE_BAD_INDEX_VECTOR:
                case SafeNativeMethods.WINBIO_E_DATABASE_CANT_CLOSE:
                case SafeNativeMethods.WINBIO_E_DATABASE_CANT_CREATE:
                case SafeNativeMethods.WINBIO_E_DATABASE_CANT_ERASE:
                case SafeNativeMethods.WINBIO_E_DATABASE_CANT_FIND:
                case SafeNativeMethods.WINBIO_E_DATABASE_CANT_OPEN:
                case SafeNativeMethods.WINBIO_E_DATABASE_CORRUPTED:
                case SafeNativeMethods.WINBIO_E_DATABASE_EOF:
                case SafeNativeMethods.WINBIO_E_DATABASE_FULL:
                case SafeNativeMethods.WINBIO_E_DATABASE_LOCKED:
                case SafeNativeMethods.WINBIO_E_DATABASE_NO_MORE_RECORDS:
                case SafeNativeMethods.WINBIO_E_DATABASE_NO_RESULTS:
                case SafeNativeMethods.WINBIO_E_DATABASE_NO_SUCH_RECORD:
                case SafeNativeMethods.WINBIO_E_DATABASE_READ_ERROR:
                case SafeNativeMethods.WINBIO_E_DATABASE_WRITE_ERROR:
                case SafeNativeMethods.WINBIO_E_DEADLOCK_DETECTED:
                case SafeNativeMethods.WINBIO_E_DEVICE_BUSY:
                case SafeNativeMethods.WINBIO_E_DEVICE_FAILURE:
                case SafeNativeMethods.WINBIO_E_DISABLED:
                case SafeNativeMethods.WINBIO_E_DUPLICATE_ENROLLMENT:
                case SafeNativeMethods.WINBIO_E_DUPLICATE_TEMPLATE:
                case SafeNativeMethods.WINBIO_E_ENROLLMENT_CANCELED_BY_SUSPEND:
                case SafeNativeMethods.WINBIO_E_ENROLLMENT_IN_PROGRESS:
                case SafeNativeMethods.WINBIO_E_EVENT_MONITOR_ACTIVE:
                case SafeNativeMethods.WINBIO_E_FAST_USER_SWITCH_DISABLED:
                case SafeNativeMethods.WINBIO_E_INCORRECT_BSP:
                case SafeNativeMethods.WINBIO_E_INCORRECT_SENSOR_POOL:
                case SafeNativeMethods.WINBIO_E_INCORRECT_SESSION_TYPE:
                case SafeNativeMethods.WINBIO_E_INSECURE_SENSOR:
                case SafeNativeMethods.WINBIO_E_INVALID_BUFFER:
                case SafeNativeMethods.WINBIO_E_INVALID_BUFFER_ID:
                case SafeNativeMethods.WINBIO_E_INVALID_CALIBRATION_FORMAT_ARRAY:
                case SafeNativeMethods.WINBIO_E_INVALID_CONTROL_CODE:
                case SafeNativeMethods.WINBIO_E_INVALID_DEVICE_STATE:
                case SafeNativeMethods.WINBIO_E_INVALID_KEY_IDENTIFIER:
                case SafeNativeMethods.WINBIO_E_INVALID_OPERATION:
                case SafeNativeMethods.WINBIO_E_INVALID_PROPERTY_ID:
                case SafeNativeMethods.WINBIO_E_INVALID_PROPERTY_TYPE:
                case SafeNativeMethods.WINBIO_E_INVALID_SENSOR_MODE:
                case SafeNativeMethods.WINBIO_E_INVALID_SUBFACTOR:
                case SafeNativeMethods.WINBIO_E_INVALID_TICKET:
                case SafeNativeMethods.WINBIO_E_INVALID_UNIT:
                case SafeNativeMethods.WINBIO_E_KEY_CREATION_FAILED:
                case SafeNativeMethods.WINBIO_E_KEY_IDENTIFIER_BUFFER_TOO_SMALL:
                case SafeNativeMethods.WINBIO_E_LOCK_VIOLATION:
                case SafeNativeMethods.WINBIO_E_MAX_ERROR_COUNT_EXCEEDED:
                case SafeNativeMethods.WINBIO_E_NO_CAPTURE_DATA:
                case SafeNativeMethods.WINBIO_E_NO_MATCH:
                case SafeNativeMethods.WINBIO_E_NO_PREBOOT_IDENTITY:
                case SafeNativeMethods.WINBIO_E_NO_SUPPORTED_CALIBRATION_FORMAT:
                case SafeNativeMethods.WINBIO_E_NOT_ACTIVE_CONSOLE:
                case SafeNativeMethods.WINBIO_E_POLICY_PROTECTION_UNAVAILABLE:
                case SafeNativeMethods.WINBIO_E_PRESENCE_MONITOR_ACTIVE:
                case SafeNativeMethods.WINBIO_E_PROPERTY_UNAVAILABLE:
                case SafeNativeMethods.WINBIO_E_SAS_ENABLED:
                case SafeNativeMethods.WINBIO_E_SELECTION_REQUIRED:
                case SafeNativeMethods.WINBIO_E_SENSOR_UNAVAILABLE:
                case SafeNativeMethods.WINBIO_E_SESSION_BUSY:
                case SafeNativeMethods.WINBIO_E_SESSION_HANDLE_CLOSED:
                case SafeNativeMethods.WINBIO_E_TICKET_QUOTA_EXCEEDED:
                case SafeNativeMethods.WINBIO_E_TRUSTLET_INTEGRITY_FAIL:
                case SafeNativeMethods.WINBIO_E_UNKNOWN_ID:
                case SafeNativeMethods.WINBIO_E_UNSUPPORTED_DATA_FORMAT:
                case SafeNativeMethods.WINBIO_E_UNSUPPORTED_DATA_TYPE:
                case SafeNativeMethods.WINBIO_E_UNSUPPORTED_FACTOR:
                case SafeNativeMethods.WINBIO_E_UNSUPPORTED_POOL_TYPE:
                case SafeNativeMethods.WINBIO_E_UNSUPPORTED_PROPERTY:
                case SafeNativeMethods.WINBIO_E_UNSUPPORTED_PURPOSE:
                case SafeNativeMethods.WINBIO_E_UNSUPPORTED_SENSOR_CALIBRATION_FORMAT:
                    var message = ConvertErrorCodeToString(hresult);
                    throw new WinBiometricException(message);
                default:
                    throw new WinBiometricException(hresult);
            }
        }

        private static void ThrowWinBiometricException(string message)
        {
            throw new WinBiometricException(message);
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
            var status = ConvertToOperationStatus(operationStatus);

            var @event = EnrollCaptured;
            if (@event != null)
            {
                var result = new CaptureEnrollResult(status, (RejectDetail)rejectDetail, status == OperationStatus.MoreData);
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
            var status = ConvertToOperationStatus(operationStatus);

            try
            {
                var @event = SampleCaptured;
                if (@event != null)
                {
                    var result = CreateCaptureSampleResult(unitId, status, sample, sampleSize, rejectDetail);
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

                var status = ConvertToOperationStatus(operationStatus);

                EventMonitoredEventArgs args = null;
                switch (@event->Type)
                {
                    case SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED:
                        var winbioEventUnclaimed = @event->Parameters.Unclaimed;
                        var unclaimed = new UnclaimedEvent(winbioEventUnclaimed.UnitId,
                                                           (RejectDetail)winbioEventUnclaimed.RejectDetail);

                        args = new EventMonitoredEventArgs(EventTypes.Unclaimed,
                                                           status,
                                                           unclaimed,
                                                           null,
                                                           null);
                        break;
                    case SafeNativeMethods.WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY:
                        var winbioEventUnclaimedidentity = @event->Parameters.UnclaimedIdentify;
                        var unclaimedIdentify = new UnclaimedIdentifyEvent(winbioEventUnclaimedidentity.UnitId,
                                                                           (FingerPosition)winbioEventUnclaimedidentity.SubFactor,
                                                                           new BiometricIdentity(&winbioEventUnclaimedidentity.Identity),
                                                                           (RejectDetail)winbioEventUnclaimedidentity.RejectDetail);

                        args = new EventMonitoredEventArgs(EventTypes.UnclaimedIdentify,
                                                           status,
                                                           null,
                                                           unclaimedIdentify,
                                                           null);
                        break;
                    case SafeNativeMethods.WINBIO_EVENT_ERROR:
                        var winbioEventError = @event->Parameters.Error;
                        var error = new ErrorEvent(winbioEventError.ErrorCode);

                        args = new EventMonitoredEventArgs(EventTypes.Error,
                                                           status,
                                                           null,
                                                           null,
                                                           error);
                        break;
                }

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
            var status = ConvertToOperationStatus(operationStatus);

            var @event = Identified;
            if (@event != null)
            {
                var result = new IdentifyResult(unitId, status,
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
            var status = ConvertToOperationStatus(operationStatus);

            var @event = SensorLocated;
            if (@event != null)
            {
                var args = new LocateSensorEventArgs(unitId, status);
                @event.Invoke(null, args);
            }
        }

        private static void VerifyCallback(IntPtr verifyCallbackContext,
                                           HRESULT operationStatus,
                                           WINBIO_UNIT_ID unitId,
                                           bool match,
                                           WINBIO_REJECT_DETAIL rejectDetail)
        {
            var status = ConvertToOperationStatus(operationStatus);

            var @event = Verified;
            if (@event != null)
            {
                var args = new VerifyEventArgs(new VerifyResult(match, unitId, status, (RejectDetail)rejectDetail));
                @event.Invoke(null, args);
            }
        }

        #endregion

        #endregion

    }

}
