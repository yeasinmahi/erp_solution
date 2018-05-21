using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Utility
{
    public class XmlParser
    {
        public static string filePathForXML = "";
        public static bool CreateXml(string rootName, object obj, string filePathForXML, out string message)
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
                XmlNode addItem = CreateItemNodes(doc, obj);
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

        private static XmlNode CreateItemNodes(XmlDocument doc, object obj)
        {
            PropertyInfo[] propertyInfos = Common.GetProperties(obj);
            XmlNode node = doc.CreateElement("voucharEntry");
            foreach (PropertyInfo p in propertyInfos)
            {
                XmlAttribute xmlAttribute = doc.CreateAttribute(p.Name);
                xmlAttribute.Value = p.GetValue(obj, null).ToString();
                node.Attributes.Append(xmlAttribute);
            }
            return node;
        }


    }
}
