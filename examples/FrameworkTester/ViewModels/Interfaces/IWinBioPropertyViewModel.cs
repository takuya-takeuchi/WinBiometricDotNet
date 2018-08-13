using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioPropertyViewModel
    {

        SettingSourceTypes Source
        {
            get;
        }

        bool Value
        {
            get;
        }

    }

}