using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    /// <summary>
    /// Represents the antispoofing policy for a user.
    /// </summary>
    public sealed class AntiSpoofPolicy
    {

        #region Constructors

        internal unsafe  AntiSpoofPolicy(SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY* ptr)
        {
            this.Action = (AntiSpoofPolicyAction) ptr->Action;
            this.Source = (PolicySource)ptr->Source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AntiSpoofPolicy"/> class.
        /// </summary>
        public AntiSpoofPolicy()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the action to take for the antispoofing policy.
        /// </summary>
        public AntiSpoofPolicyAction Action
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value for the antispoofing policy.
        /// </summary>
        public PolicySource Source
        {
            get;
            set;
        }

        #endregion

    }

}