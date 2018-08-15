using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;
using WinBiometricDotNet.Runtime.InteropServices;

namespace FrameworkTester.ViewModels
{

    public sealed class AsyncOpenFrameworkChildWindowViewModel : ChildWindowViewModel<IFrameworkHandleViewModel>, IAsyncOpenFrameworkChildWindowViewModel, IFrameworkHandleViewModel
    {

        #region Constructors

        public AsyncOpenFrameworkChildWindowViewModel(Window window, uint messageCode)
            : base(window, messageCode)
        {
        }

        #endregion

        #region Properties

        private Framework _Framework;

        public Framework Framework
        {
            get => this._Framework;
            private set
            {
                this._Framework = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        #region Overrids

        protected override void ProcessMessage(IntPtr hwnd, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var result = Marshal.PtrToAsyncResult(lParam);
            this.Result = result;
            this.Framework = result.Framework;

            var dt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff");
            var message = $"[{dt}] [{result.OperationType}]";

            this.Logs.Insert(0, message);
        }

        #endregion

        #endregion

    }

}