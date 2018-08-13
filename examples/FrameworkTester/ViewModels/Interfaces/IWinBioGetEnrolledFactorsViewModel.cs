using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioGetEnrolledFactorsViewModel : IWinBioViewModel
    {

        BiometricTypes Factor
        {
            get;
        }

        IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

    }

}