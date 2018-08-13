namespace FrameworkTester.ViewModels.Interfaces
{

    public interface IWinBioCaptureSampleWithCallbackViewModel : IWinBioCaptureSampleViewModel, IWinBioWithCallbackViewModel
    {

        bool Loop
        {
            get;
            set;
        }

    }

}