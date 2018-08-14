using System;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncFrameworkViewModel
    {

        IWindowRepositoryViewModel<IFrameworkWindowViewModel> WindowRepository
        {
            get;
        }

    }

}