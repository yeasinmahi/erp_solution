using HR_BLL.TourPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class BrandItemRequisitionApprove : BasePage
    {
        DataTable dtbl = new DataTable();
        TourPlanning bll = new TourPlanning();
        string qnt = "0.00"; string reqid;
        string xmlpath; string xmlString = ""; string innerReportHtml = ""; string innerBodyHtml = ""; int GrandTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/BrandItemsREQ_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); hdnuserid.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                try { File.Delete(xmlpath); }
                catch { }
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }
        private void Loadgrid()
        {
            try
            {
                dtbl = bll.CreateStoreRequisitionForBrandItem(2, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", 0, DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                if (dtbl.Rows.Count > 0)
                {
                    dgvlist.DataSource = dtbl; dgvlist.DataBind();
                    lblwh.Text = dtbl.Rows[0]["WHouse"].ToString();
                    lblpoint.Text = HttpContext.Current.Session[SessionParams.JOBSTATION_NAME].ToString();
                }
                else { dgvlist.DataSource = ""; dgvlist.DataBind(); }
            }
            catch { }
        }

      

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                dtbl = bll.CreateStoreRequisitionForBrandItem(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(senderdata), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                if (dtbl.Rows.Count > 0)
                {
                    dgv.DataSource = dtbl; dgv.DataBind();
                    lblRN.Text = dtbl.Rows[0]["Code"].ToString();
                    lbldt.Text = "Date: " + DateTime.Parse(dtbl.Rows[0]["DDate"].ToString()).ToString("yyyy-MM-dd");
                    issby.Text = "Requisition By : " + dtbl.Rows[0]["Messages"].ToString();
                }
                else { dgv.DataSource = ""; dgv.DataBind(); }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails();", true);
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }

        }

        protected void btnItemDtls_Click(object sender, EventArgs e)
        {
           
        }


        private void Createxml(string itemid, string quantity)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, quantity);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, quantity);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }

        private XmlNode CreateNode(XmlDocument doc, string itemid, string quantity)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Quantity);
            return node;
        }
        protected void btnApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0 && hdnconfirm.Value == "1")
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        string item = ((HiddenField)dgv.Rows[i].FindControl("hdnitemid")).Value.ToString();
                        string reqst = ((HiddenField)dgv.Rows[i].FindControl("hdnreq")).Value.ToString();
                        reqid = ((HiddenField)dgv.Rows[i].FindControl("hdnreqid")).Value.ToString();
                        qnt = ((TextBox)dgv.Rows[i].FindControl("txtAppQuantity")).Text.ToString();
                        if (qnt == "") { qnt = "0.0000"; }
                        if ((double.Parse(reqst) >= double.Parse(qnt)) && (double.Parse(qnt) > double.Parse("0")))
                        { Createxml(item, double.Parse(qnt).ToString("0.0000")); }
                    }

                    #region ------------- Insert into DataBase -------------
                    XmlDocument doc = new XmlDocument(); XmlNode xmls;
                    doc.Load(xmlpath); xmls = doc.SelectSingleNode("Requisition");
                    xmlString = xmls.InnerXml;
                    xmlString = "<Requisition>" + xmlString + "</Requisition>";
                    string trid = reqid;
                    dtbl = bll.CreateStoreRequisitionForBrandItem(4, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, int.Parse(reqid), DateTime.Now, DateTime.Now);

                    string sts = "1";
                    sts = dtbl.Rows[0]["Messages"].ToString();
                    #region -------------Loadgrid -------------------
                    dtbl = bll.CreateStoreRequisitionForBrandItem(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                    if (dtbl.Rows.Count > 0)
                    {
                        dgv.DataSource = dtbl; dgv.DataBind();
                        lblRN.Text = dtbl.Rows[0]["Code"].ToString();
                        lbldt.Text = "Date: " + DateTime.Parse(dtbl.Rows[0]["DDate"].ToString()).ToString("yyyy-MM-dd");
                        issby.Text = "Requisition By : " + dtbl.Rows[0]["Messages"].ToString();
                    }
                    else { dgv.DataSource = ""; dgv.DataBind(); }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Closediv('" + sts + "');", true);
                    Loadgrid();
                    #endregion
                    #endregion

                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
    }
}