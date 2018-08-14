using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IFrameworkWindowViewModel : IChildWindowViewModel
    {

        Framework Framework
        {
            get;
        }

    }

}