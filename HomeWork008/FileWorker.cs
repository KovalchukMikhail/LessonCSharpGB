using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork008
{
    public class FileWorker
    {
        public Dictionary<FileInfo, string> FindAllFilesWithText(string text, List<FileInfo> files)
        {
            if (files == null || files.Count == 0)
            {
                return null;
            }
            Dictionary<FileInfo, string> result = new Dictionary<FileInfo, string>();
            foreach (FileInfo file in files)
            {
                using (StreamReader sr = new StreamReader(file.FullName, System.Text.Encoding.UTF8))
                {
                    string str = sr.ReadToEnd();
                    if(str.Contains(text))
                    {
                        result.Add(file, str);
                    }
                }
            }
            return result;
        }
    }
}
