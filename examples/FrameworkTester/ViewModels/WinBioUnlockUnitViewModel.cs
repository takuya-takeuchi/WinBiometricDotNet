using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioUnlockUnitViewModel : WinBioSessionViewModel, IWinBioUnlockUnitViewModel
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
                        this.BiometricService.UnlockUnit(session, this.SelectedUnit.UnitId);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.HandleRepository?.SelectedHandle != null));
            }
        }

        public override string Name => "WinBioUnlockUnit";

        #endregion

    }

}