using System;
using System.Collections.ObjectModel;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;

namespace FrameworkTester.ViewModels
{

    public sealed class SessionWindowRepositoryViewModel : ViewModelBase, IWindowRepositoryViewModel<ISessionWindowViewModel>
    {

        #region Properties

        private ISessionWindowViewModel _SelectedWindow;

        public ISessionWindowViewModel SelectedWindow
        {
            get => this._SelectedWindow;
            set
            {
                this._SelectedWindow = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<ISessionWindowViewModel> Windows
        {
            get;
        } = new ObservableCollection<ISessionWindowViewModel>();

        #endregion

        #region Methods

        public void Add(ISessionWindowViewModel childWindow)
        {
            if (childWindow?.Handle == IntPtr.Zero)
                return;

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