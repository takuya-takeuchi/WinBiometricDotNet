using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioVerifyWithCallbackViewModel : IWinBioVerifyViewModel, IWinBioWithCallbackViewModel
    {
    }

}