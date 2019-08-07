using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_5
{
    internal static class Backup
    {

        internal static void OnChanged(FileSystemEventArgs e, string archivePath)
        {
            Console.WriteLine("Check");
            FileInfo fileInfo = new FileInfo(e.FullPath);
            string fileName = Path.GetFileName(e.Name);
            string lastWrite = fileInfo.LastWriteTime.ToString("dd.MM.yyyy-HH.mm.ss");

            string archiveFullPath = Path.Combine(archivePath, Path.GetDirectoryName(e.Name));
            if (!Directory.Exists(archiveFullPath))
            {
                Directory.CreateDirectory(archiveFullPath);
                CopyAndIndexFile(e.FullPath, Path.Combine(archiveFullPath, $"{lastWrite} - {fileName}"));
                return;
            }

            string pattern = @"\d{2}.\d{2}.\d{4}-\d{2}.\d{2}.\d{2} - " + $"{fileName}";
            DirectoryInfo files = new DirectoryInfo(archiveFullPath);
            FileInfo[] filesInfo = files.GetFiles();

            DateTime lastDate = DateTime.MinValue;
            string lastFile = null;
            foreach (var file in filesInfo)
            {
                if (!Regex.IsMatch(file.Name, pattern)) continue;
                string stringData = file.Name.Replace($" - {fileName}", "");
                DateTime.TryParseExact(stringData, "dd.MM.yyyy-HH.mm.ss", null, DateTimeStyles.None, out DateTime tempDateTime);

                if (tempDateTime <= lastDate) continue;
                lastDate = tempDateTime;
                lastFile = file.Name;
            }

            if (lastFile is null)
            {
                CopyAndIndexFile(e.FullPath, Path.Combine(archiveFullPath, $"{lastWrite} - {fileName}"));
                return;
            }

            string fileHash, storageFileHash;
            using (var stream = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read))
            {
                fileHash = GetHash(stream);
            }

            using (var stream = new FileStream(Path.Combine(archiveFullPath, lastFile), FileMode.Open, FileAccess.Read))
            {
                storageFileHash = GetHash(stream);
            }

            if (fileHash != storageFileHash)
            {
                CopyAndIndexFile(e.FullPath, Path.Combine(archiveFullPath, $"{lastWrite} - {fileName}"));
            }
        }

        internal static void CopyAndIndexFile(string sourceFileName, string destFileName)
        {
            File.Copy(sourceFileName, destFileName);
            string indexFile = Path.Combine(Path.GetDirectoryName(destFileName), "index");

            if (!File.Exists(indexFile))
            {
                using (StreamWriter sw = File.CreateText(indexFile))
                {
                    sw.WriteLine(Path.GetFileName(sourceFileName));
                }
                return;
            }

            using (StreamReader sr = File.OpenText(indexFile))
            {
                string nameOfFile = Path.GetFileName(sourceFileName);
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s == nameOfFile)
                        return;
                }
            }

            using (StreamWriter sw = File.AppendText(indexFile))
            {
                sw.WriteLine(Path.GetFileName(sourceFileName));
            }

        }

        private static string GetHash(Stream stream)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(stream), 0);
        }
    }
}
