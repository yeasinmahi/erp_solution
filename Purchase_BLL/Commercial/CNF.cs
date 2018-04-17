using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Purchase_DAL.Commercial.CNFTDSTableAdapters;
using Purchase_DAL.Commercial;
using System.Web.UI.WebControls;

namespace Purchase_BLL.Commercial
{
    public class CNF
    {

        public Table GetCnfCalcData(int cnfAgencyID, string optionalXML, int lcID, int shipmentID, string radiation, int? numjs, int? numPO, int? numTruck, int? portID, decimal exRate,decimal? miscellaniousExp)
        {
            Table tblCNF = new Table();
            TableHeaderRow htr = new TableHeaderRow();
            TableHeaderCell htd1 = new TableHeaderCell();
            TableHeaderCell htd2 = new TableHeaderCell();
            TableHeaderCell htd3 = new TableHeaderCell();
            htd1.CssClass = "tableInstallmentHeader";
            htd2.CssClass = "tableInstallmentHeader";
            htd3.CssClass = "tableInstallmentHeader";
            htd1.Text = "SL No";
            htd2.Text = "Cost Catagory";
            htd3.Text = "Amount";
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            //htd1.HorizontalAlign = HorizontalAlign.Center;
            htr.Controls.Add(htd1);
            htr.Controls.Add(htd2);
            htr.Controls.Add(htd3);

            tblCNF.Width = Unit.Percentage(60);
            tblCNF.CellPadding = 0;
            tblCNF.CellSpacing = 0;

            tblCNF.Controls.Add(htr);

            FunCommercialPaymentCNFTableAdapter adp = new FunCommercialPaymentCNFTableAdapter();
            CNFTDS.FunCommercialPaymentCNFDataTable tbl = adp.GetDataCNFCalc(cnfAgencyID, optionalXML, lcID, shipmentID, radiation, numjs, numPO, numTruck, portID, exRate, miscellaniousExp);

            TableRow tr = null;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                tr = new TableRow();
                TableCell td1 = new TableCell();
                TableCell td2 = new TableCell();
                TableCell td3 = new TableCell();

                if (i % 2 == 0) //even
                {
                    td1.CssClass = "tableInstallmentEvenrows";
                    td2.CssClass = "tableInstallmentEvenrows";
                    td3.CssClass = "tableInstallmentEvenrows";
                }
                else // ODD
                {
                    td1.CssClass = "tableInstallmentOddrows";
                    td2.CssClass = "tableInstallmentOddrows";
                    td3.CssClass = "tableInstallmentOddrows";
                }

                td1.HorizontalAlign = HorizontalAlign.Center;
                td2.HorizontalAlign = HorizontalAlign.Center;
                td3.HorizontalAlign = HorizontalAlign.Center;

                td1.Text = (i + 1).ToString();
                td2.Text = tbl[i].attName.ToString();
                td3.Text = (tbl[i].IsmonAmountNull()) ? "0" : String.Format("{0:F2}", tbl[i].monAmount.ToString());

                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                tblCNF.Controls.Add(tr);


            }


            return tblCNF;
        }

        public XmlDocument PrepareXMLForCNFExtraStepCharge(int shipmentID,int? cnfAgentID,decimal? monExRate)
        {
            
            XmlDocument doc = new XmlDocument();
           /* XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
            doc.AppendChild(xmldeclerationNode);
            XmlNode rootNode = doc.CreateElement("cnf");

            int? comAttID = null;
            decimal? value = null;


            SprCommercialCNFExtraStepChargeTableAdapter adp = new SprCommercialCNFExtraStepChargeTableAdapter();
            CNFTDS.SprCommercialCNFExtraStepChargeDataTable tbl = adp.GetExtraStepData(shipmentID,cnfAgentID,monExRate,ref comAttID,ref value);
            XmlNode addItem;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                addItem = CreateItemNodeCNF(doc, 0, tbl[i].steStepName, tbl[i].monAmount, "0");
                rootNode.AppendChild(addItem);
            }

            if (value != null)
            {
                addItem = CreateItemNodeCNF(doc, comAttID.Value, "Commission", value.Value, "0");
                rootNode.AppendChild(addItem);
            }

            doc.AppendChild(rootNode);*/
            return doc;
           
        }

        public XmlNode CreateItemNodeCNF(XmlDocument doc,int attid, string stepName, decimal amount, string ysnComm)
        {
            XmlNode itemNode = doc.CreateElement("attributes");
            XmlAttribute id = doc.CreateAttribute("id");
            id.Value = attid.ToString();
            XmlAttribute name = doc.CreateAttribute("name");
            name.Value = stepName;
            XmlAttribute monAmount = doc.CreateAttribute("amount");
            monAmount.Value = amount.ToString();
            XmlAttribute isComm = doc.CreateAttribute("ysnCom");
            isComm.Value = ysnComm;



            itemNode.Attributes.Append(id);
            itemNode.Attributes.Append(name);
            itemNode.Attributes.Append(monAmount);
            itemNode.Attributes.Append(isComm);
            

            return itemNode;
        }


        public ListItemCollection GetPaymentAttForCNF()
        {
            ListItemCollection col = new ListItemCollection();
            /*SprCommercialCNFPaymentAttributesTableAdapter adp=new SprCommercialCNFPaymentAttributesTableAdapter();
            CNFTDS.SprCommercialCNFPaymentAttributesDataTable tbl = adp.GetData();

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strName, tbl[i].intPaymentAttID.ToString()));
            }*/

            return col;
        }


        public ListItemCollection GetCNFAgency()
        {
            
            ListItemCollection col = new ListItemCollection();

            TblCommercialCNFAgencyInfoTableAdapter adp = new TblCommercialCNFAgencyInfoTableAdapter();
            CNFTDS.TblCommercialCNFAgencyInfoDataTable tbl = adp.GetCNFAgencyData();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strCNFAgencyName, tbl[i].intCNFID.ToString()));
            }

            return col;

        }

        public string InsertCNFData( int intLCID, int intShipmentID, int intCNFAgentID,DateTime dtePaymentDate, decimal exRate, bool isPaid,
                                     string optionalXML,  string radiation, int? numjs, int? numPO, int? numTruck, int? portID,decimal? miscellaniousExp
                                   )
        {
            string result = "";

            SprCommercialCalCNFDuesTableAdapter adp = new SprCommercialCalCNFDuesTableAdapter();
            try
            {
                adp.InsertCNFData(intLCID, intShipmentID, dtePaymentDate, intCNFAgentID, optionalXML, radiation, numjs, numPO, numTruck, portID, exRate, miscellaniousExp);
                result = "Inserted successfully";
            }
            catch
            {
                result = "Cannor insert ";
            }

            return result;
        }




        public ListItemCollection GetRadiationCompanyName()
        {
            ListItemCollection col = new ListItemCollection();
            TblCommercialRadiationLabTableAdapter adp = new TblCommercialRadiationLabTableAdapter();
            CNFTDS.TblCommercialRadiationLabDataTable tbl = adp.GetDataRadiation();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strLabName,tbl[i].intLabID.ToString()));
            }
            return col;
        }

        public ListItemCollection GetCNFOptCharges(int lcID)
        {
            ListItemCollection col = new ListItemCollection();
            FunCommercialCNFOptionalChargesTableAdapter adp = new FunCommercialCNFOptionalChargesTableAdapter();
            CNFTDS.FunCommercialCNFOptionalChargesDataTable tbl = adp.GetDataCNFOptionalCharge(lcID);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strName, tbl[i].intPaymentAttID.ToString()));
            }
            return col;
        }

    }
}
