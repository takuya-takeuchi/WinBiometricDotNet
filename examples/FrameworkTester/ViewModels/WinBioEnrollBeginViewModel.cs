using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnrollBeginViewModel : WinBioViewModel, IWinBioEnrollBeginViewModel
    {

        #region Fields

        private readonly IWinBiometricService _Service;

        #endregion

        #region Constructors

        public WinBioEnrollBeginViewModel()
        {
            this._Service = SimpleIoc.Default.GetInstance<IWinBiometricService>();
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
                        this._Service.BeginEnroll(this.SelectedFingerPosition, this.CurrentUnit.UnitId);
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