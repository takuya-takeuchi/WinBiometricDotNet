using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioDeleteTemplateViewModel : IWinBioViewModel
    {

        FingerPosition CurrentFingerPosition
        {
            get;
            set;
        }

        IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

    }

}