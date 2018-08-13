using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetEnrolledFactorsViewModel : WinBioViewModel, IWinBioGetEnrolledFactorsViewModel
    {

        public BiometricTypes Factor
        {
            get;
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

    }

}