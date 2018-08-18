using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultGetProperty"/> class contains the results of a call to <see cref="WinBiometric.GetProperty"/>.
    /// </summary>
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

        /// <summary>
        /// Gets the data that contains identity.
        /// </summary>
        public BiometricIdentity Identity
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies sub-factor.
        /// </summary>
        public FingerPosition FingerPosition
        {
            get;
        }

        /// <summary>
        /// Get a buffer that contains property value.
        /// </summary>
        public byte[] PropertyBuffer
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies the property that was queried.
        /// </summary>
        public PropertyId PropertyId
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies source of the property information.
        /// </summary>
        public PropertyType PropertyType
        {
            get;
        }

        #endregion

    }

}