using System;
using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioOpenSessionViewModel : WinBioViewModel, IWinBioOpenSessionViewModel
    {

        public UIntPtr SessionHandle
        {
            get;
        }

    }

}