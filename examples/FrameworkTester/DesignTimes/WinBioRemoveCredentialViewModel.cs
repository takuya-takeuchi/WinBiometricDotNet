using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioRemoveCredentialViewModel : WinBioViewModel, IWinBioRemoveCredentialViewModel
    {

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public IEnumerable<CredentialTypes> CredentialTypes
        {
            get;
        }

        public CredentialTypes SelectedCredentialType
        {
            get;
            set;
        }

    }

}