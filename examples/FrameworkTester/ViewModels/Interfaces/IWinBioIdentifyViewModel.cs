using System;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioIdentifyViewModel : IWinBioViewModel
    {

        IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        FingerPosition FingerPosition
        {
            get;
        }

        RejectDetail RejectDetail
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

        IdentityType Type
        {
            get;
        }

    }

}