using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnumServiceProvidersViewModel : WinBioViewModel, IWinBioEnumServiceProvidersViewModel
    {

        #region Properties

        private BiometricServiceProvider _CurrentServiceProvider;

        public BiometricServiceProvider CurrentServiceProvider
        {
            get => this._CurrentServiceProvider;
            set
            {
                this._CurrentServiceProvider = value;
                this.RaisePropertyChanged();
            }
        }

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

                        this.ServiceProviders.Clear();
                        foreach (var provider in this.BiometricService.EnumServiceProviders())
                            this.ServiceProviders.Add(provider);

                        if (this.ServiceProviders.Any())
                            this.CurrentServiceProvider = this.ServiceProviders.FirstOrDefault();

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

        public override string Name => "WinBioEnumServiceProviders";

        public ObservableCollection<BiometricServiceProvider> ServiceProviders
        {
            get;
        } = new ObservableCollection<BiometricServiceProvider>();
        
        #endregion

    }

}