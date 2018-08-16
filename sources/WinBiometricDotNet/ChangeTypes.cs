using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    [Flags]
    public enum ChangeTypes : uint
    {

        Unit = SafeNativeMethods.WINBIO_FRAMEWORK_CHANGE_UNIT,

    }

}