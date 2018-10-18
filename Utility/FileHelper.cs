using System;
using System.IO;

namespace Utility
{
    public class FileHelper
    {
        public static bool DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return true;
        }
        public static bool DeleteFolder(string path)
        {
            Directory.Delete(path, true);
            return true;
        }
        public static bool CopyFile(string source, string destionation)
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
    }
}
