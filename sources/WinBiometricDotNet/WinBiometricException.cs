using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class WinBiometricException : Exception
    {

        #region Events
        #endregion

        #region Fields
        #endregion

        #region Constructors

        public WinBiometricException(string message)
            : base(message)
        {
        }

        public WinBiometricException(int hresult) :
            base(ToMessage(hresult))
        {
            this.HResult = hresult;
        }

        #endregion

        #region Properties
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