using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncMonitorFrameworkChangesViewModel : IWinBioWithCallbackViewModel, IWinBioAsyncFrameworkViewModel, IWinBioViewModel
    {

        IEnumerable<ChangeTypes> ChangeTypes
        {
            get;
        }

        ChangeTypes SelectedChangeType
        {
            get;
            set;
        }

    }

}