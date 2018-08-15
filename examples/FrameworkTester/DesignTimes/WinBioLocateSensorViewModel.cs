using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioLocateSensorViewModel : WinBioViewModel, IWinBioLocateSensorViewModel, IWinBioAsyncSessionViewModel
    {

        public uint UnitId
        {
            get;
        }

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}