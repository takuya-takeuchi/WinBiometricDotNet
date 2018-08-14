using System;
using WinBiometricDotNet.Interop;

using HRESULT = System.Int32;

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
                    this.Session = new Session(result->SessionHandle);
                    this.Framework = new Framework(result->SessionHandle);
                    break;
                case OperationTypes.OpenFramework:
                    // Even though call AsyncOpenFramework, WINBIO_OPERATION_OPEN_FRAMEWORK is not set to WINBIO_ASYNC_RESULT::Operation.
                    // Why?
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

        public UIntPtr SessionHandle
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