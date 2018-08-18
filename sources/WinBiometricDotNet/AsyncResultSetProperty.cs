using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultSetProperty"/> class contains the results of a call to <see cref="WinBiometric.SetAntiSpoofPolicyProperty"/>.
    /// </summary>
    public sealed class AsyncResultSetProperty : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultSetProperty(SafeNativeMethods.WINBIO_ASYNC_RESULT_SETPROPERTY* setProperty)
        {
            this.Identity = new BiometricIdentity(&setProperty->Identity);
            this.FingerPosition = (FingerPosition)setProperty->SubFactor;
            this.PropertyType = (PropertyType)setProperty->PropertyType;
            this.PropertyId = (PropertyId)setProperty->PropertyId;

            if (setProperty->PropertyBuffer != IntPtr.Zero)
            {
                this.PropertyBuffer = new byte[(int)setProperty->PropertyBufferSize];
                Marshal.Copy(setProperty->PropertyBuffer, this.PropertyBuffer, 0, this.PropertyBuffer.Length);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the data that specifies the account for which the property was set.
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
        /// Gets a buffer that specifies the value to which the property was set.
        /// </summary>
        public byte[] PropertyBuffer
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies the property that was set.
        /// </summary>
        public PropertyId PropertyId
        {
            get;
        }

        /// <summary>
        /// Gets a value that specifies the type of the property that was set.
        /// </summary>
        public PropertyType PropertyType
        {
            get;
        }

        #endregion

    }

}