using System.Collections.Generic;
using FrameworkTester.ViewModels;
using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioSetPropertyViewModel : WinBioViewModel, IWinBioSetPropertyViewModel, IWinBioAsyncSessionViewModel
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

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}