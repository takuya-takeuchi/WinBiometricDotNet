using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioGetCredentialStateViewModel : IWinBioViewModel
    {

        IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        CredentialState State
        {
            get;
        }

    }

}