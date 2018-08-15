using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface ISessionHandleViewModel : IHandleViewModel
    {

        Session Session
        {
            get;
        }

    }

}