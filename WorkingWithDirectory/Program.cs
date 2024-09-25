using System.IO;
using System.Reflection;
using System.Text.Unicode;

namespace WorkingWithDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process process = new();
            List<string> dirsList = new() { @"c:\Otus\TestDir1", @"c:\Otus\TestDir2" };

            foreach (string dir in dirsList) 
            {
                process.CreateDirectory(dir);

                for (int i = 1; i <= 10; i++)
                {
                    string fileName = $"File{i}";
                    string pathToFile = @$"{dir}\{fileName}";
                    process.CreatFile(pathToFile);
                    process.WriteFile(pathToFile);
                }
            }
            process.AddDate(dirsList);
            process.ReadFile(dirsList);
        }
    }
}
