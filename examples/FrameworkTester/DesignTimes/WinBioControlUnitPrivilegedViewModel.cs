using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioControlUnitPrivilegedViewModel : WinBioViewModel, IWinBioControlUnitViewModel, IWinBioAsyncSessionViewModel
    {

        public IEnumerable<Component> Components
        {
            get;
        }

        public uint ControlCode
        {
            get;
            set;
        }

        public string SendBufferFile
        {
            get;
            set;
        }

        public Component SelectedComponent
        {
            get;
            set;
        }

        public uint OperationStatus
        {
            get;
        }

        public uint ReceiveBufferSize
        {
            get;
            set;
        }

        public uint ReceiveDataSize
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}