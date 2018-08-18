using WinBiometricDotNet.Interop;
using WINBIO_BIOMETRIC_SUBTYPE = System.Byte;

namespace WinBiometricDotNet
{

    /// <summary>
    /// The <see cref="FingerPosition"/> enumeration specifies the numeric number of finger position.
    /// </summary>
    public enum FingerPosition : WINBIO_BIOMETRIC_SUBTYPE
    {

        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = SafeNativeMethods.WINBIO_ANSI_381_POS_UNKNOWN,

        /// <summary>
        /// The thumb finger of right hand.
        /// </summary>
        RightThumb = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_THUMB,

        /// <summary>
        /// The index finger of right hand.
        /// </summary>
        RightIndex = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_INDEX_FINGER,

        /// <summary>
        /// The middle finger of right hand.
        /// </summary>
        RightMiddle = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER,

        /// <summary>
        /// The ring finger of right hand.
        /// </summary>
        RightRing = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_RING_FINGER,

        /// <summary>
        /// The little finger of right hand.
        /// </summary>
        RightLittle = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_LITTLE_FINGER,

        /// <summary>
        /// The thumb finger of left hand.
        /// </summary>
        LeftThumb = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_THUMB,

        /// <summary>
        /// The index finger of left hand.
        /// </summary>
        LeftIndex = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_INDEX_FINGER,

        /// <summary>
        /// The middle finger of left hand.
        /// </summary>
        LeftMiddle = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER,

        /// <summary>
        /// The ring finger of left hand.
        /// </summary>
        LeftRing = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_RING_FINGER,

        /// <summary>
        /// The little finger of left hand.
        /// </summary>
        LeftLittle = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_LITTLE_FINGER,

        /// <summary>
        /// The four-finger slap of right hand.
        /// </summary>
        RightSlap = SafeNativeMethods.WINBIO_ANSI_381_POS_RH_FOUR_FINGERS,

        /// <summary>
        /// The four-finger slap of left hand.
        /// </summary>
        LeftSlap = SafeNativeMethods.WINBIO_ANSI_381_POS_LH_FOUR_FINGERS,

        /// <summary>
        /// The two-thumbs.
        /// </summary>
        TwoThumbs = SafeNativeMethods.WINBIO_ANSI_381_POS_TWO_THUMBS,

        /// <summary>
        /// The unspecified position 01.
        /// </summary>
        UnspecifiedPosition01 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_01,

        /// <summary>
        /// The unspecified position 02.
        /// </summary>
        UnspecifiedPosition02 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_02,

        /// <summary>
        /// The unspecified position 03.
        /// </summary>
        UnspecifiedPosition03 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_03,

        /// <summary>
        /// The unspecified position 04.
        /// </summary>
        UnspecifiedPosition04 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_04,

        /// <summary>
        /// The unspecified position 05.
        /// </summary>
        UnspecifiedPosition05 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_05,

        /// <summary>
        /// The unspecified position 06.
        /// </summary>
        UnspecifiedPosition06 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_06,

        /// <summary>
        /// The unspecified position 07.
        /// </summary>
        UnspecifiedPosition07 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_07,

        /// <summary>
        /// The unspecified position 08.
        /// </summary>
        UnspecifiedPosition08 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_08,

        /// <summary>
        /// The unspecified position 09.
        /// </summary>
        UnspecifiedPosition09 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_09,

        /// <summary>
        /// The unspecified position 10.
        /// </summary>
        UnspecifiedPosition10 = SafeNativeMethods.WINBIO_FINGER_UNSPECIFIED_POS_10

    }

}