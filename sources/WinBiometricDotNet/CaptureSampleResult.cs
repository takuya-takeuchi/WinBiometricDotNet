using HRESULT = System.Int32;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="VerifyResult"/> class contains a result returned from <see cref="WinBiometric.CaptureSample"/> or <see cref="WinBiometric.CaptureSampleWithCallback"/>.
    /// </summary>
    public sealed class CaptureSampleResult
    {

        #region Constructors

        internal CaptureSampleResult(uint unitId, HRESULT operationStatus, RejectDetail rejectDetail, uint sampleSize)
        {
            this.UnitId = unitId;
            this.OperationStatus = operationStatus;
            this.RejectDetail = rejectDetail;
            this.SampleSize = sampleSize;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the data that contain sample.
        /// </summary>
        public CaptureSample Sample
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets the error code returned by the capture operation.
        /// </summary>
        public HRESULT OperationStatus
        {
            get;
        }

        /// <summary>
        /// Gets a value that contains additional information about the failure to capture a biometric sample.
        /// </summary>
        public RejectDetail RejectDetail
        {
            get;
        }

        /// <summary>
        /// Gets a value that contains the size, in bytes, of <see cref="Sample"/> property.
        /// </summary>
        public uint SampleSize
        {
            get;
        }

        /// <summary>
        /// Gets a value that contains the ID of the biometric unit that generated the sample.
        /// </summary>
        public uint UnitId
        {
            get;
        }

        #endregion

    }

}