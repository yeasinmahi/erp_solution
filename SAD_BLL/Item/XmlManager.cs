using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;

namespace SAD_BLL.Item
{
    /// <summary>
    /// Developped By Akramul Haider
    /// </summary>
    public class XmlManager
    {
        string[] itemNames = { "Pid", "PName", "Qnt", "Pr", "AccId", "AccName", "ExtId", "ExtName", "ExtPr", "Uom", "Cur", "Narr"
                                 , "SType", "LogisId", "Logis", "Prom", "Comm","IncId","IncPr","SupTax","Vat","VatPr","UomTxt"
                                 ,"PromItemId","PromItem","PromUom","PromUomText", "LogisGain","PromPr","PromItemCOA" };
        string mainNode = "node", subNode = "item";

        public string[][] CreateItems(string pId, string pName, string qnt, string pr, string accId
            , string accName, string extId, string extName, string extPr, string uom, string uomTxt
            , string currency, string narration, string salesType, string logisicId, string logisicPrice
            , string promotion, string commission, string incentiveId, string incentive
            , string suppTax, string vat, string VatPr, string promItemId, string promItem
            , string promUom, string promUomText, string logisGain,string promPrice,string promItemCOAid)
        {
            string[][] items = new string[30][];
            items[0] = new string[2];
            items[0][0] = itemNames[0];
            items[0][1] = pId;

            items[1] = new string[2];
            items[1][0] = itemNames[1];
            items[1][1] = pName;

            items[2] = new string[2];
            items[2][0] = itemNames[2];
            items[2][1] = qnt;

            items[3] = new string[2];
            items[3][0] = itemNames[3];
            items[3][1] = pr;

            items[4] = new string[2];
            items[4][0] = itemNames[4];
            items[4][1] = accId;

            items[5] = new string[2];
            items[5][0] = itemNames[5];
            items[5][1] = accName;

            items[6] = new string[2];
            items[6][0] = itemNames[6];
            items[6][1] = extId;

            items[7] = new string[2];
            items[7][0] = itemNames[7];
            items[7][1] = extName;

            items[8] = new string[2];
            items[8][0] = itemNames[8];
            items[8][1] = extPr;

            items[9] = new string[2];
            items[9][0] = itemNames[9];
            items[9][1] = uom;

            items[10] = new string[2];
            items[10][0] = itemNames[10];
            items[10][1] = currency;

            items[11] = new string[2];
            items[11][0] = itemNames[11];
            items[11][1] = narration;

            items[12] = new string[2];
            items[12][0] = itemNames[12];
            items[12][1] = salesType;

            items[13] = new string[2];
            items[13][0] = itemNames[13];
            items[13][1] = logisicId;

            items[14] = new string[2];
            items[14][0] = itemNames[14];
            items[14][1] = logisicPrice;

            items[15] = new string[2];
            items[15][0] = itemNames[15];
            items[15][1] = promotion;

            items[16] = new string[2];
            items[16][0] = itemNames[16];
            items[16][1] = commission;

            items[17] = new string[2];
            items[17][0] = itemNames[17];
            items[17][1] = incentiveId;

            items[18] = new string[2];
            items[18][0] = itemNames[18];
            items[18][1] = incentive;

            items[19] = new string[2];
            items[19][0] = itemNames[19];
            items[19][1] = suppTax;

            items[20] = new string[2];
            items[20][0] = itemNames[20];
            items[20][1] = vat;

            items[21] = new string[2];
            items[21][0] = itemNames[21];
            items[21][1] = VatPr;

            items[22] = new string[2];
            items[22][0] = itemNames[22];
            items[22][1] = uomTxt;

            items[23] = new string[2];
            items[23][0] = itemNames[23];
            items[23][1] = promItemId;

            items[24] = new string[2];
            items[24][0] = itemNames[24];
            items[24][1] = promItem;

            items[25] = new string[2];
            items[25][0] = itemNames[25];
            items[25][1] = promUom;

            items[26] = new string[2];
            items[26][0] = itemNames[26];
            items[26][1] = promUomText;

            items[27] = new string[2];
            items[27][0] = itemNames[27];
            items[27][1] = logisGain;

            items[28] = new string[2];
            items[28][0] = itemNames[28];
            items[28][1] = promPrice;

            items[29] = new string[2];
            items[29][0] = itemNames[29];
            items[29][1] = promItemCOAid;

            return items;
        }
        
        public XmlNode CreateNodeForItem(XmlDocument xmlDoc, string[][] items)
        {
            XmlNode node = xmlDoc.CreateElement(subNode);
            for (int i = 0; i < items.Length; i++)
            {               
                CreateAttribute(xmlDoc, node, items[i][0], items[i][1]);
            }
            return node;
        }
        public void CreateAttribute(XmlDocument xmlDoc, XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute attr = xmlDoc.CreateAttribute(attrName);
            attr.Value = attrValue;
            node.Attributes.Append(attr);
        }
        public XmlDocument LoadXmlFile(string xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(xmlFilePath))
            {
                xmlDoc.Load(xmlFilePath);
            }
            else
            {
                XmlNode xmldeclerationNode = xmlDoc.CreateXmlDeclaration("1.0", "utf-16", "");
                xmlDoc.AppendChild(xmldeclerationNode);
                XmlNode node = xmlDoc.CreateElement(mainNode);
                xmlDoc.AppendChild(node);
            }

            xmlDoc.Save(xmlFilePath);

            return xmlDoc;
        }
        
        
        public string MainNode
        {
            get { return mainNode; }
        }
        /*public string SubNode
        {
            get { return subNode; }
        }
        public string AccountName
        {
            get { return itemNames[0]; }
        }
        public string Narration
        {
            get { return itemNames[1]; }
        }
        public string Debit
        {
            get { return itemNames[2]; }
        }
        public string Credit
        {
            get { return itemNames[3]; }
        }
        public string AccountID
        {
            get { return itemNames[4]; }
        }
        public string AccountCode
        {
            get { return itemNames[5]; }
        }   */     
    }
}
