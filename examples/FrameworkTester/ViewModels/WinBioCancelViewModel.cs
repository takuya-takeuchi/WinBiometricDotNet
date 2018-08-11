using System;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioCancelViewModel : WinBioViewModel, IWinBioCancelViewModel
    {

        #region Fields

        private readonly IWinBiometricService _Service;

        #endregion

        #region Constructors

        public WinBioCancelViewModel()
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
                        this._Service.Cancel();
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

        public override string Name => "WinBioCancel";

        #endregion

    }

}