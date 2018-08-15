using System.Windows.Media.Imaging;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioCaptureSampleWithCallbackViewModel : WinBioViewModel, IWinBioCaptureSampleWithCallbackViewModel, IWinBioAsyncSessionViewModel
    {

        public RelayCommand CancelCommand
        {
            get;
        }

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

        public bool EnableWait
        {
            get;
            set;
        }

        public bool Loop
        {
            get;
            set;
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