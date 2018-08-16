using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnrollCaptureViewModel : IWinBioViewModel
    {

        RejectDetail RejectDetail
        {
            get;
        }

    }

}