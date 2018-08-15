using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public enum AsyncNotificationMethod
    {

        NotifyNone = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_NONE,

        NotifyCallback = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK,

        NotifyMessage = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE,

        NotifyMaximumValue = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MAXIMUM_VALUE

    }

}