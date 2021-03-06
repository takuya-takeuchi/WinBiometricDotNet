﻿using System;
using System.Collections.Generic;
using WinBiometricDotNet;
using SIZE_T = System.IntPtr;
using ULONG = System.UInt32;

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

        void AsyncOpenFramework(SIZE_T userData);

        void AsyncOpenFramework(SIZE_T targetWindow, uint messageCode);

        void AsyncOpenSession(SIZE_T userData);

        void AsyncOpenSession(SIZE_T targetWindow, uint messageCode);

        void BeginEnroll(Session session, FingerPosition position, uint unitId);

        void Cancel(Session session);

        CaptureEnrollResult CaptureEnroll(Session session);

        void CaptureEnrollWithCallback(Session session);

        CaptureSampleResult CaptureSample(Session session);

        void CaptureSampleWithCallback(Session session);

        void CloseFramework(Framework framework);

        void CloseSession(Session session);

        BiometricIdentity CommitEnroll(Session session);

        void ControlUnit(Session session,
                         uint unitId,
                         Component component,
                         ULONG controlCode,
                         byte[] sendBuffer,
                         byte[] receiveBuffer,
                         out SIZE_T receiveDataSize,
                         out ULONG operationStatus);

        void ControlUnitPrivileged(Session session,
                                   uint unitId,
                                   Component component,
                                   ULONG controlCode,
                                   byte[] sendBuffer,
                                   byte[] receiveBuffer,
                                   out SIZE_T receiveDataSize,
                                   out ULONG operationStatus);

        Guid CreateDatabase(BiometricUnit unit);

        void CreateDatabase(BiometricUnit unit, Guid guid);

        void DeleteTemplate(Session session, uint unitId, BiometricIdentity identity, FingerPosition position);

        void DiscardEnroll(Session session);

        IEnumerable<BiometricDatabase> EnumBiometricDatabases();

        IEnumerable<BiometricUnit> EnumBiometricUnits();

        IEnumerable<FingerPosition> EnumEnrollments(Session session, uint unitId);

        IEnumerable<BiometricServiceProvider> EnumServiceProviders();

        CredentialState GetCredentialState(BiometricIdentity identity, CredentialTypes credentialType);

        void GetDomainLogonSetting(out bool value, out SettingSourceType source);

        void GetEnabledSetting(out bool value, out SettingSourceType source);

        BiometricTypes GetEnrolledFactors(BiometricIdentity accountOwner);

        void GetLogonSetting(out bool value, out SettingSourceType source);

        AntiSpoofPolicy GetAntiSpoofPolicyProperty(Session session,
                                                   PropertyType propertyType,
                                                   BiometricIdentity identity);

        ULONG GetSampleHintProperty(Session session,
                                    PropertyType propertyType,
                                    uint unitId);

        void GetProperty(Session session,
                         PropertyType propertyType,
                         PropertyId propertyId,
                         uint unitId,
                         BiometricIdentity identity,
                         FingerPosition position,
                         out byte[] propertyBuffer);

        IdentifyResult Identify(Session session);

        void IdentifyWithCallback(Session session);

        uint LocateSensor(Session session);

        void LocateSensorWithCallback(Session session);

        void LockUnit(Session session, uint unitId);

        bool LogonIdentifiedUser(Session session);

        void MonitorPresence(Session session, uint unitId);

        Framework OpenFramework(IntPtr userData);

        Framework OpenFramework(IntPtr targetWindow, uint messageCode);

        Session OpenSession();

        Session OpenSession(IntPtr userData);

        Session OpenSession(IntPtr targetWindow, uint messageCode);

        void RegisterEventMonitor(Session session, EventTypes eventType);

        void ReleaseFocus();

        void RemoveAllCredentials();

        void RemoveAllDomainCredentials();

        void RemoveCredential(BiometricIdentity identity, CredentialTypes credentialType);

        void RemoveDatabase(BiometricUnit unit, Guid databaseId);

        void SelectEnroll(Session session, ulong selectorValue);

        void SetAntiSpoofPolicyProperty(Session session,
                                        PropertyType propertyType,
                                        BiometricIdentity identity,
                                        AntiSpoofPolicy antiSpoofPolicy);

        void SetCredential(CredentialTypes credentialType,
                           byte[] credential,
                           CredentialFormat format);

        void UnlockUnit(Session session, uint unitId);

        void UnregisterEventMonitor(Session session);

        VerifyResult Verify(Session session, FingerPosition position);

        void VerifyWithCallback(Session session, FingerPosition position);

        void Wait(Session session);

    }

}