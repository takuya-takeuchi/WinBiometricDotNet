using System;
using System.Collections.Generic;
using FrameworkTester.Services.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.Services
{

    public sealed class WinBiometricService : IWinBiometricService
    {

        #region Events

        public static event AsyncCompletedHandler AsyncCompleted;

        public static event EnrollCapturedHandler EnrollCaptured;

        public event EventMonitoredHandler EventMonitored;

        public static event IdentifiedHandler Identified;

        public static event SampleCapturedHandler SampleCaptured;

        public static event SensorLocatedHandler SensorLocated;

        public static event VerifyHandler Verified;

        #endregion

        #region Methods

        public void AcquireFocus()
        {
            WinBiometric.AcquireFocus();
        }

        public void AsyncEnumBiometricUnits(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            WinBiometric.AsyncEnumBiometricUnits(framework, biometricTypes);
        }

        public void AsyncEnumDatabases(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            WinBiometric.AsyncEnumDatabases(framework, biometricTypes);
        }

        public void AsyncEnumServiceProviders(Framework framework, BiometricTypes biometricTypes = BiometricTypes.Fingerprint)
        {
            WinBiometric.AsyncEnumServiceProviders(framework, biometricTypes);
        }

        public void AsyncMonitorFrameworkChanges(Framework framework, ChangeTypes changeType)
        {
            WinBiometric.AsyncMonitorFrameworkChanges(framework, changeType);
        }

        public void AsyncOpenFramework(IntPtr userData)
        {
            WinBiometric.AsyncCompleted -= AsyncCompleted;
            WinBiometric.AsyncCompleted += AsyncCompleted;

            WinBiometric.AsyncOpenFramework(userData);
        }

        public void AsyncOpenFramework(IntPtr targetWindow, uint messageCode)
        {
            WinBiometric.AsyncOpenFramework(targetWindow, messageCode);
        }

        public void AsyncOpenSession(IntPtr userData)
        {
            WinBiometric.AsyncCompleted -= AsyncCompleted;
            WinBiometric.AsyncCompleted += AsyncCompleted;

            WinBiometric.AsyncOpenSession(userData);
        }

        public void AsyncOpenSession(IntPtr targetWindow, uint messageCode)
        {
            WinBiometric.AsyncOpenSession(targetWindow, messageCode);
        }

        public void BeginEnroll(Session session, FingerPosition position, uint unitId)
        {
            WinBiometric.BeginEnroll(session, position, unitId);
        }

        public void Cancel(Session session)
        {
            WinBiometric.Cancel(session);
        }

        public CaptureEnrollResult CaptureEnroll(Session session)
        {
            return WinBiometric.CaptureEnroll(session);
        }

        public void CaptureEnrollWithCallback(Session session)
        {
            WinBiometric.EnrollCaptured -= EnrollCaptured;
            WinBiometric.EnrollCaptured += EnrollCaptured;

            WinBiometric.CaptureEnrollWithCallback(session);
        }

        public CaptureSampleResult CaptureSample(Session session)
        {
            return WinBiometric.CaptureSample(session);
        }

        public void CaptureSampleWithCallback(Session session)
        {
            WinBiometric.SampleCaptured -= SampleCaptured;
            WinBiometric.SampleCaptured += SampleCaptured;

            WinBiometric.CaptureSampleWithCallback(session);
        }

        public void CloseFramework(Framework framework)
        {
            WinBiometric.CloseFramework(framework);
        }

        public void CloseSession(Session session)
        {
            WinBiometric.CloseSession(session);
        }

        public BiometricIdentity CommitEnroll(Session session)
        {
            return WinBiometric.CommitEnroll(session);
        }

        public Guid CreateDatabase(BiometricUnit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            return WinBiometric.CreateDatabase(unit);
        }

        public void CreateDatabase(BiometricUnit unit, Guid guid)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            WinBiometric.CreateDatabase(unit, guid);
        }

        public void DeleteTemplate(Session session, uint unitId, BiometricIdentity identity, FingerPosition position)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            WinBiometric.DeleteTemplate(session, unitId, identity, position);
        }

        public void DiscardEnroll(Session session)
        {
            WinBiometric.DiscardEnroll(session);
        }

        public IEnumerable<BiometricDatabase> EnumBiometricDatabases()
        {
            return WinBiometric.EnumBiometricDatabases();
        }

        public IEnumerable<BiometricUnit> EnumBiometricUnits()
        {
            return WinBiometric.EnumBiometricUnits();
        }

        public IEnumerable<FingerPosition> EnumEnrollments(Session session, BiometricUnit unit)
        {
            return WinBiometric.EnumEnrollments(session, unit);
        }

        public IEnumerable<BiometricServiceProvider> EnumServiceProviders()
        {
            return WinBiometric.EnumServiceProviders();
        }

        public CredentialStates GetCredentialState(BiometricIdentity identity, CredentialTypes credentialType)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            return WinBiometric.GetCredentialState(identity, credentialType);
        }

        public void GetDomainLogonSetting(out bool value, out SettingSourceTypes source)
        {
            WinBiometric.GetDomainLogonSetting(out value, out source);
        }

        public void GetEnabledSetting(out bool value, out SettingSourceTypes source)
        {
            WinBiometric.GetEnabledSetting(out value, out source);
        }

        public BiometricTypes GetEnrolledFactors(BiometricIdentity accountOwner)
        {
            return WinBiometric.GetEnrolledFactors(accountOwner);
        }

        public void GetLogonSetting(out bool value, out SettingSourceTypes source)
        {
            WinBiometric.GetLogonSetting(out value, out source);
        }

        public void GetProperty(Session session,
                                PropertyTypes propertyType, 
                                PropertyId propertyId, 
                                uint unitId, 
                                BiometricIdentity identity,
                                FingerPosition position, 
                                out byte[] propertyBuffer)
        {
            WinBiometric.GetProperty(session, propertyType, propertyId, unitId, identity, position, out propertyBuffer);
        }

        public IdentifyResult Identify(Session session)
        {
            return WinBiometric.Identify(session);
        }

        public void IdentifyWithCallback(Session session)
        {
            WinBiometric.Identified -= Identified;
            WinBiometric.Identified += Identified;

            WinBiometric.IdentifyWithCallback(session);
        }

        public uint LocateSensor(Session session)
        {
            return WinBiometric.LocateSensor(session);
        }

        public void LocateSensorWithCallback(Session session)
        {
            WinBiometric.SensorLocated -= SensorLocated;
            WinBiometric.SensorLocated += SensorLocated;

            WinBiometric.LocateSensorWithCallback(session);
        }

        public void LockUnit(Session session, uint unitId)
        {
            WinBiometric.LockUnit(session, unitId);
        }

        public bool LogonIdentifiedUser(Session session)
        {
            return WinBiometric.LogonIdentifiedUser(session);
        }

        public Framework OpenFramework(IntPtr userData)
        {
            WinBiometric.AsyncCompleted -= AsyncCompleted;
            WinBiometric.AsyncCompleted += AsyncCompleted;

            return WinBiometric.OpenFramework(userData);
        }

        public Framework OpenFramework(IntPtr targetWindow, uint messageCode)
        {
            return WinBiometric.OpenFramework(targetWindow, messageCode);
        }

        public Session OpenSession()
        {
            return WinBiometric.OpenSession();
        }

        public Session OpenSession(IntPtr userData)
        {
            WinBiometric.AsyncCompleted -= AsyncCompleted;
            WinBiometric.AsyncCompleted += AsyncCompleted;

            return WinBiometric.OpenSession(userData);
        }

        public Session OpenSession(IntPtr targetWindow, uint messageCode)
        {
            return WinBiometric.OpenSession(targetWindow, messageCode);
        }

        public void RegisterEventMonitor(Session session, EventTypes eventType)
        {
            WinBiometric.EventMonitored -= this.EventMonitored;
            WinBiometric.EventMonitored += this.EventMonitored;

            WinBiometric.RegisterEventMonitor(session, eventType);
        }

        public void ReleaseFocus()
        {
            WinBiometric.ReleaseFocus();
        }

        public void RemoveDatabase(BiometricUnit unit, Guid databaseId)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            WinBiometric.RemoveDatabase(unit, databaseId);
        }

        public void SelectEnroll(Session session, ulong selectorValue)
        {
            WinBiometric.SelectEnroll(session, selectorValue);
        }

        public void UnlockUnit(Session session, uint unitId)
        {
            WinBiometric.UnlockUnit(session, unitId);
        }

        public void UnregisterEventMonitor(Session session)
        {
            WinBiometric.UnregisterEventMonitor(session);
        }

        public VerifyResult Verify(Session session, BiometricUnit unit, FingerPosition position)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            return WinBiometric.Verify(session, unit, position);
        }

        public void VerifyWithCallback(Session session, BiometricUnit unit, FingerPosition position)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            WinBiometric.Verified -= Verified;
            WinBiometric.Verified += Verified;

            WinBiometric.VerifyWithCallback(session, unit, position);
        }

        public void Wait(Session session)
        {
            WinBiometric.Wait(session);
        }

        #endregion

    }

}