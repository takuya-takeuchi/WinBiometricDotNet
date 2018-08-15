using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioUnlockUnitViewModel : WinBioViewModel, IWinBioUnlockUnitViewModel, IWinBioAsyncSessionViewModel
    {

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}