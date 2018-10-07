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
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.HR.Dispatch
{
    public partial class rptDispatchReceiveByOwner : System.Web.UI.Page
    {
        SeriLog log = new SeriLog();
        string location = "HR";
        string start = "starting HR/Dispatch/rptDispatchReceiveByOwner.aspx";
        string stop = "stopping HR/Dispatch/rptDispatchReceiveByOwner.aspx";

        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;

        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML, xmlString = "", xml;
        int intPart, intEnroll;
        string itemid, itemname, qty, remarks;

        int intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy, intJobStationStatus;       
        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount; 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/rptDispatchReceiveByOwner.aspx Page_Load", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnJobStationID.Value = Session[SessionParams.JOBSTATION_ID].ToString();
            
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            else if (hdnconfirm.Value == "3") { Show(); }
            //else if (hdnconfirm.Value == "5") { ReceiveByOwner(); }
            else
            {
                //hdnJobStationID.Value = "154";
                dt = new DataTable();
                dt = obj.GetJobStationStatus(int.Parse(hdnJobStationID.Value));
                if (dt.Rows.Count > 0)
                {
                    intJobStationStatus = int.Parse(dt.Rows[0]["ysnJobStation"].ToString());
                }

                if (intJobStationStatus == 1)
                {
                    Label3.Visible = true;
                    txtEmployeeCardNo.Visible = true;
                    lblEnroll.Visible = false;
                    txtEnrollByReceiver.Visible = false;                    
                    txtEnrollByReceiver.Text = "";
                    btnApproveDT.Visible = false;
                }
                else
                {
                    lblEnroll.Visible = true;
                    txtEnrollByReceiver.Visible = true;
                    Label3.Visible = false;
                    txtEmployeeCardNo.Visible = false;
                    txtEmployeeCardNo.Text = "";
                    btnApproveDT.Visible = true;
                }
            }

            fd = log.GetFlogDetail(stop, location, "Page_Load", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void txtEnrollR_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "txtEnrollR_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/rptDispatchReceiveByOwner.aspx txtEnrollR_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (hdnconfirm.Value == "5")
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
                    intReceiveBy = int.Parse(txtEnrollByReceiver.Text);
                    intReceiverEnroll = int.Parse(txtEnrollByReceiver.Text);
                    intApproveBy = int.Parse(hdnEnroll.Value);
                    xml = "";
                    intPart = 9;
                    string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    LoadGrid();
                    hdnDispatchID.Value = "0";
                    hdnconfirm.Value = "0";
                }
                catch { }
            }

            fd = log.GetFlogDetail(stop, location, "txtEnrollR_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }


        #region ===== Selection Change ===================================================
        protected void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPending.Checked == true) { rdoReceived.Checked = false; rdoPrimaryReceive.Checked = false; }
            else { rdoPending.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }
        protected void rdoReceived_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReceived.Checked == true) { rdoPending.Checked = false; rdoPrimaryReceive.Checked = false; }
            else { rdoReceived.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }

        protected void rdoPrimaryReceive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPrimaryReceive.Checked == true) { rdoPending.Checked = false; rdoReceived.Checked = false; }
            else { rdoPrimaryReceive.Checked = true; }
            dgvReport.DataSource = ""; dgvReport.DataBind();
        }

        
        #endregion =======================================================================

        private void Show()
        {
            LoadGrid();
            hdnconfirm.Value = "0";
            //btnShowReport.Enabled = false;
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "LoadGrid", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/rptDispatchReceiveByOwner.aspx LoadGrid", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                if (rdoPending.Checked == true)
                {
                    intPart = 8;
                    dgvReport.Columns[10].Visible = false; dgvReport.Columns[11].Visible = true; dgvReport.Columns[12].Visible = false;
                }
                else if (rdoReceived.Checked == true)
                {
                    intPart = 9; dgvReport.Columns[11].Visible = false; dgvReport.Columns[12].Visible = false;
                    dgvReport.Columns[10].Visible = true;
                }
                else if (rdoPrimaryReceive.Checked == true)
                {
                    intPart = 12;
                    dgvReport.Columns[11].Visible = false; dgvReport.Columns[12].Visible = true;
                    dgvReport.Columns[10].Visible = false;
                }

                intEnroll = int.Parse(hdnEnroll.Value); 
                dt = new DataTable();
                dt = obj.GetDispatchReport(intPart, intEnroll);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch { }

            fd = log.GetFlogDetail(stop, location, "LoadGrid", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected void txtChanged_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "txtChanged_Click", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/rptDispatchReceiveByOwner.aspx txtChanged_Click", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            string strCard = txtEmployeeCardNo.Text;
            try
            {
                if (txtEmployeeCardNo.Text != "")
                {
                    intDispatchID = int.Parse(hdnDispatchID.Value);
                    intWHID = 0;
                    strAddress = strCard;
                    strRemarks = "";
                    intCreateBy = 0;
                    intApproveBy = 0;
                    intVehicleNo = 0;
                    strVehicleNo = "";
                    strBearer = "";
                    strBearerContact = "";
                    monAmount = 0;
                    intDispatchBy = int.Parse(hdnEnroll.Value);
                    intReceiveBy = int.Parse(hdnEnroll.Value);
                    intApproveBy = int.Parse(hdnEnroll.Value);
                    xml = "";
                    intPart = 7;
                    string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    LoadGrid();
                    hdnDispatchID.Value = "0";
                    txtEmployeeCardNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "txtChanged_Click", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "txtChanged_Click", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void btnAction_OnCommand(object sender, CommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "btnAction_OnCommand", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on HR/Dispatch/rptDispatchReceiveByOwner.aspx btnAction_OnCommand", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            char[] delimiterChars = { '^' };
            string value = (e.CommandArgument).ToString();
            string[] data = value.Split(delimiterChars);
            hdnDispatchID.Value = data[0].ToString();

            if (e.CommandName.Equals("RECEIVE"))
            {
                //txtEmployeeCardNo.Text = "";
                //txtEmployeeCardNo.Focus();
                //txtEmployeeCardNo.Attributes.Add("onfocus", "this.select();");               

                ////intPart = 10;
                ////intEnroll = int.Parse(data[0].ToString());
                ////dt = new DataTable();
                ////dt = obj.GetDispatchReport(intPart, intEnroll);
                ////dgvAdd.DataSource = dt;
                ////dgvAdd.DataBind();

                ////ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewConfirm('" + 0 + "');", true);
                ////hdnconfirm.Value = "0";

                hdnDispatchID.Value = data[0].ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewOwnerReceivePopup('" + hdnDispatchID.Value + "');", true);
                
            }
            else if (e.CommandName.Equals("RECEIVEDT"))
            {
               
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
                        strVehicleNo = "";                        
                        strBearer = "";                        
                        strBearerContact = "";                       
                        try { monAmount = 0; } catch { }
                        intDispatchBy = int.Parse(hdnEnroll.Value);
                        intReceiveBy = 0;
                        intApproveBy = int.Parse(hdnEnroll.Value);
                        xml = "";
                        intPart = 6;
                        string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        LoadGrid();                        
                        hdnDispatchID.Value = "0";
                        hdnconfirm.Value = "0";
                    }
                    catch { }
                }
            }
            else if (e.CommandName.Equals("PRIMARYRECEIVE"))
            {
                if (hdnconfirm.Value == "1")
                {
                    try
                    {
                        hdnDispatchID.Value = data[0].ToString();
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
                        intReceiveBy = int.Parse(hdnEnroll.Value);
                        intApproveBy = int.Parse(hdnEnroll.Value);
                        xml = "";
                        intPart = 8;
                        string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                        LoadGrid();
                        hdnDispatchID.Value = "0";
                        hdnconfirm.Value = "0";
                    }
                    catch { }
                }
            }

            fd = log.GetFlogDetail(stop, location, "btnAction_OnCommand", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }





















    }
}