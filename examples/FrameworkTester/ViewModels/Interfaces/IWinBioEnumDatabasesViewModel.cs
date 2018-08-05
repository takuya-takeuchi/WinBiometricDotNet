using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnumDatabasesViewModel : IWinBioViewModel
    {

        RelayCommand CreateDatabaseCommand
        {
            get;
        }

        BiometricDatabase CurrentDatabase
        {
            get;
            set;
        }

        ObservableCollection<BiometricDatabase> Databases
        {
            get;
        }

        RelayCommand RemoveDatabaseCommand
        {
            get;
        }

    }

}