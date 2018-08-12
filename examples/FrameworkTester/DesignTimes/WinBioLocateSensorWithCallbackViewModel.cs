using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioLocateSensorWithCallbackViewModel : WinBioViewModel, IWinBioLocateSensorWithCallbackViewModel
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

        public uint UnitId
        {
            get;
        }

    }

}