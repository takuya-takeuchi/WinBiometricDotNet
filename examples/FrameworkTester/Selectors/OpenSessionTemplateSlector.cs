using System.Windows;
using System.Windows.Controls;
using FrameworkTester.ViewModels;

namespace FrameworkTester.Selectors
{

    internal sealed class OpenSessionTemplateSlector : DataTemplateSelector
    {

        #region Properties

        public DataTemplate Normal
        {
            get;
            set;
        }

        public DataTemplate AsyncMessage
        {
            get;
            set;
        }

        public DataTemplate AsyncCallback
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Overrids

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is SessionViewModel)
                return this.Normal;
            if (item is AsyncMessagedSessionViewModel || item is AsyncOpenSessionChildWindowViewModel)
                return this.AsyncMessage;
            if (item is AsyncCallbackedSessionViewModel)
                return this.AsyncCallback;

            return null;
        }

        #endregion

        #endregion

    }

}