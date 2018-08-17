namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the method that will handle the <see cref="WinBiometric.SampleCaptured"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="CaptureSampleEventArgs"/> that contains the event data.</param>
    public delegate void SampleCapturedHandler(object sender, CaptureSampleEventArgs e);

}