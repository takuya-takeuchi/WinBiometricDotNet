using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioGetPropertyViewModel : WinBioSessionViewModel, IWinBioGetPropertyViewModel
    {
        #region Fields

        private readonly AntiSpoofPolicyPropertyViewModel _AntiSpoofPolicyPropertyResult = new AntiSpoofPolicyPropertyViewModel();

        private readonly SampleHintPropertyViewModel _SampleHintPropertyResult = new SampleHintPropertyViewModel();

        private readonly CustomPropertyViewModel _CustomPropertyResult = new CustomPropertyViewModel();

        #endregion

        #region Constructors

        public WinBioGetPropertyViewModel()
        {
            this.Properties = new PropertyViewModel[]
            {
                new SampleHintPropertyViewModel(),
                new AntiSpoofPolicyPropertyViewModel(),
                new CustomPropertyViewModel()
            };

            this.SelectedProperty = this.Properties.First();

            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
            this.IdentityRepository.PropertyChanged += (sender, args) =>
            {
                this.ExecuteCommand.RaiseCanExecuteChanged();
            };

            foreach (var property in this.Properties)
            {
                property.PropertyChanged += (sender, args) =>
                {
                    this.ExecuteCommand.RaiseCanExecuteChanged();
                };
            }
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

                        switch (this.SelectedProperty)
                        {
                            case AntiSpoofPolicyPropertyViewModel anti:
                                var asp = this.BiometricService.GetAntiSpoofPolicyProperty(session,
                                                                                           anti.SelectedPropertyType,
                                                                                           anti.IdentityRepository.SelectedIdentity);

                                this._AntiSpoofPolicyPropertyResult.SelectedAction = asp.Action;
                                this._AntiSpoofPolicyPropertyResult.SelectedSource = asp.Source;

                                this.ResultProperty = this._AntiSpoofPolicyPropertyResult;
                                break;
                            case SampleHintPropertyViewModel sample:
                                var num = this.BiometricService.GetSampleHintProperty(session,
                                                                                      sample.SelectedPropertyType,
                                                                                      this.SelectedUnit.UnitId);

                                this._SampleHintPropertyResult.MaximumNumberOfGoodBiometricSamples = num;

                                this.ResultProperty = this._SampleHintPropertyResult;
                                break;
                            case CustomPropertyViewModel custom:
                                var propertyType = custom.SelectedPropertyType;
                                var propertyId = custom.SelectedPropertyId;
                                var unitId = this.SelectedUnit;
                                var identity = this.IdentityRepository.SelectedIdentity;
                                var fingerPosition = custom.SelectedFingerPosition;

                                this.BiometricService.GetProperty(session,
                                                                  propertyType,
                                                                  propertyId,
                                                                  unitId.UnitId,
                                                                  identity,
                                                                  fingerPosition,
                                                                  out var propertyBuffer);

                                this._CustomPropertyResult.PropertyBuffer = propertyBuffer;

                                this.ResultProperty = this._CustomPropertyResult;
                                break;
                        }

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.WindowRepository?.SelectedWindow != null && this.SelectedProperty.CanExecute()));
            }
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public override string Name => "WinBioGetProperty";

        public IEnumerable<PropertyViewModel> Properties
        {
            get;
        }

        private PropertyViewModel _SelectedProperty;

        public PropertyViewModel SelectedProperty
        {
            get => this._SelectedProperty;
            set
            {
                this._SelectedProperty = value;
                this.RaisePropertyChanged();
                
                switch (this.SelectedProperty)
                {
                    case AntiSpoofPolicyPropertyViewModel _:
                        this.ResultProperty = this._AntiSpoofPolicyPropertyResult;
                        break;
                    case SampleHintPropertyViewModel _:
                        this.ResultProperty = this._SampleHintPropertyResult;
                        break;
                    case CustomPropertyViewModel _:
                        this.ResultProperty = this._CustomPropertyResult;
                        break;
                }
            }
        }

        private PropertyViewModel _ResultProperty;

        public PropertyViewModel ResultProperty
        {
            get => this._ResultProperty;
            private set
            {
                this._ResultProperty = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}
