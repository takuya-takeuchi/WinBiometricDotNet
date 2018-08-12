using System.Collections.ObjectModel;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class BiometricIdentityRepositoryViewModel : ViewModelBase, IBiometricIdentityRepositoryViewModel
    {

        #region Properties

        private BiometricIdentity _CurrentBiometricIdentity;

        public BiometricIdentity CurrentBiometricIdentity
        {
            get => this._CurrentBiometricIdentity;
            set
            {
                this._CurrentBiometricIdentity = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<BiometricIdentity> Identities
        {
            get;
        } = new ObservableCollection<BiometricIdentity>();

        #endregion

        #region Methods

        public void Add(BiometricIdentity identity)
        {
            if (identity?.Sid == null)
                return;

            if (this.Identities.Any())
            {
                if(this.Identities.All(biometricIdentity => biometricIdentity.Sid.Value != identity.Sid.Value))
                    this.Identities.Add(identity);
            }
            else
            {
                this.Identities.Add(identity);
            }

            this.CurrentBiometricIdentity = identity;
        }

        #endregion

    }

}