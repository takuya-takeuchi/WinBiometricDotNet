using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IFrameworkHandleViewModel : IHandleViewModel
    {

        Framework Framework
        {
            get;
        }

        void Attach(Framework framework);

    }

}