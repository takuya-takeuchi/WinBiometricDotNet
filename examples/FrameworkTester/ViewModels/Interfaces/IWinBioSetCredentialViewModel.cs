using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioSetCredentialViewModel : IWinBioViewModel
    {

        CredentialFormat SelectedCredentialFormat
        {
            get;
            set;
        }

        CredentialTypes SelectedCredentialType
        {
            get;
            set;
        }

        IEnumerable<CredentialFormat> CredentialFormats
        {
            get;
        }

        IEnumerable<CredentialTypes> CredentialTypes
        {
            get;
        }

    }

}