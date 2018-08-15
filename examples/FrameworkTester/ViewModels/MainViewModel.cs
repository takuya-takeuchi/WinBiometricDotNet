using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public class MainViewModel : ViewModelBase, IMainViewModel
    {

        #region Fields

        private Session _SelectedSession;

        private bool _EventCancel;

        private readonly IDispatcherService _DispatcherService;

        private readonly IWinBiometricService _WinBiometricService;

        private readonly IFrameNavigationService _NavigationService;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            this._DispatcherService = SimpleIoc.Default.GetInstance<IDispatcherService>();
            this._WinBiometricService = SimpleIoc.Default.GetInstance<IWinBiometricService>();
            this._NavigationService = SimpleIoc.Default.GetInstance<IFrameNavigationService>();

            this.HandleRepository = SimpleIoc.Default.GetInstance<IHandleRepositoryViewModel<ISessionHandleViewModel>>();

            var winBio = typeof(IWinBioViewModel);
            foreach (var type in Assembly.GetExecutingAssembly()
                                                         .GetTypes()
                                                         .Where(type => type != winBio && type.IsInterface && type.GetInterfaces().Contains(winBio))
                                                         .OrderBy(type => type.FullName))
            {
                var model = SimpleIoc.Default.GetInstance(type) as IWinBioViewModel;
                this.TestTargets.Add(model);
            }

            foreach (var unit in this._WinBiometricService.EnumBiometricUnits())
                this.Units.Add(unit);

            this._WinBiometricService.EventMonitored += this.OnEventMonitored;
        }

        #endregion

        #region Properties

        private RelayCommand _ClearEventsCommand;

        public RelayCommand ClearEventsCommand
        {
            get
            {
                return this._ClearEventsCommand ?? (this._ClearEventsCommand = new RelayCommand(async () =>
                {
                    await Task.Run(() =>
                    {
                        this._DispatcherService.SafeAction(() =>
                        {
                            this.Events.Clear();
                        });
                    });
                }));
            }
        }

        private IWinBioViewModel _SelectedTestTarget;

        public IWinBioViewModel SelectedTestTarget
        {
            get
            {
                return this._SelectedTestTarget;
            }
            set
            {
                this._SelectedTestTarget = value;
                this.RaisePropertyChanged();

                this._NavigationService.NavigateTo(value.Name);
            }
        }

        private BiometricUnit _SelectedUnit;

        public BiometricUnit SelectedUnit
        {
            get => this._SelectedUnit;
            set
            {
                this._SelectedUnit = value;
                this.RaisePropertyChanged();

                foreach (var viewModel in this.TestTargets)
                    viewModel.SelectedUnit = value;
            }
        }

        public ObservableCollection<string> Events
        {
            get;
        } = new ObservableCollection<string>();

        private bool _EnableMonitorEvent;

        public bool EnableMonitorEvent
        {
            get => this._EnableMonitorEvent;
            set
            {
                this._EnableMonitorEvent = value;
                this.RaisePropertyChanged();
            }
        }

        private RelayCommand _LoadedCommand;

        public RelayCommand LoadedCommand
        {
            get
            {
                return this._LoadedCommand ?? (this._LoadedCommand = new RelayCommand(async () =>
                {
                    await Task.Run(() =>
                    {
                        this._DispatcherService.SafeAction(() =>
                        {
                            if (this.TestTargets.Any())
                                this.SelectedTestTarget = this.TestTargets.FirstOrDefault();

                            if (this.Units.Any())
                                this.SelectedUnit = this.Units.FirstOrDefault();
                        });
                    });
                }));
            }
        }

        public ObservableCollection<IWinBioViewModel> TestTargets
        {
            get;
        } = new ObservableCollection<IWinBioViewModel>();
        
        private bool _ToggleMonitorEvent;

        public bool ToggleMonitorEvent
        {
            get => this._ToggleMonitorEvent;
            set
            {
                this._ToggleMonitorEvent = value;
                this.RaisePropertyChanged();

                if (this._EventCancel)
                {
                    this._EventCancel = false;
                    return;
                }

                try
                {
                    if (value)
                    {
                        this._SelectedSession = this.HandleRepository.SelectedHandle.Session;
                        this._WinBiometricService.RegisterEventMonitor(this._SelectedSession, EventTypes.Unclaimed);
                    }
                    else
                    {
                        this._WinBiometricService.UnregisterEventMonitor(this._SelectedSession);
                    }
                }
                catch (Exception e)
                {
                    if (value)
                    {
                        MessageBox.Show(e.Message, "RegisterEventMonitor", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show(e.Message, "UnregisterEventMonitor", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    this._EventCancel = true;
                    this.ToggleMonitorEvent = !value;
                }
            }
        }

        public ObservableCollection<BiometricUnit> Units
        {
            get;
        } = new ObservableCollection<BiometricUnit>();
        
        public IHandleRepositoryViewModel<ISessionHandleViewModel> HandleRepository
        {
            get;
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void OnEventMonitored(object sender, EventMonitoredEventArgs e)
        {
            string message = null;
            var dt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff");

            switch (e.EventType)
            {
                case EventTypes.Unclaimed:
                    var u = e.Unclaimed;
                    message = $"[{dt}] [{e.OperationStatus}] [Unclaimed] UnidId: {u.UnidId}, RejectDetail: {u.RejectDetail}";
                    break;
                case EventTypes.UnclaimedIdentify:
                    var ui = e.UnclaimedIdentify;
                    message = $"[{dt}] [{e.OperationStatus}] [UnclaimedIdentify] UnidId: {ui.UnidId}, RejectDetail: {ui.RejectDetail}, FingerPosition: {ui.FingerPosition}";
                    
                    string subMessage = null;
                    var identity = ui.Identity;
                    switch (ui.Identity.Type)
                    {
                        case IdentityTypes.Null:
                            subMessage = $"IdentityTypes: Null";
                            break;
                        case IdentityTypes.WildCard:
                            subMessage = $"IdentityTypes: WildCard";
                            break;
                        case IdentityTypes.Guid:
                            subMessage = $"IdentityTypes: Guid, TemplateGuid: {identity.TemplateGuid}";
                            break;
                        case IdentityTypes.Sid:
                            subMessage = $"IdentityTypes: Guid, Sid: {identity.Sid}";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    message = $"{message}, {subMessage}";
                    break;
                case EventTypes.Error:
                    var err = e.Error;
                    message = $"[{dt}] [{e.OperationStatus}] [Error] ErrorCode: {err.ErrorCode}";
                    break;
            }

            this._DispatcherService.SafeAction(() =>
            {
                this.Events.Add(message);
            });
        }

        #endregion

        #endregion

    }
}