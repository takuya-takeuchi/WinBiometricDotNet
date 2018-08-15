using System;
using FrameworkTester.ViewModels.Interfaces;

using WINBIO_SESSION_HANDLE = System.UInt32;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioOpenSessionViewModel : WinBioViewModel, IWinBioOpenSessionViewModel
    {

        public WINBIO_SESSION_HANDLE SessionHandle
        {
            get;
        }

    }

}