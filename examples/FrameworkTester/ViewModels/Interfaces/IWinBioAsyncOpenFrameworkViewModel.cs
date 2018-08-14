using System;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioAsyncOpenFrameworkViewModel : IWinBioWithCallbackViewModel, IWinBioAsyncFrameworkViewModel, IWinBioViewModel
    {

        UIntPtr FrameworkHandle
        {
            get;
        }

    }

}