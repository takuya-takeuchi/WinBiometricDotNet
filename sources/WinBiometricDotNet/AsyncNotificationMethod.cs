using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// <para>Defines constants that specify how completion notifications for asynchronous operations are to be delivered to the client application.</para>
    /// <para>This API supports the product infrastructure and is not intended to be used directly from your code.</para>
    /// </summary>
    public enum AsyncNotificationMethod
    {

        /// <summary>
        /// The operation is synchronous.
        /// </summary>
        NotifyNone = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_NONE,

        /// <summary>
        /// The client-implemented PWINBIO_ASYNC_COMPLETION_CALLBACK function is called by the framework.
        /// </summary>
        NotifyCallback = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_CALLBACK,

        /// <summary>
        /// The framework sends completion notices to the client application window message queue.
        /// </summary>
        NotifyMessage = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MESSAGE,

        /// <summary>
        /// The maximum enumeration value. This constant is not directly used by the WinBioAsyncOpenFramework and WinBioAsyncOpenSession.
        /// </summary>
        NotifyMaximumValue = SafeNativeMethods.WINBIO_ASYNC_NOTIFICATION_METHOD.WINBIO_ASYNC_NOTIFY_MAXIMUM_VALUE

    }

}