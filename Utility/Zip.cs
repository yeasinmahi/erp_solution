using System.IO;
using System.IO.Compression;

namespace Utility
{
    public class Zip
    {
        public static byte[] PackageDocsAsZip(string fileName)
        {
            //if zip already exists then delete it
            if (File.Exists(fileName + ".zip"))
            {
                File.Delete(fileName + ".zip");
            }

            //now zip the source location
            ZipFile.CreateFromDirectory(fileName, fileName + ".zip", CompressionLevel.Optimal, true);

            return File.ReadAllBytes(fileName + ".zip");
        }
    }
}
