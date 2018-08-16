using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioPropertyViewModel
    {

        SettingSourceType Source
        {
            get;
        }

        bool Value
        {
            get;
        }

    }

}