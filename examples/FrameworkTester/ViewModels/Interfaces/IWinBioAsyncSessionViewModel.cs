namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncSessionViewModel
    {

        IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}