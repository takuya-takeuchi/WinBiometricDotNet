using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioGetEnrolledFactorsViewModel : WinBioViewModel, IWinBioGetEnrolledFactorsViewModel
    {

        #region Constructors

        public WinBioGetEnrolledFactorsViewModel()
        {
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
                    this.Factor = 0;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var identity = this.IdentityRepository.SelectedIdentity;
                        var result = this.BiometricService.GetEnrolledFactors(identity);

                        this.Result = "OK";

                        this.Factor = result;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.IdentityRepository?.SelectedIdentity != null));
            }
        }

        public override string Name => "WinBioGetEnrolledFactors";

        private BiometricTypes _Factor;

        public BiometricTypes Factor
        {
            get => this._Factor;
            private set
            {
                this._Factor = value;
                this.RaisePropertyChanged();
            }
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        #endregion

    }

}