using System.Collections.ObjectModel;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnumBiometricUnitsViewModel : IWinBioViewModel
    {

        ObservableCollection<BiometricUnit> Units
        {
            get;
        }

    }

}