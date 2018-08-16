using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using FrameworkTester.Views;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;
using WINBIO_FRAMEWORK_HANDLE = System.UInt32;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioAsyncOpenFrameworkViewModel : WinBioFrameworkViewModel, IWinBioAsyncOpenFrameworkViewModel, IWinBioAsyncChildWindowViewModel
    {

        #region Constructors

        public WinBioAsyncOpenFrameworkViewModel()
        {
            this.Methods = new[]
            {
                AsyncNotificationMethod.NotifyCallback,
                AsyncNotificationMethod.NotifyMessage
            };
            this.SelectedMethod = this.Methods.First();

            WinBiometric.AsyncCompleted -= this.WinBiometricAsyncCompleted;
            WinBiometric.AsyncCompleted += this.WinBiometricAsyncCompleted;
        }

        #endregion

        #region Properties

        private RelayCommand _AddWindowCommand;

        public RelayCommand AddWindowCommand
        {
            get
            {
                return this._AddWindowCommand ?? (this._AddWindowCommand = new RelayCommand(() =>
                {
                    var newWindow = new ChildWindow();
                    var childWindow = new AsyncOpenFrameworkChildWindowViewModel(newWindow, this.MessageCode + 0x8000);
                    newWindow.DataContext = childWindow;
                    newWindow.Show();

                    this.HandleRepository.Add(childWindow);
                }));
            }
        }

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    var name = this.Name;

                    try
                    {
                        this.Result = "WAIT";
                        this.FrameworkHandle = 0;
                        this.UpdateUIImmediately();

                        switch (this.SelectedMethod)
                        {
                            case AsyncNotificationMethod.NotifyCallback:
                                if (this.Async)
                                    this.BiometricService.AsyncOpenFramework(IntPtr.Zero);
                                else
                                    this.FrameworkHandle = this.BiometricService.OpenFramework(IntPtr.Zero).Handle;
                                break;
                            case AsyncNotificationMethod.NotifyMessage:
                                var childWindow = this.HandleRepository.SelectedHandle;
                                var handle = childWindow.Handle;
                                var code = childWindow.MessageCode;
                                if (this.Async)
                                    this.BiometricService.AsyncOpenFramework(handle, code);
                                else
                                {
                                    var result = this.BiometricService.OpenFramework(handle, code);
                                    this.FrameworkHandle = result.Handle;

                                    childWindow.Attach(result);
                                }
                                break;
                        }

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, this.CanExecuteCommand));
            }
        }

        public override string Name => "WinBioAsyncOpenFramework";

        private bool _EnableChildWindows;

        public bool EnableChildWindows
        {
            get => this._EnableChildWindows;
            private set
            {
                this._EnableChildWindows = value;
                this.RaisePropertyChanged();
            }
        }

        private bool _EnableMessageCode;

        public bool EnableMessageCode
        {
            get => this._EnableMessageCode;
            private set
            {
                this._EnableMessageCode = value;
                this.RaisePropertyChanged();
            }
        }

        private WINBIO_FRAMEWORK_HANDLE _FrameworkHandle;

        public WINBIO_FRAMEWORK_HANDLE FrameworkHandle
        {
            get => this._FrameworkHandle;
            private set
            {
                this._FrameworkHandle = value;
                this.RaisePropertyChanged();
            }
        }

        private bool _Async;

        public bool Async
        {
            get => this._Async;
            set
            {
                this._Async = value;
                this.RaisePropertyChanged();

                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private uint _MessageCode;

        public uint MessageCode
        {
            get => this._MessageCode;
            set
            {
                this._MessageCode = value;
                this.RaisePropertyChanged();

                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        public IEnumerable<AsyncNotificationMethod> Methods
        {
            get;
        }

        private AsyncNotificationMethod _SelectedMethod;

        public AsyncNotificationMethod SelectedMethod
        {
            get => this._SelectedMethod;
            set
            {
                this._SelectedMethod = value;
                this.RaisePropertyChanged();

                this.ExecuteCommand.RaiseCanExecuteChanged();

                switch (value)
                {
                    case AsyncNotificationMethod.NotifyCallback:
                        this.EnableChildWindows = false;
                        this.EnableMessageCode = false;
                        break;
                    case AsyncNotificationMethod.NotifyMessage:
                        this.EnableChildWindows = true;
                        this.EnableMessageCode = true;
                        break;
                    default:
                        this.EnableChildWindows = false;
                        this.EnableMessageCode = false;
                        break;
                }
            }
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricAsyncCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        #endregion

        #region Helpers

        private bool CanExecuteCommand()
        {
            switch (this.SelectedMethod)
            {
                case AsyncNotificationMethod.NotifyCallback:
                    return true;
                case AsyncNotificationMethod.NotifyMessage:
                    var childWindow = this.HandleRepository?.SelectedHandle;
                    return childWindow != null && childWindow.Handle != IntPtr.Zero;
                default:
                    return false;
            }
        }

        #endregion

        #endregion

    }

}