using System.Windows;
using System.Windows.Controls;
using FrameworkTester.ViewModels;
using WinBiometricDotNet;

namespace FrameworkTester.Selectors
{

    internal sealed class ChildWindowLogTemplateSlector : DataTemplateSelector
    {

        #region Properties

        public DataTemplate CaptureSample
        {
            get;
            set;
        }

        public DataTemplate ControlUnit
        {
            get;
            set;
        }

        public DataTemplate DeleteTemplate
        {
            get;
            set;
        }

        public DataTemplate EnrollBegin
        {
            get;
            set;
        }

        public DataTemplate EnrollCapture
        {
            get;
            set;
        }

        public DataTemplate EnrollCommit
        {
            get;
            set;
        }

        public DataTemplate EnumBiometricUnits
        {
            get;
            set;
        }

        public DataTemplate EnumDatabases
        {
            get;
            set;
        }

        public DataTemplate EnumEnrollments
        {
            get;
            set;
        }

        public DataTemplate EnumServiceProviders
        {
            get;
            set;
        }

        public DataTemplate GetEvent
        {
            get;
            set;
        }

        public DataTemplate GetProperty
        {
            get;
            set;
        }

        public DataTemplate Identify
        {
            get;
            set;
        }

        public DataTemplate SetProperty
        {
            get;
            set;
        }

        public DataTemplate Verify
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Overrids

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is AsyncResultCaptureSampleDummy)
                return this.CaptureSample;
            if (item is AsyncResultControlUnit)
                return this.ControlUnit;
            if (item is AsyncResultDeleteTemplate)
                return this.DeleteTemplate;
            if (item is AsyncResultEnrollBegin)
                return this.EnrollBegin;
            if (item is AsyncResultEnrollCapture)
                return this.EnrollCapture;
            if (item is AsyncResultEnrollCommit)
                return this.EnrollCommit;
            if (item is AsyncResultEnumBiometricUnits)
                return this.EnumBiometricUnits;
            if (item is AsyncResultEnumDatabases)
                return this.EnumDatabases;
            if (item is AsyncResultEnumEnrollmentsDummy)
                return this.EnumEnrollments;
            if (item is AsyncResultEnumServiceProviders)
                return this.EnumServiceProviders;
            if (item is AsyncResultGetEvent)
                return this.GetEvent;
            if (item is AsyncResultGetProperty)
                return this.GetProperty;
            if (item is AsyncResultIdentify)
                return this.Identify;
            if (item is AsyncResultSetProperty)
                return this.SetProperty;
            if (item is AsyncResultVerify)
                return this.Verify;

            return null;
        }

        #endregion

        #endregion

    }

}