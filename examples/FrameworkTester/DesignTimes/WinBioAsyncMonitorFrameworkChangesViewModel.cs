using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioAsyncMonitorFrameworkChangesViewModel : WinBioViewModel, IWinBioAsyncMonitorFrameworkChangesViewModel
    {

        public RelayCommand CancelCommand
        {
            get;
        }

        public bool EnableWait
        {
            get;
            set;
        }

        public IHandleRepositoryViewModel<IFrameworkHandleViewModel> HandleRepository
        {
            get;
        }

        public IEnumerable<ChangeTypes> ChangeTypes
        {
            get;
        }

        public ChangeTypes SelectedChangeType
        {
            get;
            set;
        }

    }

}