using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollDiscardViewModel : WinBioViewModel, IWinBioEnrollDiscardViewModel, IWinBioAsyncSessionViewModel
    {

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}