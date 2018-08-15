using System;
using System.Collections.ObjectModel;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;

namespace FrameworkTester.ViewModels
{

    public sealed class SessionWindowRepositoryViewModel : ViewModelBase, IWindowRepositoryViewModel<ISessionHandleViewModel>
    {

        #region Properties

        private ISessionHandleViewModel _SelectedWindow;

        public ISessionHandleViewModel SelectedWindow
        {
            get => this._SelectedWindow;
            set
            {
                this._SelectedWindow = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<ISessionHandleViewModel> Windows
        {
            get;
        } = new ObservableCollection<ISessionHandleViewModel>();

        #endregion

        #region Methods

        public void Add(ISessionHandleViewModel childWindow)
        {
            if (this.Windows.Any())
            {
                if(this.Windows.All(h => h != childWindow))
                    this.Windows.Add(childWindow);
            }
            else
            {
                this.Windows.Add(childWindow);
            }

            this.SelectedWindow = childWindow;
        }

        #endregion

    }

}