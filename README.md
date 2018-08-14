# ![Alt text](nuget/fingerprint48.png "WinBiometric.Net") WinBiometric.Net

Windows Biometric Framework .NET wrapper

[![NuGet version](https://badge.fury.io/nu/WinBiometricDotNet.svg)](https://badge.fury.io/nu/WinBiometricDotNet)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)]()
[![API Cover Progress](https://img.shields.io/badge/API%20Coverage-84.6%25%20(44/52)-green.svg)]()

## Support API

|Function|Support|Win 7|Win 8|Win 10|Note|
|----|:----:|:----:|:----:|:----:|----|
|WinBioAcquireFocus|✓|✓|✓|✓||
|WinBioAsyncEnumBiometricUnits|✓||✓|✓|Experimental|
|WinBioAsyncEnumDatabases|✓||✓|✓|Experimental|
|WinBioAsyncEnumServiceProviders|✓||✓|✓|Experimental|
|WinBioAsyncMonitorFrameworkChanges|✓||✓|✓|Experimental|
|WinBioAsyncOpenFramework|✓||✓|✓|Experimental|
|WinBioAsyncOpenSession|✓||✓|✓|Experimental|
|WinBioCancel|✓|✓|✓|✓||
|WinBioCaptureSample|✓|✓|✓|✓||
|WinBioCaptureSampleWithCallback|✓|✓|✓|✓||
|WinBioCloseFramework|✓||✓|✓||
|WinBioCloseSession|✓|✓|✓|✓||
|WinBioControlUnit||✓|✓|✓||
|WinBioControlUnitPrivileged||✓|✓|✓||
|WinBioDeleteTemplate|✓|✓|✓|✓||
|WinBioEnrollBegin|✓|✓|✓|✓||
|WinBioEnrollCapture|✓|✓|✓|✓||
|WinBioEnrollCaptureWithCallback|✓|✓|✓|✓||
|WinBioEnrollCommit|✓|✓|✓|✓||
|WinBioEnrollDiscard|✓|✓|✓|✓||
|WinBioEnrollSelect|✓|||✓|Experimental|
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
|WinBioMonitorPresence||||✓||
|WinBioOpenSession|✓|✓|✓|✓||
|WinBioRegisterEventMonitor|✓|✓|✓|✓||
|WinBioReleaseFocus|✓|✓|✓|✓||
|WinBioRemoveAllCredentials||✓|✓|✓||
|WinBioRemoveAllDomainCredentials||✓|✓|✓||
|WinBioRemoveCredential||✓|✓|✓||
|WinBioSetCredential||✓|✓|✓||
|WinBioSetProperty||||✓||
|WinBioUnlockUnit|✓|✓|✓|✓||
|WinBioUnregisterEventMonitor|✓|✓|✓|✓||
|WinBioVerify|✓|✓|✓|✓||
|WinBioVerifyWithCallback|✓|✓|✓|✓||
|WinBioWait|✓|✓|✓|✓||