using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioAsyncEnumDatabasesViewModel : WinBioViewModel, IWinBioAsyncEnumDatabasesViewModel
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

        public IWindowRepositoryViewModel<IFrameworkHandleViewModel> WindowRepository
        {
            get;
        }

        public ObservableCollection<BiometricDatabase> Databases
        {
            get;
        }

    }

}