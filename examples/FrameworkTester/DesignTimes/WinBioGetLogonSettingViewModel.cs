using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetLogonSettingViewModel : WinBioViewModel, IWinBioGetLogonSettingViewModel
    {

        public SettingSourceType Source
        {
            get;
        }

        public bool Value
        {
            get;
        }

    }

}