using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioViewModel
    {

        RelayCommand ExecuteCommand
        {
            get;
        }

        string Name
        {
            get;
        }

        string Result
        {
            get;
        }

    }

}