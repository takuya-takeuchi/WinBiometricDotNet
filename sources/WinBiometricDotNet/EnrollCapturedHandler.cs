namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the method that will handle the <see cref="WinBiometric.EnrollCaptured"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="EnrollCapturedEventArgs"/> that contains the event data.</param>
    public delegate void EnrollCapturedHandler(object sender, EnrollCapturedEventArgs e);

}