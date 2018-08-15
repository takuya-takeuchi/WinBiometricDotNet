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

        #region Methods

        public void Attach(Session session)
        {
        }

        #endregion

    }

}