using System.Linq;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultEnumEnrollments : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnumEnrollments(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENUMENROLLMENTS* enumEnrollments)
        {
            this.Identity = new BiometricIdentity(enumEnrollments->Identity);

            var array = new byte[(int)enumEnrollments->SubFactorCount];
            Marshal.Copy(enumEnrollments->SubFactorArray, array, 0, (int)enumEnrollments->SubFactorCount);
            this.FingerPositions = array.Select(f => (FingerPosition)f).ToArray();
        }

        #endregion

        #region Properties

        public BiometricIdentity Identity
        {
            get;
        }

        public FingerPosition[] FingerPositions
        {
            get;
        }

        #endregion

    }

}