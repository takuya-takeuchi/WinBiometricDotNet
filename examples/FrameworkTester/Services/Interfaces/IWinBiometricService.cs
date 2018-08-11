using System;
using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.Services.Interfaces
{

    public interface IWinBiometricService
    {

        void AcquireFocus();

        void BeginEnroll(FingerPosition position, uint unitId);

        void Cancel();

        RejectDetails CaptureEnroll();

        CaptureSampleResult CaptureSample();

        void CaptureSampleWithCallback();

        void CloseSession();

        BiometricIdentity CommitEnroll();

        Guid CreateDatabase(BiometricUnit unit);

        void CreateDatabase(BiometricUnit unit, Guid guid);

        void DiscardEnroll();

        IEnumerable<BiometricDatabase> EnumBiometricDatabases();

        IEnumerable<BiometricUnit> EnumBiometricUnits();

        IEnumerable<FingerPosition> EnumEnrollments(BiometricUnit unit);

        uint LocateSensor();

        void LocateSensorWithCallback();

        void LockUnit(uint unitId);

        Session OpenSession();

        void ReleaseFocus();

        void RemoveDatabase(BiometricUnit unit, Guid databaseId);

        void UnlockUnit(uint unitId);

        VerifyResult Verify(BiometricUnit unit, FingerPosition position);

        void VerifyWithCallback(BiometricUnit unit, FingerPosition position);

    }

}