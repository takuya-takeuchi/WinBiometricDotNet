using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioRemoveAllCredentialsViewModel : WinBioViewModel, IWinBioRemoveAllCredentialsViewModel
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

                        this.BiometricService.RemoveAllCredentials();

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        public override string Name => "WinBioRemoveAllCredentials";

        #endregion

    }

}