using WinBiometricDotNet.Interop;
using WINBIO_IDENTITY_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="IdentityType"/> enumeration specifies the format of the identity information contained in the <see cref="BiometricIdentity"/> class.
    /// </summary>
    public enum IdentityType : WINBIO_IDENTITY_TYPE
    {

        /// <summary>
        /// The template has no associated ID. 
        /// </summary>
        Null = SafeNativeMethods.WINBIO_ID_TYPE_NULL,

        /// <summary>
        /// The class matches all template identities.
        /// </summary>
        WildCard = SafeNativeMethods.WINBIO_ID_TYPE_WILDCARD,

        /// <summary>
        /// A GUID identifies the template.
        /// </summary>
        Guid = SafeNativeMethods.WINBIO_ID_TYPE_GUID,

        /// <summary>
        /// An account SID identifies the template.
        /// </summary>
        Sid = SafeNativeMethods.WINBIO_ID_TYPE_SID

    }

}