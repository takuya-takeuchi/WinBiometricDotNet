using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioCaptureSampleWithCallbackViewModel : IWinBioCaptureSampleViewModel
    {

        RelayCommand CancelCommand
        {
            get;
        }

        bool Loop
        {
            get;
            set;
        }

    }

}