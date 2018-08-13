using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public abstract class WinBioPropertyViewModel : WinBioViewModel, IWinBioPropertyViewModel
    {

        #region Properties

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    this.Source = 0;
                    this.Value = false;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        this.GetValueAndSource(out var value, out var source);

                        this.Result = "OK";

                        this.Source = source;
                        this.Value = value;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        private SettingSourceTypes _Source;

        public SettingSourceTypes Source
        {
            get => this._Source;
            private set
            {
                this._Source = value;
                this.RaisePropertyChanged();
            }
        }

        private bool _Value;

        public bool Value
        {
            get => this._Value;
            private set
            {
                this._Value = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        protected abstract void GetValueAndSource(out bool value, out SettingSourceTypes source);

        #endregion

    }

}