using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioSetCredentialViewModel : WinBioViewModel, IWinBioSetCredentialViewModel
    {

        #region Constructors

        public WinBioSetCredentialViewModel()
        {
            this.CredentialTypes = Enum.GetValues(typeof(CredentialTypes)).Cast<CredentialTypes>().ToArray();
            this.CredentialFormats = Enum.GetValues(typeof(CredentialFormat)).Cast<CredentialFormat>().ToArray();

            this.SelectedCredentialType = this.CredentialTypes.First();
            this.SelectedCredentialFormat = this.CredentialFormats.First();
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

                        var type = this.SelectedCredentialType;
                        var format = this.SelectedCredentialFormat;
                        // ToDo: Handles with care for this function
                        //        Therefore, it should fail for now
                        var credential = new byte[0];
                        this.BiometricService.SetCredential(type,
                                                            credential,
                                                            format);
               
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

        public override string Name => "WinBioSetCredential";
        
        private CredentialFormat _SelectedCredentialFormat;

        public CredentialFormat SelectedCredentialFormat
        {
            get => this._SelectedCredentialFormat;
            set
            {
                this._SelectedCredentialFormat = value;
                this.RaisePropertyChanged();
            }
        }
        
        private CredentialTypes _SelectedCredentialType;

        public CredentialTypes SelectedCredentialType
        {
            get => this._SelectedCredentialType;
            set
            {
                this._SelectedCredentialType = value;
                this.RaisePropertyChanged();
            }
        }

        public IEnumerable<CredentialFormat> CredentialFormats
        {
            get;
        }

        public IEnumerable<CredentialTypes> CredentialTypes
        {
            get;
        }

        #endregion

    }

}