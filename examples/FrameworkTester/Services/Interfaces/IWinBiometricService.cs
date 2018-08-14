using System;
using System.Collections.Generic;
using WinBiometricDotNet;

namespace FrameworkTester.Services.Interfaces
{

    public interface IWinBiometricService
    {

        event EventMonitoredHandler EventMonitored;

        void AcquireFocus();

        void AsyncEnumBiometricUnits(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint);

        void AsyncEnumDatabases(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint);

        void AsyncEnumServiceProviders(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint);

        void AsyncMonitorFrameworkChanges(Framework framework, ChangeTypes changeType);

        void AsyncOpenFramework(IntPtr userData);

        void AsyncOpenFramework(IntPtr targetWindow, uint messageCode);

        void AsyncOpenSession(IntPtr userData);

        void AsyncOpenSession(IntPtr targetWindow, uint messageCode);

        void BeginEnroll(FingerPosition position, uint unitId);

        void Cancel();

        CaptureEnrollResult CaptureEnroll();

        void CaptureEnrollWithCallback();

        CaptureSampleResult CaptureSample();

        void CaptureSampleWithCallback();

        void CloseFramework(Framework framework);

        void CloseSession();

        BiometricIdentity CommitEnroll();

        Guid CreateDatabase(BiometricUnit unit);

        void CreateDatabase(BiometricUnit unit, Guid guid);

        void DeleteTemplate(uint unitId, BiometricIdentity identity, FingerPosition position);

        void DiscardEnroll();

        IEnumerable<BiometricDatabase> EnumBiometricDatabases();

        IEnumerable<BiometricUnit> EnumBiometricUnits();

        IEnumerable<FingerPosition> EnumEnrollments(BiometricUnit unit);

        IEnumerable<BiometricServiceProvider> EnumServiceProviders();

        CredentialStates GetCredentialState(BiometricIdentity identity, CredentialTypes credentialType);

        void GetDomainLogonSetting(out bool value, out SettingSourceTypes source);

        void GetEnabledSetting(out bool value, out SettingSourceTypes source);

        BiometricTypes GetEnrolledFactors(BiometricIdentity accountOwner);

        void GetLogonSetting(out bool value, out SettingSourceTypes source);

        void GetProperty(PropertyTypes propertyType,
                         PropertyId propertyId,
                         uint unitId,
                         BiometricIdentity identity,
                         FingerPosition position,
                         out byte[] propertyBuffer);

        IdentifyResult Identify();

        void IdentifyWithCallback();

        uint LocateSensor();

        void LocateSensorWithCallback();

        void LockUnit(uint unitId);

        bool LogonIdentifiedUser();

        Framework OpenFramework(IntPtr userData);

        Framework OpenFramework(IntPtr targetWindow, uint messageCode);

        Session OpenSession();

        Session OpenSession(IntPtr userData);

        Session OpenSession(IntPtr targetWindow, uint messageCode);

        void RegisterEventMonitor(EventTypes eventType);

        void ReleaseFocus();

        void RemoveDatabase(BiometricUnit unit, Guid databaseId);

        void SelectEnroll(ulong selectorValue);

        void UnlockUnit(uint unitId);

        void UnregisterEventMonitor();

        VerifyResult Verify(BiometricUnit unit, FingerPosition position);

        void VerifyWithCallback(BiometricUnit unit, FingerPosition position);

        void Wait();

    }

}