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
        public static void CreateXml(string rootName, object obj, string filePathForXML)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode;
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
            XmlNode addItem = CreateItemNodes(doc, obj);
            rootNode.AppendChild(addItem);
            doc.AppendChild(rootNode);
            doc.Save(filePathForXML);
        }

        private static XmlNode CreateItemNodes(XmlDocument doc, object obj)
        {
            PropertyInfo[] propertyInfos = Common.GetProperties(obj);
            XmlNode node = doc.CreateElement("obj");
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
