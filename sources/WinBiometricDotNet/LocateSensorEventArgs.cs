using System;

namespace WinBiometricDotNet
{

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

        public OperationStatus OperationStatus
        {
            get;
        }

        public uint UnitId
        {
            get;
            internal set;
        }

        #endregion

    }

}