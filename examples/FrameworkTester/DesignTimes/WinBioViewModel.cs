using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public abstract class WinBioViewModel : IWinBioViewModel
    {

        public BiometricUnit SelectedUnit
        {
            get;
            set;
        }

        public RelayCommand ExecuteCommand
        {
            get;
        }

        public string Name
        {
            get;
        }

        public string Result
        {
            get;
        }

    }

}