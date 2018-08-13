using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetLogonSettingViewModel : WinBioViewModel, IWinBioGetLogonSettingViewModel
    {

        public SettingSourceTypes Source
        {
            get;
        }

        public bool Value
        {
            get;
        }

    }

}