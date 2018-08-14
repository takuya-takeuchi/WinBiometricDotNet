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

        #region Properties

        private Session _Session;

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

        public void BeginEnroll(FingerPosition position, uint unitId)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.BeginEnroll(this._Session, position, unitId);
        }

        public void Cancel()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.Cancel(this._Session);
        }

        public CaptureEnrollResult CaptureEnroll()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            return WinBiometric.CaptureEnroll(this._Session);
        }

        public void CaptureEnrollWithCallback()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.EnrollCaptured -= EnrollCaptured;
            WinBiometric.EnrollCaptured += EnrollCaptured;

            WinBiometric.CaptureEnrollWithCallback(this._Session);
        }

        public CaptureSampleResult CaptureSample()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.SampleCaptured -= SampleCaptured;
            WinBiometric.SampleCaptured += SampleCaptured;

            return WinBiometric.CaptureSample(this._Session);
        }

        public void CaptureSampleWithCallback()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.SampleCaptured -= SampleCaptured;
            WinBiometric.SampleCaptured += SampleCaptured;

            WinBiometric.CaptureSampleWithCallback(this._Session);
        }

        public void CloseFramework(Framework framework)
        {
            WinBiometric.CloseFramework(framework);
        }

        public void CloseSession()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.CloseSession(this._Session);
            this._Session = null;
        }

        public BiometricIdentity CommitEnroll()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            return WinBiometric.CommitEnroll(this._Session);
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

        public void DeleteTemplate(uint unitId, BiometricIdentity identity, FingerPosition position)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            WinBiometric.DeleteTemplate(this._Session, unitId, identity, position);
        }

        public void DiscardEnroll()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.DiscardEnroll(this._Session);
        }

        public IEnumerable<BiometricDatabase> EnumBiometricDatabases()
        {
            return WinBiometric.EnumBiometricDatabases();
        }

        public IEnumerable<BiometricUnit> EnumBiometricUnits()
        {
            return WinBiometric.EnumBiometricUnits();
        }

        public IEnumerable<FingerPosition> EnumEnrollments(BiometricUnit unit)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            return WinBiometric.EnumEnrollments(this._Session, unit);
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

        public void GetProperty(PropertyTypes propertyType, 
                                PropertyId propertyId, 
                                uint unitId, 
                                BiometricIdentity identity,
                                FingerPosition position, 
                                out byte[] propertyBuffer)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.GetProperty(this._Session, propertyType, propertyId, unitId, identity, position, out propertyBuffer);
        }

        public IdentifyResult Identify()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            return WinBiometric.Identify(this._Session);
        }

        public void IdentifyWithCallback()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.Identified -= Identified;
            WinBiometric.Identified += Identified;

            WinBiometric.IdentifyWithCallback(this._Session);
        }

        public uint LocateSensor()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            return WinBiometric.LocateSensor(this._Session);
        }

        public void LocateSensorWithCallback()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.SensorLocated -= SensorLocated;
            WinBiometric.SensorLocated += SensorLocated;

            WinBiometric.LocateSensorWithCallback(this._Session);
        }

        public void LockUnit(uint unitId)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.LockUnit(this._Session, unitId);
        }

        public bool LogonIdentifiedUser()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            return WinBiometric.LogonIdentifiedUser(this._Session);
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
            Session session;

            if (this._Session != null)
            {
                WinBiometric.CloseSession(this._Session);
                this._Session = null;
            }

            session = WinBiometric.OpenSession();
            this._Session = session;

            return session;
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

        public void RegisterEventMonitor(EventTypes eventType)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.EventMonitored -= this.EventMonitored;
            WinBiometric.EventMonitored += this.EventMonitored;

            WinBiometric.RegisterEventMonitor(this._Session, eventType);
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

        public void SelectEnroll(ulong selectorValue)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.SelectEnroll(this._Session, selectorValue);
        }

        public void UnlockUnit(uint unitId)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.UnlockUnit(this._Session, unitId);
        }

        public void UnregisterEventMonitor()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.UnregisterEventMonitor(this._Session);
        }

        public VerifyResult Verify(BiometricUnit unit, FingerPosition position)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            return WinBiometric.Verify(this._Session, unit, position);
        }

        public void VerifyWithCallback(BiometricUnit unit, FingerPosition position)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            WinBiometric.Verified -= Verified;
            WinBiometric.Verified += Verified;

            WinBiometric.VerifyWithCallback(this._Session, unit, position);
        }

        public void Wait()
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");

            WinBiometric.Wait(this._Session);
        }

        #endregion

    }

}