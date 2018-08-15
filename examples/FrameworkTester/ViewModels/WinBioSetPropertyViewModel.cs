using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioSetPropertyViewModel : WinBioSessionViewModel, IWinBioSetPropertyViewModel
    {

        #region Constructors

        public WinBioSetPropertyViewModel()
        {
            this.Properties = new PropertyViewModel[] { new AntiSpoofPolicyPropertyViewModel() };

            this.SelectedProperty = this.Properties.First();

            foreach (var property in this.Properties)
            {
                property.PropertyChanged += (sender, args) =>
                {
                    this.ExecuteCommand.RaiseCanExecuteChanged();
                };
            }
        }

        #endregion

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

                        var session = this.WindowRepository.SelectedWindow.Session;

                        switch (this.SelectedProperty)
                        {
                            case AntiSpoofPolicyPropertyViewModel anti:
                                var asp = new AntiSpoofPolicy
                                {
                                    Action = anti.SelectedAction,
                                    Source = anti.SelectedSource
                                };

                                this.BiometricService.SetAntiSpoofPolicyProperty(session,
                                                                                 anti.SelectedPropertyType,
                                                                                 anti.IdentityRepository.SelectedIdentity,
                                                                                 asp);
                                break;
                            case CustomPropertyViewModel _:
                                break;
                        }

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.WindowRepository?.SelectedWindow != null && this.SelectedProperty.CanExecute()));
            }
        }

        public override string Name => "WinBioSetProperty";

        public IEnumerable<PropertyViewModel> Properties
        {
            get;
        }

        private PropertyViewModel _SelectedProperty;

        public PropertyViewModel SelectedProperty
        {
            get => this._SelectedProperty;
            set
            {
                this._SelectedProperty = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}