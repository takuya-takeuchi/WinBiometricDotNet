using System.Windows;
using System.Windows.Controls;
using FrameworkTester.ViewModels.Interfaces;

namespace FrameworkTester.Selectors
{

    internal sealed class ChildWindowTemplateSlector : DataTemplateSelector
    {

        #region Properties

        public DataTemplate AsyncOpenFramework
        {
            get;
            set;
        }

        public DataTemplate AsyncOpenSession
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Overrids

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IAsyncOpenFrameworkChildWindowViewModel)
                return this.AsyncOpenFramework;
            if (item is IAsyncOpenSessionChildWindowViewModel)
                return this.AsyncOpenSession;

            return null;
        }

        #endregion

        #endregion

    }

}