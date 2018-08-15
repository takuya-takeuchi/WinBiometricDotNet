using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IAsyncOpenSessionChildWindowViewModel : IChildWindowViewModel
    {

        Session Session
        {
            get;
        }

    }

}