using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioRemoveCredentialViewModel : WinBioViewModel, IWinBioRemoveCredentialViewModel
    {

        #region Constructors

        public WinBioRemoveCredentialViewModel()
        {
            this.CredentialTypes = Enum.GetValues(typeof(CredentialTypes)).Cast<CredentialTypes>().ToArray();

            this.SelectedCredentialType = this.CredentialTypes.First();

            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
            this.IdentityRepository.PropertyChanged += (sender, args) =>
            {
                this.ExecuteCommand.RaiseCanExecuteChanged();
            };
        }

        #endregion

        #region Properties

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var identity = this.IdentityRepository.SelectedIdentity;
                        var credentialType = this.SelectedCredentialType;

                        this.BiometricService.RemoveCredential(identity, credentialType);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.IdentityRepository?.SelectedIdentity != null));
            }
        }

        public override string Name => "WinBioRemoveCredential";

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public IEnumerable<CredentialTypes> CredentialTypes
        {
            get;
        }

        private CredentialTypes _SelectedCredentialType;

        public CredentialTypes SelectedCredentialType
        {
            get => this._SelectedCredentialType;
            set
            {
                this._SelectedCredentialType = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}