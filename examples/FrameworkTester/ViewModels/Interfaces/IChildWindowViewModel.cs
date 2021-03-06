﻿using System;
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

        ObservableCollection<AsyncResult> AsyncResultLogs
        {
            get;
        }

        AsyncResult SelectedAsyncResult
        {
            get;
            set;
        }

        AsyncResultParameter SelectedAsyncResultParameter
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

        OperationType OperationType
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