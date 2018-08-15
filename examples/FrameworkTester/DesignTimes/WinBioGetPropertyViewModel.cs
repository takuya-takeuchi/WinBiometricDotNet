using System.Collections.Generic;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.DesignTimes
{

    public sealed class WinBioGetPropertyViewModel : WinBioViewModel, IWinBioGetPropertyViewModel, IWinBioAsyncSessionViewModel
    {

        public FingerPosition CurrentFingerPosition
        {
            get;
            set;
        }

        public PropertyId CurrentPropertyId
        {
            get;
            set;
        }

        public PropertyTypes CurrentPropertyType
        {
            get;
            set;
        }

        public IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        public byte[] PropertyBuffer
        {
            get;
        }

        public IEnumerable<PropertyTypes> PropertyTypes
        {
            get;
        }

        public IEnumerable<PropertyId> PropertyIds
        {
            get;
        }

        public IWindowRepositoryViewModel<ISessionHandleViewModel> WindowRepository
        {
            get;
        }

    }

}