using System.Collections.ObjectModel;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnumServiceProvidersViewModel : IWinBioViewModel
    {

        BiometricServiceProvider SelectedServiceProvider
        {
            get;
            set;
        }

        ObservableCollection<BiometricServiceProvider> ServiceProviders
        {
            get;
        }

    }

}