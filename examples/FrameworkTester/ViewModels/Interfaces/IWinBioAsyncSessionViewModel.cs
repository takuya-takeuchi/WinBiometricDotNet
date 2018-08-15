namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncSessionViewModel
    {

        IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}