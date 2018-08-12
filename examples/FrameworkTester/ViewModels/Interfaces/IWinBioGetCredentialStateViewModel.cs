using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioGetCredentialStateViewModel : IWinBioViewModel
    {

        IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        CredentialStates State
        {
            get;
        }

    }

}