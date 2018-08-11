using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioVerifyViewModel : IWinBioViewModel
    {

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