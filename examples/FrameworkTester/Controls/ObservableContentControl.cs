using System.Windows.Controls;

namespace FrameworkTester.Controls
{

    public class ObservableContentControl : ContentControl
    {

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            if (this.ContentTemplateSelector == null)
            {
                return;
            }
            this.OnContentTemplateSelectorChanged(null, this.ContentTemplateSelector);
        }

    }

}
