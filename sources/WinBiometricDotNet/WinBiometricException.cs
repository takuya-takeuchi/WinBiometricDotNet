using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The exception is general exception for Windows Biometric Framework. This class cannot be inherited.
    /// </summary>
    public sealed class WinBiometricException : Exception
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WinBiometricException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public WinBiometricException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WinBiometricException"/> class with a specified HRESULT, a coded numerical value that is assigned to a specific exception.
        /// </summary>
        /// <param name="hresult">HRESULT, a coded numerical value that is assigned to a specific exception.</param>
        public WinBiometricException(int hresult) :
            base(ToMessage(hresult))
        {
            this.HResult = hresult;
        }

        #endregion

        #region Methods

        #region Helpers

        private static string ToMessage(int hresult)
        {
            var dwFlag = SafeNativeMethods.FORMAT_MESSAGE_ALLOCATE_BUFFER | SafeNativeMethods.FORMAT_MESSAGE_FROM_SYSTEM | SafeNativeMethods.FORMAT_MESSAGE_IGNORE_INSERTS;
            var dwChars = SafeNativeMethods.FormatMessage(dwFlag,
                                                          IntPtr.Zero,
                                                          (uint)hresult,
                                                          0,
                                                          out var lpMsgBuf,
                                                          0,
                                                          null);

            var message = "";
            if (dwChars != 0)
            {
                message = Marshal.PtrToStringAnsi(lpMsgBuf);
                SafeNativeMethods.LocalFree(lpMsgBuf);
            }

            // Remove tail new line and line feed
            message = System.Text.RegularExpressions.Regex.Replace(message, "[\r\n]+$", "");

            return message;
        }

        #endregion

        #endregion

    }

}