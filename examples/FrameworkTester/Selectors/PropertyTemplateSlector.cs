using System.Windows;
using System.Windows.Controls;
using FrameworkTester.ViewModels;

namespace FrameworkTester.Selectors
{

    internal sealed class PropertyTemplateSlector : DataTemplateSelector
    {

        #region Properties

        public DataTemplate AntiSpoofPolicy
        {
            get;
            set;
        }

        public DataTemplate Custom
        {
            get;
            set;
        }

        public DataTemplate SampleHint
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Overrids

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is AntiSpoofPolicyPropertyViewModel)
                return this.AntiSpoofPolicy;
            if (item is CustomPropertyViewModel)
                return this.Custom;
            if (item is SampleHintPropertyViewModel)
                return this.SampleHint;

            return null;
        }

        #endregion

        #endregion

    }

}