using System;
using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.Services.Interfaces
{

    public interface IWinBiometricService
    {

        void AcquireFocus();

        CaptureSampleResult CaptureSample();

        void CaptureSampleWithCallback();

        void CloseSession();

        Guid CreateDatabase(BiometricUnit unit);

        void CreateDatabase(BiometricUnit unit, Guid guid);

        IEnumerable<BiometricDatabase> EnumBiometricDatabases();

        IEnumerable<BiometricUnit> EnumBiometricUnits();

        IEnumerable<FingerPosition> EnumEnrollments(BiometricUnit unit);

        Session OpenSession();

        void ReleaseFocus();

        void RemoveDatabase(BiometricUnit unit, Guid databaseId);

    }

}