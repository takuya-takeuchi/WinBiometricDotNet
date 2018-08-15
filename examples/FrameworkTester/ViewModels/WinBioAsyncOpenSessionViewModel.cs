using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using FrameworkTester.Views;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;
using WINBIO_SESSION_HANDLE = System.UInt32;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioAsyncOpenSessionViewModel : WinBioWithCallbackViewModel, IWinBioAsyncOpenSessionViewModel, IWinBioAsyncChildWindowViewModel
    {

        #region Constructors

        public WinBioAsyncOpenSessionViewModel()
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
                    var childWindow = new AsyncOpenSessionChildWindowViewModel(newWindow, this.MessageCode + 0x8000);
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
                        this.SessionHandle = 0;
                        this.UpdateUIImmediately();

                        var session = this.HandleRepository.SelectedHandle.Session;
                        switch (this.SelectedMethod)
                        {
                            case AsyncNotificationMethod.NotifyCallback:
                                if (this.Async)
                                    this.BiometricService.AsyncOpenSession(IntPtr.Zero);
                                else
                                    this.SessionHandle = this.BiometricService.OpenSession(IntPtr.Zero).Handle;
                                break;
                            case AsyncNotificationMethod.NotifyMessage:
                                var childWindow = this.HandleRepository.SelectedHandle;
                                var handle = childWindow.Handle;
                                var code = childWindow.MessageCode;
                                if (this.Async)
                                    this.BiometricService.AsyncOpenSession(handle, code);
                                else
                                {
                                    var result = this.BiometricService.OpenSession(handle, code);
                                    this.SessionHandle = result.Handle;

                                    childWindow.Attach(result);
                                }
                                break;
                        }

                        this.WaitCallback = true;
                        this.Result = "OK";

                        if (this.EnableWait)
                        {
                            name = "WinBioWait";
                            this.BiometricService.Wait(session);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";

                        this.WaitCallback = false;
                    }
                }, this.CanExecuteCommand));
            }
        }

        public override string Name => "WinBioAsyncOpenSession";

        private RelayCommand _CancelCommand;

        public override RelayCommand CancelCommand
        {
            get
            {
                return this._CancelCommand ?? (this._CancelCommand = new RelayCommand(() =>
                {
                    try
                    {
                        var session = this.HandleRepository.SelectedHandle.Session;
                        this.BiometricService.Cancel(session);

                        this.WaitCallback = false;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "WinBioCancel", MessageBoxButton.OK, MessageBoxImage.Error);

                        this.WaitCallback = true;
                    }
                }, () => this.WaitCallback));
            }
        }

        private bool _EnableWait;

        public override bool EnableWait
        {
            get => this._EnableWait;
            set
            {
                this._EnableWait = value;
                this.RaisePropertyChanged();
            }
        }

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

        private WINBIO_SESSION_HANDLE _SessionHandle;

        public WINBIO_SESSION_HANDLE SessionHandle
        {
            get => this._SessionHandle;
            private set
            {
                this._SessionHandle = value;
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