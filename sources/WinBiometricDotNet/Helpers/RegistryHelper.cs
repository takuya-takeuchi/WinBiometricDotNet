using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet.Helpers
{

    internal static class RegistryHelper
    {


        #region Events
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Properties
        #endregion

        #region Methods

        #region Overrids
        #endregion

        #region Event Handlers
        #endregion

        #region Helpers

        #endregion

        #endregion

    }

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
