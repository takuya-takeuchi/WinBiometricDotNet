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
            this.PropertyTypes = Enum.GetValues(typeof(PropertyTypes)).Cast<PropertyTypes>().ToArray();

            this.CurrentPropertyType = this.PropertyTypes.First();

            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
        }

        #endregion

        #region Properties

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

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public abstract string Name
        {
            get;
        }

        public IEnumerable<PropertyTypes> PropertyTypes
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