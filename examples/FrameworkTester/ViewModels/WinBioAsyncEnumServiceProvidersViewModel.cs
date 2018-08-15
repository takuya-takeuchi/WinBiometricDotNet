using System;
using System.Collections.ObjectModel;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioAsyncEnumServiceProvidersViewModel : WinBioViewModel, IWinBioAsyncEnumServiceProvidersViewModel
    {

        #region Constructors

        public WinBioAsyncEnumServiceProvidersViewModel()
        {
            WinBiometric.AsyncCompleted -= this.WinBiometricAsyncCompleted;
            WinBiometric.AsyncCompleted += this.WinBiometricAsyncCompleted;

            this.HandleRepository = SimpleIoc.Default.GetInstance<IHandleRepositoryViewModel<IFrameworkHandleViewModel>>();
            this.HandleRepository.PropertyChanged += (sender, args) =>
            {
                this.ExecuteCommand.RaiseCanExecuteChanged();
            };
        }

        #endregion

        #region Properties

        public RelayCommand CancelCommand
        {
            get;
        }

        public bool EnableWait
        {
            get;
            set;
        }

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    var name = this.Name;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var window = this.HandleRepository.SelectedHandle;
                        this.BiometricService.AsyncEnumServiceProviders(window.Framework);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.HandleRepository?.SelectedHandle != null));
            }
        }

        public override string Name => "WinBioAsyncEnumServiceProviders";

        public IHandleRepositoryViewModel<IFrameworkHandleViewModel> HandleRepository
        {
            get;
        }

        private BiometricServiceProvider _SelectedServiceProvider;

        public BiometricServiceProvider SelectedServiceProvider
        {
            get => this._SelectedServiceProvider;
            set
            {
                this._SelectedServiceProvider = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<BiometricServiceProvider> ServiceProviders
        {
            get;
        } = new ObservableCollection<BiometricServiceProvider>();

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricAsyncCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        #endregion

        #endregion

    }

}