using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioCloseFrameworkViewModel : WinBioViewModel, IWinBioCloseFrameworkViewModel
    {

        #region Constructors

        public WinBioCloseFrameworkViewModel()
        {
            WinBiometric.AsyncCompleted -= this.WinBiometricAsyncCompleted;
            WinBiometric.AsyncCompleted += this.WinBiometricAsyncCompleted;

            this.WindowRepository = SimpleIoc.Default.GetInstance<IWindowRepositoryViewModel<IFrameworkHandleViewModel>>();
            this.WindowRepository.PropertyChanged += (sender, args) =>
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
                    var name = this.Name;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var window = this.WindowRepository.SelectedWindow;
                        this.BiometricService.CloseFramework(window.Framework);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.WindowRepository?.SelectedWindow != null));
            }
        }

        public override string Name => "WinBioCloseFramework";
        
        public IWindowRepositoryViewModel<IFrameworkHandleViewModel> WindowRepository
        {
            get;
        }

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