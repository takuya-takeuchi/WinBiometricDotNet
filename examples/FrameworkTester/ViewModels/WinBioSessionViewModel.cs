using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioSessionViewModel : WinBioViewModel, IWinBioAsyncSessionViewModel
    {

        #region Constructors

        protected WinBioSessionViewModel()
        {
            this.HandleRepository = SimpleIoc.Default.GetInstance<IHandleRepositoryViewModel<ISessionHandleViewModel>>();
            this.HandleRepository.PropertyChanged += (sender, args) =>
            {
                this.ExecuteCommand.RaiseCanExecuteChanged();
            };
        }

        #endregion

        #region Properties

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

        #endregion

    }

}