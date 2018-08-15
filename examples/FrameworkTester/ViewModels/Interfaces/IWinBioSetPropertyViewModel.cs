using System.Collections.Generic;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioSetPropertyViewModel : IWinBioViewModel
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

    }

}