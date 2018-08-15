using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollSelectViewModel : WinBioViewModel, IWinBioEnrollSelectViewModel, IWinBioAsyncSessionViewModel
    {

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}