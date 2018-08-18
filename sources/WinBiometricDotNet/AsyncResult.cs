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
            this.OperationType = (OperationType)result->Operation;
            this.SequenceNumber = result->SequenceNumber;

            switch (this.OperationType)
            {
                case OperationType.Open:
                case OperationType.Close:
                case OperationType.Verify:
                case OperationType.Identify:
                case OperationType.LocateSensor:
                case OperationType.EnrollBegin:
                case OperationType.EnrollCapture:
                case OperationType.EnrollCommit:
                case OperationType.EnrollDiscard:
                case OperationType.EnumEnrollments:
                case OperationType.DeleteTemplate:
                case OperationType.CaptureSample:
                case OperationType.GetProperty:
                case OperationType.SetProperty:
                case OperationType.GetEvent:
                case OperationType.LockUnit:
                case OperationType.UnlockUnit:
                case OperationType.ControlUnit:
                case OperationType.ControlUnitPrivileged:
                    this.Session = new Session(result->SessionHandle, true);
                    break;
                case OperationType.OpenFramework:
                case OperationType.CloseFramework:
                case OperationType.EnumServiceProviders:
                case OperationType.EnumBiometricUnits:
                case OperationType.EnumDatabases:
                case OperationType.UnitArrival:
                case OperationType.UnitRemoval:
                    this.Framework = new Framework(result->SessionHandle);
                    break;
            }

            switch (this.OperationType)
            {
                case OperationType.Verify:
                    this.Parameter = new AsyncResultVerify(&result->Parameter.Verify);
                    break;
                case OperationType.Identify:
                    this.Parameter = new AsyncResultIdentify(&result->Parameter.Identify);
                    break;
                case OperationType.EnrollBegin:
                    this.Parameter = new AsyncResultEnrollBegin(&result->Parameter.EnrollBegin);
                    break;
                case OperationType.EnrollCapture:
                    this.Parameter = new AsyncResultEnrollCapture(&result->Parameter.EnrollCapture);
                    break;
                case OperationType.EnrollCommit:
                    this.Parameter = new AsyncResultEnrollCommit(&result->Parameter.EnrollCommit);
                    break;
                case OperationType.EnumEnrollments:
                    this.Parameter = new AsyncResultEnumEnrollments(&result->Parameter.EnumEnrollments);
                    break;
                case OperationType.DeleteTemplate:
                    this.Parameter = new AsyncResultDeleteTemplate(&result->Parameter.DeleteTemplate);
                    break;
                case OperationType.CaptureSample:
                    this.Parameter = new AsyncResultCaptureSample(&result->Parameter.CaptureSample);
                    break;
                case OperationType.GetProperty:
                    this.Parameter = new AsyncResultGetProperty(&result->Parameter.GetProperty);
                    break;
                case OperationType.SetProperty:
                    this.Parameter = new AsyncResultSetProperty(&result->Parameter.SetProperty);
                    break;
                case OperationType.GetEvent:
                    this.Parameter = new AsyncResultGetEvent(&result->Parameter.GetEvent);
                    break;
                case OperationType.ControlUnit:
                case OperationType.ControlUnitPrivileged:
                    this.Parameter = new AsyncResultControlUnit(&result->Parameter.ControlUnit);
                    break;
                case OperationType.EnumServiceProviders:
                    this.Parameter = new AsyncResultEnumServiceProviders(&result->Parameter.EnumServiceProviders);
                    break;
                case OperationType.EnumBiometricUnits:
                    this.Parameter = new AsyncResultEnumBiometricUnits(&result->Parameter.EnumBiometricUnits);
                    break;
                case OperationType.EnumDatabases:
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
        public OperationType OperationType
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