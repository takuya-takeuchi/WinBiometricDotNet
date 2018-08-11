using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioEnrollCaptureViewModel : IWinBioViewModel
    {

        RejectDetails RejectDetail
        {
            get;
        }

    }

}