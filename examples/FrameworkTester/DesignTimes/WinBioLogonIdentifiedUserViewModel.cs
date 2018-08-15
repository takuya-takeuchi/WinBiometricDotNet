using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioLogonIdentifiedUserViewModel : WinBioViewModel, IWinBioLogonIdentifiedUserViewModel, IWinBioAsyncSessionViewModel
    {

        public bool ReturnValue
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}