using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

using WINBIO_BIOMETRIC_SENSOR_SUBTYPE = System.UInt32;
using WINBIO_BIOMETRIC_SUBTYPE = System.Byte;
using WINBIO_BIOMETRIC_TYPE = System.UInt32;
using WINBIO_BIR_DATA_FLAGS = System.Byte;
using WINBIO_BIR_PURPOSE = System.Byte;
using WINBIO_BIR_QUALITY = System.SByte;
using WINBIO_BIR_VERSION = System.Byte;
using WINBIO_CAPABILITIES = System.UInt32;
using WINBIO_COMPONENT = System.UInt32;
using WINBIO_EVENT_TYPE = System.UInt32;
using WINBIO_FRAMEWORK_CHANGE_TYPE = System.UInt32;
using WINBIO_FRAMEWORK_HANDLE = System.IntPtr;
using WINBIO_IDENTITY_TYPE = System.UInt32;
using WINBIO_INDICATOR_STATUS = System.UInt32;
using WINBIO_OPERATION_TYPE = System.UInt32;
using WINBIO_POOL_TYPE = System.UInt32;
using WINBIO_PROPERTY_ID = System.UInt32;
using WINBIO_PROPERTY_TYPE = System.UInt32;
using WINBIO_REJECT_DETAIL = System.UInt32;
using WINBIO_SENSOR_MODE = System.UInt32;
using WINBIO_SENSOR_STATUS = System.UInt32;
using WINBIO_SESSION_FLAGS = System.UInt32;
using WINBIO_SESSION_HANDLE = System.IntPtr;
using WINBIO_SETTING_SOURCE_TYPE = System.UInt32;
using WINBIO_UNIT_ID = System.UInt32;
using WINBIO_UUID = System.Guid;

namespace WinBiometricDotNet
{

    public sealed class WinBiometric
    {

        #region Events

        public static event SampleCapturedHandler SampleCaptured;

        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        public static void AcquireFocus()
        {
            var hr = SafeNativeMethods.WinBioAcquireFocus();

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

            unsafe
            {
                var hr = SafeNativeMethods.WinBioCaptureSampleWithCallback(session.Handle,
                                                                           SafeNativeMethods.WINBIO_NO_PURPOSE_AVAILABLE,
                                                                           SafeNativeMethods.WINBIO_DATA_FLAG_RAW,
                                                                           CaptureSampleCallback,
                                                                           IntPtr.Zero);

                ThrowWinBiometricException(hr);
            }
        }

        public static void CloseSession(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var hr = SafeNativeMethods.WinBioCloseSession(session.Handle);

            ThrowWinBiometricException(hr);
        }

        public static IEnumerable<BiometricUnit> EnumBiometricUnits(BiometricType biometricType = BiometricType.Fingerprint)
        {
            var hr = SafeNativeMethods.WinBioEnumBiometricUnits((uint)biometricType,
                                                                out var unitSchemaArray,
                                                                out var unitCount);

            ThrowWinBiometricException(hr);

            foreach (var schema in unitSchemaArray)
            {
                yield return new BiometricUnit(schema);
            }
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

                return new Session(sessionHandle);
            }
        }

        public static void ReleaseFocus()
        {
            var hr = SafeNativeMethods.WinBioReleaseFocus();
            ThrowWinBiometricException(hr);
        }

        #region Helpers

        private static OperationStatus ConvertToOperationStatus(int operationStatus)
        {
            var status = OperationStatus.OK;
            if (SafeNativeMethods.Macros.FAILED(operationStatus))
            {
                switch (operationStatus)
                {
                    case SafeNativeMethods.WINBIO_E_BAD_CAPTURE:
                        status = OperationStatus.BadCapture;
                        break;
                    case SafeNativeMethods.WINBIO_E_CANCELED:
                        status = OperationStatus.Canceled;
                        break;
                    default:
                        status = OperationStatus.Unknown;
                        break;
                }
            }

            return status;
        }

        private static unsafe CaptureSampleResult CreateCaptureSampleResult(WINBIO_UNIT_ID unitId,
                                                                            OperationStatus status,
                                                                            SafeNativeMethods.WINBIO_BIR* sample,
                                                                            IntPtr sampleSize,
                                                                            WINBIO_REJECT_DETAIL rejectDetail)
        {
            var result = new CaptureSampleResult(unitId, status, rejectDetail, (uint)sampleSize);
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

        private static void ThrowWinBiometricException(int hresult)
        {
            if (!SafeNativeMethods.Macros.FAILED(hresult))
                return;
            
            var lpMsgBuf = IntPtr.Zero;
            var dwFlag = SafeNativeMethods.FORMAT_MESSAGE_ALLOCATE_BUFFER | SafeNativeMethods.FORMAT_MESSAGE_FROM_SYSTEM | SafeNativeMethods.FORMAT_MESSAGE_IGNORE_INSERTS;
            var dwChars = SafeNativeMethods.FormatMessage(dwFlag,
                                                          IntPtr.Zero,
                                                          (uint)hresult,
                                                          0,
                                                          ref lpMsgBuf,
                                                          0,
                                                          null);
            string message = "";
            if (dwChars != 0)
            {
                message = Marshal.PtrToStringAnsi(lpMsgBuf) ?? "";
                SafeNativeMethods.LocalFree(lpMsgBuf);
            }

            // 末尾の改行を削除
            message = System.Text.RegularExpressions.Regex.Replace(message, "[\r\n]+$", "");

            throw new WinBiometricException(hresult, message);
        }

        #endregion

        #region Event Handlers

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
                    sample = null;
                }
            }
        }

        #endregion

        #endregion

    }

    internal static class Converter
    {

        public static SafeNativeMethods.WINBIO_VERSION ConvertFrom(BiometricUnitVersion source)
        {
            var dst = new SafeNativeMethods.WINBIO_VERSION
            {
                MinorVersion = source.MinorVersion,
                MajorVersion = source.MajorVersion
            };
            return dst;
        }

        public static SafeNativeMethods.WINBIO_UNIT_SCHEMA ConvertFrom(BiometricUnit source)
        {
            var dst = new SafeNativeMethods.WINBIO_UNIT_SCHEMA
            {
                Description = source.Description,
                DeviceInstanceId = source.DeviceInstanceId,
                Manufacturer = source.Manufacturer,
                Model = source.Model,
                SerialNumber = source.SerialNumber,
                SensorSubType = (WINBIO_BIOMETRIC_SENSOR_SUBTYPE)source.SensorSubType,
                BiometricFactor = (WINBIO_BIOMETRIC_TYPE)source.BiometricFactor,
                Capabilities = (WINBIO_CAPABILITIES)source.Capabilities,
                PoolType = (WINBIO_POOL_TYPE)source.PoolType,
                UnitId = (WINBIO_UNIT_ID)source.UnitId,
                FirmwareVersion = ConvertFrom(source.FirmwareVersion)
            };
            return dst;
        }

    }

}
