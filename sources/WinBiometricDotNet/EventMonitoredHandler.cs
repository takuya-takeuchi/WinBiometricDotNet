namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the method that will handle the <see cref="WinBiometric.EventMonitored"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="EventMonitoredEventArgs"/> that contains the event data.</param>
    public delegate void EventMonitoredHandler(object sender, EventMonitoredEventArgs e);

}