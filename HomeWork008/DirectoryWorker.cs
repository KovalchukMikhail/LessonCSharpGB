using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork008
{
    public class DirectoryWorker
    {
        public void GetAllFilesWithExtension(string extension, string directory, List<FileInfo> files)
        {
            if (Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                FileInfo[] tempFiles = directoryInfo.GetFiles();
                foreach (FileInfo file in tempFiles)
                {
                    if(file.Extension == extension)
                    {
                        files.Add(file);
                    }
                }
                DirectoryInfo[] tempDirectories = directoryInfo.GetDirectories();
                foreach(DirectoryInfo dir in tempDirectories)
                {
                    GetAllFilesWithExtension(extension, dir.FullName, files);
                }
            }
        }
    }
}
