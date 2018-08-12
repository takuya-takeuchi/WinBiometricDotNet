using System;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioIdentifyWithCallbackViewModel : WinBioViewModel, IWinBioIdentifyWithCallbackViewModel
    {

        public RelayCommand CancelCommand
        {
            get;
        }

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

    }

}