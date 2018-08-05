using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnumBiometricUnitsViewModel : WinBioViewModel, IWinBioEnumBiometricUnitsViewModel
    {

        public ObservableCollection<BiometricUnit> Units
        {
            get;
        }

    }

}