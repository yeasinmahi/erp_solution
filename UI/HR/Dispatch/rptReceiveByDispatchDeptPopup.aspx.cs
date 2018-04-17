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
    public partial class rptReceiveByDispatchDeptPopup : System.Web.UI.Page
    {
        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;

        string[] arrayKey; char[] delimiterChars = { '[', ']' };
        string filePathForXML, xmlString = "", xml;
        int intPart, intEnroll, intID;
        string itemid, itemname, qty, remarks;

        int intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy;
        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
           
            if (!IsPostBack)
            {
                intID = int.Parse(Request.QueryString["Id"]);
                hdnDispatchID.Value = intID.ToString();
                intPart = 10;
                intEnroll = intID;
                LoadGrid();
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
                    monAmount = 0;
                    intDispatchBy = int.Parse(hdnEnroll.Value);
                    intReceiveBy = 0;
                    intApproveBy = int.Parse(hdnEnroll.Value);
                    xml = "";
                    intPart = 5;
                    string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "close", "CloseWindow();", true);
                }
                catch { }
            }
        }






    }
}