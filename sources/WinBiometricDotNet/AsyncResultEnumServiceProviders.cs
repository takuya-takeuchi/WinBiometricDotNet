using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultEnumServiceProviders"/> class contains the results of a call to <see cref="WinBiometric.AsyncEnumServiceProviders"/>.
    /// </summary>
    public sealed class AsyncResultEnumServiceProviders : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnumServiceProviders(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENUMSERVICEPROVIDERS* enumServiceProviders)
        {
            var count = (int)enumServiceProviders->BspCount;
            this.ServiceProviders = new BiometricServiceProvider[count];

            var size = Marshal.SizeOf<SafeNativeMethods.WINBIO_BSP_SCHEMA>();
            var p = (byte*)enumServiceProviders->BspSchemaArray;
            for (var index = 0; index < count; index++)
            {
                var tmp = p + size * index;
                var schema = Marshal.PtrToStructure<SafeNativeMethods.WINBIO_BSP_SCHEMA>((IntPtr)tmp);
                this.ServiceProviders[index] = new BiometricServiceProvider(schema);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the array of <see cref="BiometricServiceProvider"/>.
        /// </summary>
        public BiometricServiceProvider[] ServiceProviders
        {
            get;
        }

        #endregion

    }

}