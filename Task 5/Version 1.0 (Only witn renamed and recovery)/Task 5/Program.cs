using System;
using System.IO;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"F:\Program Files\VisualStudio\Projects\Storage\diplom.txt";
            //path = Path.GetRelativePath(@"F:\Program Files\VisualStudio\", path);
            //Console.WriteLine(path);

            //string lastWrite;
            //FileInfo file = new FileInfo(@"F:\Program Files\VisualStudio\Projects\Storage\diplom.txt");
            //lastWrite = file.LastWriteTime.ToString();
            //lastWrite = lastWrite.Replace(':', ',');
            //Console.WriteLine(lastWrite);

            //Directory.CreateDirectory($"F:\\Program Files\\VisualStudio\\Projects\\Storage\\Новая папка\\Новая папка");
            //string path1 = Path.Combine($"F:\\Program Files\\VisualStudio", $"Projects\\Storage\\a\\ghgh", $"{lastWrite}diplom1.txt");
            ////File.Copy(@"F:\Program Files\VisualStudio\Projects\Storage\diplom.txt", path1);
            //string ddd = lastWrite.Replace(',', ':');
            //DateTime d = Convert.ToDateTime(ddd);
            //Cons[ole.WriteLine(d);

            //Watcher watcher = new Watcher(@"F:\Program Files\VisualStudio\Projects\Storage", @"F:\Program Files\VisualStudio\Projects\Archive", "*.txt");
            //watcher.BeginWatch();
            //Console.Read();

            //Recovery recovery = new Recovery(@"F:\Program Files\VisualStudio\Projects\Archive", @"F:\Program Files\VisualStudio\Projects\Storage", new DateTime(2019, 08, 06, 18, 00, 00));
            //recovery.RunRecovery();

            Menu menu = new Menu();
            menu.Choice();


            //Path.GetDirectoryName(e.Name)



        }
    }
}
