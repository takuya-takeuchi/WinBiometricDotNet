using System;
using System.Windows;
using System.Windows.Media.Imaging;
using FrameworkTester.Helpers;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioCaptureSampleWithCallbackViewModel : WinBioViewModel, IWinBioCaptureSampleWithCallbackViewModel
    {

        #region Fields

        private readonly IDispatcherService _DispatcherService;

        #endregion

        #region Constructors

        public WinBioCaptureSampleWithCallbackViewModel()
        {
            this._DispatcherService = SimpleIoc.Default.GetInstance<IDispatcherService>();

            WinBiometric.SampleCaptured -= this.WinBiometricOnSampleCaptured;
            WinBiometric.SampleCaptured += this.WinBiometricOnSampleCaptured;

            this.WaitCallback = false;
        }

        #endregion

        #region Properties

        private RelayCommand _CancelCommand;

        public RelayCommand CancelCommand
        {
            get
            {
                return this._CancelCommand ?? (this._CancelCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this.BiometricService.Cancel();

                        this.WaitCallback = false;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);

                        this.WaitCallback = true;
                    }
                }, () => this._WaitCallback));
            }
        }

        private BitmapSource _CaptureImage;

        public BitmapSource CaptureImage
        {
            get
            {
                return this._CaptureImage;
            }
            private set
            {
                this._CaptureImage = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageWidth;

        public int CaptureImageWidth
        {
            get
            {
                return this._CaptureImageWidth;
            }
            private set
            {
                this._CaptureImageWidth = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageHeight;

        public int CaptureImageHeight
        {
            get
            {
                return this._CaptureImageHeight;
            }
            private set
            {
                this._CaptureImageHeight = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageHorizontalResolution;

        public int CaptureImageHorizontalResolution
        {
            get
            {
                return this._CaptureImageHorizontalResolution;
            }
            private set
            {
                this._CaptureImageHorizontalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageVerticalResolution;

        public int CaptureImageVerticalResolution
        {
            get
            {
                return this._CaptureImageVerticalResolution;
            }
            private set
            {
                this._CaptureImageVerticalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageScanHorizontalResolution;

        public int CaptureImageScanHorizontalResolution
        {
            get
            {
                return this._CaptureImageScanHorizontalResolution;
            }
            private set
            {
                this._CaptureImageScanHorizontalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private int _CaptureImageScanVerticalResolution;

        public int CaptureImageScanVerticalResolution
        {
            get
            {
                return this._CaptureImageScanVerticalResolution;
            }
            private set
            {
                this._CaptureImageScanVerticalResolution = value;
                this.RaisePropertyChanged();
            }
        }

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this.Result = "WAIT";
                        this.BiometricService.CaptureSampleWithCallback();

                        this.WaitCallback = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";

                        this.WaitCallback = false;
                    }
                }, () => !this._WaitCallback));
            }
        }

        private bool _Loop;

        public bool Loop
        {
            get
            {
                return this._Loop;
            }
            set
            {
                this._Loop = value;
                this.RaisePropertyChanged();
            }
        }

        public override string Name => "WinBioCaptureSampleWithCallback";

        private RejectDetails _RejectDetail;

        public RejectDetails RejectDetail
        {
            get
            {
                return this._RejectDetail;
            }
            private set
            {
                this._RejectDetail = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _SampleSize;

        public uint SampleSize
        {
            get
            {
                return this._SampleSize;
            }
            private set
            {
                this._SampleSize = value;
                this.RaisePropertyChanged();
            }
        }

        private uint _UnitId;

        public uint UnitId
        {
            get
            {
                return this._UnitId;
            }
            private set
            {
                this._UnitId = value;
                this.RaisePropertyChanged();
            }
        }

        private bool _WaitCallback;

        private bool WaitCallback
        {
            set
            {
                this._WaitCallback = value;

                this.RaisePropertyChanged();

                this.ExecuteCommand.RaiseCanExecuteChanged();
                this.CancelCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Methods

        #region Event Handlers

        private void WinBiometricOnSampleCaptured(object sender, CaptureSampleEventArgs e)
        {
            this._DispatcherService.SafeAction(() =>
            {
                this.WaitCallback = false;
            });

            switch (e.Result.OperationStatus)
            {
                case OperationStatus.OK:
                    this.Result = "OK";
                    break;
                case OperationStatus.BadCapture:
                    this.Result = "BadCapture";
                    break;
                case OperationStatus.Canceled:
                    this.Result = "Canceled";
                    break;
                case OperationStatus.Unknown:
                    this.Result = "Unknown";
                    break;
            }

            this.RejectDetail = e.Result.RejectDetail;
            this.SampleSize = e.Result.SampleSize;
            this.UnitId = e.Result.UnitId;

            var captureSample = e.Result.Sample;
            if (captureSample != null)
            {
                var image = BitmapSourceHelper.ToBitmapSource(captureSample.Image,
                    captureSample.Width,
                    captureSample.Height,
                    captureSample.HorizontalImageResolution,
                    captureSample.VerticalImageResolution);
                if (image.CanFreeze)
                    image.Freeze();
                this.CaptureImage = image;

                this.CaptureImageWidth = captureSample.Width;
                this.CaptureImageHeight = captureSample.Height;
                this.CaptureImageHorizontalResolution = captureSample.HorizontalImageResolution;
                this.CaptureImageVerticalResolution = captureSample.VerticalImageResolution;
                this.CaptureImageScanHorizontalResolution = captureSample.HorizontalScanResolution;
                this.CaptureImageScanVerticalResolution = captureSample.VerticalScanResolution;
            }
            else
            {
                this.CaptureImageWidth = -1;
                this.CaptureImageHeight = -1;
                this.CaptureImageHorizontalResolution = -1;
                this.CaptureImageVerticalResolution = -1;
                this.CaptureImageScanHorizontalResolution = -1;
                this.CaptureImageScanVerticalResolution = -1;
            }
        }

        #endregion

        #endregion

    }

}