using System.Collections.Generic;
using FrameworkTester.ViewModels;
using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetPropertyViewModel : WinBioViewModel, IWinBioGetPropertyViewModel, IWinBioAsyncSessionViewModel
    {

        public IEnumerable<PropertyViewModel> Properties
        {
            get;
        }

        public PropertyViewModel SelectedProperty
        {
            get;
            set;
        }

        public PropertyViewModel ResultProperty
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}