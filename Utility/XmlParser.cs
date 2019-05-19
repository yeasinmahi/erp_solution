using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Utility
{
    public class XmlParser
    {
        public static string FilePathForXml = "";

        public static bool CreateXml(string rootName, string itemName, object obj, string filePathForXml, out string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
            try
            {
                if (File.Exists(filePathForXml))
                {
                    doc.Load(filePathForXml);
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
                rootNode?.AppendChild(addItem);
            }
            catch
            {
                message = "Something Error while Fatching Object";
                return false;
            }
            try
            {
                if (rootNode != null) doc.AppendChild(rootNode);
            }
            catch
            {
                message = "Xml format Error";
                return false;
            }
            try
            {
                doc.Save(filePathForXml);
                message = "Xml Create Successful";
                return true;
            }
            catch
            {
                message = "Xml Saving Problem";
                return false;
            }
        }
        public static string GetXml(string rootName, string itemName, object obj,out string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
            try
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                rootNode = doc.CreateElement(rootName);
            }
            catch
            {
                message = "File Path Related Problem";
                return string.Empty;
            }

            try
            {
                XmlNode addItem = CreateItemNodes(itemName, doc, obj);
                rootNode.AppendChild(addItem);
            }
            catch
            {
                message = "Something Error while Fatching Object";
                return string.Empty;
            }
            try
            {
                doc.AppendChild(rootNode);
                message = "Successfully Created xml";
                return doc.InnerXml;
            }
            catch
            {
                message = "Xml format Error";
                return string.Empty;
            }
        }
        public static bool CreateXml(string rootName, string itemName, List<object> objs, string filePathForXml, out string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
            try
            {
                if (File.Exists(filePathForXml))
                {
                    doc.Load(filePathForXml);
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
                foreach (object obj in objs)
                {
                    XmlNode addItem = CreateItemNodes(itemName, doc, obj);
                    rootNode?.AppendChild(addItem);
                }
            }
            catch
            {
                message = "Something Error while Fatching Object";
                return false;
            }
            try
            {
                if (rootNode != null) doc.AppendChild(rootNode);
            }
            catch
            {
                message = "Xml format Error";
                return false;
            }
            try
            {
                doc.Save(filePathForXml);
                message = "Xml Create Successful";
                return true;
            }
            catch
            {
                message = "Xml Saving Problem";
                return false;
            }
        }
        public static string GetXml(string rootName, string itemName, List<object> objs, out string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
            try
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                rootNode = doc.CreateElement(rootName);
            }
            catch
            {
                message = "File Path Related Problem";
                return string.Empty;
            }

            try
            {
                foreach (object obj in objs)
                {
                    XmlNode addItem = CreateItemNodes(itemName, doc, obj);
                    rootNode.AppendChild(addItem);
                }
            }
            catch
            {
                message = "Something Error while Fatching Object";
                return string.Empty;
            }
            try
            {
                doc.AppendChild(rootNode);
                message = "Successfully Created xml";
                return doc.InnerXml;
            }
            catch
            {
                message = "Xml format Error";
                return string.Empty;
            }
        }

        public static bool CreateXml(string rootName, object obj, string filePathForXml, out string message)
        {
            return CreateXml(rootName, null, obj, filePathForXml, out message);
        }
        public static string GetXml(string rootName, object obj, out string message)
        {
            return GetXml(rootName, null, obj, out message);
        }

        private static XmlNode CreateItemNodes(string itemName,XmlDocument doc, object obj)
        {
            XmlNode node = doc.CreateElement(string.IsNullOrWhiteSpace(itemName) ? "voucharEntry" : itemName);
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
            return doc.InnerXml;
        }
        public static string GetXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return doc.InnerXml;
        }
    }
}
