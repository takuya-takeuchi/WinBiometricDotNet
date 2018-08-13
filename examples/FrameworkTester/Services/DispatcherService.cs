using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using FrameworkTester.Services.Interfaces;

namespace FrameworkTester.Services
{

    public sealed class DispatcherService : IDispatcherService
    {

        #region Fields

        private readonly Dispatcher _Dispatcher;

        #endregion

        #region Constructors

        public DispatcherService(Dispatcher dispatcher)
        {
            this._Dispatcher = dispatcher;
        }

        #endregion

        #region Methods

        public async Task SafeAction(Action action)
        {
            if (!this._Dispatcher.CheckAccess())
                await this._Dispatcher.InvokeAsync(action);
            else
                action.Invoke();
        }

        public void UpdateUI(DispatcherPriority priority, int waitMsec)
        {
            var frame = new DispatcherFrame();
            var callback = new DispatcherOperationCallback(obj =>
            {
                ((DispatcherFrame)obj).Continue = false;
                return null;
            });

            this._Dispatcher.BeginInvoke(priority, callback, frame);
            Dispatcher.PushFrame(frame);
            Thread.Sleep(waitMsec);
        }

        #endregion

    }

}
