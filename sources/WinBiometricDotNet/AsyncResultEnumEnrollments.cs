using System.Linq;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultEnumEnrollments"/> class contains the results of a call to <see cref="WinBiometric.EnumEnrollments"/>.
    /// </summary>
    public sealed class AsyncResultEnumEnrollments : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnumEnrollments(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENUMENROLLMENTS* enumEnrollments)
        {
            this.Identity = new BiometricIdentity(&enumEnrollments->Identity);

            var array = new byte[(int)enumEnrollments->SubFactorCount];
            Marshal.Copy(enumEnrollments->SubFactorArray, array, 0, (int)enumEnrollments->SubFactorCount);
            this.FingerPositions = array.Select(f => (FingerPosition)f).ToArray();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the GUID or SID of the template from which the sub-factors were retrieved.
        /// </summary>
        public BiometricIdentity Identity
        {
            get;
        }

        /// <summary>
        /// Gets the array of <see cref="FingerPosition"/>.
        /// </summary>
        public FingerPosition[] FingerPositions
        {
            get;
        }

        #endregion

    }

}