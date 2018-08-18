using System;
using System.Windows.Data;
using WinBiometricDotNet.Runtime.InteropServices;
using HRESULT = System.Int32;

namespace FrameworkTester.Converters
{

    public sealed class HResultToStringConveter : IValueConverter
    {

        #region Methods

        #region Overrids

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is HRESULT hresult)
                return $"0x{hresult:X8} ({Marshal.GetWinBiometricExceptionFromHR(hresult).Message})";

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
