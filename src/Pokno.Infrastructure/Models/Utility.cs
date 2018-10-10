using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Pokno.Model;
using Pokno.Model.Model;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using FirstFloor.ModernUI.Windows.Controls;
using System.Globalization;
using System.Security;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace Pokno.Infrastructure.Models
{
    public class Utility
    {
        public static Store Store { get; set; }
        public static Setting Setting { get; set; }
        public static Person LoggedInUser { get; set; }
        public static EsnecilStatus EsnecilStatus {get; set;}

        public static string ApplicationRoot = AppDomain.CurrentDomain.BaseDirectory;
        public static string DefaultDbPath = AppDomain.CurrentDomain.BaseDirectory + @"db\Pokno.db";

        //public static string DbPath = null;
        //public static string DbPath = System.AppDomain.CurrentDomain.BaseDirectory + @"db\Pokno.db";

        public enum MessageIcon
        {
            Information,
            Exclamation,
            Question,
            Error,
            None
        }

        public static string GetDbPath()
        {
            string db = null;

            try
            {
                string xmlpath = Utility.ApplicationRoot + @"\db\db.xml";
                XmlTextReader reader = new XmlTextReader(xmlpath);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "path")
                        {
                            db = reader.ReadInnerXml();
                            break;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(db))
                {
                    db = DefaultDbPath;
                }
            }
            catch (FileNotFoundException)
            {
                db = DefaultDbPath;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, Utility.MessageIcon.Error);
            }

            return db;
        }

        public static void DisplayMessage(string message, MessageIcon messageIcon)
        {
            MessageBoxImage messageBoxImage = new MessageBoxImage();

            switch (messageIcon)
            {
                case MessageIcon.Information:
                    {
                        messageBoxImage = MessageBoxImage.Information;
                        break;
                    }
                case MessageIcon.Exclamation:
                    {
                        messageBoxImage = MessageBoxImage.Exclamation;
                        break;
                    }
                case MessageIcon.Question:
                    {
                        messageBoxImage = MessageBoxImage.Question;
                        break;
                    }
                case MessageIcon.Error:
                    {
                        messageBoxImage = MessageBoxImage.Error;
                        break;
                    }
                case MessageIcon.None:
                default:
                    {
                        messageBoxImage = MessageBoxImage.None;
                        break;
                    }
            }

            System.Windows.MessageBox.Show(message, "MESSAGE DIALOG", MessageBoxButton.OK, messageBoxImage);
        }
        public static void DisplayMessage(string message)
        {
            MessageBoxButton button = MessageBoxButton.OK;
            ModernDialog.ShowMessage(message, "Message Dialog", button);


            //MessageBoxButton btn = MessageBoxButton.OK;
            //if (true == ok.IsChecked) btn = MessageBoxButton.OK;
            //else if (true == okcancel.IsChecked) btn = MessageBoxButton.OKCancel;
            //else if (true == yesno.IsChecked) btn = MessageBoxButton.YesNo;
            //else if (true == yesnocancel.IsChecked) btn = MessageBoxButton.YesNoCancel;
            //var result = ModernDialog.ShowMessage(message, "Message Dialog", btn);
            //this.msgboxResult.Text = result.ToString();
        }

        public static BitmapImage SetImageSource(string imagePath)
        {
            BitmapImage bitmap = null;

            try
            {
                if (string.IsNullOrWhiteSpace(imagePath))
                {
                    return null;
                }

                // Create a BitmapSource  
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(imagePath);
                bitmap.EndInit();
            }
            catch(Exception)
            {
                bitmap = null;
            }

            return bitmap;
        }

        public static MessageBoxResult DisplayMessage(string message, MessageBoxButton messageBoxButton)
        {
            MessageBoxResult response = ModernDialog.ShowMessage(message, "Message Dialog", messageBoxButton);
            return response;
        }

        public static DateTime GetDate()
        {
            try
            {
                DateTime? date = null;
                if (Setting != null && Setting.ApplicationDate != null)
                {
                    date = Setting.ApplicationDate;
                }
                else
                {
                    date = DateTime.Now;
                }

                DateTime currentDate = DateTime.Now;
                date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, currentDate.Hour, currentDate.Minute, currentDate.Second);

                return date.Value;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static List<Value> GetMonthsInYear()
        {
            List<Value> values = new List<Value>();

            try
            {
                string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;

                for (int i = 0; i < names.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(names[i]))
                    {
                        int j = i + 1;
                        Value value = new Value();
                        value.Id = j;
                        value.Name = names[i];
                        values.Add(value);
                    }
                }

                return values;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ConvertToUnsecureString(SecureString secureString)
        {
            if (secureString == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static bool IsEqual(SecureString ss1, SecureString ss2)
        {
            IntPtr bstr1 = IntPtr.Zero;
            IntPtr bstr2 = IntPtr.Zero;
            try
            {
                bstr1 = Marshal.SecureStringToBSTR(ss1);
                bstr2 = Marshal.SecureStringToBSTR(ss2);
                int length1 = Marshal.ReadInt32(bstr1, -4);
                int length2 = Marshal.ReadInt32(bstr2, -4);
                if (length1 == length2)
                {
                    for (int x = 0; x < length1; ++x)
                    {
                        byte b1 = Marshal.ReadByte(bstr1, x);
                        byte b2 = Marshal.ReadByte(bstr2, x);
                        if (b1 != b2) return false;
                    }
                }
                else return false;
                return true;
            }
            finally
            {
                if (bstr2 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr2);
                if (bstr1 != IntPtr.Zero) Marshal.ZeroFreeBSTR(bstr1);
            }
        }

        public static string ChooseFile()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "SQLite Files (*.db)|*.db";
                openFileDialog.DefaultExt = ".db";

                string selectedFilePath = null;
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes) 
                {
                    selectedFilePath = openFileDialog.FileName;
                }

                return selectedFilePath;





                //OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.Filter = "SQLite Files (*.db)|*.db";
                //openFileDialog.DefaultExt = ".db";

                //string selectedFilePath = null;
                //bool? result = openFileDialog.ShowDialog();
                //if (result == true)
                //{
                //    selectedFilePath = openFileDialog.FileName;
                //}

                //return selectedFilePath;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string ChooseFile(string defaultExtension, string fileFilter)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = defaultExtension;
                openFileDialog.Filter = fileFilter;

                string selectedFilePath = null;
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    selectedFilePath = openFileDialog.FileName;
                }

                //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                                
                //Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                //openFileDialog.DefaultExt = ".db";
                //openFileDialog.Filter = "SQLite Files (*.db)|*.db";
                ////dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

                //bool? result = openFileDialog.ShowDialog();
                //if (result == true)
                //{
                //    selectedFilePath = openFileDialog.FileName;
                //}

                return selectedFilePath;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string BrowseFolder()
        {
            try
            {
                string selectedFolderPath = null;
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.SelectedPath = "C:\\";

                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedFolderPath = folderDialog.SelectedPath;
                }
              

                return selectedFolderPath;
            }
            catch (Exception)
            {
                throw;
            }
        }


        


    }


}
