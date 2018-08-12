using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class BiometricServiceProvider
    {

        #region Constructors

        internal BiometricServiceProvider(SafeNativeMethods.WINBIO_BSP_SCHEMA schema)
        {
            this.BiometricFactor = (BiometricTypes)schema.BiometricFactor;
            this.Id = schema.BspId;
            this.Description = schema.Description;
            this.Vendor = schema.Vendor;
            this.Version = new BiometricUnitVersion(schema.Version);
        }

        #endregion

        #region Properties

        public BiometricTypes BiometricFactor
        {
            get;
        }

        public string Description
        {
            get;
        }

        public Guid Id
        {
            get;
        }

        public string Vendor
        {
            get;
        }

        public BiometricUnitVersion Version
        {
            get;
        }

        #endregion

    }

}