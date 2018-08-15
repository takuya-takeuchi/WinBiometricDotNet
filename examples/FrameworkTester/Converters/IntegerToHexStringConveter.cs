using System;
using System.Windows.Data;

namespace FrameworkTester.Converters
{

    public sealed class IntegerToHexStringConveter : IValueConverter
    {

        #region Methods

        #region Overrids

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is IntPtr ptr)
                return $"0x{ptr.ToString("X16")}";
            if (value is UIntPtr uptr)
                return $"0x{((ulong)uptr).ToString("X16")}";
            if (value is uint ui)
                return $"0x{ui.ToString("X16")}";
            if (value is int i)
                return $"0x{i.ToString("X16")}";

            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new ArgumentException();
        }

        #endregion

        #endregion

    }

}
