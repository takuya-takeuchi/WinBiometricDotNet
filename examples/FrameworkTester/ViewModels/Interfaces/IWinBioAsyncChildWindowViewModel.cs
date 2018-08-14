using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncChildWindowViewModel
    {

        bool Async
        {
            get;
            set;
        }

        bool EnableChildWindows
        {
            get;
        }

        bool EnableMessageCode
        {
            get;
        }

        RelayCommand AddWindowCommand
        {
            get;
        }

        uint MessageCode
        {
            get;
            set;
        }

        IEnumerable<AsyncNotificationMethod> Methods
        {
            get;
        }

        AsyncNotificationMethod SelectedMethod
        {
            get;
            set;
        }

    }

}