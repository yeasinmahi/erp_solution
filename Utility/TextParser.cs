using System.IO;
using System.Reflection;

namespace Utility
{
    public class TextParser
    {
        public static void CreateText(object obj, string fileFullPath, out string message)
        {
            var sw = File.Exists(fileFullPath) ? File.AppendText(fileFullPath) : Common.GetStreamWriter(fileFullPath);
            CreateTextFromObject(obj, sw).Close();
            message = string.Empty;
        }

        private static StreamWriter CreateTextFromObject(object obj, StreamWriter sw)
        {
            PropertyInfo[] propertyInfos = Common.GetProperties(obj);
            //foreach (PropertyInfo propertyInfo in propertyInfos)
            //{
            //    sw.Write(propertyInfo.GetValue(obj).ToString());
                
            //    sw.Write(",");
            //}
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                sw.Write(propertyInfos[i].GetValue(obj).ToString());
                if (!i.Equals(propertyInfos.Length-1))
                {
                    sw.Write(",");
                }
                else
                {
                    sw.WriteLine();
                }
            }
            return sw;
        }
    }
}
