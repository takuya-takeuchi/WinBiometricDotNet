using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioViewModel
    {

        BiometricUnit CurrentUnit
        {
            get;
            set;
        }

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