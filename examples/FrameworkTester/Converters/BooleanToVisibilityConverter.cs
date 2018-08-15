using System;
using System.Windows;
using System.Windows.Data;

namespace FrameworkTester.Converters
{

    public sealed class BooleanToVisibilityConverter : IValueConverter
    {

        #region Properties

        public bool IsHidden
        {
            get;
            set;
        }

        public bool TriggerValue
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Overrids

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return this.GetVisibility(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Event Handlers
        #endregion

        #region Helpers

        private object GetVisibility(object value)
        {
            if (!(value is bool))
            {
                return DependencyProperty.UnsetValue;
            }

            var objValue = (bool)value;
            if ((objValue && this.TriggerValue && this.IsHidden) || (!objValue && !this.TriggerValue && this.IsHidden))
            {
                return Visibility.Hidden;
            }

            if ((objValue && this.TriggerValue && !this.IsHidden) || (!objValue && !this.TriggerValue && !this.IsHidden))
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        #endregion

        #endregion

    }

}