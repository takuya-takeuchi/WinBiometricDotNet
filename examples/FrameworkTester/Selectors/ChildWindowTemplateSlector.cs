using System.Windows;
using System.Windows.Controls;
using FrameworkTester.ViewModels.Interfaces;
using WinBiometricDotNet;

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
            if (item is AsyncResult result)
            {
                if (result.Session != null)
                    return this.AsyncOpenSession;
                if (result.Framework != null)
                    return this.AsyncOpenFramework;
            }

            return null;
        }

        #endregion

        #endregion

    }

}