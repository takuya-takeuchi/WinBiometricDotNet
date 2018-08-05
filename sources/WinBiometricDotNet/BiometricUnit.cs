using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

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
            this.UnitId = (int) schema.UnitId;
            this.FirmwareVersion = new BiometricUnitVersion(schema.FirmwareVersion);
        }

        #endregion

        #region Properties

        public BiometricTypes BiometricFactor
        {
            get;
            internal set;
        }

        public BiometricSensorSubType SensorSubType
        {
            get;
            internal set;
        }

        public int UnitId
        {
            get;
            internal set;
        }

        public string DeviceInstanceId
        {
            get;
            internal set;
        }

        public string Description
        {
            get;
            internal set;
        }

        public string Manufacturer
        {
            get;
            internal set;
        }

        public string Model
        {
            get;
            internal set;
        }

        public string SerialNumber
        {
            get;
            internal set;
        }

        public BiometricUnitVersion FirmwareVersion
        {
            get;
            internal set;
        }

        public BiometricCapabilities Capabilities
        {
            get;
            internal set;
        }

        public BiometricPoolType PoolType
        {
            get;
            internal set;
        }

        #endregion

    }

}