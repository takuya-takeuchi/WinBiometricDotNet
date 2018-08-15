using System;
using System.Collections.ObjectModel;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;

namespace FrameworkTester.ViewModels
{

    public sealed class FrameworkWindowRepositoryViewModel : ViewModelBase, IWindowRepositoryViewModel<IFrameworkHandleViewModel>
    {

        #region Properties

        private IFrameworkHandleViewModel _SelectedWindow;

        public IFrameworkHandleViewModel SelectedWindow
        {
            get => this._SelectedWindow;
            set
            {
                this._SelectedWindow = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<IFrameworkHandleViewModel> Windows
        {
            get;
        } = new ObservableCollection<IFrameworkHandleViewModel>();

        #endregion

        #region Methods

        public void Add(IFrameworkHandleViewModel childWindow)
        {
            if (childWindow?.Handle == IntPtr.Zero)
                return;

            if (this.Windows.Any())
            {
                if (this.Windows.All(h => h != childWindow))
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