using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultEnumDatabases"/> class contains the results of a call to <see cref="WinBiometric.AsyncEnumDatabases"/>.
    /// </summary>
    public sealed class AsyncResultEnumDatabases : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnumDatabases(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENUMDATABASES* enumDatabases)
        {
            var count = (int)enumDatabases->StorageCount;
            this.Databases = new BiometricDatabase[count];

            var size = Marshal.SizeOf<SafeNativeMethods.WINBIO_STORAGE_SCHEMA>();
            var p = (byte*)enumDatabases->StorageSchemaArray;
            for (var index = 0; index < count; index++)
            {
                var tmp = p + size * index;
                var schema = Marshal.PtrToStructure<SafeNativeMethods.WINBIO_STORAGE_SCHEMA>((IntPtr)tmp);
                this.Databases[index] = new BiometricDatabase(schema);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the array of <see cref="BiometricDatabase"/>.
        /// </summary>
        public BiometricDatabase[] Databases
        {
            get;
        }

        #endregion

    }

}