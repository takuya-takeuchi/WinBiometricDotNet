using System;
using System.Collections.ObjectModel;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioAsyncEnumBiometricUnitsViewModel : WinBioViewModel, IWinBioAsyncEnumBiometricUnitsViewModel
    {

        #region Constructors

        public WinBioAsyncEnumBiometricUnitsViewModel()
        {
            WinBiometric.AsyncCompleted -= this.WinBiometricAsyncCompleted;
            WinBiometric.AsyncCompleted += this.WinBiometricAsyncCompleted;

            this.WindowRepository = SimpleIoc.Default.GetInstance<IWindowRepositoryViewModel<IFrameworkWindowViewModel>>();
            this.WindowRepository.PropertyChanged += (sender, args) =>
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

                        var window = this.WindowRepository.SelectedWindow;
                        this.BiometricService.AsyncEnumBiometricUnits(window.Framework);

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

        public override string Name => "WinBioAsyncEnumBiometricUnits";
        
        public IWindowRepositoryViewModel<IFrameworkWindowViewModel> WindowRepository
        {
            get;
        }

        public ObservableCollection<BiometricUnit> Units
        {
            get;
        } = new ObservableCollection<BiometricUnit>();

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