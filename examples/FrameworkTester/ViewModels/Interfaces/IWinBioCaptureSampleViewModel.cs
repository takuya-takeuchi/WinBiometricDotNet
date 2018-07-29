using System.Windows.Media.Imaging;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioCaptureSampleViewModel : IWinBioViewModel
    {

        BitmapSource CaptureImage
        {
            get;
        }

        int CaptureImageWidth
        {
            get;
        }

        int CaptureImageHeight
        {
            get;
        }

        int CaptureImageHorizontalResolution
        {
            get;
        }

        int CaptureImageVerticalResolution
        {
            get;
        }

        int CaptureImageScanHorizontalResolution
        {
            get;
        }

        int CaptureImageScanVerticalResolution
        {
            get;
        }

        uint RejectDetail
        {
            get;
        }

        uint SampleSize
        {
            get;
        }

        uint UnitId
        {
            get;
        }

    }

}