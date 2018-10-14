using System.IO;
using System.IO.Compression;

namespace Utility
{
    public class ZipHelper
    {
        public static byte[] PackageDocsAsZip(string fileName)
        {
            //if zip already exists then delete it
            
            FileHelper.DeleteFile(fileName + ".zip");

            //now zip the source location
            ZipFile.CreateFromDirectory(fileName, fileName + ".zip", CompressionLevel.Optimal, true);
            byte[] bytes = File.ReadAllBytes(fileName + ".zip");
            FileHelper.DeleteFile(fileName + ".zip");
            return bytes;
        }

        
    }
}
