namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the method that will handle the <see cref="WinBiometric.Verified"/> event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="VerifyEventArgs"/> that contains the event data.</param>
    public delegate void VerifyHandler(object sender, VerifyEventArgs e);

}