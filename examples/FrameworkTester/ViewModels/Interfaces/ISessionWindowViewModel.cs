using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface ISessionWindowViewModel : IChildWindowViewModel
    {

        Session Session
        {
            get;
        }

    }

}