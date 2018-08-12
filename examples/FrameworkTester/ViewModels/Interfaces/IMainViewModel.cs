using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IMainViewModel
    {

        RelayCommand ClearEventsCommand
        {
            get;
        }

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

        ObservableCollection<string> Events
        {
            get;
        }

        bool EnableMonitorEvent
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

        bool ToggleMonitorEvent
        {
            get;
        }

        ObservableCollection<BiometricUnit> Units
        {
            get;
        }

    }

}
