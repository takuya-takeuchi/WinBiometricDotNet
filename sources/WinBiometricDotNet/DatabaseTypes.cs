using System;

namespace WinBiometricDotNet
{

    [Flags]
    public enum DatabaseTypes
    {

        File = 0x00000001,

        DatabaseManagementSystem = 0x00000002,

        OnChip = 0x00000003,

        SmartCard = 0x00000004

    }

}