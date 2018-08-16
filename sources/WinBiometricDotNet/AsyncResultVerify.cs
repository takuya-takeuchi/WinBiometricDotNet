using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultVerify : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultVerify(SafeNativeMethods.WINBIO_ASYNC_RESULT_VERIFY* verify)
        {
            this.Match = verify->Match;
            this.RejectDetail = (RejectDetails)verify->RejectDetail;
        }

        #endregion

        #region Properties

        public bool Match
        {
            get;
        }

        public RejectDetails RejectDetail
        {
            get;
        }

        #endregion

    }

}