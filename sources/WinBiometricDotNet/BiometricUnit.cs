using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="BiometricUnit"/> class describes the capabilities of a biometric unit.
    /// </summary>
    public sealed class BiometricUnit
    {

        #region Constructors

        internal BiometricUnit(SafeNativeMethods.WINBIO_UNIT_SCHEMA schema)
        {
            this.Description = schema.Description;
            this.DeviceInstanceId = schema.DeviceInstanceId;
            this.Manufacturer = schema.Manufacturer;
            this.Model = schema.Model;
            this.SerialNumber = schema.SerialNumber;
            this.SensorSubType = (BiometricSensorSubType) schema.SensorSubType;
            this.BiometricFactor = (BiometricTypes) schema.BiometricFactor;
            this.Capabilities = (BiometricCapabilities) schema.Capabilities;
            this.PoolType = (BiometricPoolType) schema.PoolType;
            this.UnitId = schema.UnitId;
            this.FirmwareVersion = new BiometricUnitVersion(schema.FirmwareVersion);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the type of the biometric unit.
        /// </summary>
        public BiometricTypes BiometricFactor
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the onboard sensor capabilities.
        /// </summary>
        public BiometricSensorSubType SensorSubType
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets a value that identifies the biometric unit. 
        /// </summary>
        public uint UnitId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the device ID.
        /// </summary>
        public string DeviceInstanceId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets a description of the biometric unit.
        /// </summary>
        public string Description
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the name of the manufacturer.
        /// </summary>
        public string Manufacturer
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the model number of the biometric unit.
        /// </summary>
        public string Model
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the serial number of the biometric unit. 
        /// </summary>
        public string SerialNumber
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the major and minor version numbers for the biometric unit.
        /// </summary>
        public BiometricUnitVersion FirmwareVersion
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the capabilities of biometric sensor.
        /// </summary>
        public BiometricCapabilities Capabilities
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the type of biometric unit pool.
        /// </summary>
        public BiometricPoolType PoolType
        {
            get;
            internal set;
        }

        #endregion

    }

}