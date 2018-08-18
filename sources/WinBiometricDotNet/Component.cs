using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="Component"/> enumeration specifies the type of adapter being used.
    /// </summary>
    public enum Component : uint
    {

        /// <summary>
        /// Specifies a sensor adapter.
        /// </summary>
        Sensor = SafeNativeMethods.WINBIO_COMPONENT_SENSOR,

        /// <summary>
        /// Specifies an engine adapter.
        /// </summary>
        Engine = SafeNativeMethods.WINBIO_COMPONENT_ENGINE,

        /// <summary>
        /// Specifies a storage adapter.
        /// </summary>
        Storage = SafeNativeMethods.WINBIO_COMPONENT_STORAGE,

    }

}