using System;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioOpenSessionViewModel : WinBioViewModel, IWinBioOpenSessionViewModel
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

        public override RelayCommand ExecuteCommand
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

        public override string Name => "WinBioOpenSession";

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