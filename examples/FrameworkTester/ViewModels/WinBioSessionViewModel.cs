using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioSessionViewModel : WinBioViewModel, IWinBioAsyncSessionViewModel
    {

        #region Constructors

        protected WinBioSessionViewModel()
        {
            this.WindowRepository = SimpleIoc.Default.GetInstance<IWindowRepositoryViewModel<ISessionHandleViewModel>>();
        }

        #endregion

        #region Properties

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

        #endregion

    }

}