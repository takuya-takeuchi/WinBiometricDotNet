using System;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class AsyncMessagedSessionViewModel : ISessionHandleViewModel
    {

        #region Constructors

        public AsyncMessagedSessionViewModel(Session session, uint messageCode, IntPtr handle)
        {
            this.Session = session;
            this.MessageCode = messageCode;
            this.Handle = handle;
        }

        #endregion

        #region Properties

        public IntPtr Handle
        {
            get;
        }

        public uint MessageCode
        {
            get;
        }

        public Session Session
        {
            get;
        }

        #endregion

        #region Methods

        public void Attach(Session session)
        {
        }

        #endregion

    }

}