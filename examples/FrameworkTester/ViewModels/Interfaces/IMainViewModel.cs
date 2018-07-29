using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IMainViewModel
    {

        IWinBioViewModel CurrentTestTarget
        {
            get;
            set;
        }

        BiometricUnit CurrentUnit
        {
            get;
            set;
        }

        RelayCommand LoadedCommand
        {
            get;
        }

        ObservableCollection<IWinBioViewModel> TestTargets
        {
            get;
        }

        ObservableCollection<BiometricUnit> Units
        {
            get;
        }

    }

}
