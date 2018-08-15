using System;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IHandleViewModel
    {

        IntPtr Handle
        {
            get;
        }

        uint MessageCode
        {
            get;
        }

    }

}