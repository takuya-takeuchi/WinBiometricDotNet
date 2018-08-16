namespace WinBiometricDotNet
{

    public sealed class CaptureSampleResult
    {

        #region Constructors

        internal CaptureSampleResult(uint unitId, OperationStatus operationStatus, RejectDetail rejectDetail, uint sampleSize)
        {
            this.UnitId = unitId;
            this.OperationStatus = operationStatus;
            this.RejectDetail = rejectDetail;
            this.SampleSize = sampleSize;
        }

        #endregion

        #region Properties

        public CaptureSample Sample
        {
            get;
            internal set;
        }

        public OperationStatus OperationStatus
        {
            get;
        }

        public RejectDetail RejectDetail
        {
            get;
        }

        public uint SampleSize
        {
            get;
        }

        public uint UnitId
        {
            get;
        }

        #endregion

    }

}