using System;
using System.Collections.ObjectModel;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnumBiometricUnitsViewModel : ViewModelBase, IWinBioEnumBiometricUnitsViewModel
    {

        #region Fields

        private readonly IWinBiometricService _Service;

        #endregion

        #region Constructors

        public WinBioEnumBiometricUnitsViewModel()
        {
            this._Service = SimpleIoc.Default.GetInstance<IWinBiometricService>();
        }

        #endregion

        #region Properties

        private RelayCommand _ExecuteCommand;

        public RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this._Units.Clear();
                        foreach (var unit in this._Service.EnumBiometricUnits())
                            this._Units.Add(unit);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        public string Name => "WinBioEnumBiometricUnits";

        private string _Result;

        public string Result
        {
            get
            {
                return this._Result;
            }
            private set
            {
                this._Result = value;
                this.RaisePropertyChanged();
            }
        }

        private readonly ObservableCollection<BiometricUnit> _Units = new ObservableCollection<BiometricUnit>();

        public ObservableCollection<BiometricUnit> Units
        {
            get
            {
                return this._Units;
            }
        }

        #endregion

    }

}