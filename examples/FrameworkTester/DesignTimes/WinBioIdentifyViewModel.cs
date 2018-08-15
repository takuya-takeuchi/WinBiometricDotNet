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

        public RejectDetails RejectDetail
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

        public IdentityTypes Type
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}