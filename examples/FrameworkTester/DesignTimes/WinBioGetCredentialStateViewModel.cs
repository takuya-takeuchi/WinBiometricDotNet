using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetCredentialStateViewModel : WinBioViewModel, IWinBioGetCredentialStateViewModel
    {

        public CredentialStates State
        {
            get;
        }

    }

}