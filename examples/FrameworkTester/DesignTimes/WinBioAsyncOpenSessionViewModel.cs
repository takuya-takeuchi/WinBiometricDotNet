using System;
using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioAsyncOpenSessionViewModel : WinBioViewModel, IWinBioAsyncOpenSessionViewModel
    {

        public RelayCommand AddWindowCommand
        {
            get;
        }

        public RelayCommand CancelCommand
        {
            get;
        }

        public bool EnableWait
        {
            get;
            set;
        }

        public bool Async
        {
            get;
            set;
        }

        public bool EnableChildWindows
        {
            get;
        }

        public bool EnableMessageCode
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionWindowViewModel> WindowRepository
        {
            get;
        }

        public uint MessageCode
        {
            get;
            set;
        }

        public IEnumerable<AsyncNotificationMethod> Methods
        {
            get;
            set;
        }

        public AsyncNotificationMethod SelectedMethod
        {
            get;
            set;
        }

        public IntPtr SessionHandle
        {
            get;
        }

    }

}