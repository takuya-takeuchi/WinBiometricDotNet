namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncFrameworkViewModel
    {

        IHandleRepositoryViewModel<IFrameworkHandleViewModel> HandleRepository
        {
            get;
        }

    }

}