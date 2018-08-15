using WinBiometricDotNet.Interop;

namespace WinBiometricDotNet
{

    public sealed class AntiSpoofPolicy
    {

        #region Constructors

        internal unsafe  AntiSpoofPolicy(SafeNativeMethods.WINBIO_ANTI_SPOOF_POLICY* ptr)
        {
            this.Action = (AntiSpoofPolicyAction) ptr->Action;
            this.Source = (PolicySource)ptr->Source;
        }

        public AntiSpoofPolicy()
        {
        }

        #endregion

        #region Properties

        public AntiSpoofPolicyAction Action
        {
            get;
            set;
        }

        public PolicySource Source
        {
            get;
            set;
        }

        #endregion

    }

}