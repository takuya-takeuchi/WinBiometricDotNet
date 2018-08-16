using WinBiometricDotNet.Interop;
using WINBIO_PROPERTY_TYPE = System.UInt32;

namespace WinBiometricDotNet
{

    public enum PropertyType : WINBIO_PROPERTY_TYPE
    {

        Session = SafeNativeMethods.WINBIO_PROPERTY_TYPE_SESSION,

        Unit = SafeNativeMethods.WINBIO_PROPERTY_TYPE_UNIT,

        Template = SafeNativeMethods.WINBIO_PROPERTY_TYPE_TEMPLATE,

        Account = SafeNativeMethods.WINBIO_PROPERTY_TYPE_ACCOUNT,

    }

}