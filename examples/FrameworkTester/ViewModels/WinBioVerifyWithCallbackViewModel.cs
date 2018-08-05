using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using FrameworkTester.Helpers;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioVerifyWithCallbackViewModel : WinBioViewModel, IWinBioVerifyWithCallbackViewModel
    {

        #region Fields

        private readonly IWinBiometricService _Service;

        #endregion

        #region Constructors

        public WinBioVerifyWithCallbackViewModel()
        {
            this._Service = SimpleIoc.Default.GetInstance<IWinBiometricService>();
            this._FingerPositions = Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>().ToArray();
            WinBiometric.Verified += this.WinBiometricVerified;
        }

        #endregion

        #region Properties

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

                    try
                    {
                        this.Result = "WAIT";
                        this._Service.VerifyWithCallback(this.CurrentUnit, this.SelectedFingerPosition);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";
                    }
                }));
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

        private RejectDetails _RejectDetail;

        public RejectDetails RejectDetail
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

        private IEnumerable<FingerPosition> _FingerPositions;

        public IEnumerable<FingerPosition> FingerPositions
        {
            get
            {
                return this._FingerPositions;
            }
            private set
            {
                this._FingerPositions = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricVerified(object sender, VerifyEventArgs e)
        {
            switch (e.Result.OperationStatus)
            {
                case OperationStatus.OK:
                    this.Result = "OK";
                    break;
                case OperationStatus.BadCapture:
                    this.Result = "BadCapture";
                    break;
                case OperationStatus.Canceled:
                    this.Result = "Canceled";
                    break;
                case OperationStatus.NoMatch:
                    this.Result = "NoMatch";
                    break;
                case OperationStatus.Unknown:
                    this.Result = "Unknown";
                    break;
            }

            this.RejectDetail = e.Result.RejectDetail;
            this.IsMatch = e.Result.IsMatch;
            this.UnitId = e.Result.UnitId;
        }

        #endregion

        #endregion

    }

}