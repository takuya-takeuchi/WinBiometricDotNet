namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncSessionViewModel
    {

        IWindowRepositoryViewModel<ISessionWindowViewModel> WindowRepository
        {
            get;
        }

    }

}