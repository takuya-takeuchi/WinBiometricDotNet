using WinBiometricDotNet.Interop;
using WINBIO_SETTING_SOURCE_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    public enum SettingSourceType : WINBIO_SETTING_SOURCE_TYPE
    {

        Invalid = SafeNativeMethods.WINBIO_SETTING_SOURCE_INVALID,

        Default = SafeNativeMethods.WINBIO_SETTING_SOURCE_DEFAULT,

        Policy = SafeNativeMethods.WINBIO_SETTING_SOURCE_POLICY,

        Local = SafeNativeMethods.WINBIO_SETTING_SOURCE_LOCAL

    }

}