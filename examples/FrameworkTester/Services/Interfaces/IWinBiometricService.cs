using System;
using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.Services.Interfaces
{

    public interface IWinBiometricService
    {

        event EventMonitoredHandler EventMonitored;

        void AcquireFocus();

        void BeginEnroll(FingerPosition position, uint unitId);

        void Cancel();

        RejectDetails CaptureEnroll();

        void CaptureEnrollWithCallback();

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

        IEnumerable<BiometricServiceProvider> EnumServiceProviders();

        CredentialStates GetCredentialState(BiometricIdentity identity, CredentialTypes credentialType);

        IdentifyResult Identify();

        void IdentifyWithCallback();

        uint LocateSensor();

        void LocateSensorWithCallback();

        void LockUnit(uint unitId);

        bool LogonIdentifiedUser();

        Session OpenSession();

        void RegisterEventMonitor(EventTypes eventType);

        void ReleaseFocus();

        void RemoveDatabase(BiometricUnit unit, Guid databaseId);

        void UnlockUnit(uint unitId);

        void UnregisterEventMonitor();

        VerifyResult Verify(BiometricUnit unit, FingerPosition position);

        void VerifyWithCallback(BiometricUnit unit, FingerPosition position);

    }

}