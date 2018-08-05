/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:FrameworkTester"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

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

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<IDispatcherService>(() => new DispatcherService(Application.Current.Dispatcher));
            SimpleIoc.Default.Register<IWinBiometricService, WinBiometricService>();

            var navigationService = new FrameNavigationService();
            var winBio = typeof(IWinBioViewModel);
            foreach (var type in Assembly.GetExecutingAssembly()
                                                         .GetTypes()
                                                         .OrderBy(type => type.FullName)
                                                         .Where(type => type != winBio && !type.IsAbstract && !type.IsInterface && type.GetInterfaces().Contains(winBio))
                                                         .Select(Activator.CreateInstance)
                                                         .Where(type => type is ViewModelBase)
                                                         .Cast<IWinBioViewModel>())
            {
                navigationService.Configure(type.Name, new Uri($"pack://application:,,,/Views/{type.Name}.xaml", UriKind.Absolute));
            }

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
            SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();
            
            SimpleIoc.Default.Register<IWinBioAcquireFocusViewModel>(() => new WinBioAcquireFocusViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCaptureSampleViewModel>(() => new WinBioCaptureSampleViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCaptureSampleWithCallbackViewModel>(() => new WinBioCaptureSampleWithCallbackViewModel(), true);
            SimpleIoc.Default.Register<IWinBioCloseSessionViewModel>(() => new WinBioCloseSessionViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnumDatabasesViewModel>(() => new WinBioEnumDatabasesViewModel(), true);
            SimpleIoc.Default.Register<IWinBioEnumBiometricUnitsViewModel>(() => new WinBioEnumBiometricUnitsViewModel(), true);
            SimpleIoc.Default.Register<IWinBioOpenSessionViewModel>(() => new WinBioOpenSessionViewModel(), true);
            SimpleIoc.Default.Register<IWinBioReleaseFocusViewModel>(() => new WinBioReleaseFocusViewModel(), true);
        }

        public IMainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IMainViewModel>();
            }
        }

        public IWinBioAcquireFocusViewModel AcquireFocus => ServiceLocator.Current.GetInstance<IWinBioAcquireFocusViewModel>();

        public IWinBioCaptureSampleViewModel WinBioCaptureSample => ServiceLocator.Current.GetInstance<IWinBioCaptureSampleViewModel>();

        public IWinBioCaptureSampleWithCallbackViewModel WinBioCaptureSampleWithCallback => ServiceLocator.Current.GetInstance<IWinBioCaptureSampleWithCallbackViewModel>();

        public IWinBioCloseSessionViewModel WinBioCloseSession => ServiceLocator.Current.GetInstance<IWinBioCloseSessionViewModel>();

        public IWinBioEnumDatabasesViewModel WinBioEnumDatabases => ServiceLocator.Current.GetInstance<IWinBioEnumDatabasesViewModel>();

        public IWinBioEnumBiometricUnitsViewModel WinBioEnumBiometricUnits => ServiceLocator.Current.GetInstance<IWinBioEnumBiometricUnitsViewModel>();

        public IWinBioOpenSessionViewModel WinBioOpenSession => ServiceLocator.Current.GetInstance<IWinBioOpenSessionViewModel>();

        public IWinBioReleaseFocusViewModel ReleaseFocus => ServiceLocator.Current.GetInstance<IWinBioReleaseFocusViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}