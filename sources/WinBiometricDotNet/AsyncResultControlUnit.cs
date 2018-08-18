using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;
using ULONG = System.UInt32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultControlUnit"/> class contains the results of a call to <see cref="WinBiometric.ControlUnit"/> or <see cref="WinBiometric.ControlUnitPrivileged"/>.
    /// </summary>
    public sealed class AsyncResultControlUnit : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultControlUnit(SafeNativeMethods.WINBIO_ASYNC_RESULT_CONTROLUNIT* controlUnit)
        {
            this.Component = (Component)controlUnit->Component;
            this.ControlCode = controlUnit->ControlCode;
            this.OperationStatus = controlUnit->OperationStatus;
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

        /// <summary>
        /// Gets a value that specifies the component within the biometric unit that performed the operation.
        /// </summary>
        public Component Component
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies the vendor-defined code recognized by the biometric unit.
        /// </summary>
        public uint ControlCode
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies the vendor-defined status code that specifies the outcome of the control operation.
        /// </summary>
        public ULONG OperationStatus
        {
            get;
        }

        /// <summary>
        /// Gets a buffer that receives information sent by the adapter specified by the <see cref="Component"/> property.
        /// </summary>
        public byte[] ReceiveBuffer
        {
            get;
        }

        /// <summary>
        /// Gets a size, in bytes, of the data written to the buffer specified by the <see cref="ReceiveBuffer"/> property.
        /// </summary>
        public int ReceiveDataSize
        {
            get;
        }

        /// <summary>
        /// Gets a buffer that contains the control information sent to the adapter by the component.
        /// </summary>
        public byte[] SendBuffer
        {
            get;
        }

        #endregion

    }

}