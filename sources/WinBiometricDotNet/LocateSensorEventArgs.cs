using System;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Provides data for the <see cref="WinBiometric.SensorLocated"/> event handler.
    /// </summary>
    public sealed class LocateSensorEventArgs : EventArgs
    {

        #region Constructors

        internal LocateSensorEventArgs(uint unitId, OperationStatus operationStatus)
        {
            this.UnitId = unitId;
            this.OperationStatus = operationStatus;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the error code returned by the capture operation.
        /// </summary>
        public OperationStatus OperationStatus
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies the biometric unit.
        /// </summary>
        public uint UnitId
        {
            get;
            internal set;
        }

        #endregion

    }

}