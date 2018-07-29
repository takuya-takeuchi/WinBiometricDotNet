using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FrameworkTester.Services.Interfaces;

namespace FrameworkTester.Services
{

    public sealed class FrameNavigationService : IFrameNavigationService, INotifyPropertyChanged
    {

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Fields

        private readonly Dictionary<string, Uri> _PagesByKey;

        private readonly List<string> _Historic;

        private string _CurrentPageKey;

        #endregion

        #region Constructors

        public FrameNavigationService()
        {
            this._PagesByKey = new Dictionary<string, Uri>();
            this._Historic = new List<string>();
        }

        #endregion

        #region Properties

        public string CurrentPageKey
        {
            get
            {
                return this._CurrentPageKey;
            }
            private set
            {
                if (this._CurrentPageKey == value)
                {
                    return;
                }

                this._CurrentPageKey = value;
                this.OnPropertyChanged();
            }
        }

        public object Parameter
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public void GoBack()
        {
            if (this._Historic.Count > 1)
            {
                this._Historic.RemoveAt(this._Historic.Count - 1);
                this.NavigateTo(this._Historic.Last(), null);
            }
        }

        public void NavigateTo(string pageKey)
        {
            this.NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            lock (this._PagesByKey)
            {
                if (!this._PagesByKey.ContainsKey(pageKey))
                    throw new ArgumentException($"No such page: {pageKey}", pageKey);

                if (GetDescendantFromName(Application.Current.MainWindow, "Frame") is Frame frame)
                {
                    frame.Source = this._PagesByKey[pageKey];
                }

                this.Parameter = parameter;
                this._Historic.Add(pageKey);
                this.CurrentPageKey = pageKey;
            }
        }

        public void Configure(string key, Uri pageType)
        {
            lock (this._PagesByKey)
            {
                if (this._PagesByKey.ContainsKey(key))
                {
                    this._PagesByKey[key] = pageType;
                }
                else
                {
                    this._PagesByKey.Add(key, pageType);
                }
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            if (count < 1)
                return null;

            for (var i = 0; i < count; i++)
            {
                if (!(VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement))
                    continue;

                if (frameworkElement.Name == name)
                    return frameworkElement;

                frameworkElement = GetDescendantFromName(frameworkElement, name);
                if (frameworkElement != null)
                    return frameworkElement;
            }
            return null;
        }

        #region Helpers

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #endregion
    }

}
