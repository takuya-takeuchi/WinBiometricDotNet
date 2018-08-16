using System;
using WinBiometricDotNet.Interop;
using ULONG = System.UInt32;

namespace WinBiometricDotNet
{

    [Flags]
    public enum DatabaseTypes: ULONG
    {

        File = SafeNativeMethods.WINBIO_DATABASE_TYPE_FILE,

        DatabaseManagementSystem = SafeNativeMethods.WINBIO_DATABASE_TYPE_DBMS,

        OnChip = SafeNativeMethods.WINBIO_DATABASE_TYPE_ONCHIP,

        SmartCard = SafeNativeMethods.WINBIO_DATABASE_TYPE_SMARTCARD

    }

}