using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet.Runtime.InteropServices
{

    public static class Marshal
    {

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

    }

}
