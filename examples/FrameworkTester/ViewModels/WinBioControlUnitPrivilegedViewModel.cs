using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioControlUnitPrivilegedViewModel : WinBioSessionViewModel, IWinBioControlUnitPrivilegedViewModel
    {

        #region Constructors

        public WinBioControlUnitPrivilegedViewModel()
        {
            this.Components = Enum.GetValues(typeof(Component)).Cast<Component>().ToArray();
            this.SelectedComponent = this.Components.First();
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
                    this.OperationStatus = 0;
                    this.ReceiveDataSize = 0;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var path = this.SendBufferFile;
                        if (!File.Exists(path))
                            throw new FileNotFoundException(path);

                        var sendBuffer = File.ReadAllBytes(path);
                        var receiveBuffer = new byte[this.ReceiveBufferSize];

                        var session = this.HandleRepository.SelectedHandle.Session;
                        this.BiometricService.ControlUnitPrivileged(session, 
                                                                    this.SelectedUnit.UnitId,
                                                                    this.SelectedComponent,
                                                                    this.ControlCode,
                                                                    sendBuffer,
                                                                    receiveBuffer,
                                                                    out var receiveDataSize,
                                                                    out var operationStatus);

                        this.Result = "OK";

                        this.OperationStatus = operationStatus;
                        this.ReceiveDataSize = (uint)receiveDataSize;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.HandleRepository?.SelectedHandle != null));
            }
        }

        public override string Name => "WinBioControlUnitPrivileged";
        
        public IEnumerable<Component> Components
        {
            get;
        }

        private uint _ControlCode;

        public uint ControlCode
        {
            get => this._ControlCode;
            set
            {
                this._ControlCode = value;
                this.RaisePropertyChanged();
            }
        }

        private string _SendBufferFile;

        public string SendBufferFile
        {
            get => this._SendBufferFile;
            set
            {
                this._SendBufferFile = value;
                this.RaisePropertyChanged();
            }
        }

        private Component _SelectedComponent;

        public Component SelectedComponent
        {
            get => this._SelectedComponent;
            set
            {
                this._SelectedComponent = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _OperationStatus;

        public uint OperationStatus
        {
            get => this._OperationStatus;
            private set
            {
                this._OperationStatus = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _ReceiveBufferSize;

        public uint ReceiveBufferSize
        {
            get => this._ReceiveBufferSize;
            set
            {
                this._ReceiveBufferSize = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _ReceiveDataSize;

        public uint ReceiveDataSize
        {
            get => this._ReceiveDataSize;
            private set
            {
                this._ReceiveDataSize = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}