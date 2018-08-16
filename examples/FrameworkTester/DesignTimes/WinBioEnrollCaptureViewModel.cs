using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollCaptureViewModel : WinBioViewModel, IWinBioEnrollCaptureViewModel, IWinBioAsyncSessionViewModel
    {

        public RejectDetail RejectDetail
        {
            get;
        }

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}