# ![Alt text](nuget/fingerprint48.png "WinBiometric.Net") WinBiometric.Net

Windows Biometric Framework .NET wrapper

[![NuGet version](https://badge.fury.io/nu/WinBiometricDotNet.svg)](https://badge.fury.io/nu/WinBiometricDotNet)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)]()
[![API Cover Progress](https://img.shields.io/badge/API%20Coverage-100.0%25%20(52/52)-green.svg)]()

## Support API

|Function|Support|Win 7|Win 8|Win 10|Note|
|----|:----:|:----:|:----:|:----:|----|
|WinBioAcquireFocus|✓|✓|✓|✓||
|WinBioAsyncEnumBiometricUnits|✓||✓|✓||
|WinBioAsyncEnumDatabases|✓||✓|✓||
|WinBioAsyncEnumServiceProviders|✓||✓|✓||
|WinBioAsyncMonitorFrameworkChanges|✓||✓|✓||
|WinBioAsyncOpenFramework|✓||✓|✓||
|WinBioAsyncOpenSession|✓||✓|✓||
|WinBioCancel|✓|✓|✓|✓||
|WinBioCaptureSample|✓|✓|✓|✓||
|WinBioCaptureSampleWithCallback|✓|✓|✓|✓||
|WinBioCloseFramework|✓||✓|✓||
|WinBioCloseSession|✓|✓|✓|✓||
|WinBioControlUnit|✓|✓|✓|✓||
|WinBioControlUnitPrivileged|✓|✓|✓|✓||
|WinBioDeleteTemplate|✓|✓|✓|✓||
|WinBioEnrollBegin|✓|✓|✓|✓||
|WinBioEnrollCapture|✓|✓|✓|✓||
|WinBioEnrollCaptureWithCallback|✓|✓|✓|✓||
|WinBioEnrollCommit|✓|✓|✓|✓||
|WinBioEnrollDiscard|✓|✓|✓|✓||
|WinBioEnrollSelect|✓|||✓||
|WinBioEnumBiometricUnits|✓|✓|✓|✓||
|WinBioEnumDatabases|✓|✓|✓|✓||
|WinBioEnumEnrollments|✓|✓|✓|✓||
|WinBioEnumServiceProviders|✓|✓|✓|✓||
|WinBioFree|✓|✓|✓|✓|Internal use only|
|WinBioGetCredentialState|✓|✓|✓|✓||
|WinBioGetDomainLogonSetting|✓|✓|✓|✓||
|WinBioGetEnabledSetting|✓|✓|✓|✓||
|WinBioGetEnrolledFactors|✓|||✓||
|WinBioGetLogonSetting|✓|✓|✓|✓||
|WinBioGetProperty|✓|✓|✓|✓||
|WinBioIdentify|✓|✓|✓|✓||
|WinBioIdentifyWithCallback|✓|✓|✓|✓||
|WinBioLocateSensor|✓|✓|✓|✓||
|WinBioLocateSensorWithCallback|✓|✓|✓|✓||
|WinBioLockUnit|✓|✓|✓|✓||
|WinBioLogonIdentifiedUser|✓|✓|✓|✓||
|WinBioMonitorPresence|✓|||✓||
|WinBioOpenSession|✓|✓|✓|✓||
|WinBioRegisterEventMonitor|✓|✓|✓|✓||
|WinBioReleaseFocus|✓|✓|✓|✓||
|WinBioRemoveAllCredentials|✓|✓|✓|✓||
|WinBioRemoveAllDomainCredentials|✓|✓|✓|✓||
|WinBioRemoveCredential|✓|✓|✓|✓||
|WinBioSetCredential|✓|✓|✓|✓||
|WinBioSetProperty|✓|||✓||
|WinBioUnlockUnit|✓|✓|✓|✓||
|WinBioUnregisterEventMonitor|✓|✓|✓|✓||
|WinBioVerify|✓|✓|✓|✓||
|WinBioVerifyWithCallback|✓|✓|✓|✓||
|WinBioWait|✓|✓|✓|✓||

## Known Issue

- ***AsyncOpenSession*** and ***AsyncOpenFramework*** throws Exception if specifies ***WINBIO_ASYNC_NOTIFY_CALLBACK***.