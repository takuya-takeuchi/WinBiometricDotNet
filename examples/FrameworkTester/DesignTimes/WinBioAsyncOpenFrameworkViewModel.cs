using System;
using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioAsyncOpenFrameworkViewModel : WinBioViewModel, IWinBioAsyncOpenFrameworkViewModel
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

        public IWindowRepositoryViewModel<IFrameworkWindowViewModel> WindowRepository
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

        public UIntPtr FrameworkHandle
        {
            get;
        }

    }

}