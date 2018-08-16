using System;
using System.Text;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="BiometricDatabase"/> class describes the capabilities of a biometric storage adapter.
    /// </summary>
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

        /// <summary>
        /// Gets the type of biometric measurement saved in the database.
        /// </summary>
        public BiometricTypes BiometricFactor
        {
            get;
        }

        /// <summary>
        /// Gets a string value that can be sent to a database server to identify the database.
        /// </summary>
        public string ConnectionString
        {
            get;
        }

        /// <summary>
        /// Gets a flag about the characteristics of the database.
        /// </summary>
        public DatabaseFlags DatabaseFlag
        {
            get;
        }

        /// <summary>
        /// Gets a GUID that identifies the database.
        /// </summary>
        public Guid DatabaseId
        {
            get;
        }

        /// <summary>
        /// Gets a type about the characteristics of the database.
        /// </summary>
        public DatabaseTypes DatabaseTypes
        {
            get;
        }

        /// <summary>
        /// Gets a GUID that identifies the format of the templates in the database.
        /// </summary>
        public Guid DataFormat
        {
            get;
        }

        /// <summary>
        /// Gets the path and file name of the database if it resides on the computer disk.
        /// </summary>
        public string FilePath
        {
            get;
        }

        #endregion

    }

}