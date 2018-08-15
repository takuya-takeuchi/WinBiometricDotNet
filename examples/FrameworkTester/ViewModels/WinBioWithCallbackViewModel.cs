using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioWithCallbackViewModel : WinBioSessionViewModel, IWinBioWithCallbackViewModel
    {

        #region Properties

        public abstract RelayCommand CancelCommand
        {
            get;
        }

        public abstract bool EnableWait
        {
            get;
            set;
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