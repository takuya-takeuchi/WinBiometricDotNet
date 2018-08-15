using System;
using System.Collections.ObjectModel;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioAsyncEnumDatabasesViewModel : WinBioViewModel, IWinBioAsyncEnumDatabasesViewModel
    {

        #region Constructors

        public WinBioAsyncEnumDatabasesViewModel()
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
                        this.BiometricService.AsyncEnumDatabases(window.Framework);

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

        public override string Name => "WinBioAsyncEnumDatabases";

        public IHandleRepositoryViewModel<IFrameworkHandleViewModel> HandleRepository
        {
            get;
        }

        public ObservableCollection<BiometricDatabase> Databases
        {
            get;
        } = new ObservableCollection<BiometricDatabase>();

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