using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IChildWindowViewModel
    {

        IntPtr Handle
        {
            get;
        }

        DateTime LastReceived
        {
            get;
        }

        RelayCommand ClearLogsCommand
        {
            get;
        }

        ObservableCollection<string> Logs
        {
            get;
        }

        uint MessageCode
        {
            get;
        }

        int ApiStatus
        {
            get;
        }

        OperationTypes OperationType
        {
            get;
        }

        ulong SequenceNumber
        {
            get;
        }

        uint UnitId
        {
            get;
        }

        IntPtr UserData
        {
            get;
        }

        DateTime TimeStamp
        {
            get;
        }

    }

}