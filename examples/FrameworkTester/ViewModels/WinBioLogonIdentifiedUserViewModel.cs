using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioLogonIdentifiedUserViewModel : WinBioViewModel, IWinBioLogonIdentifiedUserViewModel
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
                        var result = this.BiometricService.LogonIdentifiedUser();
                        this.Result = "OK";

                        this.ReturnValue = result;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }));
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