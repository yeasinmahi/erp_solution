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
    public partial class BrandItemIssuedByWH : BasePage
    {
        DataTable dtbl = new DataTable();
        TourPlanning bll = new TourPlanning();
        string qnt = "0.00"; string reqid; string whid; string unitid;
        string xmlpath; string xmlString = ""; string innerReportHtml = ""; string innerBodyHtml = ""; int GrandTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/BrandItemsISSUEREQ_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");

            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); hdnuserid.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                try { File.Delete(xmlpath); }
                catch { }
            }
        
        }

        private void Loadgrid()
        {
            try
            {
                dtbl = bll.CreateStoreRequisitionForBrandItem(5, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", 0, DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
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
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Loadgrid();
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                dtbl = bll.CreateStoreRequisitionForBrandItem(6, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(senderdata), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                if (dtbl.Rows.Count > 0)
                {
                    dgvissue.DataSource = dtbl; dgvissue.DataBind();
                    lblRN.Text = dtbl.Rows[0]["Code"].ToString();
                    lbldt.Text = "Date: " + DateTime.Parse(dtbl.Rows[0]["DDate"].ToString()).ToString("yyyy-MM-dd");
                    issby.Text = "Requisition By : " + dtbl.Rows[0]["Messages"].ToString();
                }
                else { dgvissue.DataSource = ""; dgvissue.DataBind(); }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails();", true);
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }

        private void Createxml(string itemid, string quantity, string wh, string unit, string dudt)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(xmlpath))
            {
                doc.Load(xmlpath);
                XmlNode rootNode = doc.SelectSingleNode("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, quantity, wh, unit, dudt);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("Requisition");
                XmlNode addItem = CreateNode(doc, itemid, quantity, wh, unit, dudt);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(xmlpath);
        }

        private XmlNode CreateNode(XmlDocument doc, string itemid, string quantity, string wh, string unit, string dudt)
        {
            XmlNode node = doc.CreateElement("req");
            XmlAttribute Itemid = doc.CreateAttribute("itemid");
            Itemid.Value = itemid;
            XmlAttribute Quantity = doc.CreateAttribute("quantity");
            Quantity.Value = quantity;
            XmlAttribute WHID = doc.CreateAttribute("wh");
            WHID.Value = wh;
            XmlAttribute UNTID = doc.CreateAttribute("unit");
            UNTID.Value = unit;
            XmlAttribute DDDATE = doc.CreateAttribute("dudt");
            DDDATE.Value = dudt;

            node.Attributes.Append(Itemid);
            node.Attributes.Append(Quantity);
            node.Attributes.Append(WHID);
            node.Attributes.Append(UNTID);
            node.Attributes.Append(DDDATE);
            return node;
        }


        protected void btnApp_Click(object sender, EventArgs e)
        {


             try
            {
                if (dgvissue.Rows.Count > 0 && hdnconfirm.Value == "1")
                {
                    int rc = dgvissue.Rows.Count;


                    for (int i = 0; i < rc; i++)
                    {
                        string item = ((HiddenField)dgvissue.Rows[i].FindControl("hdnitemid")).Value.ToString();
                        string reqst = ((HiddenField)dgvissue.Rows[i].FindControl("hdnreq")).Value.ToString();
                        reqid = ((HiddenField)dgvissue.Rows[i].FindControl("hdnreqid")).Value.ToString();
                
                        qnt = ((TextBox)dgvissue.Rows[i].FindControl("txtIssueQuantity")).Text.ToString();
                       
                        whid = ((HiddenField)dgvissue.Rows[i].FindControl("hdnwhid")).Value.ToString();
                        unitid = ((HiddenField)dgvissue.Rows[i].FindControl("hdnUnitid")).Value.ToString();
                        string date = ((HiddenField)dgvissue.Rows[i].FindControl("hdnDate")).Value.ToString();
                        if (qnt == "") { qnt = "0.0000"; }
                        if ((double.Parse(reqst) >= double.Parse(qnt)) && (double.Parse(qnt) > double.Parse("0")))
                        { Createxml(item, double.Parse(qnt).ToString("0.0000"), whid, unitid, date); }
                    }

                    #region ------------- Insert into DataBase -------------
                    XmlDocument doc = new XmlDocument(); XmlNode xmls;
                    doc.Load(xmlpath); xmls = doc.SelectSingleNode("Requisition");
                    xmlString = xmls.InnerXml;
                    xmlString = "<Requisition>" + xmlString + "</Requisition>";
                    string trid = reqid;
                    dtbl = bll.CreateStoreRequisitionForBrandItem(7, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, int.Parse(reqid), DateTime.Now, DateTime.Now);

                    string sts = "1";
                    sts = dtbl.Rows[0]["Messages"].ToString();
                    File.Delete(xmlpath);
                    #region -------------Loadgrid -------------------
                    dtbl = bll.CreateStoreRequisitionForBrandItem(6, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                    if (dtbl.Rows.Count > 0)
                    {
                        dgvissue.DataSource = dtbl; dgvissue.DataBind();
                        lblRN.Text = dtbl.Rows[0]["Code"].ToString();
                        lbldt.Text = "Date: " + DateTime.Parse(dtbl.Rows[0]["DDate"].ToString()).ToString("yyyy-MM-dd");
                        issby.Text = "Requisition By : " + dtbl.Rows[0]["Messages"].ToString();
                    }
                    else { dgvissue.DataSource = ""; dgvissue.DataBind(); }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Closediv('" + sts + "');", true);
                    Loadgrid();
                    #endregion
                    #endregion

                }
            }
             catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }


        protected void btnItemDtls_Click(object sender, EventArgs e)
        {

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvissue.Rows.Count > 0 && hdnconfirm.Value == "1")
                {
                    int rc = dgvissue.Rows.Count;


                    for (int i = 0; i < rc; i++)
                    {
                        string item = ((HiddenField)dgvissue.Rows[i].FindControl("hdnitemid")).Value.ToString();
                        string reqst = ((HiddenField)dgvissue.Rows[i].FindControl("hdnreq")).Value.ToString();
                        reqid = ((HiddenField)dgvissue.Rows[i].FindControl("hdnreqid")).Value.ToString();
                    }
                    dtbl = bll.CreateStoreRequisitionForBrandItem(8, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text));
                    string sts = "1";
                    sts = dtbl.Rows[0]["Messages"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Closediv('" + sts + "');", true);
                }
                else
                { }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }



    }
}