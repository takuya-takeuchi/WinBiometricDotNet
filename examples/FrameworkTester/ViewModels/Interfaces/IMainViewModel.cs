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

        IWinBioViewModel SelectedTestTarget
        {
            get;
            set;
        }

        BiometricUnit SelectedUnit
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

        IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}
