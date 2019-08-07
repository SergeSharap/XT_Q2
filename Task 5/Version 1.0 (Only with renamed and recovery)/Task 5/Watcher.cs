using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Task_5
{
    internal class Watcher
    {
        private FileSystemWatcher watcher;
        private readonly string archivePath;

        public Watcher(string path, string archivePath, string filter)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(path);
            
            watcher = new FileSystemWatcher(path, filter)
            {
                IncludeSubdirectories = true
            };
            this.archivePath = archivePath;
            Directory.CreateDirectory(archivePath);


            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            //watcher.Deleted += Watcher_Deleted;
            //watcher.Renamed += Watcher_Renamed;
        }

        //private void Watcher_Renamed(object sender, RenamedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //private void Watcher_Created(object sender, FileSystemEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File is changed");
            Backup.OnChanged(e, archivePath);
        }
        
        public void BeginWatch()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void StopWatch()
        {
            watcher.EnableRaisingEvents = false;
        }
    }
}
