using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnrollBeginViewModel : IWinBioViewModel
    {

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