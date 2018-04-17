using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace UI.GetInOut
{
    public partial class MatarialsOut : System.Web.UI.Page
    {
        string filePathForXML;
        string xmlString = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            string strEnroll = "32897";

            filePathForXML = Server.MapPath("student" + strEnroll + ".xml");
            if (!IsPostBack)
            {
                try { File.Delete(filePathForXML); }
                catch { }

            }
            LoadGridwithXml();


        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXML);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlString = dSftTm.InnerXml;
                xmlString = "<voucher>" + xmlString + "</voucher>";
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgv.DataSource = ds; }

                else { dgv.DataSource = ""; }
                dgv.DataBind();
            }
            catch { }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            //DataRow dr;

            //GridView2.DataSource = dt;
            //GridView2.DataBind();
            string getpass = Txtgetpass.Text.ToString();
            string item = Txtitem.Text.ToString();
            string qty = Txtqty.Text.ToString();
            string drivername = Txtdriver.Text.ToString();
            string mobaile = Txtmobaile.Text.ToString();
            string destination = Txtdestination.Text.ToString();
            string outtype = Ddltype.Text.ToString();
            string scaleid = Txtscaleid.Text.ToString();
            string grossweight = Txtgrossweight.Text.ToString();
            string netweight = txtnetweight.Text.ToString();


           

            CreateVoucherXml(getpass,item,qty,drivername,mobaile,destination,outtype,scaleid,grossweight,netweight);


        }

        private void CreateVoucherXml(string getpass, string item, string qty, string drivername, string mobaile, string destination, string outtype, string scaleid, string grossweight, string netweight)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNode(doc, getpass, item, qty, drivername, mobaile, destination, outtype, scaleid, grossweight, netweight);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNode(doc, getpass, item, qty, drivername, mobaile, destination, outtype, scaleid, grossweight, netweight);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
            LoadGridwithXml();
        }

        private XmlNode CreateItemNode(XmlDocument doc, string getpass, string item, string qty, string drivername, string mobaile, string destination, string outtype, string scaleid, string grossweight, string netweight)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Getpass = doc.CreateAttribute("getpass");
           Getpass.Value = getpass;
            XmlAttribute Item = doc.CreateAttribute("item");
            Item.Value = item;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Drivername = doc.CreateAttribute("drivername");
            Drivername.Value = drivername;
            
            XmlAttribute Mobaile = doc.CreateAttribute("mobaile");
            Mobaile.Value = mobaile;
            XmlAttribute Destination = doc.CreateAttribute("destination");
            Destination.Value = destination;
            XmlAttribute Outtype= doc.CreateAttribute("outtype");
            Outtype.Value = outtype;
            
            XmlAttribute Scaleid = doc.CreateAttribute("scaleid");
            Scaleid.Value = scaleid;
            XmlAttribute Grossweight = doc.CreateAttribute("grossweight");
            Grossweight.Value = grossweight;
            XmlAttribute Netweight = doc.CreateAttribute("netweight");
            Netweight.Value = netweight;
            

            node.Attributes.Append(Getpass);

            node.Attributes.Append(Item);
            node.Attributes.Append(Drivername);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Drivername);
            node.Attributes.Append(Mobaile);
            node.Attributes.Append(Destination);
            node.Attributes.Append(Outtype);
            node.Attributes.Append(Scaleid);
            node.Attributes.Append(Grossweight);
            node.Attributes.Append(Netweight);
           


            return node;

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

        }
    }
}