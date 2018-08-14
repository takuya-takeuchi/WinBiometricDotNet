using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioAsyncEnumServiceProvidersViewModel : WinBioViewModel, IWinBioAsyncEnumServiceProvidersViewModel
    {

        public RelayCommand CancelCommand
        {
            get;
        }

        public bool EnableWait
        {
            get;
            set;
        }

        public IWindowRepositoryViewModel<IFrameworkWindowViewModel> WindowRepository
        {
            get;
        }

        public BiometricServiceProvider CurrentServiceProvider
        {
            get;
            set;
        }

        public ObservableCollection<BiometricServiceProvider> ServiceProviders
        {
            get;
        }

    }

}