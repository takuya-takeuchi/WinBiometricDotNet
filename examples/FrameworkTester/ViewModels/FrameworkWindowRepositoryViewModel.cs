using System;
using System.Collections.ObjectModel;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;

namespace FrameworkTester.ViewModels
{

    public sealed class FrameworkWindowRepositoryViewModel : ViewModelBase, IWindowRepositoryViewModel<IFrameworkWindowViewModel>
    {

        #region Properties

        private IFrameworkWindowViewModel _SelectedWindow;

        public IFrameworkWindowViewModel SelectedWindow
        {
            get => this._SelectedWindow;
            set
            {
                this._SelectedWindow = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<IFrameworkWindowViewModel> Windows
        {
            get;
        } = new ObservableCollection<IFrameworkWindowViewModel>();

        #endregion

        #region Methods

        public void Add(IFrameworkWindowViewModel childWindow)
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