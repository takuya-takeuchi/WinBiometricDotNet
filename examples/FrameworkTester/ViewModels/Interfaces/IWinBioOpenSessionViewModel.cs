using System;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioOpenSessionViewModel : IWinBioViewModel
    {

        UIntPtr SessionHandle
        {
            get;
        }

    }

}
