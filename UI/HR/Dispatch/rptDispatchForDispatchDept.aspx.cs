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
using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;
using HR_BLL.Global;
using Dairy_BLL;
using HR_BLL.Dispatch;
namespace UI.HR.Dispatch
{
    public partial class rptDispatchForDispatchDept : System.Web.UI.Page
    {
        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;

        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML, xmlString = "", xml;
        int intPart, intEnroll;
        string itemid, itemname, qty, remarks;

        int intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy;
        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            filePathForXML = Server.MapPath("~/HR/Dispatch/Data/AddDispatch_" + hdnEnroll.Value + ".xml");
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();              
            }
        }

        #region ===== Gridview Report ====================================================
        
        protected void btnShowReport_Click(object sender, EventArgs e)
        {            
            LoadGrid();            
        }
        private void LoadGrid()
        {
            try
            {
                if (rdoPending.Checked == true)
                {
                    intPart = 5;
                    dgvReport.Columns[10].Visible = true; dgvReport.Columns[11].Visible = false;
                }
                else if (rdoComplete.Checked == true)
                {
                    intPart = 7; dgvReport.Columns[10].Visible = false; dgvReport.Columns[11].Visible = false;
                }
                else if (rdoDispatch.Checked == true)
                {
                    intPart = 6; dgvReport.Columns[10].Visible = false; dgvReport.Columns[11].Visible = true;
                }

                intEnroll = int.Parse(hdnEnroll.Value);
                dt = new DataTable();
                dt = obj.GetDispatchReport(intPart, intEnroll);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch { }
        }
        #endregion =======================================================================
        
        #region ===== Selection Change ===================================================
        protected void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPending.Checked == true) { rdoComplete.Checked = false; rdoDispatch.Checked = false; }
            else { rdoPending.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }
        protected void rdoComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoComplete.Checked == true) { rdoPending.Checked = false; rdoDispatch.Checked = false; }
            else { rdoComplete.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }
        protected void rdoDispatch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDispatch.Checked == true) { rdoPending.Checked = false; rdoComplete.Checked = false; }
            else { rdoDispatch.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }
        #endregion =======================================================================

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            char[] delimiterChars = { '^' };
            string value = (e.CommandArgument).ToString();
            string[] data = value.Split(delimiterChars);

            if (e.CommandName.Equals("RECEIVE"))
            {
                hdnDispatchID.Value = data[0].ToString();                
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewReceiveByDispatchDeptPopup('" + hdnDispatchID.Value + "');", true);
                
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);
            }
            else if (e.CommandName.Equals("RECEIVEDT"))
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        intDispatchID = int.Parse(hdnDispatchID.Value);
                        intWHID = 0;
                        strAddress = "";
                        strRemarks = "";
                        intCreateBy = 0;
                        intApproveBy = 0;
                        intVehicleNo = 0;
                        strVehicleNo = "";
                        strBearer = "";
                        strBearerContact = "";
                        monAmount = 0;
                        intDispatchBy = int.Parse(hdnEnroll.Value);
                        intReceiveBy = 0;
                        intApproveBy = int.Parse(hdnEnroll.Value);
                        xml = "";
                        intPart = 5;
                        string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        LoadGrid();
                        hdnDispatchID.Value = "0";
                    }
                    catch { }
                }
            }
            else if (e.CommandName.Equals("DISPATCH"))
            {
                //hdnDispatchID.Value = data[0].ToString();
                //intPart = 10;
                //intEnroll = int.Parse(data[0].ToString());
                //dt = new DataTable();
                //dt = obj.GetDispatchReport(intPart, intEnroll);
                //if (dt.Rows.Count > 0)
                //{
                //    txtTokenNo.Text = dt.Rows[0]["strDispatchCode"].ToString();
                //    txtTokenNo.Enabled = false;
                //}
                //dgvAdd1.DataSource = dt;
                //dgvAdd1.DataBind();

                hdnDispatchID.Value = data[0].ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDispatchPopup('" + hdnDispatchID.Value + "');", true);

                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirmDispatch('" + 0 + "');", true);
            }
            else if (e.CommandName.Equals("DISPATCHDT"))
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        intDispatchID = int.Parse(hdnDispatchID.Value);
                        intWHID = 0;
                        strAddress = "";
                        strRemarks = "";
                        intCreateBy = 0;
                        intApproveBy = 0;
                        intVehicleNo = 0;
                        strVehicleNo = txtVehicleNo.Text;
                        if(txtVehicleNo.Text == "") { return; }
                        strBearer = txtBearer.Text;
                        if(txtBearer.Text == "") { return; }
                        strBearerContact = txtContactNo.Text;
                        if(txtContactNo.Text == "") { return; }
                        try { monAmount = decimal.Parse(txtAmount.Text); } catch { }
                        intDispatchBy = int.Parse(hdnEnroll.Value);
                        intReceiveBy = 0;
                        intApproveBy = int.Parse(hdnEnroll.Value);
                        xml = "";
                        strDispatchType = "";
                        intPart = 6;
                        string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        LoadGrid();
                        txtBearer.Text = "";
                        txtContactNo.Text = "";
                        txtVehicleNo.Text = "";
                        txtAmount.Text = "";
                        hdnDispatchID.Value = "0";
                    }
                    catch { }
                }
            }                
        }
        
       
















    }
}