using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="AsyncResultEnrollCommit"/> class contains the results of an asynchronous call to <see cref="WinBiometric.CommitEnroll"/>.
    /// </summary>
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

        /// <summary>
        /// Gets the data that receives the identifier (GUID or SID) of the template.
        /// </summary>
        public BiometricIdentity Identity
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the template being added to the database is new.
        /// </summary>
        public bool IsNewTemplate
        {
            get;
        }

        #endregion

    }

}