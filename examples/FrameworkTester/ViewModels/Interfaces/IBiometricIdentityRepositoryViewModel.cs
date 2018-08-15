using System.Collections.ObjectModel;
using System.ComponentModel;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IBiometricIdentityRepositoryViewModel : INotifyPropertyChanged
    {

        void Add(BiometricIdentity identity);

        BiometricIdentity SelectedIdentity
        {
            get;
            set;
        }

        ObservableCollection<BiometricIdentity> Identities
        {
            get;
        }

    }

}