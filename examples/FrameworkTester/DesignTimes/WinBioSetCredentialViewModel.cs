using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioSetCredentialViewModel : WinBioViewModel, IWinBioSetCredentialViewModel, IWinBioAsyncSessionViewModel
    {

        public CredentialFormat SelectedCredentialFormat
        {
            get;
            set;
        }

        public CredentialTypes SelectedCredentialType
        {
            get;
            set;
        }

        public IEnumerable<CredentialFormat> CredentialFormats
        {
            get;
        }

        public IEnumerable<CredentialTypes> CredentialTypes
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}