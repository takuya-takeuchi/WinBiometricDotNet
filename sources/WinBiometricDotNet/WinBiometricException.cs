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

        public WinBiometricException(int hresult, string message) :
            base(message)
        {
            var lpMsgBuf = IntPtr.Zero;
            var dwFlag = SafeNativeMethods.FORMAT_MESSAGE_ALLOCATE_BUFFER | SafeNativeMethods.FORMAT_MESSAGE_FROM_SYSTEM | SafeNativeMethods.FORMAT_MESSAGE_IGNORE_INSERTS;
            var dwChars = SafeNativeMethods.FormatMessage(dwFlag,
                                                          IntPtr.Zero,
                                                          (uint)hresult,
                                                          0,
                                                          ref lpMsgBuf,
                                                          0,
                                                          null);
            if (dwChars != 0)
            {
                var sRet = Marshal.PtrToStringAnsi(lpMsgBuf);
                SafeNativeMethods.LocalFree(lpMsgBuf);
            }

            this.HResult = hresult;
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        #region Overrids
        #endregion

        #region Event Handlers
        #endregion

        #region Helpers
        #endregion

        #endregion

    }

}