namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the method that will handle the <see cref="WinBiometric.SensorLocated"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="LocateSensorEventArgs"/> that contains the event data.</param>
    public delegate void SensorLocatedHandler(object sender, LocateSensorEventArgs e);

}