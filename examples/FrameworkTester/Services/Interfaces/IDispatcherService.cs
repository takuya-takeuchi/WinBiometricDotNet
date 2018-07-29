using System;
using System.Threading.Tasks;

namespace FrameworkTester.Services.Interfaces
{

    public interface IDispatcherService
    {

        Task SafeAction(Action action);

    }

}
