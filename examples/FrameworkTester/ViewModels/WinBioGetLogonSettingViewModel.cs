using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioGetLogonSettingViewModel : WinBioPropertyViewModel, IWinBioGetLogonSettingViewModel
    {

        public override string Name => "WinBioGetLogonSetting";

        protected override void GetValueAndSource(out bool value, out SettingSourceTypes source)
        {
            this.BiometricService.GetDomainLogonSetting(out value, out source);
        }

    }

}