using System;
using System.Runtime.InteropServices;
using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AsyncResultCaptureSample : AsyncResultParameter
    {

        #region Constructors

        internal unsafe AsyncResultCaptureSample(SafeNativeMethods.WINBIO_ASYNC_RESULT_CAPTURESAMPLE* captureSample)
        {
            this.RejectDetail = (RejectDetail)captureSample->RejectDetail;
            this.SampleSize = (int)captureSample->SampleSize;

            var sample = (SafeNativeMethods.WINBIO_BIR*)captureSample->Sample;
            if (captureSample != null)
            {
                var tmp = (UIntPtr)((ulong)sample + sample->StandardDataBlock.Offset);
                var ansiBdbHeader = (SafeNativeMethods.WINBIO_BDB_ANSI_381_HEADER*)tmp;
                var bdbAnsi381Header = sizeof(SafeNativeMethods.WINBIO_BDB_ANSI_381_HEADER);
                var ansiBdbRecord = (SafeNativeMethods.WINBIO_BDB_ANSI_381_RECORD*)((byte*)(ansiBdbHeader) + bdbAnsi381Header);
                var bdbAnsi381Record = sizeof(SafeNativeMethods.WINBIO_BDB_ANSI_381_RECORD);
                var firstPixel = (IntPtr)ansiBdbRecord + bdbAnsi381Record;

                var image = new byte[ansiBdbRecord->BlockLength - bdbAnsi381Record];
                Marshal.Copy(firstPixel, image, 0, image.Length);

                this.Sample = new CaptureSample(ansiBdbRecord->HorizontalLineLength,
                                                ansiBdbRecord->VerticalLineLength,
                                                ansiBdbHeader->HorizontalScanResolution,
                                                ansiBdbHeader->VerticalScanResolution,
                                                ansiBdbHeader->HorizontalImageResolution,
                                                ansiBdbHeader->VerticalImageResolution,
                                                image);
            }
        }

        #endregion

        #region Properties

        public CaptureSample Sample
        {
            get;
        }

        public int SampleSize
        {
            get;
        }

        public RejectDetail RejectDetail
        {
            get;
        }

        #endregion

    }

}