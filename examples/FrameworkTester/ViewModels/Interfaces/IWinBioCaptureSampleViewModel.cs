using System.Windows.Media.Imaging;
using WinBiometricDotNet;

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

        RejectDetail RejectDetail
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