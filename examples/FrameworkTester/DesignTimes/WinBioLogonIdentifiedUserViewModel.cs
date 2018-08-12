using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioLogonIdentifiedUserViewModel : WinBioViewModel, IWinBioLogonIdentifiedUserViewModel
    {

        public bool ReturnValue
        {
            get;
        }

    }

}