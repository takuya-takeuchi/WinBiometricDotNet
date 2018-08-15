using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnrollCaptureViewModel : WinBioSessionViewModel, IWinBioEnrollCaptureViewModel
    {

        #region Properties

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    this.RejectDetail = 0;

                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var session = this.WindowRepository.SelectedWindow.Session;
                        var result = this.BiometricService.CaptureEnroll(session);

                        switch (result.OperationStatus)
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
                            case OperationStatus.MoreData:
                                this.Result = "MoreData";
                                break;
                            case OperationStatus.Unknown:
                                this.Result = "Unknown";
                                break;
                        }

                        this.RejectDetail = result.RejectDetail;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.WindowRepository?.SelectedWindow != null));
            }
        }

        public override string Name => "WinBioEnrollCapture";

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

        #endregion

    }

}