using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollCaptureViewModel : WinBioViewModel, IWinBioEnrollCaptureViewModel, IWinBioAsyncSessionViewModel
    {

        public RejectDetails RejectDetail
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}