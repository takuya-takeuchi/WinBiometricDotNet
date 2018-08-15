using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollBeginViewModel : WinBioViewModel, IWinBioEnrollBeginViewModel, IWinBioAsyncSessionViewModel
    {

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