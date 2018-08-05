using System.Windows.Media.Imaging;
using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioCaptureSampleViewModel : WinBioViewModel, IWinBioCaptureSampleViewModel
    {

        public BitmapSource CaptureImage
        {
            get;
        }

        public int CaptureImageWidth
        {
            get;
        }

        public int CaptureImageHeight
        {
            get;
        }

        public int CaptureImageHorizontalResolution
        {
            get;
        }

        public int CaptureImageVerticalResolution
        {
            get;
        }

        public int CaptureImageScanHorizontalResolution
        {
            get;
        }

        public int CaptureImageScanVerticalResolution
        {
            get;
        }

        public uint RejectDetail
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

    }

}