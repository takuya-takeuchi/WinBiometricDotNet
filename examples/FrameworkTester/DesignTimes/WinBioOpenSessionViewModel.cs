using System;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioOpenSessionViewModel : IWinBioOpenSessionViewModel
    {

        public RelayCommand ExecuteCommand
        {
            get;
        }

        public string Name
        {
            get;
        }

        public string Result
        {
            get;
        }

        public IntPtr SessionHandle
        {
            get;
        }

    }

}