using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDirectory
{
    public class Process
    {
        public void CreateDirectory(string dirPath) 
        {
            string dirName = dirPath.Split('\\')[^1];
            DirectoryInfo dir = new(dirPath);
            try
            {
                if (dir.Exists)
                {
                    Console.WriteLine($"Path - {dirPath} exists already.");
                    return;
                }

                dir.Create();
                Console.WriteLine($"The directory {dirName} was created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }

        public void CreatFile(string path)
        {
            FileStream fs = File.Create(path, 1024);
            fs.Dispose();
        }
        public void WriteFile(string path)
        {
            string fileName = path.Split('\\')[^1];
            try
            {
                if (fileName == null || fileName.Length == 0)
                {
                    throw new ArgumentNullException("FileName");
                }

                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Exists)
                {
                    using (FileStream sr = File.Open(path, FileMode.Open, FileAccess.Write))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes($"File name: {fileName}" + Environment.NewLine);
                        sr.Write(info, 0, info.Length);
                    }
                }
                else
                {
                    throw new FileNotFoundException("The file was not found.", fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }

        public void AddDate(List<string> dirsList) 
        {
            foreach (string dir in dirsList)
            {
                DirectoryInfo directory = new DirectoryInfo(dir);
                if (!directory.Exists)
                {
                    Console.WriteLine($"Directory - {dir} dose not exist.");
                    return;
                }
                FileInfo[] fi = directory.GetFiles();
                foreach (FileInfo fileInfo in fi)
                {
                    File.AppendAllText(@$"{fileInfo.FullName}", DateTime.Now.ToString());
                }
            }
        }


        public void ReadFile(List<string> dirsList)
        {
            foreach (string dir in dirsList)
            {
                DirectoryInfo directory = new DirectoryInfo(dir);
                if (!directory.Exists)
                {
                    Console.WriteLine($"Directory - {dir} dose not exist.");
                    return;
                }
                FileInfo[] fi = directory.GetFiles();
                foreach (FileInfo fileInfo in fi)
                {
                    using (StreamReader sr = File.OpenText(fileInfo.FullName))
                    {
                        string s = "";
                        List<string> list = new();
                        while ((s = sr.ReadLine()) != null)
                        {
                            list.Add(s);
                        }
                        Console.WriteLine($"{fileInfo.Name}: {list[0]} + {list[1]}");
                    }
                }
            }
        }
    }
}