using System;
using System.Collections.Generic;
using System.Linq;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public abstract class PropertyViewModel : ViewModelBase
    {

        #region Constructors

        protected PropertyViewModel()
        {
            this.PropertyTypes = Enum.GetValues(typeof(PropertyType)).Cast<PropertyType>().ToArray();

            this.SelectedPropertyType = this.PropertyTypes.First();

            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
        }

        #endregion

        #region Properties

        private PropertyType _SelectedPropertyType;

        public PropertyType SelectedPropertyType
        {
            get => this._SelectedPropertyType;
            set
            {
                this._SelectedPropertyType = value;
                this.RaisePropertyChanged();
            }
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public abstract string Name
        {
            get;
        }

        public IEnumerable<PropertyType> PropertyTypes
        {
            get;
        }

        #endregion

        #region Methods

        public virtual bool CanExecute()
        {
            return true;
        }

        #endregion

    }

}