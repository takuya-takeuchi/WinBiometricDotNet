using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioLogonIdentifiedUserViewModel : WinBioSessionViewModel, IWinBioLogonIdentifiedUserViewModel
    {

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

                        var session = this.HandleRepository.SelectedHandle.Session;
                        var result = this.BiometricService.LogonIdentifiedUser(session);

                        this.Result = "OK";

                        this.ReturnValue = result;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.HandleRepository?.SelectedHandle != null));
            }
        }

        public override string Name => "WinBioLogonIdentifiedUser";

        private bool _ReturnValue;

        public bool ReturnValue
        {
            get => this._ReturnValue;
            private set
            {
                this._ReturnValue = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}