namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="CaptureSample"/> class contains a fingerprint sample data.
    /// </summary>
    public sealed class CaptureSample
    {

        #region Constructors

        internal CaptureSample(int width, 
                               int height, 
                               int horizontalScanResolution, 
                               int verticalScanResolution, 
                               int horizontalImageResolution, 
                               int verticalImageResolution,
                               byte[] image)
        {
            this.Width = width;
            this.Height = height;
            this.HorizontalScanResolution = horizontalScanResolution;
            this.VerticalScanResolution = verticalScanResolution;
            this.HorizontalImageResolution = horizontalImageResolution;
            this.VerticalImageResolution = verticalImageResolution;
            this.Image = image;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the height, in pixels.
        /// </summary>
        public int Height
        {
            get;
        }

        /// <summary>
        /// Gets the pixel data of the captured fingerprint or palm image.
        /// </summary>
        public byte[] Image
        {
            get;
        }

        /// <summary>
        /// Gets the horizontal resolution of the captured fingerprint or palm image.
        /// </summary>
        public int HorizontalImageResolution
        {
            get;
        }

        /// <summary>
        /// Gets the horizontal resolution of the scan.
        /// </summary>
        public int HorizontalScanResolution
        {
            get;
        }

        /// <summary>
        /// Gets the vertical resolution of the captured fingerprint or palm image.
        /// </summary>
        public int VerticalImageResolution
        {
            get;
        }

        /// <summary>
        /// Gets the vertical resolution of the scan.
        /// </summary>
        public int VerticalScanResolution
        {
            get;
        }

        /// <summary>
        /// Gets the width, in pixels.
        /// </summary>
        public int Width
        {
            get;
        }

        #endregion

    }

}