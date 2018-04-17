using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

using UI.ClassFiles;


namespace UI.GetInOut
{
    public partial class VehicleMaintenance : System.Web.UI.Page
    {




        string filePathForXMLSpare;
        string filePathForXMLService;
        //string filePathForXMLDecissions;
        //string filePathForXMLNextMetting;

        string xmlStringSpare = "";
        string xmlStringService = "";
        //string xmlStringDecissions = "";
        //string xmlStringNextMetting = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string strEnroll = "32897".ToString();
            //string strEnroll = Convert.ToString(Session[SessionParams.USER_ID].ToString());
            filePathForXMLSpare = Server.MapPath("Spare" + strEnroll + ".xml");
            filePathForXMLService = Server.MapPath("Service" + strEnroll + ".xml");
            
            if (!IsPostBack)
            {



                try { File.Delete(filePathForXMLSpare); }
                catch { }
                try { File.Delete(filePathForXMLService); }
                catch { }
                //try { File.Delete(filePathForXMLDecissions); }
                //catch { }
                //try { File.Delete(filePathForXMLNextMetting); }
                //catch { }

              
            }
            LoadGridwithXmlSpare();
        }

        protected void BtnSpare_Click(object sender, EventArgs e)
        {
            DataTable spare = new DataTable();
       
            string datespare =TxtDteSpare.Text.ToString();
            string ddlspare = DdlParticularParts.SelectedItem.ToString();
            string uom = DdlUom.SelectedItem.Text.ToString();
            string qty =TxtQty.Text.ToString();
            string mcost =TxtMaterialCost.Text.ToString();



            CreateVoucherXmlSpare(datespare,ddlspare,uom,qty,mcost);
        }

        private void CreateVoucherXmlSpare(string datespare, string ddlspare, string uom, string qty, string mcost)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLSpare))
            {
                doc.Load(filePathForXMLSpare);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeSpare(doc,datespare,ddlspare,uom,qty,mcost);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeSpare(doc,datespare,ddlspare,uom,qty,mcost);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLSpare);
            LoadGridwithXmlSpare();
        }

        private void LoadGridwithXmlSpare()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLSpare);
                XmlNode dSftTmz = doc.SelectSingleNode("voucher");
                xmlStringSpare = dSftTmz.InnerXml;
                xmlStringSpare = "<voucher>" + xmlStringSpare + "</voucher>";
                StringReader sr = new StringReader(xmlStringSpare);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { GridView1.DataSource = ds; }

                else { GridView1.DataSource = ""; }
                GridView1.DataBind();
            }
            catch { }
        }

        private XmlNode CreateItemNodeSpare(XmlDocument doc, string datespare, string ddlspare, string uom, string  qty, string mcost)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Datespare = doc.CreateAttribute("datespare");
            Datespare.Value=datespare;
            XmlAttribute Ddlspare = doc.CreateAttribute("ddlspare");
            Ddlspare.Value = ddlspare;
            XmlAttribute Uom = doc.CreateAttribute("uom");
            Uom.Value =uom;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value =qty;
            XmlAttribute Mcost = doc.CreateAttribute("mcost");
            Mcost.Value =mcost;

            node.Attributes.Append(Datespare);
            node.Attributes.Append(Ddlspare);
            node.Attributes.Append(Uom);

            node.Attributes.Append(Qty);
            node.Attributes.Append(Mcost);


            return node;
        }

        protected void BtnService_Click(object sender, EventArgs e)
        {
      

            string scharge =DdlServiceCharge.SelectedItem.ToString();
            string charge = TxtChargeTk.Text.ToString();
            CreateVoucherXmlService(scharge,charge);
        }

        private void CreateVoucherXmlService(string scharge, string charge)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLService))
            {
                doc.Load(filePathForXMLService);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeService(doc,scharge,charge);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeService(doc,scharge, charge);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLService);
            LoadGridwithXmlService();
        }

        private XmlNode CreateItemNodeService(XmlDocument doc, string scharge, string charge)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Scharge = doc.CreateAttribute("scharge");
            Scharge.Value =scharge;
            XmlAttribute Charge = doc.CreateAttribute("charge");
           Charge.Value =charge;
          


            node.Attributes.Append(Scharge);

            node.Attributes.Append(Charge);
       
            return node;
        }

        private void LoadGridwithXmlService()
        {
            try
            {
                XmlDocument doc2 = new XmlDocument();
                doc2.Load(filePathForXMLService);
                XmlNode dSftTm = doc2.SelectSingleNode("voucher");
                xmlStringService = dSftTm.InnerXml;
                xmlStringService = "<voucher>" + xmlStringService + "</voucher>";
                StringReader sr = new StringReader(xmlStringService);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { GridView2.DataSource = ds; }

                else { GridView2.DataSource = ""; }
                GridView2.DataBind();
            }
            catch { }
        }
    }
}