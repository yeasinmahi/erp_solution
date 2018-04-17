using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;

namespace BLL.Accounts.Voucher
{
    /// <summary>
    /// Developped By Akramul Haider
    /// </summary>
    public class XmlManager
    {
        string[] itemNames = { "Acc", "Narr", "Dr", "Cr", "AccID","AccCode" };
        string mainNode = "node", subNode = "item", cshInhndTxt = "Cash In Hand";
        
        public string[][] CreateItems(string accName, string accID, string narration, string drAmount, string crAmount)
        {
            string[][] items = new string[5][];
            items[0] = new string[2];
            items[0][0] = itemNames[0];
            items[0][1] = accName;

            items[1] = new string[2];
            items[1][0] = itemNames[1];
            items[1][1] = narration;

            items[2] = new string[2];
            items[2][0] = itemNames[2];
            items[2][1] = drAmount;

            items[3] = new string[2];
            items[3][0] = itemNames[3];
            items[3][1] = crAmount;

            items[4] = new string[2];
            items[4][0] = itemNames[4];
            items[4][1] = accID;

            return items;
        }
        public string[][] CreateItems(string accName, string accID, string narration, string drAmount, string crAmount,string accCode)
        {
            string[][] items = new string[6][];
            items[0] = new string[2];
            items[0][0] = itemNames[0];
            items[0][1] = accName;

            items[1] = new string[2];
            items[1][0] = itemNames[1];
            items[1][1] = narration;

            items[2] = new string[2];
            items[2][0] = itemNames[2];
            items[2][1] = drAmount;

            items[3] = new string[2];
            items[3][0] = itemNames[3];
            items[3][1] = crAmount;

            items[4] = new string[2];
            items[4][0] = itemNames[4];
            items[4][1] = accID;

            items[5] = new string[2];
            items[5][0] = itemNames[5];
            items[5][1] = accCode;

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
        
        public void CreateFirstRow(string accName, string accID, bool isDr, string bnCh, string xmlFilePath)
        {
            string drAmount = "", crAmount = "";
            XmlDocument xmlDoc = LoadXmlFile(xmlFilePath);
            XmlNodeList nodes = xmlDoc.SelectSingleNode(MainNode).ChildNodes;
            if (nodes.Count <= 0)
            {
                //Create
                string[][] items;

                if (isDr) drAmount = "0";
                else crAmount = "0";

                if (bnCh == "bn")
                {
                    items = CreateItems(accName, accID, "", crAmount, drAmount);
                }
                else if (bnCh == "ch")
                {
                    items = CreateItems(cshInhndTxt, "0", "", crAmount, drAmount);
                }
                else if (bnCh == "cn")
                {
                    items = CreateItems(accName, accID, "", crAmount, drAmount);
                }
                else //jr
                {
                    return;
                }

                XmlNode selectNode = xmlDoc.SelectSingleNode(MainNode);
                selectNode.AppendChild(CreateNodeForItem(xmlDoc, items));

                xmlDoc.Save(xmlFilePath);
            }            
        }
        public void CreateFirstRow(string accName, string accID, bool isDr, string bnCh, string xmlFilePath, string accCode)
        {
            string drAmount = "", crAmount = "";
            XmlDocument xmlDoc = LoadXmlFile(xmlFilePath);
            XmlNodeList nodes = xmlDoc.SelectSingleNode(MainNode).ChildNodes;
            if (nodes.Count <= 0)
            {
                //Create
                string[][] items;

                if (isDr) drAmount = "0";
                else crAmount = "0";

                if (bnCh == "bn")
                {
                    items = CreateItems(accName, accID, "", crAmount, drAmount,accCode);
                }
                else if (bnCh == "ch")
                {
                    items = CreateItems(cshInhndTxt, "0", "", crAmount, drAmount,accCode);
                }
                else if (bnCh == "cn")
                {
                    items = CreateItems(accName, accID, "", crAmount, drAmount, accCode);
                }
                else //jr
                {
                    return;
                }

                XmlNode selectNode = xmlDoc.SelectSingleNode(MainNode);
                selectNode.AppendChild(CreateNodeForItem(xmlDoc, items));

                xmlDoc.Save(xmlFilePath);
            }
        }
        public void ChangeFirstRow(string xmlFilePath, string accName, string accID)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFilePath);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[0].BeginEdit();
                    ds.Tables[0].Rows[0][AccountName] = accName;
                    ds.Tables[0].Rows[0][AccountID] = accID;
                    ds.Tables[0].Rows[0].EndEdit();
                    ds.WriteXml(xmlFilePath);
                }
            }
        }
        public void ModifyFirstRow(string drAmount, string crAmount, string xmlFilePath, string bnCh)
        {
            if (bnCh != "jr")
            {
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFilePath);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string str = "";
                        double tmp = 0;

                        ds.Tables[0].Rows[0].BeginEdit();

                        str = ds.Tables[0].Rows[0][Debit].ToString();
                        if (str != "") tmp = double.Parse(str);
                        if (crAmount != "") tmp += double.Parse(crAmount);
                        if (tmp > 0) ds.Tables[0].Rows[0][Debit] = tmp.ToString();
                        else ds.Tables[0].Rows[0][Debit] = "";

                        tmp = 0;
                        str = ds.Tables[0].Rows[0][Credit].ToString();
                        if (str != "") tmp = double.Parse(str);
                        if (drAmount != "") tmp += double.Parse(drAmount);
                        if (tmp > 0) ds.Tables[0].Rows[0][Credit] = tmp.ToString();
                        else ds.Tables[0].Rows[0][Credit] = "";

                        ds.Tables[0].Rows[0].EndEdit();
                        ds.WriteXml(xmlFilePath);
                    }
                }
            }
        }

        public string MainNode
        {
            get { return mainNode; }
        }
        public string SubNode
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
        }
        public string CashInHandText
        {
            get { return cshInhndTxt; }
        }
    }
}
