namespace FrameworkTester.ViewModels
{

    public sealed class SampleHintPropertyViewModel : PropertyViewModel
    {

        #region Properties

        public override string Name => "WINBIO_PROPERTY_SAMPLE_HINT";

        private uint _MaximumNumberOfGoodBiometricSamples;

        public uint MaximumNumberOfGoodBiometricSamples
        {
            get => this._MaximumNumberOfGoodBiometricSamples;
            set
            {
                this._MaximumNumberOfGoodBiometricSamples = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}