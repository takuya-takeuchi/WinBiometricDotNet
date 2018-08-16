using System;
using System.Collections.ObjectModel;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnumBiometricUnitsViewModel : WinBioViewModel, IWinBioEnumBiometricUnitsViewModel
    {

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

                        this.Units.Clear();
                        foreach (var unit in this.BiometricService.EnumBiometricUnits())
                            this.Units.Add(unit);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        public override string Name => "WinBioEnumBiometricUnits";

        public ObservableCollection<BiometricUnit> Units
        {
            get;
        } = new ObservableCollection<BiometricUnit>();

        #endregion

    }

}