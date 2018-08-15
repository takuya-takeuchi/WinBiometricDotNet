using System;
using System.Collections.Generic;
using System.Linq;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class AntiSpoofPolicyPropertyViewModel : PropertyViewModel
    {

        #region Constructors

        public AntiSpoofPolicyPropertyViewModel()
        {
            this.Actions = Enum.GetValues(typeof(AntiSpoofPolicyAction)).Cast<AntiSpoofPolicyAction>().ToArray();
            this.Sources = Enum.GetValues(typeof(PolicySource)).Cast<PolicySource>().ToArray();

            this.SelectedAction = this.Actions.First();
            this.SelectedSource = this.Sources.First();
        }

        #endregion

        #region Properties

        public override string Name => "WINBIO_PROPERTY_ANTI_SPOOF_POLICY";

        public IEnumerable<AntiSpoofPolicyAction> Actions
        {
            get;
        }

        public IEnumerable<PolicySource> Sources
        {
            get;
        }

        private AntiSpoofPolicyAction _SelectedAction;

        public AntiSpoofPolicyAction SelectedAction
        {
            get => this._SelectedAction;
            set
            {
                this._SelectedAction = value;
                this.RaisePropertyChanged();
            }
        }

        private PolicySource _SelectedSource;

        public PolicySource SelectedSource
        {
            get => this._SelectedSource;
            set
            {
                this._SelectedSource = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        public override bool CanExecute()
        {
            return this.IdentityRepository.CurrentBiometricIdentity != null;
        }

        #endregion

    }

}