namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the method that will handle the <see cref="WinBiometric.AsyncCompleted"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="AsyncCompletedEventArgs"/> that contains the event data.</param>
    public delegate void AsyncCompletedHandler(object sender, AsyncCompletedEventArgs e);

}