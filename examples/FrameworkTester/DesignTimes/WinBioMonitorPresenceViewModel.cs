using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioMonitorPresenceViewModel : WinBioViewModel, IWinBioMonitorPresenceViewModel, IWinBioAsyncSessionViewModel
    {

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}