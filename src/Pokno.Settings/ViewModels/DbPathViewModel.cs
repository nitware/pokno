using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Infrastructure.Models;
using Pokno.Infrastructure.ViewModel;
using Prism.Commands;
using System.Windows;
using System.Xml;
using System.IO;

namespace Pokno.Settings.ViewModels
{
    public class DbPathViewModel : BaseApplicationViewModel
    {
        private string _color;
        private string _dbPath;
        private bool _useDefaultDb;
        
        public DbPathViewModel()
        {
            SelectDbFileCommand = new DelegateCommand(OnSelectDbFileCommand, CanSelectDbFile);
            SetDbCommand = new DelegateCommand(OnSetDbCommand, CanSetDb);

            SetDbPath(Utility.GetDbPath());
        }

        public DelegateCommand SetDbCommand { get; protected set; }
        public DelegateCommand SelectDbFileCommand { get; protected set; }

        public string Color 
        {
            get { return _color; }
            set
            {
                _color = value;
                base.OnPropertyChanged("Color");
            }
        }
        public bool UseDefaultDb
        {
            get { return _useDefaultDb; }
            set
            {
                _useDefaultDb = value;
                base.OnPropertyChanged("UseDefaultDb");

                Color = _useDefaultDb ? "White" : "Gray";

                SelectDbFileCommand.RaiseCanExecuteChanged();
            }
        }
        public string DbPath
        {
            get { return _dbPath; }
            set
            {
                _dbPath = value;
                base.OnPropertyChanged("DbPath");
            }
        }

        private bool CanSetDb()
        {
            return true;
        }
        private bool CanSelectDbFile()
        {
            return UseDefaultDb ? false : true;
        }
        private void SetDbPath(string dbPath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(dbPath))
                {
                    if (dbPath == Utility.DefaultDbPath)
                    {
                        DbPath = null;
                        UseDefaultDb = true;
                    }
                    else
                    {
                        DbPath = dbPath;
                        UseDefaultDb = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message);
            }
        }
       
        private void OnSetDbCommand()
        {
            XmlTextWriter writer = null;
            string dbFilePath = Utility.ApplicationRoot + @"\db\db.xml";

            try
            {
                string dbPath = "";

                if (!UseDefaultDb)
                {
                    dbPath = DbPath;

                    if (string.IsNullOrWhiteSpace(dbPath))
                    {
                        Utility.DisplayMessage("Invalid Db path!", Utility.MessageIcon.Exclamation);
                        return;
                    }
                    else if (!File.Exists(dbPath))
                    {
                        Utility.DisplayMessage("Selected Db path not found!", Utility.MessageIcon.Exclamation);
                        return;
                    }
                }

                writer = new XmlTextWriter(dbFilePath, Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;

                writer.WriteStartElement("db");
                writer.WriteStartElement("path");
                writer.WriteString(dbPath);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                Utility.DisplayMessage("Db path has been successfully set. StorePro will automatically shut down, for the changes to take effect", Utility.MessageIcon.Information);

                Application.Current.Shutdown();
            }
            catch (System.IO.FileNotFoundException fnfex)
            {
                Utility.DisplayMessage(fnfex.Message, Utility.MessageIcon.Error);
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        private void OnSelectDbFileCommand()
        {
            try
            {
                DbPath = Utility.ChooseFile();
            }
            catch (Exception ex)
            {
                Utility.DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }
        }
        //private void SetDbPath()
        //{
           
        //}


    }



}
