using System.Collections.Generic;
using System.Collections.ObjectModel;

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