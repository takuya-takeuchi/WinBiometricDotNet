using System.Collections.Generic;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioVerifyWithCallbackViewModel : IWinBioViewModel
    {

        RelayCommand CancelCommand
        {
            get;
        }

        bool IsMatch
        {
            get;
        }

        RejectDetails RejectDetail
        {
            get;
        }

        uint UnitId
        {
            get;
        }

        FingerPosition SelectedFingerPosition
        {
            get;
            set;
        }

        IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

    }

}