using WINBIO_SESSION_HANDLE = System.UInt32;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioOpenSessionViewModel : IWinBioViewModel
    {

        WINBIO_SESSION_HANDLE SessionHandle
        {
            get;
        }

    }

}
