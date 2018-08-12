using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioGetCredentialStateViewModel : IWinBioViewModel
    {

        CredentialStates State
        {
            get;
        }

    }

}