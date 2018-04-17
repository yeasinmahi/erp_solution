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
    public class XmlManagerSO
    {
        string[] itemNames = { "Pid", "PName", "Qnt", "Pr", "AccId", "AccName", "ExtId", "ExtName", "ExtPr", "Uom", "Cur", "Narr"//11
                                 , "SType", "LogisId", "Prom", "Comm","IncId","IncPr","SupTax","Vat","VatPr","UomTxt"//21
                                 ,"PromItemId","PromItem","PromUom","PromUomText", "PromPr","PromItemCOA","SoPkId","ApprQnt"};
        string mainNode = "node", subNode = "item";

        public string[][] CreateNewItems(string pId, string pName, string qnt, string approvedQnt, string pr, string accId
            , string accName, string extId, string extName, string extPr, string uom, string uomTxt
            , string currency, string narration, string salesType, string logisicId
            , string promotion, string commission, string incentiveId, string incentive
            , string suppTax, string vat, string VatPr, string promItemId, string promItem
            , string promUom, string promUomText, string promPrice, string promItemCOAid)
        {
            return CreateItems(pId, pName, qnt, approvedQnt, pr, accId
            , accName, extId, extName, extPr, uom, uomTxt
            , currency, narration, salesType, logisicId
            , promotion, commission, incentiveId, incentive
            , suppTax, vat, VatPr, promItemId, promItem
            , promUom, promUomText, promPrice, promItemCOAid, "0");
        }
        public string[][] CreateItems(string pId, string pName, string qnt, string approvedQnt, string pr, string accId
            , string accName, string extId, string extName, string extPr, string uom, string uomTxt
            , string currency, string narration, string salesType, string logisicId
            , string promotion, string commission, string incentiveId, string incentive
            , string suppTax, string vat, string VatPr, string promItemId, string promItem
            , string promUom, string promUomText, string promPrice, string promItemCOAid
            , string salesOrderPkId)
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
            items[14][1] = promotion;

            items[15] = new string[2];
            items[15][0] = itemNames[15];
            items[15][1] = commission;

            items[16] = new string[2];
            items[16][0] = itemNames[16];
            items[16][1] = incentiveId;

            items[17] = new string[2];
            items[17][0] = itemNames[17];
            items[17][1] = incentive;

            items[18] = new string[2];
            items[18][0] = itemNames[18];
            items[18][1] = suppTax;

            items[19] = new string[2];
            items[19][0] = itemNames[19];
            items[19][1] = vat;

            items[20] = new string[2];
            items[20][0] = itemNames[20];
            items[20][1] = VatPr;

            items[21] = new string[2];
            items[21][0] = itemNames[21];
            items[21][1] = uomTxt;

            items[22] = new string[2];
            items[22][0] = itemNames[22];
            items[22][1] = promItemId;

            items[23] = new string[2];
            items[23][0] = itemNames[23];
            items[23][1] = promItem;

            items[24] = new string[2];
            items[24][0] = itemNames[24];
            items[24][1] = promUom;

            items[25] = new string[2];
            items[25][0] = itemNames[25];
            items[25][1] = promUomText;

            items[26] = new string[2];
            items[26][0] = itemNames[26];
            items[26][1] = promPrice;

            items[27] = new string[2];
            items[27][0] = itemNames[27];
            items[27][1] = promItemCOAid;

            items[28] = new string[2];
            items[28][0] = itemNames[28];
            items[28][1] = salesOrderPkId;

            items[29] = new string[2];
            items[29][0] = itemNames[29];
            items[29][1] = approvedQnt;

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


        string[] itemNamestest = { "Pid", "PName", "Qnt", "Pr", "AccId", "AccName", "ExtId", "ExtName", "ExtPr", "Uom", "Cur", "Narr"//11
                                 , "SType", "LogisId", "Prom", "Comm","IncId","IncPr","SupTax","Vat","VatPr","UomTxt"//21
                                 ,"PromItemId","PromItem","PromUom","PromUomText", "PromPr","PromItemCOA","SoPkId","ApprQnt"
        ,"DiscountAmount","Damage","Special","SRSubsidy","Supplvheicle","Customvheicle","Companyvhc","HallprintNumber"};
        string mainNodetest = "node", subNodetest = "item";

        public string[][] CreateNewItemstest(string pId, string pName, string qnt, string approvedQnt, string pr, string accId
            , string accName, string extId, string extName, string extPr, string uom, string uomTxt
            , string currency, string narration, string salesType, string logisicId
            , string promotion, string commission, string incentiveId, string incentive
            , string suppTax, string vat, string VatPr, string promItemId, string promItem
            , string promUom, string promUomText, string promPrice, string promItemCOAid
            , string discountamount
            ,string damage
            ,string special
            ,string srsubsidy
            , string supplvheicle
            , string customvheicle
            , string companyvhc
            ,string hallprintnumber

            )
        {
            return CreateItemstest(pId, pName, qnt, approvedQnt, pr, accId
            , accName, extId, extName, extPr, uom, uomTxt
            , currency, narration, salesType, logisicId
            , promotion, commission, incentiveId, incentive
            , suppTax, vat, VatPr, promItemId, promItem
            , promUom, promUomText, promPrice, promItemCOAid, "0", discountamount
            ,damage,special, srsubsidy, supplvheicle,customvheicle,companyvhc, hallprintnumber
            );
        }
        public string[][] CreateItemstest(string pId, string pName, string qnt, string approvedQnt, string pr, string accId
            , string accName, string extId, string extName, string extPr, string uom, string uomTxt
            , string currency, string narration, string salesType, string logisicId
            , string promotion, string commission, string incentiveId, string incentive
            , string suppTax, string vat, string VatPr, string promItemId, string promItem
            , string promUom, string promUomText, string promPrice, string promItemCOAid
            , string salesOrderPkId
            , string discountamount
            ,string damage
            ,string special
            ,string srsubsidy
            , string supplvheicle
            , string customvheicle
            , string companyvhc
            , string hallprintnumber
            )
        {
            string[][] items = new string[38][];
            items[0] = new string[2];
            items[0][0] = itemNamestest[0];
            items[0][1] = pId;

            items[1] = new string[2];
            items[1][0] = itemNamestest[1];
            items[1][1] = pName;

            items[2] = new string[2];
            items[2][0] = itemNamestest[2];
            items[2][1] = qnt;

            items[3] = new string[2];
            items[3][0] = itemNamestest[3];
            items[3][1] = pr;

            items[4] = new string[2];
            items[4][0] = itemNamestest[4];
            items[4][1] = accId;

            items[5] = new string[2];
            items[5][0] = itemNamestest[5];
            items[5][1] = accName;

            items[6] = new string[2];
            items[6][0] = itemNamestest[6];
            items[6][1] = extId;

            items[7] = new string[2];
            items[7][0] = itemNamestest[7];
            items[7][1] = extName;

            items[8] = new string[2];
            items[8][0] = itemNamestest[8];
            items[8][1] = extPr;

            items[9] = new string[2];
            items[9][0] = itemNamestest[9];
            items[9][1] = uom;

            items[10] = new string[2];
            items[10][0] = itemNamestest[10];
            items[10][1] = currency;

            items[11] = new string[2];
            items[11][0] = itemNamestest[11];
            items[11][1] = narration;

            items[12] = new string[2];
            items[12][0] = itemNamestest[12];
            items[12][1] = salesType;

            items[13] = new string[2];
            items[13][0] = itemNamestest[13];
            items[13][1] = logisicId;

            items[14] = new string[2];
            items[14][0] = itemNamestest[14];
            items[14][1] = promotion;

            items[15] = new string[2];
            items[15][0] = itemNamestest[15];
            items[15][1] = commission;

            items[16] = new string[2];
            items[16][0] = itemNamestest[16];
            items[16][1] = incentiveId;

            items[17] = new string[2];
            items[17][0] = itemNamestest[17];
            items[17][1] = incentive;

            items[18] = new string[2];
            items[18][0] = itemNamestest[18];
            items[18][1] = suppTax;

            items[19] = new string[2];
            items[19][0] = itemNamestest[19];
            items[19][1] = vat;

            items[20] = new string[2];
            items[20][0] = itemNamestest[20];
            items[20][1] = VatPr;

            items[21] = new string[2];
            items[21][0] = itemNamestest[21];
            items[21][1] = uomTxt;

            items[22] = new string[2];
            items[22][0] = itemNamestest[22];
            items[22][1] = promItemId;

            items[23] = new string[2];
            items[23][0] = itemNamestest[23];
            items[23][1] = promItem;

            items[24] = new string[2];
            items[24][0] = itemNamestest[24];
            items[24][1] = promUom;

            items[25] = new string[2];
            items[25][0] = itemNamestest[25];
            items[25][1] = promUomText;

            items[26] = new string[2];
            items[26][0] = itemNamestest[26];
            items[26][1] = promPrice;

            items[27] = new string[2];
            items[27][0] = itemNamestest[27];
            items[27][1] = promItemCOAid;

            items[28] = new string[2];
            items[28][0] = itemNamestest[28];
            items[28][1] = salesOrderPkId;

            items[29] = new string[2];
            items[29][0] = itemNamestest[29];
            items[29][1] = approvedQnt;

            items[30] = new string[2];
            items[30][0] = itemNamestest[30];
            items[30][1] = discountamount;

            items[31] = new string[2];
            items[31][0] = itemNamestest[31];
            items[31][1] = damage;

            items[32] = new string[2];
            items[32][0] = itemNamestest[32];
            items[32][1] = special;

            items[33] = new string[2];
            items[33][0] = itemNamestest[33];
            items[33][1] = srsubsidy;

            items[34] = new string[2];
            items[34][0] = itemNamestest[34];
            items[34][1] = supplvheicle;

            items[35] = new string[2];
            items[35][0] = itemNamestest[35];
            items[35][1] = customvheicle;

            items[36] = new string[2];
            items[36][0] = itemNamestest[36];
            items[36][1] = companyvhc;

            items[37] = new string[2];
            items[37][0] = itemNamestest[37];
            items[37][1] = hallprintnumber;

          
            return items;
        }

        public XmlNode CreateNodeForItemtest(XmlDocument xmlDoc, string[][] items)
        {
            XmlNode node = xmlDoc.CreateElement(subNodetest);
            for (int i = 0; i < items.Length; i++)
            {
                CreateAttributetest(xmlDoc, node, items[i][0], items[i][1]);
            }
            return node;
        }
        public void CreateAttributetest(XmlDocument xmlDoc, XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute attr = xmlDoc.CreateAttribute(attrName);
            attr.Value = attrValue;
            node.Attributes.Append(attr);
        }
        public XmlDocument LoadXmlFiletest(string xmlFilePathtest)
        {
            XmlDocument xmlDoctest = new XmlDocument();
            if (File.Exists(xmlFilePathtest))
            {
                xmlDoctest.Load(xmlFilePathtest);
            }
            else
            {
                XmlNode xmldeclerationNode = xmlDoctest.CreateXmlDeclaration("1.0", "utf-16", "");
                xmlDoctest.AppendChild(xmldeclerationNode);
                XmlNode node = xmlDoctest.CreateElement(mainNodetest);
                xmlDoctest.AppendChild(node);
            }

            xmlDoctest.Save(xmlFilePathtest);

            return xmlDoctest;
        }


        public string MainNodetest
        {
            get { return mainNodetest; }
        }


        //Brandxml ..............................................


        string[] itemNamesBrandproduct = { "Pid", "PName",  "Qnt",  "Uom","UomTxt",  "Narr"};
        string mainNodebrand = "node", subNodebrand = "item";

        public string[][] CreateNewItemsbrand(string pId, string pName, string qnt,string uom, string uomTxt,string narr)
        {
            return CreateItemsbrand(pId, pName, qnt, uom, uomTxt, narr);
        }
        public string[][] CreateItemsbrand(string pId, string pName, string qnt, string uom, string uomTxt, string narr
            )
        {
            string[][] items = new string[6][];
            items[0] = new string[2];
            items[0][0] = itemNamesBrandproduct[0];
            items[0][1] = pId;
            items[1] = new string[2];
            items[1][0] = itemNamesBrandproduct[1];
            items[1][1] = pName;
            items[2] = new string[2];
            items[2][0] = itemNamesBrandproduct[2];
            items[2][1] = qnt;
            items[3] = new string[2];
            items[3][0] = itemNamesBrandproduct[3];
            items[3][1] = uom;
            items[4] = new string[2];
            items[4][0] = itemNamesBrandproduct[4];
            items[4][1] = uomTxt;
            items[5] = new string[2];
            items[5][0] = itemNamesBrandproduct[5];
            items[5][1] = narr;


            return items;
        }

        public XmlNode CreateNodeForItembrand(XmlDocument xmlDoc, string[][] items)
        {
            XmlNode node = xmlDoc.CreateElement(subNodebrand);
            for (int i = 0; i < items.Length; i++)
            {
                CreateAttributebrand(xmlDoc, node, items[i][0], items[i][1]);
            }
            return node;
        }
        public void CreateAttributebrand(XmlDocument xmlDoc, XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute attr = xmlDoc.CreateAttribute(attrName);
            attr.Value = attrValue;
            node.Attributes.Append(attr);
        }
        public XmlDocument LoadXmlFilebrand(string xmlFilePathbrand)
        {
            XmlDocument xmlDocbrand = new XmlDocument();
            if (File.Exists(xmlFilePathbrand))
            {
                xmlDocbrand.Load(xmlFilePathbrand);
            }
            else
            {
                XmlNode xmldeclerationNode = xmlDocbrand.CreateXmlDeclaration("1.0", "utf-16", "");
                xmlDocbrand.AppendChild(xmldeclerationNode);
                XmlNode node = xmlDocbrand.CreateElement(mainNodetest);
                xmlDocbrand.AppendChild(node);
            }

            xmlDocbrand.Save(xmlFilePathbrand);

            return xmlDocbrand;
        }


        public string MainNodebrand
        {
            get { return mainNodebrand; }
        }


        //RawMaterialxml ..............................................


        string[] itemNamesrawmaterialproduct = { "Pid", "PName", "Qnt", "Uom", "UomTxt", "Narr","Price" };
        string mainNoderaw = "node", subNoderaw = "item";

        public string[][] CreateNewItemsraw(string pId, string pName, string qnt, string uom, string uomTxt, string narr,string price)
        {
            return CreateItemsraw(pId, pName, qnt, uom, uomTxt, narr, price);
        }
        public string[][] CreateItemsraw(string pId, string pName, string qnt, string uom, string uomTxt, string narr,string price
            )
        {
            string[][] items = new string[7][];
            items[0] = new string[2];
            items[0][0] = itemNamesrawmaterialproduct[0];
            items[0][1] = pId;
            items[1] = new string[2];
            items[1][0] = itemNamesrawmaterialproduct[1];
            items[1][1] = pName;
            items[2] = new string[2];
            items[2][0] = itemNamesrawmaterialproduct[2];
            items[2][1] = qnt;
            items[3] = new string[2];
            items[3][0] = itemNamesrawmaterialproduct[3];
            items[3][1] = uom;
            items[4] = new string[2];
            items[4][0] = itemNamesrawmaterialproduct[4];
            items[4][1] = uomTxt;
            items[5] = new string[2];
            items[5][0] = itemNamesrawmaterialproduct[5];
            items[5][1] = narr;
            items[6] = new string[2];
            items[6][0] = itemNamesrawmaterialproduct[6];
            items[6][1] = price;
           


            return items;
        }

        public XmlNode CreateNodeForItemraw(XmlDocument xmlDoc, string[][] items)
        {
            XmlNode node = xmlDoc.CreateElement(subNoderaw);
            for (int i = 0; i < items.Length; i++)
            {
                CreateAttributeraw(xmlDoc, node, items[i][0], items[i][1]);
            }
            return node;
        }
        public void CreateAttributeraw(XmlDocument xmlDoc, XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute attr = xmlDoc.CreateAttribute(attrName);
            attr.Value = attrValue;
            node.Attributes.Append(attr);
        }
        public XmlDocument LoadXmlFileraw(string xmlFilePathraw)
        {
            XmlDocument xmlDocraw = new XmlDocument();
            if (File.Exists(xmlFilePathraw))
            {
                xmlDocraw.Load(xmlFilePathraw);
            }
            else
            {
                XmlNode xmldeclerationNode = xmlDocraw.CreateXmlDeclaration("1.0", "utf-16", "");
                xmlDocraw.AppendChild(xmldeclerationNode);
                XmlNode node = xmlDocraw.CreateElement(mainNoderaw);
                xmlDocraw.AppendChild(node);
            }

            xmlDocraw.Save(xmlFilePathraw);

            return xmlDocraw;
        }


        public string MainNoderaw
        {
            get { return mainNoderaw; }
        }















    }
}
