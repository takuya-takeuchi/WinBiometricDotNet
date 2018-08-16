using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultGetProperty : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultGetProperty(SafeNativeMethods.WINBIO_ASYNC_RESULT_GETPROPERTY* getProperty)
        {
            this.Identity = new BiometricIdentity(&getProperty->Identity);
            this.FingerPosition = (FingerPosition)getProperty->SubFactor;
            this.PropertyType = (PropertyType)getProperty->PropertyType;
            this.PropertyId = (PropertyId)getProperty->PropertyId;

            if (getProperty->PropertyBuffer != IntPtr.Zero)
            {
                this.PropertyBuffer = new byte[(int)getProperty->PropertyBufferSize];
                Marshal.Copy(getProperty->PropertyBuffer, this.PropertyBuffer, 0, this.PropertyBuffer.Length);
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

        public PropertyType PropertyType
        {
            get;
        }

        #endregion

    }

}