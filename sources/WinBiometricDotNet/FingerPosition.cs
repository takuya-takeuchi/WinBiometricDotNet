using WinBiometricDotNet.Interop;
using WINBIO_BIOMETRIC_SUBTYPE = System.Byte;

namespace WinBiometricDotNet
{

    public enum FingerPosition : WINBIO_BIOMETRIC_SUBTYPE
    {

        Unknown = SafeNativeMethods.WINBIO_ANSI_381_POS_UNKNOWN,

        RightThumb = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_THUMB,

        RightIndex = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_INDEX_FINGER,

        RightMiddle = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER,

        RightRing = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_RING_FINGER,

        RightLittle = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_LITTLE_FINGER,

        LeftThumb = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_THUMB,

        LeftIndex = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_INDEX_FINGER,

        LeftMiddle = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER,

        LeftRing = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_RING_FINGER,

        LeftLittle = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_LITTLE_FINGER,

        RightSlap = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_FOUR_FINGERS,

        LeftSlap = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_FOUR_FINGERS,

        TwoThumbs = SafeNativeMethods.WINBIO_ANSI_381_POS_TWO_THUMBS,

        UnspecifiedPosition01 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_01,

        UnspecifiedPosition02 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_02,

        UnspecifiedPosition03 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_03,

        UnspecifiedPosition04 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_04,

        UnspecifiedPosition05 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_05,

        UnspecifiedPosition06 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_06,

        UnspecifiedPosition07 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_07,

        UnspecifiedPosition08 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_08,

        UnspecifiedPosition09 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_09,

        UnspecifiedPosition10 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_10

    }

}