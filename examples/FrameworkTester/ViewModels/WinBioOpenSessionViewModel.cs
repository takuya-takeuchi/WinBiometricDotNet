using System;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioOpenSessionViewModel : ViewModelBase, IWinBioOpenSessionViewModel
    {

        #region Fields

        private readonly IWinBiometricService _Service;

        #endregion

        #region Constructors

        public WinBioOpenSessionViewModel()
        {
            this._Service = SimpleIoc.Default.GetInstance<IWinBiometricService>();
        }

        #endregion

        #region Properties

        private RelayCommand _ExecuteCommand;

        public RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    try
                    {
                        var session = this._Service.OpenSession();
                        this.SessionHandle = session.Handle;

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        public string Name => "WinBioOpenSession";

        private string _Result;

        public string Result
        {
            get
            {
                return this._Result;
            }
            private set
            {
                this._Result = value;
                this.RaisePropertyChanged();
            }
        }

        private IntPtr _SessionHandle;

        public IntPtr SessionHandle
        {
            get
            {
                return this._SessionHandle;
            }
            private set
            {
                this._SessionHandle = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

    }

}