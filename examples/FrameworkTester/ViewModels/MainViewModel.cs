using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        #region Events
        #endregion

        #region Fields

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

            var winBio = typeof(IWinBioViewModel);
            foreach (var type in Assembly.GetExecutingAssembly()
                                                         .GetTypes()
                                                         .OrderBy(type => type.FullName)
                                                         .Where(type => type != winBio && type.IsInterface && type.GetInterfaces().Contains(winBio)))
            {

                var model = SimpleIoc.Default.GetInstance(type) as IWinBioViewModel;
                this._TestTargets.Add(model);
            }

            foreach (var unit in this._WinBiometricService.EnumBiometricUnits())
                this._Units.Add(unit);
        }

        #endregion

        #region Properties

        private IWinBioViewModel _CurrentTestTarget;

        public IWinBioViewModel CurrentTestTarget
        {
            get
            {
                return this._CurrentTestTarget;
            }
            set
            {
                this._CurrentTestTarget = value;
                this.RaisePropertyChanged();

                this._NavigationService.NavigateTo(value.Name);
            }
        }

        private BiometricUnit _CurrentUnit;

        public BiometricUnit CurrentUnit
        {
            get
            {
                return this._CurrentUnit;
            }
            set
            {
                this._CurrentUnit = value;
                this.RaisePropertyChanged();

                foreach (var viewModel in this._TestTargets)
                    viewModel.CurrentUnit = value;
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
                            if (this._TestTargets.Any())
                                this.CurrentTestTarget = this._TestTargets.FirstOrDefault();

                            if (this._Units.Any())
                                this.CurrentUnit = this._Units.FirstOrDefault();
                        });
                    });
                }));
            }
        }

        private readonly ObservableCollection<IWinBioViewModel> _TestTargets = new ObservableCollection<IWinBioViewModel>();

        public ObservableCollection<IWinBioViewModel> TestTargets => this._TestTargets;

        private readonly ObservableCollection<BiometricUnit> _Units = new ObservableCollection<BiometricUnit>();

        public ObservableCollection<BiometricUnit> Units => this._Units;

        #endregion

        #region Methods

        #region Overrids
        #endregion

        #region Event Handlers
        #endregion

        #region Helpers
        #endregion

        #endregion

    }
}