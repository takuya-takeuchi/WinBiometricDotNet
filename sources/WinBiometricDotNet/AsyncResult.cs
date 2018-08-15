using System;
using WinBiometricDotNet.Interop;
using HRESULT = System.Int32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResult"/> class contains the results of an asynchronous operation.
    /// </summary>
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

        /// <summary>
        /// Gets the error code returned by the operation.
        /// </summary>
        public HRESULT ApiStatus
        {
            get;
        }

        /// <summary>
        /// Gets the handle of an asynchronous session started by calling the <see cref="WinBiometric.AsyncOpenFramework"/> function.
        /// </summary>
        public Framework Framework
        {
            get;
        }

        /// <summary>
        /// Gets type of the asynchronous operation.
        /// </summary>
        public OperationTypes OperationType
        {
            get;
        }

        /// <summary>
        /// Gets the sequence number of the asynchronous operation.
        /// </summary>
        public ulong SequenceNumber
        {
            get;
        }

        /// <summary>
        /// Gets the handle of an asynchronous session started by calling the <see cref="WinBiometric.AsyncOpenSession"/> function.
        /// </summary>
        public Session Session
        {
            get;
        }

        /// <summary>
        /// Gets the system date and time at which the biometric operation began.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
        }

        /// <summary>
        /// Gets the numeric unit identifier of the biometric unit that performed the operation.
        /// </summary>
        public uint UnitId
        {
            get;
        }

        /// <summary>
        /// Gets the address of an optional buffer supplied by the caller.
        /// </summary>
        public IntPtr UserData
        {
            get;
        }

        #endregion

    }

}