using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="ChangeTypes"/> enumeration identify the type of change that occurred in the framework.
    /// </summary>
    [Flags]
    public enum ChangeTypes : uint
    {

        /// <summary>
        /// A biometric unit was attached to or detached from the computer.
        /// </summary>
        Unit = SafeNativeMethods.WINBIO_FRAMEWORK_CHANGE_UNIT,

    }

}