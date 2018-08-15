using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnrollBeginViewModel : WinBioSessionViewModel, IWinBioEnrollBeginViewModel
    {

        #region Constructors

        public WinBioEnrollBeginViewModel()
        {
            this.FingerPositions = Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>().ToArray();
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
                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var session = this.WindowRepository.SelectedWindow.Session;
                        this.BiometricService.BeginEnroll(session, this.SelectedFingerPosition, this.CurrentUnit.UnitId);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.WindowRepository?.SelectedWindow != null));
            }
        }

        public override string Name => "WinBioEnrollBegin";

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

    }

}