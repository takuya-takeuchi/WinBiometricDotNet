using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioFrameworkViewModel : WinBioViewModel, IWinBioAsyncFrameworkViewModel
    {

        #region Constructors

        protected WinBioFrameworkViewModel()
        {
            this.HandleRepository = SimpleIoc.Default.GetInstance<IHandleRepositoryViewModel<IFrameworkHandleViewModel>>();
            this.HandleRepository.PropertyChanged += (sender, args) =>
            {
                this.ExecuteCommand.RaiseCanExecuteChanged();
            };
        }

        #endregion

        #region Properties

        public IHandleRepositoryViewModel<IFrameworkHandleViewModel> HandleRepository
        {
            get;
        }

        #endregion

    }

}