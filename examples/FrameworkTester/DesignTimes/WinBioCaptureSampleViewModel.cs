using System.Windows.Media.Imaging;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioCaptureSampleViewModel : WinBioViewModel, IWinBioCaptureSampleViewModel, IWinBioAsyncSessionViewModel
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

        public RejectDetails RejectDetail
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

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}