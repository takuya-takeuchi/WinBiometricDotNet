using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;
using WinBiometricDotNet.Runtime.InteropServices;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnrollCaptureWithCallbackViewModel : WinBioWithCallbackViewModel, IWinBioEnrollCaptureWithCallbackViewModel
    {

        #region Constructors

        public WinBioEnrollCaptureWithCallbackViewModel()
        {
            WinBiometric.EnrollCaptured -= this.WinBiometricEnrollCaptured;
            WinBiometric.EnrollCaptured += this.WinBiometricEnrollCaptured;

            this.WaitCallback = false;
        }

        #endregion

        #region Properties

        private RelayCommand _CancelCommand;

        public override RelayCommand CancelCommand
        {
            get
            {
                return this._CancelCommand ?? (this._CancelCommand = new RelayCommand(() =>
                {
                    try
                    {
                        var session = this.HandleRepository.SelectedHandle.Session;
                        this.BiometricService.Cancel(session);

                        this.WaitCallback = false;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "WinBioCancel", MessageBoxButton.OK, MessageBoxImage.Error);

                        this.WaitCallback = true;
                    }
                }, () => this.WaitCallback));
            }
        }

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    this.RejectDetail = 0;
                    var name = this.Name;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var session = this.HandleRepository.SelectedHandle.Session;
                        this.BiometricService.CaptureEnrollWithCallback(session);

                        this.WaitCallback = true;

                        if (this.EnableWait)
                        {
                            name = "WinBioWait";
                            this.BiometricService.Wait(session);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";

                        this.WaitCallback = false;
                    }
                }, () => !this.WaitCallback && this.HandleRepository?.SelectedHandle != null));
            }
        }

        private bool _EnableWait;

        public override bool EnableWait
        {
            get => this._EnableWait;
            set
            {
                this._EnableWait = value;
                this.RaisePropertyChanged();
            }
        }

        public override string Name => "WinBioEnrollCaptureWithCallback";

        private RejectDetail _RejectDetail;

        public RejectDetail RejectDetail
        {
            get
            {
                return this._RejectDetail;
            }
            private set
            {
                this._RejectDetail = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricEnrollCaptured(object sender, EnrollCapturedEventArgs e)
        {
            this.DispatcherService.SafeAction(() =>
            {
                this.WaitCallback = false;
            });

            this.Result = Marshal.GetWinBiometricExceptionFromHR(e.Result.OperationStatus).Message;

            this.RejectDetail = e.Result.RejectDetail;
        }

        #endregion

        #endregion

    }

}