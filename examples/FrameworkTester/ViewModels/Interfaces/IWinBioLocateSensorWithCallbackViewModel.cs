using GalaSoft.MvvmLight.Command;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioLocateSensorWithCallbackViewModel : IWinBioViewModel
    {

        RelayCommand CancelCommand
        {
            get;
        }

        uint UnitId
        {
            get;
        }

    }

}