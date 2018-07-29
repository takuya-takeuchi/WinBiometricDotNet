using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FrameworkTester.Helpers
{

    internal sealed class BitmapSourceHelper
    {

        public static BitmapSource ToBitmapSource(byte[] image, int width, int height, double dpiX, double dpiY)
        {
            unsafe
            {
                fixed (byte* p = &image[0])
                {
                    var palette = new BitmapPalette(Enumerable.Range(0, 256).Select(i => Color.FromRgb((byte)i, (byte)i, (byte)i)).ToList());

                    // capture sample image does not contain stride gap
                    return BitmapFrame.Create(width, height, dpiX, dpiY, PixelFormats.Indexed8, palette, (IntPtr)p, image.Length, width);
                }
            }
        }

    }

}
