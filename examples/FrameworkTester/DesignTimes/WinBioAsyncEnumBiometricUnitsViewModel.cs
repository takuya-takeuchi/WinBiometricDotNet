using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioAsyncEnumBiometricUnitsViewModel : WinBioViewModel, IWinBioAsyncEnumBiometricUnitsViewModel
    {

        public IWindowRepositoryViewModel<IFrameworkHandleViewModel> WindowRepository
        {
            get;
        }

        public RelayCommand CancelCommand
        {
            get;
        }

        public bool EnableWait
        {
            get;
            set;
        }

        public ObservableCollection<BiometricUnit> Units
        {
            get;
        }

    }

}