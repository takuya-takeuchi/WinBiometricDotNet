using System;
using WinBiometricDotNet.Interop;
using ULONG = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="DatabaseFlags"/> enumeration specifies the characteristics of database.
    /// </summary>
    [Flags]
    public enum DatabaseFlags : ULONG
    {

        /// <summary>
        /// The storage medium containing the database can be physically removed from the computer.
        /// </summary>
        Removable = SafeNativeMethods.WINBIO_DATABASE_FLAG_REMOVABLE,

        /// <summary>
        /// The database resides on a remote computer.
        /// </summary>
        Remote = SafeNativeMethods.WINBIO_DATABASE_FLAG_REMOTE

    }

}