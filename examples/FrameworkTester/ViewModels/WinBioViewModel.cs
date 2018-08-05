using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioViewModel : ViewModelBase, IWinBioViewModel
    {

        #region Properties

        private BiometricUnit _CurrentUnit;

        public BiometricUnit CurrentUnit
        {
            get
            {
                return this._CurrentUnit;
            }
            set
            {
                this._CurrentUnit = value;
                this.RaisePropertyChanged();
            }
        }
        
        public abstract string Name
        {
            get;
        }

        public abstract RelayCommand ExecuteCommand
        {
            get;
        }

        private string _Result;

        public string Result
        {
            get
            {
                return this._Result;
            }
            protected set
            {
                this._Result = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}