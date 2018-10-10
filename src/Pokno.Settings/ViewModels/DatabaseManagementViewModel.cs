using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Prism.Events;
using Prism.Commands;
using System.Data.SQLite;
using System.ComponentModel;
using Pokno.Infrastructure.ViewModel;
using Pokno.Infrastructure.Models;
using Pokno.Service;

namespace Pokno.Settings.ViewModels
{
    public class DatabaseManagementViewModel : BaseApplicationViewModel
    {
        private bool _canBackupDb;
        private bool _canCompactDb;
        private bool _canRestoreDb;
        private string _backupFolderPath;
        private string _backedUpFilePath;
        private string _databaseFileSize;
        private string _shrinkedFileSize;
        private string _recorveredFileSize;
        private long _databaseRawFileSize;

        private IEventAggregator _eventAggregator;
        private readonly IBusinessFacade _service;
        private BackgroundWorker _worker;
       
        public DatabaseManagementViewModel(IBusinessFacade service, IEventAggregator eventAggregator)
        {
            _service = service;
            _eventAggregator = eventAggregator;

            SetDbProperties();
            CanBackupDb = Utility.LoggedInUser.Role.PersonRight.CanBackupDb;
            CanRestoreDb = Utility.LoggedInUser.Role.PersonRight.CanRestoreDb;
            CanCompactDb = Utility.LoggedInUser.Role.PersonRight.CanCompactDb;

            SelectBackupFileCommand = new DelegateCommand(OnSelectBackupFileCommand);
            SelectBackedUpFileCommand = new DelegateCommand(OnSelectBackedUpFileCommand);
            RestoreDatabaseCommand = new DelegateCommand(OnRestoreDatabaseCommand, CanRestoreDatabase);
            BackupDatabaseCommand = new DelegateCommand(OnBackupDatabaseCommand, CanBackupDatabase);
            ShrinkDatabaseCommand = new DelegateCommand(OnShrinkDatabaseCommand);
                        

            //ReadFile();
        }

        public string DataSource { get; private set; }
        public string DatabaseFilePath { get; private set; }
        public DelegateCommand SelectBackupFileCommand { get; private set; }
        public DelegateCommand SelectBackedUpFileCommand { get; private set; }
        public DelegateCommand RestoreDatabaseCommand { get; private set; }
        public DelegateCommand BackupDatabaseCommand { get; private set; }
        public DelegateCommand ShrinkDatabaseCommand { get; private set; }

        public bool CanCompactDb 
        {
            get { return _canCompactDb; }
            set
            {
                _canCompactDb = value;
                base.OnPropertyChanged("CanCompactDb");
            }
        }
        public bool CanBackupDb
        {
            get { return _canBackupDb; }
            set
            {
                _canBackupDb = value;
                base.OnPropertyChanged("CanBackupDb");
            }
        }
        public bool CanRestoreDb
        {
            get { return _canRestoreDb; }
            set
            {
                _canRestoreDb = value;
                base.OnPropertyChanged("CanRestoreDb");
            }
        }

        public string TabCaption
        {
            get { return "DB Maintenance"; }
        }
        public string BackupFolderPath
        {
            get { return _backupFolderPath; }
            set
            {
                _backupFolderPath = value;
                base.OnPropertyChanged("BackupFolderPath");
                BackupDatabaseCommand.RaiseCanExecuteChanged();
            }
        }
        public string BackedUpFilePath
        {
            get { return _backedUpFilePath; }
            set
            {
                _backedUpFilePath = value;
                base.OnPropertyChanged("BackedUpFilePath");
                RestoreDatabaseCommand.RaiseCanExecuteChanged();
            }
        }
        public string DatabaseFileSize
        {
            get { return _databaseFileSize; }
            set
            {
                _databaseFileSize = value;
                base.OnPropertyChanged("DatabaseFileSize");
            }
        }
        public long DatabaseRawFileSize
        {
            get { return _databaseRawFileSize; }
            set
            {
                _databaseRawFileSize = value;
                base.OnPropertyChanged("DatabaseRawFileSize");
            }
        }
        public string ShrinkedFileSize
        {
            get { return _shrinkedFileSize; }
            set
            {
                _shrinkedFileSize = value;
                base.OnPropertyChanged("ShrinkedFileSize");
            }
        }
        public string RecorveredFileSize
        {
            get { return _recorveredFileSize; }
            set
            {
                _recorveredFileSize = value;
                base.OnPropertyChanged("RecorveredFileSize");
            }
        }

        private bool CanRestoreDatabase()
        {
            return !string.IsNullOrWhiteSpace(BackedUpFilePath);
        }
        private bool CanBackupDatabase()
        {
            return !string.IsNullOrWhiteSpace(BackupFolderPath);
        }
        private void SetDbProperties()
        {
            try
            {
                DataSource = string.Format("Data Source={0}\\Pokno.db; Version=3;", AppDomain.CurrentDomain.BaseDirectory + @"db");
                DatabaseFilePath = string.Format("{0}\\Pokno.db", AppDomain.CurrentDomain.BaseDirectory + @"db");

                SetDbFileSize();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void SetDbFileSize()
        {
            try
            {
                DatabaseRawFileSize = GetRawFileSize(DatabaseFilePath);
                DatabaseFileSize = GetCalculatedFileSize(DatabaseRawFileSize);

                ShrinkedFileSize = "";
                RecorveredFileSize = "";
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        private string GetCalculatedFileSize(long dbFileSize)
        {
            const decimal ONE_KILO_BYTE = 1024;
            const decimal ONE_MEGA_BYTE = 1048576;
            const decimal ONE_GIGA_BYTE = 1073741824;
            const decimal ONE_TERA_BYTE = 1099511627776;
            const decimal ONE_PETA_BYTE = 1125899906842624;
            const decimal ONE_EXA_BYTE = 1152921504606846976;
            //const decimal ONE_ZETTA_BYTE = 1180591620717411303424;
            //const decimal ONE_YOTTA_BYTE = 1208925819614629174706176;

            try
            {
                string fileSize = null;
                decimal calculatedFileSize = 0;

                if (dbFileSize >= ONE_EXA_BYTE)
                {
                    calculatedFileSize = Math.Round(dbFileSize / ONE_EXA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " EB";
                }
                else if (dbFileSize >= ONE_PETA_BYTE)
                {
                    calculatedFileSize = Math.Round(dbFileSize / ONE_PETA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " PB";
                }
                else if (dbFileSize >= ONE_TERA_BYTE)
                {
                    calculatedFileSize = Math.Round(dbFileSize / ONE_TERA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " TB";
                }
                else if (dbFileSize >= ONE_GIGA_BYTE)
                {
                    calculatedFileSize = Math.Round(dbFileSize / ONE_GIGA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " GB";
                }
                else if (dbFileSize >= ONE_MEGA_BYTE)
                {
                    calculatedFileSize = Math.Round(dbFileSize / ONE_MEGA_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " MB";
                }
                else if (dbFileSize >= ONE_KILO_BYTE)
                {
                    calculatedFileSize = Math.Round(dbFileSize / ONE_KILO_BYTE, 2);
                    fileSize = calculatedFileSize.ToString() + " KB";
                }
                else
                {
                    calculatedFileSize = Math.Round(calculatedFileSize, 2);
                    fileSize = calculatedFileSize > 1 ? calculatedFileSize.ToString() + " Bytes" : calculatedFileSize.ToString() + " Byte";
                }

                return fileSize;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private long GetRawFileSize(string filePath)
        {
            try
            {
                FileInfo databaseFile = new FileInfo(filePath);
                long dbFileSize = databaseFile.Length;
                return dbFileSize;
            }
            catch(Exception)
            {
                throw;
            }
        }
        private void OnBackupDatabaseCommand()
        {
            SQLiteConnection sourceDbConnection = null;
            SQLiteConnection destinationDbConnection = null;

            try
            {
                if (InvalidBackupDirectory())
                {
                    return;
                }

                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnBackupDatabaseCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            sourceDbConnection = new SQLiteConnection(DataSource);
                            destinationDbConnection = new SQLiteConnection(string.Format("Data Source={0}\\PoknoBkp.db; Version=3;", BackupFolderPath));

                            sourceDbConnection.Open();
                            destinationDbConnection.Open();

                            sourceDbConnection.BackupDatabase(destinationDbConnection, "main", "main", -1, null, 0);

                            destinationDbConnection.Close();
                            sourceDbConnection.Close();


                           
                            //using (var sourceDbConnection = new System.Data.SQLite.SQLiteConnection(DataSource))
                            //{
                            //    using (var destinationDbConnection = new System.Data.SQLite.SQLiteConnection(string.Format("Data Source={0}\\PoknoBkp.db; Version=3;", BackupFolderPath)))
                            //    {
                            //        sourceDbConnection.Open();
                            //        destinationDbConnection.Open();

                            //        sourceDbConnection.BackupDatabase(destinationDbConnection, "main", "main", -1, null, 0);

                            //        sourceDbConnection.Close();
                            //        destinationDbConnection.Close();
                            //    }
                            //}
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
            finally
            {
                if (sourceDbConnection != null)
                {
                    sourceDbConnection.Dispose();
                }
                if (destinationDbConnection != null)
                {
                    destinationDbConnection.Dispose();
                }
            }
        }

        private bool InvalidBackupDirectory()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(BackupFolderPath))
                {
                    Utility.DisplayMessage("Please select backup file location!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (!Directory.Exists(BackupFolderPath))
                {
                    Utility.DisplayMessage("Select backup file location does not exist!", Utility.MessageIcon.Exclamation);
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void OnBackupDatabaseCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message, Utility.MessageIcon.Error);
                    return;
                }

                Utility.DisplayMessage("Store database backup was successful.", Utility.MessageIcon.Information);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnShrinkDatabaseCommand()
        {
            SQLiteCommand cmd = null;
            SQLiteConnection dbConnection = null;

            try
            {
                using (_worker = new BackgroundWorker())
                {
                    _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnShrinkDatabaseCommandCompleted);
                    _worker.DoWork += (s, e) =>
                        {
                            dbConnection = new SQLiteConnection(DataSource);
                            dbConnection.Open();

                            cmd = dbConnection.CreateCommand();
                            cmd.CommandText = "vacuum";
                            cmd.ExecuteNonQuery();

                            dbConnection.Close();


                            

                            //using (SQLiteConnection dbConnection = new SQLiteConnection(DataSource))
                            //{
                            //    dbConnection.Open();
                            //    using (SQLiteCommand cmd = dbConnection.CreateCommand())
                            //    {
                            //        cmd.CommandText = "vacuum";
                            //        cmd.ExecuteNonQuery();
                            //    }

                            //    dbConnection.Close();
                            //}
                        };
                    _worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (dbConnection != null)
                {
                    dbConnection.Dispose();
                }
            }
        }

        private void OnShrinkDatabaseCommandCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Utility.DisplayMessage(e.Error.Message, Utility.MessageIcon.Error);
                    return;
                }

                long shrinkedFileSize = GetRawFileSize(DatabaseFilePath);
                long recorveredFileSize = DatabaseRawFileSize - shrinkedFileSize;

                ShrinkedFileSize = GetCalculatedFileSize(shrinkedFileSize);
                RecorveredFileSize = GetCalculatedFileSize(recorveredFileSize);

                Utility.DisplayMessage("Your store database has been successfully shrinked/compacted.", Utility.MessageIcon.Information);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnRestoreDatabaseCommand()
        {
            try
            {
                if (IsInvalid(BackedUpFilePath, DatabaseFilePath))
                {
                    return;
                }

                File.Copy(BackedUpFilePath, DatabaseFilePath, true);
                _service.RefreshDatabase(DatabaseFilePath);

                SetDbFileSize();
                Utility.DisplayMessage("The database has been successfully restored.", Utility.MessageIcon.Information);
            }
            catch(Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private void OnSelectBackedUpFileCommand()
        {
            try
            {
               //string backedUpPath = Utility.ChooseFile();
               //if (string.IsNullOrWhiteSpace(backedUpPath))
               //{
               //    return;
               //}

               BackedUpFilePath = Utility.ChooseFile();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        private void OnSelectBackupFileCommand()
        {
            try
            {
                //string backupPath = Utility.BrowseFolder();
                //if (string.IsNullOrWhiteSpace(backupPath))
                //{
                //    return;
                //}

                BackupFolderPath = Utility.BrowseFolder();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        private bool IsInvalid(string sourceFile, string destinationFile)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceFile))
                {
                    Utility.DisplayMessage("No source file specified!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (string.IsNullOrWhiteSpace(destinationFile))
                {
                    Utility.DisplayMessage("No destination file selected!", Utility.MessageIcon.Exclamation);
                    return true;
                }

                const string SQLITE_DB_EXTENSION = ".db";
                FileInfo backedUpFile = new FileInfo(sourceFile);
                FileInfo databaseFile = new FileInfo(destinationFile);

                string sourceFileExtension = backedUpFile.Extension;
                string destinationFileExtension = databaseFile.Extension;
                if (sourceFileExtension != SQLITE_DB_EXTENSION)
                {
                    Utility.DisplayMessage("The source file, is not a valid database file!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (destinationFileExtension != SQLITE_DB_EXTENSION)
                {
                    Utility.DisplayMessage("The destination file, is not a valid database file!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                                
                if (backedUpFile == null)
                {
                    Utility.DisplayMessage("Invalid source file!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (databaseFile == null)
                {
                    Utility.DisplayMessage("Invalid destination file!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                
                if (!File.Exists(sourceFile))
                {
                    Utility.DisplayMessage("Specified source file does not exist!", Utility.MessageIcon.Exclamation);
                    return true;
                }
                else if (!File.Exists(destinationFile))
                {
                    Utility.DisplayMessage("Specified destination file does not exist!", Utility.MessageIcon.Exclamation);
                    return true;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void ReadFile()
        {
            try
            {
                string posBook = @"C:\Users\Dan\Documents\library\Books\pos\eBook-186408705628_2.pdf";
                string posBookCracked = @"C:\Users\Dan\Documents\library\Books\pos\cracked_pos.doc";
               


                //// Make a new file via FileInfo.Open().
                //FileInfo f2 = new FileInfo(posBook);
                //FileStream fs2 = f2.OpenRead();
                //StreamReader sreader = f2.OpenText();

                //FileStream fs = f2.Open(FileMode.Open, FileAccess.ReadWrite);

                //StreamWriter swriterAppend = File.AppendText(posBook);

                int j = 0;
               
                byte[] bookContent  = File.ReadAllBytes(posBook);
                //byte[] m = new byte[bookContent.Length - 1900];
                //for (int i = 1000; i < bookContent.Length - 1000; i++)
                //{
                //    m[j++]= bookContent[i];
                //}
               
                //m = bookContent.Take(bookContent.Length - 2).ToArray();
                //File.WriteAllBytes(posBookCracked, m);
                File.WriteAllBytes(posBookCracked, bookContent);
                

                

                

                //FileInfo f6 = new FileInfo(@"C:\Users\Dan\Documents\library\Books\pos\copy.txt");
                //StreamWriter swriter = f6.CreateText();
                //swriter.Write(sreader.ReadToEnd());

                //string text = sreader.ReadToEnd();

                //bool canRead = fs2.CanRead;
                ////fs2.ToString();
                //Utility.DisplayMessage(text.Length.ToString(), Utility.MessageIcon.Information);

                // Use the FileStream object...

                // Close down file stream.
                //fs2.Close();
                //fs2.Dispose();

                //sreader.Dispose();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }

        

        

        

        





    }
}
