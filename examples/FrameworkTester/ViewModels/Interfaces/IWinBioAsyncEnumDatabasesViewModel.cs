using System.Collections.ObjectModel;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncEnumDatabasesViewModel : IWinBioWithCallbackViewModel, IWinBioAsyncFrameworkViewModel, IWinBioViewModel
    {

        ObservableCollection<BiometricDatabase> Databases
        {
            get;
        }

    }

}