using WINBIO_FRAMEWORK_HANDLE = System.UInt32;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncOpenFrameworkViewModel : IWinBioWithCallbackViewModel, IWinBioAsyncFrameworkViewModel, IWinBioViewModel
    {

        WINBIO_FRAMEWORK_HANDLE FrameworkHandle
        {
            get;
        }

    }

}