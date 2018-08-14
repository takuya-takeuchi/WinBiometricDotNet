using System;
using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class ChildWindowViewModel : ViewModelBase, IChildWindowViewModel
    {

        public IntPtr Handle
        {
            get;
        }

        public DateTime LastReceived
        {
            get;
        }

        public RelayCommand ClearLogsCommand
        {
            get;
        }

        public ObservableCollection<string> Logs
        {
            get;
        }

        public uint MessageCode
        {
            get;
        }

        public int ApiStatus
        {
            get;
        }

        public OperationTypes OperationType
        {
            get;
        }

        public ulong SequenceNumber
        {
            get;
        }

        public IntPtr SessionHandle
        {
            get;
        }

        public uint UnitId
        {
            get;
        }

        public IntPtr UserData
        {
            get;
        }

        public DateTime TimeStamp
        {
            get;
        }

    }

}