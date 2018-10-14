using System.IO;
using System.IO.Compression;

namespace Utility
{
    public class Zip
    {
        public static byte[] PackageDocsAsZip(string fileName)
        {
            //if zip already exists then delete it
            
            DeleteFile(fileName + ".zip");

            //now zip the source location
            ZipFile.CreateFromDirectory(fileName, fileName + ".zip", CompressionLevel.Optimal, true);
            byte[] bytes = File.ReadAllBytes(fileName + ".zip");
            DeleteFile(fileName + ".zip");
            return bytes;
        }

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
    }
}
