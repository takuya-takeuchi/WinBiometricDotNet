using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioCloseFrameworkViewModel : WinBioViewModel, IWinBioCloseFrameworkViewModel
    {

        public IWindowRepositoryViewModel<IFrameworkHandleViewModel> WindowRepository
        {
            get;
        }

    }

}