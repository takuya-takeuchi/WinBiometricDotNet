using System;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;
using WinBiometricDotNet.Runtime.InteropServices;

namespace FrameworkTester.ViewModels
{

    public sealed class AsyncOpenSessionChildWindowViewModel : ChildWindowViewModel<ISessionHandleViewModel>, IAsyncOpenSessionChildWindowViewModel, ISessionHandleViewModel
    {

        #region Constructors

        public AsyncOpenSessionChildWindowViewModel(Window window, uint messageCode)
            : base(window, messageCode)
        {
        }

        #endregion

        #region Properties

        private Session _Session;

        public Session Session
        {
            get => this._Session;
            private set
            {
                this._Session = value;
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
            this.Session = result.Session;

            var dt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff");
            var message = $"[{dt}] [{result.OperationType}]";

            this.Logs.Insert(0, message);
        }

        #endregion

        #endregion

    }

}