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

    public sealed class WinBioGetPropertyViewModel : WinBioViewModel, IWinBioGetPropertyViewModel
    {

        #region Constructors

        public WinBioGetPropertyViewModel()
        {
            this.FingerPositions = Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>().ToArray();
            this.PropertyTypes = Enum.GetValues(typeof(PropertyTypes)).Cast<PropertyTypes>().ToArray();
            this.PropertyIds = Enum.GetValues(typeof(PropertyId)).Cast<PropertyId>().ToArray();

            this.CurrentFingerPosition = this.FingerPositions.First();
            this.CurrentPropertyType = this.PropertyTypes.First();
            this.CurrentPropertyId = this.PropertyIds.First();

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

        private PropertyId _CurrentPropertyId;

        public PropertyId CurrentPropertyId
        {
            get => this._CurrentPropertyId;
            set
            {
                this._CurrentPropertyId = value;
                this.RaisePropertyChanged();
            }
        }

        private PropertyTypes _CurrentPropertyType;

        public PropertyTypes CurrentPropertyType
        {
            get => this._CurrentPropertyType;
            set
            {
                this._CurrentPropertyType = value;
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
                    this.PropertyBuffer = null;

                    try
                    {
                        this.Result = "WAIT";

                        var propertyType = this.CurrentPropertyType;
                        var propertyId = this.CurrentPropertyId;
                        var unitId = this.CurrentUnit;
                        var identity = this.IdentityRepository.CurrentBiometricIdentity;
                        var fingerPosition = this.CurrentFingerPosition;

                        this.BiometricService.GetProperty(propertyType,
                                                          propertyId,
                                                          unitId.UnitId,
                                                          identity,
                                                          fingerPosition, 
                                                          out var propertyBuffer);

                        this.Result = "OK";

                        this.PropertyBuffer = propertyBuffer;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }));
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

        public override string Name => "WinBioGetProperty";

        private byte[] _PropertyBuffer;

        public byte[] PropertyBuffer
        {
            get => this._PropertyBuffer;
            private set
            {
                this._PropertyBuffer = value;
                this.RaisePropertyChanged();
            }
        }

        public IEnumerable<PropertyId> PropertyIds
        {
            get;
        }

        public IEnumerable<PropertyTypes> PropertyTypes
        {
            get;
        }

        #endregion

    }

}
