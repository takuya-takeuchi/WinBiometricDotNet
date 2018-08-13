using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioGetDomainLogonSettingViewModel : WinBioPropertyViewModel, IWinBioGetDomainLogonSettingViewModel
    {

        public override string Name => "WinBioGetDomainLogonSetting";

        protected override void GetValueAndSource(out bool value, out SettingSourceTypes source)
        {
            this.BiometricService.GetDomainLogonSetting(out value, out source);
        }

    }

}