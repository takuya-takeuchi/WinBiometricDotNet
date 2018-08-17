using System;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="BiometricServiceProvider"/> class describes the capabilities of a biometric service provider.
    /// </summary>
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

        /// <summary>
        /// Gets the type of biometric measurement used by this device.
        /// </summary>
        public BiometricTypes BiometricFactor
        {
            get;
        }

        /// <summary>
        /// Gets a description of the biometric service provider.
        /// </summary>
        public string Description
        {
            get;
        }

        /// <summary>
        /// Gets a value that uniquely identifies this biometric service provider component.
        /// </summary>
        public Guid Id
        {
            get;
        }

        /// <summary>
        /// Gets the name of the vendor supplying the biometric service provider.
        /// </summary>
        public string Vendor
        {
            get;
        }

        /// <summary>
        /// Gets the software version of the biometric service provider component.
        /// </summary>
        public BiometricUnitVersion Version
        {
            get;
        }

        #endregion

    }

}