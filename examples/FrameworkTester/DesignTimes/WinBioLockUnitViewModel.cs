using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioLockUnitViewModel : WinBioViewModel, IWinBioLockUnitViewModel, IWinBioAsyncSessionViewModel
    {

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}