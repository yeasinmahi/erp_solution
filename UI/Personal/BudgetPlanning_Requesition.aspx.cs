using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Personal
{
    public partial class BudgetPlanning_Requesition : System.Web.UI.Page
    {
        string filePathForXMLAssetAccoA;

        string xmlStringAssetAccoA = "";
        string optype, opex, existing;
        protected void Page_Load(object sender, EventArgs e)
        {
           // filePathForXMLAssetAccoA = Server.MapPath("~/Personal/Data/AssetAccoIA_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            filePathForXMLAssetAccoA = Server.MapPath("~/Personal/Data/AssetAccoIA_" + 32897.ToString() + ".xml");
            if(!IsPostBack)
            {
                try { File.Delete(filePathForXMLAssetAccoA); }
                catch { }
                //try
                //{
                //    Ping myPing = new Ping();
                //    String host = "erp.akij.net";
                //    byte[] buffer = new byte[32];
                //    int timeout = 1;
                //    PingOptions pingOptions = new PingOptions();
                //    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                //    if (reply.Status == IPStatus.Success)
                //    {

                //        Label5.Text = "Network:||||||".ToString();
                //        Label5.ForeColor = System.Drawing.Color.Green;
                //    }
                   
                //}
                //catch (Exception)
                //{
                //    Label5.Text = "Network:-----!".ToString();
                //    Label5.ForeColor = System.Drawing.Color.Red;
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please contact with IT Department');", true);
                //}
            }
        }

        protected void OperationID_CheckedChanged(object sender, EventArgs e)
        {
            NonOperationID.Checked = false;
            OperationID.Checked = true;
        }

        protected void NonOperationID_CheckedChanged(object sender, EventArgs e)
        {
            OperationID.Checked = false;

            NonOperationID.Checked = true;
        }

        protected void OpexID_CheckedChanged(object sender, EventArgs e)
        {
            OpexID.Checked = true;

            CapexID.Checked = false;
        }

        protected void CapexID_CheckedChanged(object sender, EventArgs e)
        {
            CapexID.Checked = true;

            OpexID.Checked = false;

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Checked = true;
            RadioButton2.Checked = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Checked = false;
            RadioButton2.Checked = true;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string costcenter = DdlCostCenter.SelectedItem.ToString();
                string opname = TxtOperationName.Text.ToString();
                if (OperationID.Checked == true) { optype = "Operation".ToString(); }
                if (NonOperationID.Checked == true) { optype = "nonOperation".ToString(); }
                string nmaetype = DdlOpName.SelectedItem.ToString();
                if (OpexID.Checked == true) { opex = "Opex".ToString(); }
                if (CapexID.Checked == true) { opex = "Capex".ToString(); }
                string name = Txtname.Text.ToString();
                if (RadioButton1.Checked == true) { existing = "Exixting".ToString(); }
                if (RadioButton2.Checked == true) { existing = "New".ToString(); }
                string qty = TxtQty.Text.ToString();
                string amount = TxtAmount.Text.ToString();
                CreateVoucherXml(costcenter, opname, optype, nmaetype, opex, name, existing, qty, amount);
            }
            catch { }
        }

        private void CreateVoucherXml(string costcenter, string opname, string optype, string nmaetype, string opex, string name, string existing, string qty, string amount)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXMLAssetAccoA))
            {
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode rootNode = doc.SelectSingleNode("voucher");
                XmlNode addItem = CreateItemNodeGetpassOut(doc, costcenter, opname, optype, nmaetype, opex, name, existing, qty, amount);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("voucher");
                XmlNode addItem = CreateItemNodeGetpassOut(doc, costcenter, opname, optype, nmaetype, opex, name, existing, qty, amount);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXMLAssetAccoA);
            LoadGridwithXml();
        }

        private void LoadGridwithXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePathForXMLAssetAccoA);
                XmlNode dSftTm = doc.SelectSingleNode("voucher");
                xmlStringAssetAccoA = dSftTm.InnerXml;
                xmlStringAssetAccoA = "<voucher>" + xmlStringAssetAccoA + "</voucher>";
                StringReader sr = new StringReader(xmlStringAssetAccoA);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                { dgvbudget.DataSource = ds; }

                else { dgvbudget.DataSource = ""; }
                dgvbudget.DataBind();
            }
            catch { }
        }


        private XmlNode CreateItemNodeGetpassOut(XmlDocument doc, string costcenter, string opname, string optype, string nmaetype, string opex, string name, string existing, string qty, string amount)
        {
            XmlNode node = doc.CreateElement("voucherentry");
            XmlAttribute Costcenter = doc.CreateAttribute("costcenter");
            Costcenter.Value = costcenter;
            XmlAttribute Opname = doc.CreateAttribute("opname");
            Opname.Value = opname;
            XmlAttribute Optype = doc.CreateAttribute("optype");
            Optype.Value = optype;
            XmlAttribute Nmaetype = doc.CreateAttribute("nmaetype");
            Nmaetype.Value = nmaetype;
            XmlAttribute Opex = doc.CreateAttribute("opex");
            Opex.Value = opex;
            XmlAttribute Name = doc.CreateAttribute("name");
            Name.Value = name;
            XmlAttribute Existing = doc.CreateAttribute("existing");
            Existing.Value = existing;
            XmlAttribute Qty = doc.CreateAttribute("qty");
            Qty.Value = qty;
            XmlAttribute Amount = doc.CreateAttribute("amount");
            Amount.Value = amount;



            node.Attributes.Append(Costcenter);
            node.Attributes.Append(Opname);
            node.Attributes.Append(Optype);
            node.Attributes.Append(Nmaetype);
            node.Attributes.Append(Opex);
            node.Attributes.Append(Name);
            node.Attributes.Append(Existing);
            node.Attributes.Append(Qty);
            node.Attributes.Append(Amount);
          



            return node;
        }

        protected void dgvbudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                LoadGridwithXml();
                DataSet dsGrid = (DataSet)dgvbudget.DataSource;
                dsGrid.Tables[0].Rows[dgvbudget.Rows[e.RowIndex].DataItemIndex].Delete();
                dsGrid.WriteXml(filePathForXMLAssetAccoA);
                DataSet dsGridAfterDelete = (DataSet)dgvbudget.DataSource;
                if (dsGridAfterDelete.Tables[0].Rows.Count <= 0)
                { File.Delete(filePathForXMLAssetAccoA); dgvbudget.DataSource = ""; dgvbudget.DataBind(); }
                else { LoadGridwithXml(); }
            }

            catch { }
        }

        

        
    }
}