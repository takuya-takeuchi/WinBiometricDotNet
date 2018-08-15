using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using FrameworkTester.Services.Interfaces;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnumDatabasesViewModel : WinBioViewModel, IWinBioEnumDatabasesViewModel
    {

        #region Fields

        private readonly IDispatcherService _DispatcherService;

        #endregion

        #region Constructors

        public WinBioEnumDatabasesViewModel()
        {
            this._DispatcherService = SimpleIoc.Default.GetInstance<IDispatcherService>();

            this._Databases.CollectionChanged += (sender, args) =>
            {
                this._DispatcherService.SafeAction(() => this.RemoveDatabaseCommand.RaiseCanExecuteChanged());
            };
        }

        #endregion

        #region Properties

        private RelayCommand _CreateDatabaseCommand;

        public RelayCommand CreateDatabaseCommand
        {
            get
            {
                return this._CreateDatabaseCommand ?? (this._CreateDatabaseCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this.Result = "WAIT";
                        this.UpdateUIImmediately();

                        var guid = this.BiometricService.CreateDatabase(this.SelectedUnit);

                        this.Result = "OK";

                        MessageBox.Show($"{guid} was created.");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        private BiometricDatabase _SelectedDatabase;

        public BiometricDatabase SelectedDatabase
        {
            get
            {
                return this._SelectedDatabase;
            }
            set
            {
                this._SelectedDatabase = value;
                this.RaisePropertyChanged();
            }
        }

        private RelayCommand _ExecuteCommand;

        public override RelayCommand ExecuteCommand
        {
            get
            {
                return this._ExecuteCommand ?? (this._ExecuteCommand = new RelayCommand(() =>
                {
                    try
                    {
                        this.SelectedDatabase = null;

                        this._Databases.Clear();
                        foreach (var database in this.BiometricService.EnumBiometricDatabases())
                            this._Databases.Add(database);

                        if (this._Databases.Any())
                            this.SelectedDatabase = this._Databases.First();

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, this.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Result = "FAIL";
                    }
                }));
            }
        }

        public override string Name => "WinBioEnumDatabases";

        private readonly ObservableCollection<BiometricDatabase> _Databases = new ObservableCollection<BiometricDatabase>();

        public ObservableCollection<BiometricDatabase> Databases
        {
            get
            {
                return this._Databases;
            }
        }

        private RelayCommand _RemoveDatabaseCommand;

        public RelayCommand RemoveDatabaseCommand
        {
            get
            {
                return this._RemoveDatabaseCommand ?? (this._RemoveDatabaseCommand = new RelayCommand(() =>
                {
                    try
                    {
                        var databaseId = this._SelectedDatabase.DatabaseId;
                        this.BiometricService.RemoveDatabase(this.SelectedUnit, databaseId);
                        this.Result = "OK";

                        var database = this._Databases.First(d => d.DatabaseId == databaseId);
                        if (database != null)
                            this._Databases.Remove(database);

                        MessageBox.Show($"{databaseId} was removed.");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        this.Result = "FAIL";
                    }
                }, () => this._Databases.Any()));
            }
        }

        #endregion

    }

}