using System;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnrollCommitViewModel : IWinBioViewModel
    {

        IdentityTypes Type
        {
            get;
        }

        string Sid
        {
            get;
        }

        Guid TemplateGuid
        {
            get;
        }

    }

}