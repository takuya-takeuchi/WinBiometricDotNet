using GalaSoft.MvvmLight.Views;

namespace FrameworkTester.Services.Interfaces
{

    public interface IFrameNavigationService : INavigationService
    {

        object Parameter
        {
            get;
        }

    }

}