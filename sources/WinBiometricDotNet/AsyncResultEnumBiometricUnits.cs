using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultEnumBiometricUnits : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnumBiometricUnits(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENUMBIOMETRICUNITS* enumBiometricUnits)
        {
            var count = (int)enumBiometricUnits->UnitCount;
            this.BiometricUnits = new BiometricUnit[count];

            var size = Marshal.SizeOf<SafeNativeMethods.WINBIO_UNIT_SCHEMA>();
            var p = (byte*)enumBiometricUnits->UnitSchemaArray;
            for (var index = 0; index < count; index++)
            {
                var tmp = p + size * index;
                var schema = Marshal.PtrToStructure<SafeNativeMethods.WINBIO_UNIT_SCHEMA>((IntPtr)tmp);
                this.BiometricUnits[index] = new BiometricUnit(schema);
            }
        }

        #endregion

        #region Properties

        public BiometricUnit[] BiometricUnits
        {
            get;
        }

        #endregion

    }

}