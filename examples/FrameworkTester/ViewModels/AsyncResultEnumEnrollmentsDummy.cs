using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    internal sealed class AsyncResultEnumEnrollmentsDummy : AsyncResultParameter
    {

        #region Constructors

        internal AsyncResultEnumEnrollmentsDummy(AsyncResultEnumEnrollments enumEnrollments)
        {
            this.Identity = enumEnrollments.Identity;

            this.FingerPositions.Clear();

            foreach (var value in Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>())
            {
                var b = enumEnrollments.FingerPositions.Contains(value);
                this.FingerPositions.Add(new KeyValuePair<string, bool>(value.ToString(), b));
            }
        }

        #endregion

        #region Properties

        public BiometricIdentity Identity
        {
            get;
        }

        public ObservableCollection<KeyValuePair<string, bool>> FingerPositions
        {
            get;
        } = new ObservableCollection<KeyValuePair<string, bool>>();

        #endregion

    }

}