using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioEnrollCaptureViewModel : WinBioViewModel, IWinBioEnrollCaptureViewModel
    {

        public RejectDetails RejectDetail
        {
            get;
        }

    }

}