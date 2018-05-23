

using System;
using System.IO;
using System.Reflection;

namespace Utility
{
    public class Common
    {

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
        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }

        public static StreamWriter GetStreamWriter(string path)
        {
            if (!File.Exists(path))
            {
                return File.CreateText(path);
            }
            return null;
        }
        public enum ModulaFileName
        {
            Item,
            Order,
            OrderLine,
            StrockUpdate
        }

        public static string GetModulaFullPath(string path, Enum fileName)
        {
            return path + fileName.ToString("F") + ".txt";
        }
        //public static bool CreateFile(string fileName)
        //{
        //    if (!File.Exists(path))
        //    {
        //        using (StreamWriter sw = File.CreateText(path))
        //        {
        //            foreach (var line in employeeList.Items)
        //            {
        //                sw.WriteLine(((Employee)line).FirstName);
        //                sw.WriteLine(((Employee)line).LastName);
        //                sw.WriteLine(((Employee)line).JobTitle);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        StreamWriter sw = File.AppendText(path);

        //        foreach (var line in employeeList.Items)
        //        {
        //            sw.WriteLine(((Employee)line).FirstName);
        //            sw.WriteLine(((Employee)line).LastName);
        //            sw.WriteLine(((Employee)line).JobTitle);
        //        }
        //        sw.Close();
        //    }
        //}

        //public static bool Write()
        //{
        //    using (StreamWriter writetext = new StreamWriter("write.txt"))
        //    {
        //        writetext.WriteLine("writing in text file");
        //    }
        //}
    }
}
