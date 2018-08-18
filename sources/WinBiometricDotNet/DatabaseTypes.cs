using System;
using WinBiometricDotNet.Interop;
using ULONG = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="DatabaseTypes"/> enumeration specifies the type of database.
    /// </summary>
    [Flags]
    public enum DatabaseTypes: ULONG
    {

        /// <summary>
        /// The database is contained in a file.
        /// </summary>
        File = SafeNativeMethods.WINBIO_DATABASE_TYPE_FILE,

        /// <summary>
        /// The database is managed by an external database management system (DBMS) component, such as Microsoft SQL Server.
        /// </summary>
        DatabaseManagementSystem = SafeNativeMethods.WINBIO_DATABASE_TYPE_DBMS,

        /// <summary>
        /// The database resides on the biometric sensor.
        /// </summary>
        OnChip = SafeNativeMethods.WINBIO_DATABASE_TYPE_ONCHIP,

        /// <summary>
        /// The database resides on a smart card.
        /// </summary>
        SmartCard = SafeNativeMethods.WINBIO_DATABASE_TYPE_SMARTCARD

    }

}