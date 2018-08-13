using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FrameworkTester.Services.Interfaces
{

    public interface IDispatcherService
    {

        Task SafeAction(Action action);

        void UpdateUI(DispatcherPriority priority, int waitMsec);

    }

}
