using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Utility
{
    public class XmlParser
    {
        public static string filePathForXML = "";

        public static bool CreateXml(string rootName, string itemName, object obj, string filePathForXML, out string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
            try
            {
                if (System.IO.File.Exists(filePathForXML))
                {
                    doc.Load(filePathForXML);
                    rootNode = doc.SelectSingleNode(rootName);

                }
                else
                {
                    XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                    doc.AppendChild(xmldeclerationNode);
                    rootNode = doc.CreateElement(rootName);
                }
            }
            catch
            {
                message = "File Path Related Problem";
                return false;
            }

            try
            {
                XmlNode addItem = CreateItemNodes(itemName,doc, obj);
                rootNode.AppendChild(addItem);
            }
            catch
            {
                message = "Something Error while Fatching Object";
                return false;
            }
            try
            {
                doc.AppendChild(rootNode);
            }
            catch
            {
                message = "Xml format Error";
                return false;
            }
            try
            {
                doc.Save(filePathForXML);
                message = "Xml Create Successful";
                return true;
            }
            catch
            {
                message = "Xml Saving Problem";
                return false;
            }
        }

        public static bool CreateXml(string rootName, object obj, string filePathForXML, out string message)
        {
            return CreateXml(rootName, null, obj, filePathForXML, out message);
        }

        private static XmlNode CreateItemNodes(string itemName,XmlDocument doc, object obj)
        {
            XmlNode node = doc.CreateElement(String.IsNullOrWhiteSpace(itemName) ? "voucharEntry" : itemName);
            PropertyInfo[] propertyInfos = Common.GetProperties(obj);
           
            foreach (PropertyInfo p in propertyInfos)
            {
                XmlAttribute xmlAttribute = doc.CreateAttribute(p.Name);
                xmlAttribute.Value = p.GetValue(obj, null).ToString();
                node.Attributes?.Append(xmlAttribute);
            }
            return node;
        }

        public static string ConvertXmlToString(XmlDocument doc)
        {
            XmlNode dSftTm = doc.SelectSingleNode("OvertimeEntry");
            string xmlString = dSftTm.InnerXml;
            xmlString = "<OvertimeEntry>" + xmlString + "</OvertimeEntry>";
            return xmlString;
        }

        public static bool DeleteFile(string filepath)
        {
            try
            {
                File.Delete(filepath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
