namespace HomeWork008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = string.Empty;
            string extension = string.Empty;
            string text = string.Empty;

            if (args.Length == 3)
            {
                dir = args[0];
                extension = args[1];
                text = args[2];
            }  
            else if (args.Length == 2)
            {
                dir = @"..\..\..\Text";
                extension = args[0];
                text = args[1];
            } 
            else
            {
                Console.WriteLine("Переданы некорректные параметры");
                return;
            }
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            DirectoryWorker dirWorker = new DirectoryWorker();
            List<FileInfo> files = new List<FileInfo>();
            dirWorker.GetAllFilesWithExtension(extension, dir, files);
            if(files.Count > 0)
            {
                FileWorker fileWorker = new FileWorker();
                Dictionary<FileInfo, string> dict = fileWorker.FindAllFilesWithText(text, files);
                if(dict.Count > 0)
                {
                    foreach (KeyValuePair<FileInfo, string> file in dict)
                    {
                        Console.WriteLine($"В тексте файла {file.Key.FullName}\nСодержится искомый фрагмент [{text}]\n" +
                            $"Полный текст файла:\n{file.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("Не удалось найти файл содержащий введенный фрагмент");
                }
            }
        }
    }
}