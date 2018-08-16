using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultEnrollCommit : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultEnrollCommit(SafeNativeMethods.WINBIO_ASYNC_RESULT_ENROLLCOMMIT* enrollCommit)
        {
            this.Identity = new BiometricIdentity(&enrollCommit->Identity);
            this.IsNewTemplate = enrollCommit->IsNewTemplate;
        }

        #endregion

        #region Properties

        public BiometricIdentity Identity
        {
            get;
        }

        public bool IsNewTemplate
        {
            get;
        }

        #endregion

    }

}