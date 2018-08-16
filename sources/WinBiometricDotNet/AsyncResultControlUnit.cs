using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultControlUnit : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultControlUnit(SafeNativeMethods.WINBIO_ASYNC_RESULT_CONTROLUNIT* controlUnit)
        {
            this.Component = (Component)controlUnit->Component;
            this.ControlCode = controlUnit->ControlCode;
            this.OperationStatus = (OperationStatus)controlUnit->OperationStatus;
            this.ReceiveDataSize = (int)controlUnit->ReceiveDataSize;

            if (controlUnit->SendBuffer != IntPtr.Zero)
            {
                this.SendBuffer = new byte[(int)controlUnit->SendBufferSize];
                Marshal.Copy(controlUnit->SendBuffer, this.SendBuffer, 0, this.SendBuffer.Length);
            }

            if (controlUnit->ReceiveBuffer != IntPtr.Zero)
            {
                this.ReceiveBuffer = new byte[(int)controlUnit->ReceiveBufferSize];
                Marshal.Copy(controlUnit->ReceiveBuffer, this.ReceiveBuffer, 0, this.ReceiveBuffer.Length);
            }
        }

        #endregion

        #region Properties

        public Component Component
        {
            get;
        }

        public uint ControlCode
        {
            get;
        }

        public OperationStatus OperationStatus
        {
            get;
        }

        public byte[] ReceiveBuffer
        {
            get;
        }

        public int ReceiveDataSize
        {
            get;
        }

        public byte[] SendBuffer
        {
            get;
        }

        #endregion

    }

}