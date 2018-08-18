using System;
using System.IO;
using System.Text;
using WinBiometricDotNet.Interop;
using HRESULT = System.Int32;

namespace WinBiometricDotNet.Runtime.InteropServices
{

    /// <summary>
    /// Provides a collection of methods for converting managed to unmanaged types, as well as other miscellaneous methods used when interacting with unmanaged code.
    /// </summary>
    public static class Marshal
    {

        #region Methods

        /// <summary>
        /// Converts the specified HRESULT error code to a corresponding <see cref="WinBiometricException"/> object.
        /// </summary>
        /// <param name="errorCode">The HRESULT to be converted.</param>
        /// <returns>An object that represents the converted HRESULT.</returns>
        public static WinBiometricException GetWinBiometricExceptionFromHR(HRESULT errorCode)
        {
            switch (errorCode)
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
                    var message = ConvertErrorCodeToString(errorCode);
                    return new WinBiometricException(message);
                default:
                    return new WinBiometricException(errorCode);
            }
        }

        /// <summary>
        /// Marshals data from an LPARAM value of windows message to a <see cref="AsyncResult"/> object.
        /// </summary>
        /// <param name="ptr">A LPARAM value of windows message.</param>
        /// <returns><see cref="AsyncResult"/>.</returns>
        /// <remarks><paramref name="ptr"/> will be released when this method returns.</remarks>
        public static AsyncResult PtrToAsyncResult(IntPtr ptr)
        {
            unsafe
            {
                try
                {
                    var ret = System.Runtime.InteropServices.Marshal.PtrToStructure<SafeNativeMethods.WINBIO_ASYNC_RESULT>(ptr);
                    return new AsyncResult(&ret);
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                        SafeNativeMethods.WinBioFree(ptr);
                }
            }
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

            // Remove tail new line and line feed
            if (message != null)
                message = System.Text.RegularExpressions.Regex.Replace(message, "[\r\n]+$", "");

            // Caller must release buffer with LocalFree()
            return message;
        }

        #endregion

        #endregion

    }

}
