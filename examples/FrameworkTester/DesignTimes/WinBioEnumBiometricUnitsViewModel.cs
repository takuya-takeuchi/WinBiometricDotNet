using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnumBiometricUnitsViewModel : IWinBioEnumBiometricUnitsViewModel
    {

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

        public ObservableCollection<BiometricUnit> Units
        {
            get;
        }

    }

}