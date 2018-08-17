using WinBiometricDotNet.Interop;
using WINBIO_SETTING_SOURCE_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="SettingSourceType"/> enumeration determine the Windows Biometric Framework is currently enabled.
    /// </summary>
    public enum SettingSourceType : WINBIO_SETTING_SOURCE_TYPE
    {

        /// <summary>
        /// The setting is not valid.
        /// </summary>
        Invalid = SafeNativeMethods.WINBIO_SETTING_SOURCE_INVALID,

        /// <summary>
        /// The setting originated from built-in policy.
        /// </summary>
        Default = SafeNativeMethods.WINBIO_SETTING_SOURCE_DEFAULT,

        /// <summary>
        /// The setting was created by Group Policy.
        /// </summary>
        Policy = SafeNativeMethods.WINBIO_SETTING_SOURCE_POLICY,

        /// <summary>
        /// The setting originated in the local computer registry.
        /// </summary>
        Local = SafeNativeMethods.WINBIO_SETTING_SOURCE_LOCAL

    }

}