using System.Collections.Generic;
using System.Collections.ObjectModel;
using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnumEnrollmentsViewModel : WinBioViewModel, IWinBioEnumEnrollmentsViewModel, IWinBioAsyncSessionViewModel
    {

        public ObservableCollection<KeyValuePair<string, bool>> FingerPositions
        {
            get;
        }

        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

    }

}