using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;
using WinBiometricDotNet.Runtime.InteropServices;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioVerifyWithCallbackViewModel : WinBioWithCallbackViewModel, IWinBioVerifyWithCallbackViewModel
    {

        #region Constructors

        public WinBioVerifyWithCallbackViewModel()
        {
            this.FingerPositions = Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>().ToArray();

            WinBiometric.Verified -= this.WinBiometricVerified;
            WinBiometric.Verified += this.WinBiometricVerified;

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
                    this.IsMatch = false;
                    this.UnitId = 0;
                    this.RejectDetail = 0;
                    var name = this.Name;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var session = this.HandleRepository.SelectedHandle.Session;
                        this.BiometricService.VerifyWithCallback(session, this.SelectedFingerPosition);

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

        private bool _IsMatch;

        public bool IsMatch
        {
            get
            {
                return this._IsMatch;
            }
            private set
            {
                this._IsMatch = value;
                this.RaisePropertyChanged();
            }
        }

        public override string Name => "WinBioVerifyWithCallback";

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

        private FingerPosition _SelectedFingerPosition;

        public FingerPosition SelectedFingerPosition
        {
            get
            {
                return this._SelectedFingerPosition;
            }
            set
            {
                this._SelectedFingerPosition = value;
                this.RaisePropertyChanged();
            }
        }

        public IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricVerified(object sender, VerifyEventArgs e)
        {
            this.DispatcherService.SafeAction(() =>
            {
                this.WaitCallback = false;
            });

            this.Result = Marshal.GetWinBiometricExceptionFromHR(e.Result.OperationStatus).Message;

            this.RejectDetail = e.Result.RejectDetail;
            this.IsMatch = e.Result.IsMatch;
            this.UnitId = e.Result.UnitId;
        }

        #endregion

        #endregion

    }

}