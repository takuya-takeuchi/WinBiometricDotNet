using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollCaptureWithCallbackViewModel : WinBioViewModel, IWinBioEnrollCaptureWithCallbackViewModel
    {

        public RelayCommand CancelCommand
        {
            get;
        }

        public RejectDetails RejectDetail
        {
            get;
        }

    }

}