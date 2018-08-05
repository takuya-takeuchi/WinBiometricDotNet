using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnumEnrollmentsViewModel : IWinBioViewModel
    {

        ObservableCollection<KeyValuePair<string, bool>> FingerPositions
        {
            get;
        }

    }

}