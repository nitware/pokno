using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Business.Interfaces;

namespace Pokno.Business
{
    public class FileManager : IFileManager
    {
        public bool FileExist(string filePath)
        {
            try
            {
                return File.Exists(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetFileName(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return null;
                }

                FileInfo file = new FileInfo(filePath);
                return file.Name;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Save(string destinationFolder, string sourceFilePath, string destinationfileName)
        {
            try
            {
                if (!File.Exists(sourceFilePath))
                {
                    throw new Exception("Source file path does no exit!");
                }

                DeleteAllFilesInFolder(destinationFolder);

                string destinationfilePath = destinationFolder + @"\" + destinationfileName;
                if (File.Exists(destinationfilePath))
                {
                    File.Delete(destinationfilePath);
                }
                                                
                CreateFolder(destinationFolder);
                File.Copy(sourceFilePath, destinationfilePath, true);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void DeleteAllFilesInFolder(string destinationFolder)
        {
            try
            {
                if (!Directory.Exists(destinationFolder))
                {
                    return;
                }

                IEnumerable<string> filePaths = Directory.EnumerateFiles(destinationFolder);
                if (filePaths != null && filePaths.Count() > 0)
                {
                    foreach (string filePath in filePaths)
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch(IOException ex)
                        {
                            if (!ex.Message.Contains("it is being used by another process"))
                            {
                                throw new IOException(ex.Message);
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void CreateFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }




    }




}
