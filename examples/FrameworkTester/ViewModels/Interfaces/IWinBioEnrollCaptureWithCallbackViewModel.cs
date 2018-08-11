using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnrollCaptureWithCallbackViewModel : IWinBioViewModel
    {

        RelayCommand CancelCommand
        {
            get;
        }

        RejectDetails RejectDetail
        {
            get;
        }

    }

}