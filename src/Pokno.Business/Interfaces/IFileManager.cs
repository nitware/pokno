using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Business.Interfaces
{
    public interface IFileManager
    {
        bool FileExist(string filePath);
        string GetFileName(string filePath);
        void DeleteAllFilesInFolder(string destinationFolder);
        void Save(string destinationFolder, string sourceFilePath, string destinationfileName);
        void CreateFolder(string folderPath);
    }



}
