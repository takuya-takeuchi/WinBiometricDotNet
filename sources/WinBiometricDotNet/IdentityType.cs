using WinBiometricDotNet.Interop;
using WINBIO_IDENTITY_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    public enum IdentityType : WINBIO_IDENTITY_TYPE
    {

        Null = SafeNativeMethods.WINBIO_ID_TYPE_NULL,

        WildCard = SafeNativeMethods.WINBIO_ID_TYPE_WILDCARD,

        Guid = SafeNativeMethods.WINBIO_ID_TYPE_GUID,

        Sid = SafeNativeMethods.WINBIO_ID_TYPE_SID

    }

}