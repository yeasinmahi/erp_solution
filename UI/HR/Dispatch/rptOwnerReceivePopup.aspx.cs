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
    public partial class rptOwnerReceivePopup : System.Web.UI.Page
    {

        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;

        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML, xmlString = "", xml;
        int intPart, intEnroll, intID, intJobStationStatus;
        string itemid, itemname, qty, remarks;
        
        int intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy;
        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnJobStationID.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            if (!IsPostBack)
            {
                intID = int.Parse(Request.QueryString["Id"]);
                hdnDispatchID.Value = intID.ToString();
                intPart = 10;
                intEnroll = intID;
                LoadGrid();


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
                    lblEnroll.Visible = true;
                    txtEnrollByReceiver.Visible = true;

                    txtEnrollByReceiver.Text = "";
                    txtEmployeeCardNo.Text = "";
                    btnApproveDT.Visible = true;                    
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
            
        }

        private void LoadGrid()
        {
            dt = new DataTable();
            dt = obj.GetDispatchReport(intPart, intEnroll);
            dgvAdd.DataSource = dt;
            dgvAdd.DataBind();
        }

        protected void btnApproveDT_Click(object sender, EventArgs e)
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
                }
                catch { }
            }
        }
        protected void txtChanged_Click(object sender, EventArgs e)
        {
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
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
            }
            catch { }
        }
        protected void txtEnrollR_Click(object sender, EventArgs e)
        {
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
                    hdnconfirm.Value = "0";
                    txtEmployeeCardNo.Text = "";
                    txtEnrollByReceiver.Text = "";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { }
            }
        }



    }
}