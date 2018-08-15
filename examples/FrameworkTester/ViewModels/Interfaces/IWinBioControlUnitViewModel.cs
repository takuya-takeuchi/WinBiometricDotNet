using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioControlUnitViewModel : IWinBioViewModel
    {

        IEnumerable<Component> Components
        {
            get;
        }

        uint ControlCode
        {
            get;
            set;
        }

        string SendBufferFile
        {
            get;
            set;
        }

        Component SelectedComponent
        {
            get;
            set;
        }

        uint OperationStatus
        {
            get;
        }

        uint ReceiveBufferSize
        {
            get;
            set;
        }

        uint ReceiveDataSize
        {
            get;
        }

    }

}