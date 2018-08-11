using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioWithCallbackViewModel : WinBioViewModel, IWinBioWithCallbackViewModel
    {

        #region Constructors

        protected WinBioWithCallbackViewModel()
        {
            this.DispatcherService = SimpleIoc.Default.GetInstance<IDispatcherService>();
        }

        #endregion

        #region Properties

        public abstract RelayCommand CancelCommand
        {
            get;
        }

        protected IDispatcherService DispatcherService
        {
            get;
        }

        private bool _WaitCallback;

        protected bool WaitCallback
        {
            get => this._WaitCallback;
            set
            {
                this._WaitCallback = value;

                this.RaisePropertyChanged();

                this.ExecuteCommand.RaiseCanExecuteChanged();
                this.CancelCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

    }

}