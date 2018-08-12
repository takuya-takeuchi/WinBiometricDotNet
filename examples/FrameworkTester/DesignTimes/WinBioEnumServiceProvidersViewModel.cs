using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnumServiceProvidersViewModel : WinBioViewModel, IWinBioEnumServiceProvidersViewModel
    {

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