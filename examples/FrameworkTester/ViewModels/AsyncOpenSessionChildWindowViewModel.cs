using System;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Ioc;
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
            this.IdentityRepository = SimpleIoc.Default.GetInstance<IBiometricIdentityRepositoryViewModel>();
        }

        #endregion

        #region Properties

        public IBiometricIdentityRepositoryViewModel IdentityRepository
        {
            get;
        }

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

        public void Attach(Session session)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            try
            {
                if (this.Session != null)
                    SimpleIoc.Default.GetInstance<IWinBiometricService>().CloseSession(this.Session);
            }
            catch
            {

            }

            this.Session = session;
        }

        #endregion

        #region Methods

        #region Overrids

        protected override void ProcessMessage(IntPtr hwnd, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var result = Marshal.PtrToAsyncResult(lParam);

            this.Result = result;
            this.Session = result.Session;

            if(result.Parameter is AsyncResultIdentity identity)
            {
                this.IdentityRepository.Add(identity.Identity);
            }

            this.AsyncResultLogs.Insert(0, result);
            this.SelectedAsyncResult = result;
        }

        #endregion

        #endregion

    }

}