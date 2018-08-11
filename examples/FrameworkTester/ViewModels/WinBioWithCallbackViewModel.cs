using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioWithCallbackViewModel : WinBioViewModel, IWinBioViewModel
    {

        #region Constructors

        protected WinBioWithCallbackViewModel()
        {
            this.DispatcherService = SimpleIoc.Default.GetInstance<IDispatcherService>();
        }

        #endregion

        #region Properties

        protected IDispatcherService DispatcherService
        {
            get;
        }

        #endregion

    }

}