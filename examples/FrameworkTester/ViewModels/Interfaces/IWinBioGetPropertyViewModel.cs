using System.Collections.Generic;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioGetPropertyViewModel : IWinBioViewModel
    {

        IEnumerable<PropertyViewModel> Properties
        {
            get;
        }

        PropertyViewModel SelectedProperty
        {
            get;
            set;
        }

        PropertyViewModel ResultProperty
        {
            get;
        }

    }

}