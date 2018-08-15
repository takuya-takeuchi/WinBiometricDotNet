using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum Component : uint
    {

        Sensor = SafeNativeMethods.WINBIO_COMPONENT_SENSOR,

        Engine = SafeNativeMethods.WINBIO_COMPONENT_ENGINE,

        Storage = SafeNativeMethods.WINBIO_COMPONENT_STORAGE,

    }

}