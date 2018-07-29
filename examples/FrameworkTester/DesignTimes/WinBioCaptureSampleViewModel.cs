using System.Windows.Media.Imaging;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioCaptureSampleViewModel : IWinBioCaptureSampleViewModel
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

        public RelayCommand ExecuteCommand
        {
            get;
        }

        public string Name
        {
            get;
        }

        public uint RejectDetail
        {
            get;
        }

        public string Result
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