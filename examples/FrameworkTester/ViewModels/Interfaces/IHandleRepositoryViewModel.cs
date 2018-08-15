using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IHandleRepositoryViewModel<T> : INotifyPropertyChanged
        where T : IHandleViewModel
    {

        void Add(T handle);

        T SelectedHandle
        {
            get;
            set;
        }

        ObservableCollection<T> Handles
        {
            get;
        }

    }

}