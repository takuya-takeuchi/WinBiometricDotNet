using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using FrameworkTester.ViewModels.Interfaces;
using GalaSoft.MvvmLight.Command;
using WinBiometricDotNet;

namespace FrameworkTester.ViewModels
{

    public sealed class WinBioEnumDatabasesViewModel : WinBioWithCallbackViewModel, IWinBioEnumDatabasesViewModel
    {

        #region Constructors

        public WinBioEnumDatabasesViewModel()
        {
            this._Databases.CollectionChanged += (sender, args) =>
            {
                this.DispatcherService.SafeAction(() => this.RemoveDatabaseCommand.RaiseCanExecuteChanged());
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
                        var guid = this.BiometricService.CreateDatabase(this.CurrentUnit);
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

        private BiometricDatabase _CurrentDatabase;

        public BiometricDatabase CurrentDatabase
        {
            get
            {
                return this._CurrentDatabase;
            }
            set
            {
                this._CurrentDatabase = value;
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
                        this.CurrentDatabase = null;

                        this._Databases.Clear();
                        foreach (var database in this.BiometricService.EnumBiometricDatabases())
                            this._Databases.Add(database);

                        if (this._Databases.Any())
                            this.CurrentDatabase = this._Databases.First();

                        this.Result = "OK";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
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
                        var databaseId = this._CurrentDatabase.DatabaseId;
                        this.BiometricService.RemoveDatabase(this.CurrentUnit, databaseId);
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