using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet.Helpers
{

    [StructLayout(LayoutKind.Sequential)]
    public struct PoolConfiguration
    {

        public UInt32 ConfigurationFlags;

        public UInt32 DatabaseAttributes;

        public Guid DatabaseId;

        public Guid DataFormat;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SafeNativeMethods.MAX_PATH)]
        public string SensorAdapter;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SafeNativeMethods.MAX_PATH)]
        public string EngineAdapter;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SafeNativeMethods.MAX_PATH)]
        public string StorageAdapter;

    }

}
