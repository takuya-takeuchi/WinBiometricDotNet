using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public abstract class ChildWindowViewModel<T> : ViewModelBase, IChildWindowViewModel
        where T: class, IHandleViewModel
    {

        #region Fields

        private readonly IDispatcherService _DispatcherService;

        private readonly IHandleRepositoryViewModel<T> _HandleRepository;

        private HwndSource _HwndSource;

        private readonly Window _Window;

        #endregion

        #region Constructors

        protected ChildWindowViewModel(Window window, uint messageCode)
        {
            this._DispatcherService = SimpleIoc.Default.GetInstance<IDispatcherService>();
            this._HandleRepository = SimpleIoc.Default.GetInstance<IHandleRepositoryViewModel<T>>();

            this._Window = window;
            this.MessageCode = messageCode;

            this._Window.Loaded += this.OnLoaded;
        }

        #endregion

        #region Properties

        private RelayCommand _ClearLogsCommand;

        public RelayCommand ClearLogsCommand
        {
            get
            {
                return this._ClearLogsCommand ?? (this._ClearLogsCommand = new RelayCommand(async () =>
                {
                    await Task.Run(() =>
                    {
                        this._DispatcherService.SafeAction(() =>
                        {
                            this.AsyncResultLogs.Clear();
                        });
                    });
                }));
            }
        }

        private AsyncResult _Result;

        protected AsyncResult Result
        {
            get => this._Result;
            set
            {
                this._Result = value;

                this.ApiStatus = value?.ApiStatus ?? 0;
                this.OperationType = value?.OperationType ?? 0;
                this.SequenceNumber = value?.SequenceNumber ?? 0;
                //this.SessionHandle = value?.SessionHandle ?? UIntPtr.Zero;
                this.UnitId = value?.UnitId ?? 0;
                this.UserData = value?.UserData ?? IntPtr.Zero;
                this.TimeStamp = value?.TimeStamp ?? DateTime.FromFileTime(0);
            }
        }

        private IntPtr _Handle;

        public IntPtr Handle
        {
            get => this._Handle;
            private set
            {
                this._Handle = value;
                this.RaisePropertyChanged();
            }
        }

        private DateTime _LastReceived;

        public DateTime LastReceived
        {
            get => this._LastReceived;
            private set
            {
                this._LastReceived = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<AsyncResult> AsyncResultLogs
        {
            get;
        } = new ObservableCollection<AsyncResult>();

        private AsyncResult _SelectedAsyncResult;

        public AsyncResult SelectedAsyncResult
        {
            get => this._SelectedAsyncResult;
            set
            {
                this._SelectedAsyncResult = value;
                this.RaisePropertyChanged();

                if (value?.Parameter is AsyncResultCaptureSample sample)
                {
                    this.SelectedAsyncResultParameter = new AsyncResultCaptureSampleDummy(sample);
                }
                else if (value?.Parameter is AsyncResultEnumEnrollments enumEnrollments)
                {
                    this.SelectedAsyncResultParameter = new AsyncResultEnumEnrollmentsDummy(enumEnrollments);
                }
                else
                {
                    this.SelectedAsyncResultParameter = value?.Parameter;
                }
            }
        }

        private AsyncResultParameter _SelectedAsyncResultParameter;

        public AsyncResultParameter SelectedAsyncResultParameter
        {
            get => this._SelectedAsyncResultParameter;
            private set
            {
                this._SelectedAsyncResultParameter = value;
                this.RaisePropertyChanged();
            }
        }

        public uint MessageCode
        {
            get;
        }

        private int _ApiStatus;

        public int ApiStatus
        {
            get => this._ApiStatus;
            private set
            {
                this._ApiStatus = value;
                this.RaisePropertyChanged();
            }
        }

        private OperationTypes _OperationType;

        public OperationTypes OperationType
        {
            get => this._OperationType;
            private set
            {
                this._OperationType = value;
                this.RaisePropertyChanged();
            }
        }

        private ulong _SequenceNumber;

        public ulong SequenceNumber
        {
            get => this._SequenceNumber;
            private set
            {
                this._SequenceNumber = value;
                this.RaisePropertyChanged();
            }
        }

        private UIntPtr _SessionHandle;

        public UIntPtr SessionHandle
        {
            get => this._SessionHandle;
            private set
            {
                this._SessionHandle = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _UnitId;

        public uint UnitId
        {
            get => this._UnitId;
            private set
            {
                this._UnitId = value;
                this.RaisePropertyChanged();
            }
        }

        private IntPtr _UserData;

        public IntPtr UserData
        {
            get => this._UserData;
            private set
            {
                this._UserData = value;
                this.RaisePropertyChanged();
            }
        }

        private DateTime _TimeStamp;

        public DateTime TimeStamp
        {
            get => this._TimeStamp;
            private set
            {
                this._TimeStamp = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        protected abstract void ProcessMessage(IntPtr hwnd, IntPtr wParam, IntPtr lParam, ref bool handled);

        #region Event Handlers

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var handle = new WindowInteropHelper(this._Window).Handle;
            this._HwndSource = HwndSource.FromHwnd(handle);
            if (this._HwndSource == null)
                return;

            this._HwndSource.AddHook(this.WndProc);

            this.Handle = handle;
            
            this._Window.Loaded -= this.OnLoaded;
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // WM_CLOSE
            if (msg == 0x0010)
            {
                this._HandleRepository.Handles.Remove(this as T);
            }
            else if (msg == this.MessageCode)
            {
                this.LastReceived = DateTime.Now;
                this.ProcessMessage(hwnd, wParam, lParam, ref handled);
            }

            return IntPtr.Zero;
        }

        #endregion

        #endregion

    }

}