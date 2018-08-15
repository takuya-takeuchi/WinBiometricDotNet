using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface ISessionHandleViewModel : IHandleViewModel
    {

        Session Session
        {
            get;
        }
        
        void Attach(Session session);

    }

}