using Flogging.Core;
using GLOBAL_BLL;
using SAD_BLL.Customer;
using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.SAD.Delivery
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected decimal totAmount = 0, totPieces = 0, aprPieces = 0;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Order\\DeliveryViewForPendingOrder";
        string stop = "stopping SAD\\Order\\DeliveryViewForPendingOrder";

        string Unitid, ShipPointid, SalesOffid, CustType, ReportType, challanid, custid, filePathForXML, xmlString = "", xml;
        int intColumnStatus, intType;

        SalesOrderView obj = new SalesOrderView();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

                pnlMarque.DataBind();
                //File.Delete(filePathForXML); dgvInvoice.DataSource = ""; dgvInvoice.DataBind();
               
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetCustomerList(string prefixText, int count)
        {
            return CustomerInfoSt.GetCustomerDataForAutoFill(HttpContext.Current.Session[SessionParams.CURRENT_UNIT].ToString(), prefixText, HttpContext.Current.Session[SessionParams.CURRENT_CUS_TYPE].ToString(), HttpContext.Current.Session[SessionParams.CURRENT_SO].ToString());
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            DateTime fromDate = txtFrom.Text == "" ? DateTime.Now.AddDays(-365) : CommonClass.GetDateAtSQLDateFormat(txtFrom.Text);
            DateTime toDate = txtTo.Text == "" ? DateTime.Now.AddDays(30) : CommonClass.GetDateAtSQLDateFormat(txtTo.Text);
            hdnFrom.Value = fromDate.ToString();
            hdnTo.Value = toDate.ToString();
            //dgvInvoice.DataBind();
        }
        
        protected void ddlSo_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlCusType.DataBind();
        }        

        protected void ddlShip_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
            ddlSo.DataBind();
            ddlCusType.DataBind();
        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }

        protected void ddlShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_SHIP] = ddlShip.SelectedValue;
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            ddlShip.DataBind();
            ddlSo.DataBind();
            ddlCusType.DataBind();
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[ClassFiles.SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            Session[SessionParams.CURRENT_SO] = ddlSo.SelectedValue;
        }
        protected void ddlCusType_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }
        protected void ddlCusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_CUS_TYPE] = ddlCusType.SelectedValue;
        }

        protected void btnSingle_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PurchaseVoucher.aspx btnPrepareAllVoucher_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (hdnconfirm.Value == "1")
                {                   
                    intType = 1;                    
                    InvoiceGenerate(intType);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void btnGroup_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on PaymentModule/PurchaseVoucher.aspx btnPrepareAllVoucher_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (hdnconfirm.Value == "1")
                {
                    intType = 2;
                    InvoiceGenerate(intType);
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "btnPrepareAllVoucher_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        public void InvoiceGenerate(int intType)
        {
            if (filePathForXML != null) { File.Delete(filePathForXML); }

            if (dgvInvoice.Rows.Count > 0)
            {
                for (int index = 0; index < dgvInvoice.Rows.Count; index++)
                {
                    if (((CheckBox)dgvInvoice.Rows[index].FindControl("chkRow")).Checked == true)
                    {
                        challanid = ((Label)dgvInvoice.Rows[index].FindControl("lblID")).Text.ToString();
                        custid = ((Label)dgvInvoice.Rows[index].FindControl("lblCusID")).Text.ToString();

                        if (challanid != "" || custid != "")
                        {
                            CreateVoucherXml(challanid, custid);
                        }
                    }
                    else
                    {
                        // not selected
                    }
                }
            }

            if (dgvInvoice.Rows.Count > 0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePathForXML);
                    XmlNode dSftTm = doc.SelectSingleNode("INV");
                    string xmlString = dSftTm.InnerXml;
                    xmlString = "<INV>" + xmlString + "</INV>";
                    xml = xmlString;
                }
                catch { }
            }
            if (xml == null) { return; }
            if (xml == "") { return; }

            //*** Final Insert
            string message = obj.InvoiceGenerate(intType, int.Parse(Session[SessionParams.USER_ID].ToString()), xml);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            if (filePathForXML != null) { File.Delete(filePathForXML); }
            //LoadGrid();
        }

        private void CreateVoucherXml(string challanid, string custid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("INV");
                XmlNode addItem = CreateItemNode(doc, challanid, custid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("INV");
                XmlNode addItem = CreateItemNode(doc, challanid, custid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string challanid, string custid)
        {
            XmlNode node = doc.CreateElement("INV");
            XmlAttribute Challanid = doc.CreateAttribute("challanid"); Challanid.Value = challanid;
            XmlAttribute Custid = doc.CreateAttribute("custid"); Custid.Value = custid;

            node.Attributes.Append(Challanid);
            node.Attributes.Append(Custid);
            return node;
        }

        protected void txtCus_TextChanged(object sender, EventArgs e)
        {
            char[] ch = { '[', ']' };
            string[] temp = txtCus.Text.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length > 1) hdnCustomer.Value = temp[temp.Length - 1];
            else hdnCustomer.Value = "";
        }
        
        protected void dgvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //dgvInvoice.PageIndex = e.NewPageIndex;
        }






    }
}