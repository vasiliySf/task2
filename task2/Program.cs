using System;
using System.IO;
namespace FileSystem
{
    class Program
    {
        static long SizeFiles;

        static void Main(string[] args)
        {
            string rootDir;
            //задаем папку для обхода
            if (args.Length == 0)
                rootDir = @"e:\Camera\";
            else
                rootDir = args[0].ToString();


            //вызываем рекурсивный метод
            Walk(new DirectoryInfo(rootDir));
            Console.WriteLine(SizeFiles.ToString());

        }
        static void Walk(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            // Получаем все файлы в текущем каталоге
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                //выводим имена файлов в консоль
                foreach (FileInfo fi in files)
                {
                    //Console.WriteLine(fi.FullName);
                    SizeFiles += fi.Length;
                }

                //получаем все подкаталоги
                subDirs = root.GetDirectories();
                //проходим по каждому подкаталогу
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    //РЕКУРСИЯ
                    Walk(dirInfo);
                }
            }
        }
    }
}
