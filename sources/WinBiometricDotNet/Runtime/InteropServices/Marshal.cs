using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet.Runtime.InteropServices
{

    /// <summary>
    /// Provides a collection of methods for converting managed to unmanaged types, as well as other miscellaneous methods used when interacting with unmanaged code.
    /// </summary>
    public static class Marshal
    {

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

    }

}
