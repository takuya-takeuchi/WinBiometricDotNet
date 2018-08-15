using System;
using System.Collections.ObjectModel;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;

namespace FrameworkTester.ViewModels
{

    public sealed class FrameworkHandleRepositoryViewModel : ViewModelBase, IHandleRepositoryViewModel<IFrameworkHandleViewModel>
    {

        #region Properties

        private IFrameworkHandleViewModel _SelectedWindow;

        public IFrameworkHandleViewModel SelectedHandle
        {
            get => this._SelectedWindow;
            set
            {
                this._SelectedWindow = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<IFrameworkHandleViewModel> Handles
        {
            get;
        } = new ObservableCollection<IFrameworkHandleViewModel>();

        #endregion

        #region Methods

        public void Add(IFrameworkHandleViewModel handle)
        {
            if (handle?.Handle == IntPtr.Zero)
                return;

            if (this.Handles.Any())
            {
                if (this.Handles.All(h => h != handle))
                    this.Handles.Add(handle);
            }
            else
            {
                this.Handles.Add(handle);
            }

            this.SelectedHandle = handle;
        }

        #endregion

    }

}