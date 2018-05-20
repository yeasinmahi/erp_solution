using SCM_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.IO;
using System.Xml;

namespace UI.PaymentModule
{
    public partial class BillApproval : BasePage
    {
        #region===== Variable & Object Declaration ====================================================
        Billing_BLL objBillReg = new Billing_BLL();
        DataTable dt;

        string filePathForXML, xmlString, xml, challan, mrrid, amount;
        int intUnitid, intPOID, intSuppid, intCOAID, intEnroll, intAction, intEntryType, intLevel, intBillID;
        string strPType, strReffNo, strSupplierName, billid, actionid;
        DateTime dteFDate, dteTDate;

        #endregion ====================================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                filePathForXML = Server.MapPath("~/PaymentModule/Data/BillApp_" + hdnEnroll.Value + ".xml");
                if (!IsPostBack)
                {
                    File.Delete(filePathForXML);
                    btnApproveAll.Visible = false;
                    hdnLevel.Value = "0";
                    dt = new DataTable();
                    dt = objBillReg.GetUserInfoForAudit(int.Parse(hdnEnroll.Value));
                    if (bool.Parse(dt.Rows[0]["ysnAudit2"].ToString()) == true)
                    {
                        hdnLevel.Value = "2";
                        btnApproveAll.Visible = true;
                        lblHeading.Text = "BILL APPROVAL (LEVEL-2)";
                    }
                    else if (bool.Parse(dt.Rows[0]["ysnAudit1"].ToString()) == true)
                    {
                        hdnLevel.Value = "1";
                        lblHeading.Text = "BILL APPROVAL (LEVEL-1)";
                    }
                    if(hdnLevel.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Bill Approval Permission Denied.');", true);
                        return;
                    }

                    //File.Delete(filePathForXML);   
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    dt = objBillReg.GetAllUnit();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();                    
                }
            }
            catch { }
        }

        #region===== Button Action============ ===================================================
        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                if (dgvBillReport.Rows.Count > 0)
                {
                    for (int index = 0; index < dgvBillReport.Rows.Count; index++)
                    {   
                        billid = ((Label)dgvBillReport.Rows[index].FindControl("lblID")).Text.ToString();
                        actionid = ((DropDownList)dgvBillReport.Rows[index].FindControl("ddlActionStatus")).SelectedValue.ToString();

                        if (billid != "" && actionid != "" && actionid != "1")
                        {
                            CreateVoucherXml(billid, actionid);
                        }
                    }
                }

                if (dgvBillReport.Rows.Count > 0)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(filePathForXML);
                        XmlNode dSftTm = doc.SelectSingleNode("BillApp");
                        string xmlString = dSftTm.InnerXml;
                        xmlString = "<BillApp>" + xmlString + "</BillApp>";
                        xml = xmlString;
                    }
                    catch { }                    
                }
                if (xml == "") { return; }

                //*** Final Insert
                string message = objBillReg.InsertAllBillApproval(int.Parse(hdnLevel.Value), int.Parse(hdnEnroll.Value), xml);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);                
                LoadGrid();
            }
        }

        private void CreateVoucherXml(string billid, string actionid)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filePathForXML))
            {
                doc.Load(filePathForXML);
                XmlNode rootNode = doc.SelectSingleNode("BillApp");
                XmlNode addItem = CreateItemNode(doc, billid, actionid);
                rootNode.AppendChild(addItem);
            }
            else
            {
                XmlNode xmldeclerationNode = doc.CreateXmlDeclaration("1.0", "", "");
                doc.AppendChild(xmldeclerationNode);
                XmlNode rootNode = doc.CreateElement("BillApp");
                XmlNode addItem = CreateItemNode(doc, billid, actionid);
                rootNode.AppendChild(addItem);
                doc.AppendChild(rootNode);
            }
            doc.Save(filePathForXML);
        }
        private XmlNode CreateItemNode(XmlDocument doc, string billid, string actionid)
        {
            XmlNode node = doc.CreateElement("BillApp");
            XmlAttribute Billid = doc.CreateAttribute("billid"); Billid.Value = billid;
            XmlAttribute Actionid = doc.CreateAttribute("actionid"); Actionid.Value = actionid;

            node.Attributes.Append(Billid);
            node.Attributes.Append(Actionid);            
            return node;
        }
        
        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            LoadGridSingle();            
        }
        private void LoadGridSingle()
        {
            try
            {
                strReffNo = txtBillRegNo.Text;

                dt = objBillReg.GetBillInfoByBillReg(strReffNo);
                dgvBillReport.DataSource = dt;
                dgvBillReport.DataBind();
            }
            catch { }
        }
        private void LoadGrid()
        {
            intUnitid = int.Parse(ddlUnit.SelectedValue.ToString());
            dteFDate = DateTime.Parse(txtFromDate.Text);
            dteTDate = DateTime.Parse(txtToDate.Text);
            intAction = int.Parse(ddlAction.SelectedValue.ToString());
            intEntryType = 1;
            intLevel = int.Parse(hdnLevel.Value);

            dt = objBillReg.GetPaymentApprovalSummaryAllUnitForWeb(intUnitid, dteFDate, dteTDate, intAction, intEntryType, intLevel);
            dgvBillReport.DataSource = dt;
            dgvBillReport.DataBind();

            dgvBillReport.Columns[12].Visible = false;
            dgvBillReport.Columns[1].Visible = false;
            dgvBillReport.Columns[7].Visible = false;
            dgvBillReport.Columns[8].Visible = false;
            dgvBillReport.Columns[11].Visible = false;

            if (hdnLevel.Value == "1")
            {
                dgvBillReport.Columns[12].Visible = true;
                dgvBillReport.Columns[1].Visible = true;
                dgvBillReport.Columns[7].Visible = true;
                dgvBillReport.Columns[8].Visible = true;
                dgvBillReport.Columns[11].Visible = false;

            }
            else
            {
                dgvBillReport.Columns[12].Visible = false;
                dgvBillReport.Columns[1].Visible = false;
                dgvBillReport.Columns[7].Visible = false;
                dgvBillReport.Columns[8].Visible = false;
                dgvBillReport.Columns[11].Visible = true;
            }
        }
        #endregion=====================================================================================

        protected void dgvBillReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvBillReport.Rows[rowIndex];

            char[] ch1 = { ':', ':' };
            string[] temp1 = (row.FindControl("lblReff") as Label).Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
            string strPOCheck = temp1[0].ToString();
            try { intPOID = int.Parse(temp1[1].ToString());} catch { intPOID = 0; }

            if (e.CommandName == "S")
            {                
                try
                {                        
                    if (strPOCheck == "PO")
                    {
                        Session["pono"] = intPOID.ToString();//intBillID.ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('../SCM/PoDetalisView.aspx');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This is not a PO.');", true);
                        return;
                    }
                }
                catch { }                
            }
            else if (e.CommandName == "SD")
            {
                Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;
                intBillID = int.Parse((row.FindControl("lblID") as Label).Text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewBillDetailsPopup('" + intBillID.ToString() + "');", true);
            }
            else if (e.CommandName == "A")
            {
                Session["party"] = (row.FindControl("lblPartyName") as Label).Text;
                Session["billamount"] = (row.FindControl("lblBillAmount") as Label).Text;
                intBillID = int.Parse((row.FindControl("lblID") as Label).Text);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewApproveActionPopup('" + intBillID.ToString() + "');", true);
            }

        }























    }
}