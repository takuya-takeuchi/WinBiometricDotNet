using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioCloseSessionViewModel : IWinBioCloseSessionViewModel
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

    }

}