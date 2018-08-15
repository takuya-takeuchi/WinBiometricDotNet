using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioCloseSessionViewModel : WinBioViewModel, IWinBioCloseSessionViewModel, IWinBioAsyncSessionViewModel
    {

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}