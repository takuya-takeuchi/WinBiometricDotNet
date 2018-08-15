using System;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class SessionViewModel : ISessionHandleViewModel
    {

        #region Constructors

        public SessionViewModel(Session session)
        {
            this.Session = session;
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

    }

    public sealed class AsyncCallbackedSessionViewModel : ISessionHandleViewModel
    {

        #region Constructors

        public AsyncCallbackedSessionViewModel(Session session)
        {
            this.Session = session;
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

    }

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

    }

}