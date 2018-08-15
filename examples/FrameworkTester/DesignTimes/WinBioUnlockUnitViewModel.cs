using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioUnlockUnitViewModel : WinBioViewModel, IWinBioUnlockUnitViewModel, IWinBioAsyncSessionViewModel
    {

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}