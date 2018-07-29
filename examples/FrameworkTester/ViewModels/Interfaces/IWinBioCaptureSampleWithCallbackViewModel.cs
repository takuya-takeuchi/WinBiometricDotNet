namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioCaptureSampleWithCallbackViewModel : IWinBioCaptureSampleViewModel
    {

        bool Loop
        {
            get;
            set;
        }

    }

}