using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioGetPropertyViewModel : IWinBioViewModel
    {

        FingerPosition CurrentFingerPosition
        {
            get;
            set;
        }

        PropertyId CurrentPropertyId
        {
            get;
            set;
        }

        PropertyTypes CurrentPropertyType
        {
            get;
            set;
        }

        IEnumerable<FingerPosition> FingerPositions
        {
            get;
        }

        IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

        byte[] PropertyBuffer
        {
            get;
        }

        IEnumerable<PropertyTypes> PropertyTypes
        {
            get;
        }

        IEnumerable<PropertyId> PropertyIds
        {
            get;
        }

    }

}