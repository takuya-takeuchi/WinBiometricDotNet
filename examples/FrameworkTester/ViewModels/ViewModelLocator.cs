using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using CommonServiceLocator;
using FrameworkTester.Services;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDispatcherService>(() => new DispatcherService(Application.Current.Dispatcher));
            SimpleIoc.Default.Register<IWinBiometricService, WinBiometricService>();
            SimpleIoc.Default.Register<IBiometricIdentityRepositoryViewModel, BiometricIdentityRepositoryViewModel>();
            SimpleIoc.Default.Register<IHandleRepositoryViewModel<ISessionHandleViewModel>, SessionHandleRepositoryViewModel>();
            SimpleIoc.Default.Register<IHandleRepositoryViewModel<IFrameworkHandleViewModel>, FrameworkHandleRepositoryViewModel>();

            var navigationService = new FrameNavigationService();
            var winBio = typeof(IWinBioViewModel);
            foreach (var type in Assembly.GetExecutingAssembly()
                                                         .GetTypes()
                                                         .Where(type => type != winBio && !type.IsAbstract && !type.IsInterface && type.GetInterfaces().Contains(winBio))
                                                         .Where(type => type.IsSubclassOf(typeof(ViewModelBase)))
                                                         .OrderBy(type => type.FullName)
                                                         .Select(Activator.CreateInstance)
                                                         .Where(type => type is ViewModelBase)
                                                         .Cast<IWinBioViewModel>())
            {
                navigationService.Configure(type.Name, new Uri($"pack://application:,,,/Views/{type.Name}.xaml", UriKind.Absolute));
            }

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
            SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();

            SimpleIoc.Default.Register<IWinBioAcquireFocusViewModel>(() => new WinBioAcquireFocusViewModel(), true);
            SimpleIoc.Default.Register<IWinBioAsyncEnumBiometricUnitsViewModel>(() => new WinBioAsyncEnumBiometricUnitsViewModel(), true);
            SimpleIoc.Default.Register<IWinBioAsyncEnumDatabasesViewModel>(() => new WinBioAsyncEnumDatabasesViewModel(), true);
            SimpleIoc.Default.Register<IWinBioAsyncEnumServiceProvidersViewModel>(() => new WinBioAsyncEnumServiceProvidersViewModel(), true);
            SimpleIoc.Default.Register<IWinBioAsyncMonitorFrameworkChangesViewModel>(() => new WinBioAsyncMonitorFrameworkChangesViewModel(), true);
            SimpleIoc.Default.Register<IWinBioAsyncOpenFrameworkViewModel>(() => new WinBioAsyncOpenFrameworkViewModel(), true);
            SimpleIoc.Default.Register<IWinBioAsyncOpenSessionViewModel>(() => new WinBioAsyncOpenSessionViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCancelViewModel>(() => new WinBioCancelViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCaptureSampleViewModel>(() => new WinBioCaptureSampleViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCaptureSampleWithCallbackViewModel>(() => new WinBioCaptureSampleWithCallbackViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCloseFrameworkViewModel>(() => new WinBioCloseFrameworkViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCloseSessionViewModel>(() => new WinBioCloseSessionViewModel(), true);
            SimpleIoc.Default.Register<IWinBioControlUnitViewModel>(() => new WinBioControlUnitViewModel(), true);
            SimpleIoc.Default.Register<IWinBioControlUnitPrivilegedViewModel>(() => new WinBioControlUnitPrivilegedViewModel(), true);
            SimpleIoc.Default.Register<IWinBioDeleteTemplateViewModel>(() => new WinBioDeleteTemplateViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnrollBeginViewModel>(() => new WinBioEnrollBeginViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnrollCaptureViewModel>(() => new WinBioEnrollCaptureViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnrollCaptureWithCallbackViewModel>(() => new WinBioEnrollCaptureWithCallbackViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnrollCommitViewModel>(() => new WinBioEnrollCommitViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnrollDiscardViewModel>(() => new WinBioEnrollDiscardViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnrollSelectViewModel>(() => new WinBioEnrollSelectViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnumBiometricUnitsViewModel>(() => new WinBioEnumBiometricUnitsViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnumDatabasesViewModel>(() => new WinBioEnumDatabasesViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnumEnrollmentsViewModel>(() => new WinBioEnumEnrollmentsViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnumServiceProvidersViewModel>(() => new WinBioEnumServiceProvidersViewModel(), true);
            SimpleIoc.Default.Register<IWinBioGetCredentialStateViewModel>(() => new WinBioGetCredentialStateViewModel(), true);
            SimpleIoc.Default.Register<IWinBioGetDomainLogonSettingViewModel>(() => new WinBioGetDomainLogonSettingViewModel(), true);
            SimpleIoc.Default.Register<IWinBioGetEnabledSettingViewModel>(() => new WinBioGetEnabledSettingViewModel(), true);
            SimpleIoc.Default.Register<IWinBioGetEnrolledFactorsViewModel>(() => new WinBioGetEnrolledFactorsViewModel(), true);
            SimpleIoc.Default.Register<IWinBioGetLogonSettingViewModel>(() => new WinBioGetLogonSettingViewModel(), true);
            SimpleIoc.Default.Register<IWinBioGetPropertyViewModel>(() => new WinBioGetPropertyViewModel(), true);
            SimpleIoc.Default.Register<IWinBioIdentifyViewModel>(() => new WinBioIdentifyViewModel(), true);
            SimpleIoc.Default.Register<IWinBioIdentifyWithCallbackViewModel>(() => new WinBioIdentifyWithCallbackViewModel(), true);
            SimpleIoc.Default.Register<IWinBioLocateSensorViewModel>(() => new WinBioLocateSensorViewModel(), true);
            SimpleIoc.Default.Register<IWinBioLocateSensorWithCallbackViewModel>(() => new WinBioLocateSensorWithCallbackViewModel(), true);
            SimpleIoc.Default.Register<IWinBioLockUnitViewModel>(() => new WinBioLockUnitViewModel(), true);
            SimpleIoc.Default.Register<IWinBioLogonIdentifiedUserViewModel>(() => new WinBioLogonIdentifiedUserViewModel(), true);
            SimpleIoc.Default.Register<IWinBioMonitorPresenceViewModel>(() => new WinBioMonitorPresenceViewModel(), true);
            SimpleIoc.Default.Register<IWinBioOpenSessionViewModel>(() => new WinBioOpenSessionViewModel(), true);
            SimpleIoc.Default.Register<IWinBioReleaseFocusViewModel>(() => new WinBioReleaseFocusViewModel(), true);
            SimpleIoc.Default.Register<IWinBioRemoveAllCredentialsViewModel>(() => new WinBioRemoveAllCredentialsViewModel(), true);
            SimpleIoc.Default.Register<IWinBioRemoveAllDomainCredentialsViewModel>(() => new WinBioRemoveAllDomainCredentialsViewModel(), true);
            SimpleIoc.Default.Register<IWinBioRemoveCredentialViewModel>(() => new WinBioRemoveCredentialViewModel(), true);
            SimpleIoc.Default.Register<IWinBioSetCredentialViewModel>(() => new WinBioSetCredentialViewModel(), true);
            SimpleIoc.Default.Register<IWinBioSetPropertyViewModel>(() => new WinBioSetPropertyViewModel(), true);
            SimpleIoc.Default.Register<IWinBioUnlockUnitViewModel>(() => new WinBioUnlockUnitViewModel(), true);
            SimpleIoc.Default.Register<IWinBioVerifyViewModel>(() => new WinBioVerifyViewModel(), true);
            SimpleIoc.Default.Register<IWinBioVerifyWithCallbackViewModel>(() => new WinBioVerifyWithCallbackViewModel(), true);
        }

        public IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();

        public IWinBioAcquireFocusViewModel WinBioAcquireFocus => ServiceLocator.Current.GetInstance<IWinBioAcquireFocusViewModel>();

        public IWinBioAsyncEnumBiometricUnitsViewModel WinBioAsyncEnumBiometricUnits => ServiceLocator.Current.GetInstance<IWinBioAsyncEnumBiometricUnitsViewModel>();

        public IWinBioAsyncEnumDatabasesViewModel WinBioAsyncEnumDatabases => ServiceLocator.Current.GetInstance<IWinBioAsyncEnumDatabasesViewModel>();

        public IWinBioAsyncEnumServiceProvidersViewModel WinBioAsyncEnumServiceProviders => ServiceLocator.Current.GetInstance<IWinBioAsyncEnumServiceProvidersViewModel>();

        public IWinBioAsyncMonitorFrameworkChangesViewModel WinBioAsyncMonitorFrameworkChanges => ServiceLocator.Current.GetInstance<IWinBioAsyncMonitorFrameworkChangesViewModel>();

        public IWinBioAsyncOpenFrameworkViewModel WinBioAsyncOpenFramework => ServiceLocator.Current.GetInstance<IWinBioAsyncOpenFrameworkViewModel>();

        public IWinBioAsyncOpenSessionViewModel WinBioAsyncOpenSession => ServiceLocator.Current.GetInstance<IWinBioAsyncOpenSessionViewModel>();

        public IWinBioCancelViewModel WinBioCancel => ServiceLocator.Current.GetInstance<IWinBioCancelViewModel>();

        public IWinBioCaptureSampleViewModel WinBioCaptureSample => ServiceLocator.Current.GetInstance<IWinBioCaptureSampleViewModel>();

        public IWinBioCaptureSampleWithCallbackViewModel WinBioCaptureSampleWithCallback => ServiceLocator.Current.GetInstance<IWinBioCaptureSampleWithCallbackViewModel>();

        public IWinBioCloseFrameworkViewModel WinBioCloseFramework => ServiceLocator.Current.GetInstance<IWinBioCloseFrameworkViewModel>();

        public IWinBioCloseSessionViewModel WinBioCloseSession => ServiceLocator.Current.GetInstance<IWinBioCloseSessionViewModel>();

        public IWinBioControlUnitViewModel WinBioControlUnit => ServiceLocator.Current.GetInstance<IWinBioControlUnitViewModel>();

        public IWinBioControlUnitPrivilegedViewModel WinBioControlUnitPrivileged => ServiceLocator.Current.GetInstance<IWinBioControlUnitPrivilegedViewModel>();

        public IWinBioDeleteTemplateViewModel WinBioDeleteTemplate => ServiceLocator.Current.GetInstance<IWinBioDeleteTemplateViewModel>();

        public IWinBioEnrollBeginViewModel WinBioEnrollBegin => ServiceLocator.Current.GetInstance<IWinBioEnrollBeginViewModel>();

        public IWinBioEnrollCaptureViewModel WinBioEnrollCapture => ServiceLocator.Current.GetInstance<IWinBioEnrollCaptureViewModel>();

        public IWinBioEnrollCaptureWithCallbackViewModel WinBioEnrollCaptureWithCallback => ServiceLocator.Current.GetInstance<IWinBioEnrollCaptureWithCallbackViewModel>();

        public IWinBioEnrollCommitViewModel WinBioEnrollCommit => ServiceLocator.Current.GetInstance<IWinBioEnrollCommitViewModel>();

        public IWinBioEnrollDiscardViewModel WinBioEnrollDiscard => ServiceLocator.Current.GetInstance<IWinBioEnrollDiscardViewModel>();

        public IWinBioEnumDatabasesViewModel WinBioEnumDatabases => ServiceLocator.Current.GetInstance<IWinBioEnumDatabasesViewModel>();

        public IWinBioEnumBiometricUnitsViewModel WinBioEnumBiometricUnits => ServiceLocator.Current.GetInstance<IWinBioEnumBiometricUnitsViewModel>();

        public IWinBioEnumEnrollmentsViewModel WinBioEnumEnrollments => ServiceLocator.Current.GetInstance<IWinBioEnumEnrollmentsViewModel>();

        public IWinBioEnrollSelectViewModel WinBioEnrollSelect => ServiceLocator.Current.GetInstance<IWinBioEnrollSelectViewModel>();

        public IWinBioEnumServiceProvidersViewModel WinBioEnumServiceProviders => ServiceLocator.Current.GetInstance<IWinBioEnumServiceProvidersViewModel>();

        public IWinBioGetCredentialStateViewModel WinBioGetCredentialState => ServiceLocator.Current.GetInstance<IWinBioGetCredentialStateViewModel>();

        public IWinBioGetDomainLogonSettingViewModel WinBioGetDomainLogonSetting => ServiceLocator.Current.GetInstance<IWinBioGetDomainLogonSettingViewModel>();

        public IWinBioGetEnabledSettingViewModel WinBioGetEnabledSetting => ServiceLocator.Current.GetInstance<IWinBioGetEnabledSettingViewModel>();

        public IWinBioGetEnrolledFactorsViewModel WinBioGetEnrolledFactors => ServiceLocator.Current.GetInstance<IWinBioGetEnrolledFactorsViewModel>();

        public IWinBioGetLogonSettingViewModel WinBioGetLogonSetting => ServiceLocator.Current.GetInstance<IWinBioGetLogonSettingViewModel>();

        public IWinBioGetPropertyViewModel WinBioGetProperty => ServiceLocator.Current.GetInstance<IWinBioGetPropertyViewModel>();

        public IWinBioIdentifyViewModel WinBioIdentify => ServiceLocator.Current.GetInstance<IWinBioIdentifyViewModel>();

        public IWinBioIdentifyWithCallbackViewModel WinBioIdentifyWithCallback => ServiceLocator.Current.GetInstance<IWinBioIdentifyWithCallbackViewModel>();

        public IWinBioLocateSensorViewModel WinBioLocateSensor => ServiceLocator.Current.GetInstance<IWinBioLocateSensorViewModel>();

        public IWinBioLocateSensorWithCallbackViewModel WinBioLocateSensorWithCallback => ServiceLocator.Current.GetInstance<IWinBioLocateSensorWithCallbackViewModel>();

        public IWinBioLockUnitViewModel WinBioLockUnit => ServiceLocator.Current.GetInstance<IWinBioLockUnitViewModel>();

        public IWinBioLogonIdentifiedUserViewModel WinBioLogonIdentifiedUser => ServiceLocator.Current.GetInstance<IWinBioLogonIdentifiedUserViewModel>();

        public IWinBioMonitorPresenceViewModel WinBioMonitorPresence => ServiceLocator.Current.GetInstance<IWinBioMonitorPresenceViewModel>();

        public IWinBioOpenSessionViewModel WinBioOpenSession => ServiceLocator.Current.GetInstance<IWinBioOpenSessionViewModel>();

        public IWinBioReleaseFocusViewModel WinBioReleaseFocus => ServiceLocator.Current.GetInstance<IWinBioReleaseFocusViewModel>();

        public IWinBioRemoveAllCredentialsViewModel WinBioRemoveAllCredentials => ServiceLocator.Current.GetInstance<IWinBioRemoveAllCredentialsViewModel>();

        public IWinBioRemoveAllDomainCredentialsViewModel WinBioRemoveAllDomainCredentials => ServiceLocator.Current.GetInstance<IWinBioRemoveAllDomainCredentialsViewModel>();

        public IWinBioRemoveCredentialViewModel WinBioRemoveCredential => ServiceLocator.Current.GetInstance<IWinBioRemoveCredentialViewModel>();

        public IWinBioSetCredentialViewModel WinBioSetCredential => ServiceLocator.Current.GetInstance<IWinBioSetCredentialViewModel>();

        public IWinBioSetPropertyViewModel WinBioSetProperty => ServiceLocator.Current.GetInstance<IWinBioSetPropertyViewModel>();

        public IWinBioUnlockUnitViewModel WinBioUnlockUnit => ServiceLocator.Current.GetInstance<IWinBioUnlockUnitViewModel>();

        public IWinBioVerifyViewModel WinBioVerify => ServiceLocator.Current.GetInstance<IWinBioVerifyViewModel>();

        public IWinBioVerifyWithCallbackViewModel WinBioVerifyWithCallback => ServiceLocator.Current.GetInstance<IWinBioVerifyWithCallbackViewModel>();

    }

}