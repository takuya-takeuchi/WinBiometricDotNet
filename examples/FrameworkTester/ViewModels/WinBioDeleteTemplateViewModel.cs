using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioDeleteTemplateViewModel : WinBioViewModel, IWinBioDeleteTemplateViewModel
    {

        #region Constructors

        public WinBioDeleteTemplateViewModel()
        {
            this.FingerPositions = Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>().ToArray();

            this.CurrentFingerPosition = this.FingerPositions.First();

            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
            this.IdentityRepository.PropertyChanged += (sender, args) =>
            {
                this.ExecuteCommand.RaiseCanExecuteChanged();
            };
        }

        #endregion

        #region Properties

        private FingerPosition _CurrentFingerPosition;

        public FingerPosition CurrentFingerPosition
        {
            get => this._CurrentFingerPosition;
            set
            {
                this._CurrentFingerPosition = value;
                this.RaisePropertyChanged();
            }
        }

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

                        var unitId = this.CurrentUnit;
                        var identity = this.IdentityRepository.CurrentBiometricIdentity;
                        var fingerPosition = this.CurrentFingerPosition;
               
                        this.BiometricService.DeleteTemplate(unitId.UnitId,
                                                             identity,
                                                             fingerPosition);
               
                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.IdentityRepository?.CurrentBiometricIdentity != null));
            }
        }

        public IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public override string Name => "WinBioDeleteTemplate";

        #endregion

    }

}