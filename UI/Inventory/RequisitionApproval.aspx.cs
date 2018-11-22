using HR_BLL.Global;
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
    public partial class RequisitionApproval : BasePage
    {
        DaysOfWeek bll = new DaysOfWeek(); DataTable dtbl = new DataTable(); string qnt = "0.00"; string reqid;
        string xmlpath; string xmlString = ""; string innerReportHtml = ""; string innerBodyHtml = ""; int GrandTotal = 0; int intInsertBy = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("~/Inventory/Data/REQ_" + HttpContext.Current.Session[SessionParams.USER_ID].ToString() + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); txtFDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); hdnuserid.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                try { File.Delete(xmlpath); } catch { }
            }
        }
        protected void Dtls_Click(object sender, EventArgs e)
        {
            try
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                dtbl = bll.CreateStoreRequisition(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(senderdata), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text), intInsertBy);
                if (dtbl.Rows.Count > 0) { dgv.DataSource = dtbl; dgv.DataBind();
                    lblRN.Text = dtbl.Rows[0]["Code"].ToString();
                    lbldt.Text = "Date: " + DateTime.Parse(dtbl.Rows[0]["DDate"].ToString()).ToString("yyyy-MM-dd");
                    issby.Text = "Requisition By : " + dtbl.Rows[0]["Messages"].ToString();
                }
                else { dgv.DataSource = ""; dgv.DataBind(); }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails();", true);
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        protected void ItemDtls_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);
                #region --------------- Bind Item details ---------------

                dtbl = bll.CreateStoreRequisition(2, int.Parse(datas[4].ToString()), "", int.Parse(datas[2].ToString()), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text), intInsertBy);
                if (dtbl.Rows.Count > 0)
                {
                    for (int row = 0; row < dtbl.Rows.Count; row++)
                    {
                        innerBodyHtml = innerBodyHtml + @"<tr style = 'font:normal 10px verdana;'>
                            <td class='tblrowodd' style = 'text-align:center; width:20px;'>" + (row + 1).ToString() + @".</td>
                            <td class='tblrowodd' style = 'text-align:center; width:75px;'>" + DateTime.Parse(dtbl.Rows[row]["DDate"].ToString()).ToString("yyyy-MM-dd") + @"</td>
                            <td class='tblrowodd' style = 'text-align:right; width:50px;'>" + dtbl.Rows[row]["Quantity"].ToString() + @"</td>
                            </tr>";
                        GrandTotal = GrandTotal + int.Parse(dtbl.Rows[row]["Quantity"].ToString());
                    }
                    innerReportHtml = @"<table style='text-align:center; width:275px; font:bold 11px verdana;'> 
                        <tr><td colspan='3' style='font-size:12px; background-color:#fae9e9'>Item Name : " +
                        dtbl.Rows[0]["Items"].ToString() + @"<br /></td></tr>           
                        <tr class='tblroweven'><td>SL.</td><td>Date</td><td>Quantity</td></tr>
                        <tr><td colspan='3'>"; innerReportHtml = innerReportHtml + innerBodyHtml + @"</td></tr>
                        <tr style = 'text-align:right;  background-color:#fae9e9; color:blue;'><td colspan='2'> TOTAL : </td><td>" + GrandTotal + @"</td></tr></table>";
                    report.InnerHtml = innerReportHtml;
                }

                #endregion
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ItemDetails('" + datas[2].ToString() + "','" + datas[4].ToString() + "');", true);
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }
        protected void App_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnconfirm.Value == "1")
                {
                    char[] delimiterChars = { '^' };
                    string temp = ((Button)sender).CommandArgument.ToString();
                    string[] datas = temp.Split(delimiterChars);
                    int idx = int.Parse(datas[0].ToString());
                    qnt = ((TextBox)dgv.Rows[idx].FindControl("txtAppQuantity")).Text.ToString();
                    if (qnt.Length == 0 || int.Parse(qnt) > int.Parse(datas[3].ToString())) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Closediv('Approved quantity is greater than request quantity.');", true); return; }
                    else
                    {
                        Createxml(datas[2].ToString(), qnt);
                        XmlDocument doc = new XmlDocument(); XmlNode xmls;
                        doc.Load(xmlpath); xmls = doc.SelectSingleNode("Requisition");
                        xmlString = xmls.InnerXml;
                        xmlString = "<Requisition>" + xmlString + "</Requisition>";
                        dtbl = bll.CreateStoreRequisition(4, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, int.Parse(datas[1].ToString()), DateTime.Now, DateTime.Now, intInsertBy);

                        string sts = "0";
                        sts = dtbl.Rows[0]["Messages"].ToString();
                        #region -------------Loadgrid -------------------
                        dtbl = bll.CreateStoreRequisition(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(datas[1].ToString()), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text), intInsertBy);
                        if (dtbl.Rows.Count > 0)
                        {
                            dgv.DataSource = dtbl; dgv.DataBind();
                            lblRN.Text = dtbl.Rows[0]["Code"].ToString();
                            lbldt.Text = "Date: " + DateTime.Parse(dtbl.Rows[0]["DDate"].ToString()).ToString("yyyy-MM-dd");
                            issby.Text = "Requisition By : " + dtbl.Rows[0]["Messages"].ToString();
                        }
                        else { dgv.DataSource = ""; dgv.DataBind(); sts = "1"; }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Closediv('" + sts + "');", true);

                        #endregion
                        Loadgrid();

                    }
                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
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
        protected void btnShow_Click(object sender, EventArgs e)
        { Loadgrid(); }
        private void Loadgrid()
        {
            try
            {
                dtbl = bll.CreateStoreRequisition(2, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", 0, DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text), intInsertBy);
                if (dtbl.Rows.Count > 0) { dgvlist.DataSource = dtbl; dgvlist.DataBind();
                    lblwh.Text = dtbl.Rows[0]["WHouse"].ToString();
                    lblpoint.Text = HttpContext.Current.Session[SessionParams.JOBSTATION_NAME].ToString();
                }
                else { dgvlist.DataSource = ""; dgvlist.DataBind(); }
            }
            catch { }
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
                    dtbl = bll.CreateStoreRequisition(4, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), xmlString, int.Parse(reqid), DateTime.Now, DateTime.Now, intInsertBy);

                    string sts = "1";
                    sts = dtbl.Rows[0]["Messages"].ToString();
                    #region -------------Loadgrid -------------------
                    dtbl = bll.CreateStoreRequisition(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text), intInsertBy);
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
                    try { File.Delete(xmlpath); }
                    catch { }
                    #endregion
                    #endregion

                }
            }
            catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0 && hdnconfirm.Value == "1")
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
               {
               
                    reqid = ((HiddenField)dgv.Rows[i].FindControl("hdnreqid")).Value.ToString();
               
                }

                #region ------------- Insert into DataBase -------------
               
                dtbl = bll.CreateStoreRequisition(6, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Now, DateTime.Now, intInsertBy);

                string sts = "1";
                sts = dtbl.Rows[0]["Messages"].ToString();
                #region -------------Loadgrid -------------------
                dtbl = bll.CreateStoreRequisition(3, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(reqid), DateTime.Parse(txtFDate.Text), DateTime.Parse(txtTDate.Text), intInsertBy);
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
                try { File.Delete(xmlpath); }
                catch { }
                #endregion
                #endregion

            }
        }
       
 
    }
}