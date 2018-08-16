using System;
using WinBiometricDotNet.Interop;
using ULONG = System.UInt32;

namespace WinBiometricDotNet
{

    [Flags]
    public enum DatabaseFlags : ULONG
    {

        Removable = SafeNativeMethods.WINBIO_DATABASE_FLAG_REMOVABLE,

        Remote = SafeNativeMethods.WINBIO_DATABASE_FLAG_REMOTE

    }

}