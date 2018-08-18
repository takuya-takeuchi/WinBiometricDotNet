namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the method that will handle the <see cref="WinBiometric.Identified"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="IdentifiedEventArgs"/> that contains the event data.</param>
    public delegate void IdentifiedHandler(object sender, IdentifiedEventArgs e);

}