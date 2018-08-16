using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetCredentialStateViewModel : WinBioViewModel, IWinBioGetCredentialStateViewModel
    {
        
        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public CredentialState State
        {
            get;
        }

    }

}