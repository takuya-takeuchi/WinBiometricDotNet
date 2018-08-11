using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioWithCallbackViewModel
    {

        RelayCommand CancelCommand
        {
            get;
        }

    }

}