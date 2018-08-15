using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioVerifyViewModel : WinBioViewModel, IWinBioVerifyViewModel, IWinBioAsyncSessionViewModel
    {

        public bool IsMatch
        {
            get;
        }

        public RejectDetails RejectDetail
        {
            get;
        }

        public uint UnitId
        {
            get;
        }

        public FingerPosition SelectedFingerPosition
        {
            get;
            set;
        }

        public IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}