using System;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollCommitViewModel : WinBioViewModel, IWinBioEnrollCommitViewModel
    {

        public IdentityTypes Type
        {
            get;
        }

        public string Sid
        {
            get;
        }

        public Guid TemplateGuid
        {
            get;
        }

    }

}