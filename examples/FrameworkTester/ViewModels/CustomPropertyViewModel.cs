using System;
using System.Collections.Generic;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class CustomPropertyViewModel : PropertyViewModel
    {

        #region Constructors

        public CustomPropertyViewModel()
        {
            this.FingerPositions = Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>().ToArray();
            this.PropertyIds = Enum.GetValues(typeof(PropertyId)).Cast<PropertyId>().ToArray();

            this.CurrentFingerPosition = this.FingerPositions.First();
            this.CurrentPropertyType = this.PropertyTypes.First();
            this.CurrentPropertyId = this.PropertyIds.First();

            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
        }

        #endregion

        #region Properties

        public override string Name => "Custom";

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

        public IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

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

        #endregion

    }

}