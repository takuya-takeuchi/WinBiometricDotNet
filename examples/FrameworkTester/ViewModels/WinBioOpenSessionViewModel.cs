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
                        var session = this.BiometricService.OpenSession();
                        this.SessionHandle = session.Handle;

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        public override string Name => "WinBioOpenSession";

        private IntPtr _SessionHandle;

        public IntPtr SessionHandle
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