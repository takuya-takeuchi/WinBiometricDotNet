namespace WinBiometricDotNet
{

    public sealed class AsyncResultVerify
    {

        #region Constructors

        internal AsyncResultVerify(bool match, RejectDetails rejectDetail)
        {
            this.Match = match;
            this.RejectDetail = rejectDetail;

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