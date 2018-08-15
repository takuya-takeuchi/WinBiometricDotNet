using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnumEnrollmentsViewModel : WinBioSessionViewModel, IWinBioEnumEnrollmentsViewModel
    {

        #region Properties

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        this._FingerPositions.Clear();

                        var session = this.HandleRepository.SelectedHandle.Session;
                        var positions = this.BiometricService.EnumEnrollments(session, this.SelectedUnit);
                        var resuls = new List<KeyValuePair<string, bool>>();
                        foreach (var value in Enum.GetValues(typeof(FingerPosition)).Cast<FingerPosition>())
                        {
                            var b = positions.Contains(value);
                            resuls.Add(new KeyValuePair<string, bool>(value.ToString(), b));
                        }

                        foreach (var keyValuePair in resuls)
                            this._FingerPositions.Add(keyValuePair);

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }, () => this.HandleRepository?.SelectedHandle != null));
            }
        }

        public override string Name => "WinBioEnumEnrollments";

        private readonly ObservableCollection<KeyValuePair<string, bool>> _FingerPositions = new ObservableCollection<KeyValuePair<string, bool>>();

        public ObservableCollection<KeyValuePair<string, bool>> FingerPositions
        {
            get
            {
                return this._FingerPositions;
            }
        }

        #endregion

    }

}