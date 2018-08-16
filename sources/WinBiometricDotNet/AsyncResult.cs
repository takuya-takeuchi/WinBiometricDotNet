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
                    this.Session = new Session(result->SessionHandle, true);
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

            switch (this.OperationType)
            {
                case OperationTypes.Verify:
                    this.Parameter = new AsyncResultVerify(&result->Parameter.Verify);
                    break;
                case OperationTypes.Identify:
                    this.Parameter = new AsyncResultIdentity(&result->Parameter.Identify);
                    break;
                case OperationTypes.EnrollBegin:
                    this.Parameter = new AsyncResultEnrollBegin(&result->Parameter.EnrollBegin);
                    break;
                case OperationTypes.EnrollCapture:
                    this.Parameter = new AsyncResultEnrollCapture(&result->Parameter.EnrollCapture);
                    break;
                case OperationTypes.EnrollCommit:
                    this.Parameter = new AsyncResultEnrollCommit(&result->Parameter.EnrollCommit);
                    break;
                case OperationTypes.EnumEnrollments:
                    this.Parameter = new AsyncResultEnumEnrollments(&result->Parameter.EnumEnrollments);
                    break;
                case OperationTypes.DeleteTemplate:
                    this.Parameter = new AsyncResultDeleteTemplate(&result->Parameter.DeleteTemplate);
                    break;
                case OperationTypes.CaptureSample:
                    this.Parameter = new AsyncResultCaptureSample(&result->Parameter.CaptureSample);
                    break;
                case OperationTypes.GetProperty:
                    this.Parameter = new AsyncResultGetProperty(&result->Parameter.GetProperty);
                    break;
                case OperationTypes.SetProperty:
                    this.Parameter = new AsyncResultSetProperty(&result->Parameter.SetProperty);
                    break;
                case OperationTypes.GetEvent:
                    this.Parameter = new AsyncResultGetEvent(&result->Parameter.GetEvent);
                    break;
                case OperationTypes.ControlUnit:
                case OperationTypes.ControlUnitPrivileged:
                    this.Parameter = new AsyncResultControlUnit(&result->Parameter.ControlUnit);
                    break;
                case OperationTypes.EnumServiceProviders:
                    this.Parameter = new AsyncResultEnumServiceProviders(&result->Parameter.EnumServiceProviders);
                    break;
                case OperationTypes.EnumBiometricUnits:
                    this.Parameter = new AsyncResultEnumBiometricUnits(&result->Parameter.EnumBiometricUnits);
                    break;
                case OperationTypes.EnumDatabases:
                    this.Parameter = new AsyncResultEnumDatabases(&result->Parameter.EnumDatabases);
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
        /// Gets the data that contain additional information about the success or failure of asynchronous operations begun by the client application.
        /// </summary>
        public AsyncResultParameter Parameter
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