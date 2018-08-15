using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WINBIO_SESSION_HANDLE = System.UInt32;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioOpenSessionViewModel : WinBioSessionViewModel, IWinBioOpenSessionViewModel
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

                        this.HandleRepository.Add(new SessionViewModel(session));

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

        private WINBIO_SESSION_HANDLE _SessionHandle;

        public WINBIO_SESSION_HANDLE SessionHandle
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