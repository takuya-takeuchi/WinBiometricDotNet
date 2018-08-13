using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetDomainLogonSettingViewModel : WinBioViewModel, IWinBioGetDomainLogonSettingViewModel
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