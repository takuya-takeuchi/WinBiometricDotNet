using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioOpenSessionViewModel : WinBioViewModel, IWinBioOpenSessionViewModel
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

                        var session = this.BiometricService.OpenSession();

                        this.Result = "OK";

                        this.SessionHandle = session.Handle;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        public override string Name => "WinBioOpenSession";

        private UIntPtr _SessionHandle;

        public UIntPtr SessionHandle
        {
            get
            {
                return this._SessionHandle;
            }
            private set
            {
                this._SessionHandle = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}