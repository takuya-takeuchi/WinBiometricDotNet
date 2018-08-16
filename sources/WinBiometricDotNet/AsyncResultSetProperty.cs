using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultSetProperty : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultSetProperty(SafeNativeMethods.WINBIO_ASYNC_RESULT_SETPROPERTY* setProperty)
        {
            this.Identity = new BiometricIdentity(&setProperty->Identity);
            this.FingerPosition = (FingerPosition)setProperty->SubFactor;
            this.PropertyType = (PropertyTypes)setProperty->PropertyType;
            this.PropertyId = (PropertyId)setProperty->PropertyId;

            if (setProperty->PropertyBuffer != IntPtr.Zero)
            {
                this.PropertyBuffer = new byte[(int)setProperty->PropertyBufferSize];
                Marshal.Copy(setProperty->PropertyBuffer, this.PropertyBuffer, 0, this.PropertyBuffer.Length);
            }
        }

        #endregion

        #region Properties

        public BiometricIdentity Identity
        {
            get;
        }

        public FingerPosition FingerPosition
        {
            get;
        }

        public byte[] PropertyBuffer
        {
            get;
        }

        public PropertyId PropertyId
        {
            get;
        }

        public PropertyTypes PropertyType
        {
            get;
        }

        #endregion

    }

}