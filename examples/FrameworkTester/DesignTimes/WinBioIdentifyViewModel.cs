using System;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioIdentifyViewModel : WinBioViewModel, IWinBioIdentifyViewModel, IWinBioAsyncSessionViewModel
    {

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public FingerPosition FingerPosition
        {
            get;
        }

        public RejectDetail RejectDetail
        {
            get;
        }

        public string Sid
        {
            get;
        }

        public uint UnitId
        {
            get;
        }

        public Guid TemplateGuid
        {
            get;
        }

        public IdentityType Type
        {
            get;
        }

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}