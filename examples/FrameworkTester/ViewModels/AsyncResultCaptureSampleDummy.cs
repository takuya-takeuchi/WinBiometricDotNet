using System.Windows.Media.Imaging;
using FrameworkTester.Helpers;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    internal sealed class AsyncResultCaptureSampleDummy : AsyncResultParameter
    {

        #region Constructors

        internal AsyncResultCaptureSampleDummy(AsyncResultCaptureSample captureSample)
        {
            this.Sample = captureSample.Sample;
            this.SampleSize = captureSample.SampleSize;
            this.RejectDetail = captureSample.RejectDetail;

            var image = BitmapSourceHelper.ToBitmapSource(captureSample.Sample.Image,
                captureSample.Sample.Width,
                captureSample.Sample.Height,
                captureSample.Sample.HorizontalImageResolution,
                captureSample.Sample.VerticalImageResolution);
            if (image.CanFreeze)
                image.Freeze();

            this.CaptureImage = image;
        }

        #endregion

        #region Properties

        public BitmapSource CaptureImage
        {
            get;
        }

        public CaptureSample Sample
        {
            get;
        }

        public int SampleSize
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