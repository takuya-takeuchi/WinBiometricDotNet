using System;
using System.Collections.Generic;
using FrameworkTester.Services.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.Services
{

    public sealed class WinBiometricService : IWinBiometricService
    {

        #region Events

        public static event EnrollCapturedHandler EnrollCaptured;

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

        public RejectDetails CaptureEnroll()
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

        public void UnlockUnit(uint unitId)
        {
            if (this._Session == null)
                throw new Exception("There is no opened session.");
            
            WinBiometric.UnlockUnit(this._Session, unitId);
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

        #region Overrids
        #endregion

        #endregion

    }

}