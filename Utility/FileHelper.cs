using System;
using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public static class FileHelper
    {
        public static bool DeleteFile(this string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return true;
        }
        public static bool IsExist(this string fileName)
        {
            return File.Exists(fileName);
        }
        public static bool DeleteFolder(this string path)
        {
            Directory.Delete(path, true);
            return true;
        }
        public static bool CopyTo(this string source, string destionation)
        {
            try
            {
                File.Copy(source, destionation, true);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
        public static bool CreateFolder(this string path)
        {
            string dir = Path.GetFullPath(path);
            bool exists = Directory.Exists(Path.GetFullPath(path));
            if (!exists)
            {
                Directory.CreateDirectory(dir);
                return true;
            }
            return false;
        }
        public static void CreateFolder(this List<string> paths)
        {
            foreach (string path in paths)
            {
                CreateFolder(path);
            }
        }
    }
}
