using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnumDatabasesViewModel : WinBioViewModel, IWinBioEnumDatabasesViewModel
    {

        public RelayCommand CreateDatabaseCommand
        {
            get;
        }

        public BiometricDatabase CurrentDatabase
        {
            get;
            set;
        }

        public ObservableCollection<BiometricDatabase> Databases
        {
            get;
        }

        public RelayCommand RemoveDatabaseCommand
        {
            get;
        }

    }

}