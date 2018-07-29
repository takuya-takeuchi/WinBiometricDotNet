using System;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioOpenSessionViewModel : IWinBioViewModel
    {

        IntPtr SessionHandle
        {
            get;
        }

    }

}
