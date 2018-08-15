using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioLocateSensorViewModel : WinBioSessionViewModel, IWinBioLocateSensorViewModel
    {

        #region Properties

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    this.UnitId = 0;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var session = this.HandleRepository.SelectedHandle.Session;
                        var result = this.BiometricService.LocateSensor(session);

                        this.Result = "OK";

                        this.UnitId = result;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.HandleRepository?.SelectedHandle != null));
            }
        }

        public override string Name => "WinBioLocateSensor";

        private uint _UnitId;

        public uint UnitId
        {
            get
            {
                return this._UnitId;
            }
            private set
            {
                this._UnitId = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}