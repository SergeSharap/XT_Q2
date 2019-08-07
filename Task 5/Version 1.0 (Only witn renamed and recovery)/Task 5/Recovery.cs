using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_5
{
    internal class Recovery
    {
        private readonly string archivePath;
        private readonly string storagePath;
        private readonly DateTime recoveryDateTime;
        private List<string> files;

        public Recovery(string archPath, string storPath, DateTime date)
        {
            archivePath = archPath;
            storagePath = storPath;
            recoveryDateTime = date;
            files = new List<string>();
        }

        public void RunRecovery()
        {
            DirectoryInfo storageDir = new DirectoryInfo(storagePath);

            foreach (FileInfo file in storageDir.EnumerateFiles())
                file.Delete();
            foreach (DirectoryInfo dir in storageDir.EnumerateDirectories())
                dir.Delete(true);
            
            DirectoryInfo archiveDir = new DirectoryInfo(archivePath);
            RecursiveRecovery(archiveDir);
        }

        private void RecursiveRecovery(DirectoryInfo dir)
        {
            FileInfo[] filesInfo = dir.GetFiles();
            DirectoryInfo[] dirInfo = dir.GetDirectories();
            files.Clear();

            using (StreamReader sr = File.OpenText(Path.Combine(dir.FullName, "index")))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    files.Add(s);
                }
            }

            foreach (var file in files)
            {
                string pattern = @"\d{2}.\d{2}.\d{4}-\d{2}.\d{2}.\d{2} - " + $"{file}";
                DateTime dateTime = DateTime.MinValue;
                FileInfo recoveryFile = null;

                foreach (var fileInfo in filesInfo)
                {
                    if (!Regex.IsMatch(fileInfo.Name, pattern)) continue;
                    string stringData = fileInfo.Name.Replace($" - {file}", "");
                    if (!DateTime.TryParseExact(stringData, "dd.MM.yyyy-HH.mm.ss", null, DateTimeStyles.None, out DateTime tempDateTime))
                        throw new InvalidCastException();

                    if (tempDateTime >= recoveryDateTime || tempDateTime <= dateTime) continue;
                    dateTime = tempDateTime;
                    recoveryFile = fileInfo;
                }

                if (recoveryFile == null) continue;

                string destPath = Path.Combine(storagePath, Path.GetRelativePath(archivePath, dir.FullName), file);
                if (!Directory.Exists(Path.GetDirectoryName(destPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                File.Copy(recoveryFile.FullName, destPath);
                //FileSystemEventArgs e = new FileSystemEventArgs(WatcherChangeTypes.Created, Path.GetDirectoryName(destPath), Path.GetFileName(destPath));
                //Backup.OnChanged(e, archivePath);
            }

            foreach (DirectoryInfo childDir in dirInfo)
                RecursiveRecovery(childDir);
        }
    }
}
