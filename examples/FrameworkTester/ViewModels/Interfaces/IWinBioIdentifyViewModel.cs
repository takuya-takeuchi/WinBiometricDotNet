using System;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioIdentifyViewModel : IWinBioViewModel
    {

        FingerPosition FingerPosition
        {
            get;
        }

        RejectDetails RejectDetail
        {
            get;
        }

        string Sid
        {
            get;
        }

        uint UnitId
        {
            get;
        }

        Guid TemplateGuid
        {
            get;
        }

        IdentityTypes Type
        {
            get;
        }

    }

}