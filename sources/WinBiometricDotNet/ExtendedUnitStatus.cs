using System;

namespace WinBiometricDotNet
{

    public sealed class ExtendedUnitStatus
    {

        #region Properties

        public SensorStatus Availability
        {
            get;
            set;
        }

        public UInt32 ReasonCode
        {
            get;
            set;
        }

        #endregion

    }

}