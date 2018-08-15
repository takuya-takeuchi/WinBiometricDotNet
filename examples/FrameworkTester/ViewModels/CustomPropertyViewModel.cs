using System;
using System.Collections.Generic;
using System.Linq;
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

            this.SelectedFingerPosition = this.FingerPositions.First();
            this.SelectedPropertyId = this.PropertyIds.First();
        }

        #endregion

        #region Properties

        public override string Name => "Custom";

        private FingerPosition _SelectedFingerPosition;

        public FingerPosition SelectedFingerPosition
        {
            get => this._SelectedFingerPosition;
            set
            {
                this._SelectedFingerPosition = value;
                this.RaisePropertyChanged();
            }
        }

        private PropertyId _SelectedPropertyId;

        public PropertyId SelectedPropertyId
        {
            get => this._SelectedPropertyId;
            set
            {
                this._SelectedPropertyId = value;
                this.RaisePropertyChanged();
            }
        }

        public IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        private byte[] _PropertyBuffer;

        public byte[] PropertyBuffer
        {
            get => this._PropertyBuffer;
            set
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

        #region Methods

        public override bool CanExecute()
        {
            return this.IdentityRepository.SelectedIdentity != null;
        }

        #endregion

    }

}