using System.Collections.ObjectModel;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;

namespace FrameworkTester.ViewModels
{

    public sealed class SessionHandleRepositoryViewModel : ViewModelBase, IHandleRepositoryViewModel<ISessionHandleViewModel>
    {

        #region Properties

        private ISessionHandleViewModel _SelectedHandle;

        public ISessionHandleViewModel SelectedHandle
        {
            get => this._SelectedHandle;
            set
            {
                this._SelectedHandle = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<ISessionHandleViewModel> Handles
        {
            get;
        } = new ObservableCollection<ISessionHandleViewModel>();

        #endregion

        #region Methods

        public void Add(ISessionHandleViewModel handle)
        {
            if (this.Handles.Any())
            {
                if(this.Handles.All(h => h != handle))
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