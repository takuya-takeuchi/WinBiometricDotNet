using System;
using System.Text;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class BiometricDatabase
    {

        #region Constructors

        internal BiometricDatabase(SafeNativeMethods.WINBIO_STORAGE_SCHEMA schema)
        {
            this.BiometricFactor = (BiometricTypes)schema.BiometricFactor;
            this.DatabaseId = schema.DatabaseId;
            this.DataFormat = schema.DataFormat;
            this.DatabaseFlag = (DatabaseFlags)(schema.Attributes & SafeNativeMethods.WINBIO_DATABASE_FLAG_MASK);
            this.DatabaseTypes = (DatabaseTypes)(schema.Attributes & SafeNativeMethods.WINBIO_DATABASE_TYPE_MASK);
            this.ConnectionString = Encoding.Unicode.GetString(schema.ConnectionString).TrimEnd('\0');
            this.FilePath = Encoding.Unicode.GetString(schema.FilePath).TrimEnd('\0');
        }

        #endregion

        #region Properties

        public BiometricTypes BiometricFactor
        {
            get;
        }

        public string ConnectionString
        {
            get;
        }

        public DatabaseFlags DatabaseFlag
        {
            get;
        }

        public Guid DatabaseId
        {
            get;
        }

        public DatabaseTypes DatabaseTypes
        {
            get;
        }

        public Guid DataFormat
        {
            get;
        }

        public string FilePath
        {
            get;
        }

        #endregion

    }

}