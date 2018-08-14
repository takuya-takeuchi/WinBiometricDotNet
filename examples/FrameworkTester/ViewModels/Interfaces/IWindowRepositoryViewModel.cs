using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWindowRepositoryViewModel<T> : INotifyPropertyChanged
        where T : IChildWindowViewModel
    {

        void Add(T window);

        T SelectedWindow
        {
            get;
            set;
        }

        ObservableCollection<T> Windows
        {
            get;
        }

    }

}