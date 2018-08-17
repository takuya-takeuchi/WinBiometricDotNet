using WinBiometricDotNet.Interop;
using WINBIO_PROPERTY_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="PropertyType"/> enumeration specifies the source of the property information.
    /// </summary>
    public enum PropertyType : WINBIO_PROPERTY_TYPE
    {

        /// <summary>
        /// The property applies to a specific biometric session.
        /// </summary>
        Session = SafeNativeMethods.WINBIO_PROPERTY_TYPE_SESSION,

        /// <summary>
        /// The property applies to a specific biometric template.
        /// </summary>
        Unit = SafeNativeMethods.WINBIO_PROPERTY_TYPE_UNIT,

        /// <summary>
        /// The property applies to a specific biometric unit.
        /// </summary>
        Template = SafeNativeMethods.WINBIO_PROPERTY_TYPE_TEMPLATE,

        /// <summary>
        /// The property applies to a specific user account that has a biometric enrollment.
        /// </summary>
        Account = SafeNativeMethods.WINBIO_PROPERTY_TYPE_ACCOUNT

    }

}