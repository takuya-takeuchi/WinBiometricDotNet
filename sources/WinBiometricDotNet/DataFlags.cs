using System;
using WinBiometricDotNet.Interop;
using WINBIO_BIR_DATA_FLAGS = System.Byte;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="DataFlags"/> enumeration specifies the type of processing to be applied to the captured sample.
    /// </summary>
    [Flags]
    public enum DataFlags : WINBIO_BIR_DATA_FLAGS
    {

        /// <summary>
        /// The data is encrypted.
        /// </summary>
        Privacy = SafeNativeMethods.WINBIO_DATA_FLAG_PRIVACY,

        /// <summary>
        /// The data is digitally signed or is protected by a message authentication code (MAC).
        /// </summary>
        Integrity = SafeNativeMethods.WINBIO_DATA_FLAG_INTEGRITY,

        /// <summary>
        /// If this flag and the <see cref="Integrity"/> flag are set, the data is signed. If this flag is not set but the <see cref="Integrity"/> flag is set, a MAC is computed on the data.
        /// </summary>
        Signed = SafeNativeMethods.WINBIO_DATA_FLAG_SIGNED,

        /// <summary>
        /// The data is in the format with which it was captured.
        /// </summary>
        Raw = SafeNativeMethods.WINBIO_DATA_FLAG_RAW,

        /// <summary>
        /// The data is not raw but has not been completely processed.
        /// </summary>
        Intermediate = SafeNativeMethods.WINBIO_DATA_FLAG_INTERMEDIATE,

        /// <summary>
        /// The data has been processed.
        /// </summary>
        Processed = SafeNativeMethods.WINBIO_DATA_FLAG_PROCESSED,

        /// <summary>
        /// The flag mask.
        /// </summary>
        /// <remarks>This value is always one (1).</remarks>
        OptionMaskPresent = SafeNativeMethods.WINBIO_DATA_FLAG_OPTION_MASK_PRESENT

    }

}