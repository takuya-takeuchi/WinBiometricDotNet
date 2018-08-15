using System;
using WinBiometricDotNet.Interop;

using HRESULT = System.Int32;
using WINBIO_SESSION_HANDLE = System.UInt32;

namespace WinBiometricDotNet
{

    public sealed class AsyncResult
    {

        #region Constructors

        internal unsafe AsyncResult(SafeNativeMethods.WINBIO_ASYNC_RESULT* result)
        {
            this.ApiStatus = result->ApiStatus;
            this.OperationType = (OperationTypes)result->Operation;
            this.SequenceNumber = result->SequenceNumber;

            switch (this.OperationType)
            {
                case OperationTypes.Open:
                case OperationTypes.Close:
                case OperationTypes.Verify:
                case OperationTypes.Identify:
                case OperationTypes.LocateSensor:
                case OperationTypes.EnrollBegin:
                case OperationTypes.EnrollCapture:
                case OperationTypes.EnrollCommit:
                case OperationTypes.EnrollDiscard:
                case OperationTypes.EnumEnrollments:
                case OperationTypes.DeleteTemplate:
                case OperationTypes.CaptureSample:
                case OperationTypes.GetProperty:
                case OperationTypes.SetProperty:
                case OperationTypes.GetEvent:
                case OperationTypes.LockUnit:
                case OperationTypes.UnlockUnit:
                case OperationTypes.ControlUnit:
                case OperationTypes.ControlUnitPrivileged:
                    this.Session = new Session(result->SessionHandle);
                    break;
                case OperationTypes.OpenFramework:
                case OperationTypes.CloseFramework:
                case OperationTypes.EnumServiceProviders:
                case OperationTypes.EnumBiometricUnits:
                case OperationTypes.EnumDatabases:
                case OperationTypes.UnitArrival:
                case OperationTypes.UnitRemoval:
                    this.Framework = new Framework(result->SessionHandle);
                    break;
            }

            this.UnitId = result->UnitId;
            this.UserData = result->UserData;
            this.TimeStamp = DateTime.FromFileTime(result->TimeStamp);
        }

        #endregion

        #region Properties

        public HRESULT ApiStatus
        {
            get;
        }

        public Framework Framework
        {
            get;
        }

        public OperationTypes OperationType
        {
            get;
        }

        public ulong SequenceNumber
        {
            get;
        }

        public WINBIO_SESSION_HANDLE SessionHandle
        {
            get;
        }

        public Session Session
        {
            get;
        }

        public DateTime TimeStamp
        {
            get;
        }

        public uint UnitId
        {
            get;
        }

        public IntPtr UserData
        {
            get;
        }

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

}