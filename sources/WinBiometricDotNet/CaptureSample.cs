namespace WinBiometricDotNet
{

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

        public int Height
        {
            get;
        }

        public byte[] Image
        {
            get;
        }

        public int HorizontalImageResolution
        {
            get;
        }

        public int HorizontalScanResolution
        {
            get;
        }

        public int VerticalImageResolution
        {
            get;
        }

        public int VerticalScanResolution
        {
            get;
        }

        public int Width
        {
            get;
        }

        #endregion

    }

}