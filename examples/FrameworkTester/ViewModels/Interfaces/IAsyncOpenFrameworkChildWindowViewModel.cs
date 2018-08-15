using System;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IAsyncOpenFrameworkChildWindowViewModel : IChildWindowViewModel
    {

        Framework Framework
        {
            get;
        }

    }

}