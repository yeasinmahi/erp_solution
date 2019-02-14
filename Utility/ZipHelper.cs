using System.IO;
using System.IO.Compression;

namespace Utility
{
    public static class ZipHelper
    {
        public static byte[] CreateZip(this string fileName)
        {
            //if zip already exists then delete it

            (fileName + ".zip").DeleteFile();

            //now zip the source location
            ZipFile.CreateFromDirectory(fileName, fileName + ".zip", CompressionLevel.Optimal, true);
            byte[] bytes = File.ReadAllBytes(fileName + ".zip");
            (fileName + ".zip").DeleteFile();
            return bytes;
        }
    }
}
