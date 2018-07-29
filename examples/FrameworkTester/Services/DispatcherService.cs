using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using FrameworkTester.Services.Interfaces;

namespace FrameworkTester.Services
{

    public sealed class DispatcherService : IDispatcherService
    {

        #region フィールド

        private readonly Dispatcher _Dispatcher;

        #endregion

        #region コンストラクタ

        public DispatcherService(Dispatcher dispatcher)
        {
            this._Dispatcher = dispatcher;
        }

        #endregion

        #region メソッド

        public async Task SafeAction(Action action)
        {
            if (!this._Dispatcher.CheckAccess())
                await this._Dispatcher.InvokeAsync(action);
            else
                action.Invoke();
        }

        #endregion

    }

}
