using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioRemoveCredentialViewModel : IWinBioViewModel
    {

        IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        IEnumerable<CredentialTypes> CredentialTypes
        {
            get;
        }

        CredentialTypes SelectedCredentialType
        {
            get;
            set;
        }

    }

}