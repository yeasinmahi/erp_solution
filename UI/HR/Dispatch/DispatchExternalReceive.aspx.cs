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
    public partial class DispatchExternalReceive : System.Web.UI.Page
    {
        DispatchGlobalBLL obj = new DispatchGlobalBLL();
        DataTable dt;
        
        string filePathForXML, xmlString = "", xml;
        string categoryid, categoryname, itemid, itemname, qty, remarks, Unitid;
        string[] arrayKey; char[] delimiterChars = { '[', ']' };

        int intEnroll, intPart, intDispatchID, intWHID, intDispatchType, intReceiverEnroll, intCreateBy, intApproveBy, intVehicleNo, intDispatchBy, intReceiveBy;

        string strDispatchType, strReceiver, strAddress, strRemarks, strVehicleNo, strBearer, strBearerContact;
        decimal monAmount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

                dt = new DataTable();
                dt = obj.GetEmpInfo(int.Parse(hdnEnroll.Value));
                if (dt.Rows.Count > 0)
                {
                    txtFName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                    txtSUnit.Text = dt.Rows[0]["strUnit"].ToString();
                    txtSJobS.Text = dt.Rows[0]["strJobStationName"].ToString();
                    txtSPhone.Text = dt.Rows[0]["strContactNo1"].ToString();
                    txtSAddress.Text = dt.Rows[0]["strStationAddress"].ToString();
                    txtSMail.Text = dt.Rows[0]["strOfficeEmail"].ToString();

                    Unitid = Session[SessionParams.UNIT_ID].ToString();
                    HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();

                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                intPart = 1;
                intDispatchID = 0;
                try { intWHID = 0; } catch { return; }
                try { intDispatchType = int.Parse(ddlDispatchType.SelectedValue.ToString()); } catch { }
                strDispatchType = ddlDispatchType.SelectedItem.ToString();

                if (intDispatchType == 2)
                {
                    try
                    {
                        char[] ch1 = { '[', ']' };
                        string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                        intReceiverEnroll = int.Parse(temp1[1].ToString());
                        strReceiver = temp1[0].ToString();
                    }
                    catch { intReceiverEnroll = 0; }

                    if (intReceiverEnroll == 0)
                    { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Employee Properly.');", true); return; }
                }
                
                strAddress = txtJobS.Text;
                strRemarks = txtRemarksMain.Text;
                intCreateBy = int.Parse(hdnEnroll.Value);
                intApproveBy = 0;
                intVehicleNo = 0;
                strVehicleNo = "External Receive";
                strBearer = "";
                strBearerContact = "";
                monAmount = 0;
                intDispatchBy = 0;
                intReceiveBy = 0;

                ////try
                ////{
                ////    XmlDocument doc = new XmlDocument();
                ////    doc.Load(filePathForXML);
                ////    XmlNode dSftTm = doc.SelectSingleNode("Dispatch");
                ////    xmlString = dSftTm.InnerXml;
                ////    xmlString = "<Dispatch>" + xmlString + "</Dispatch>";
                ////    xml = xmlString;
                ////}
                ////catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Add Item.');", true); return; }
                ////if (xml == "") { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Add Item.');", true); return; }
                xml = "";
                string message = obj.DispatchInsertUpdate(intPart, intDispatchID, intWHID, intDispatchType, strDispatchType, intReceiverEnroll, strReceiver, strAddress, strRemarks, intCreateBy, intApproveBy, intVehicleNo, strVehicleNo, strBearer, strBearerContact, monAmount, intDispatchBy, intReceiveBy, xml);

                txtDept.Text = "";
                txtDesig.Text = "";
                txtJobS.Text = "";
                txtUnit.Text = "";
                txtSearchAssignedTo.Text = "";
                txtRemarksMain.Text = "";
                if (filePathForXML != null)
                { File.Delete(filePathForXML); }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
            }
        }

        #region ===== Selection Change =================================================================
        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0; }

            dt = new DataTable();
            dt = obj.GetEmpInfo(intEnroll);
            if (dt.Rows.Count > 0)
            {
                txtUnit.Text = dt.Rows[0]["strUnit"].ToString();
                txtJobS.Text = dt.Rows[0]["strJobStationName"].ToString();
                txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                txtDesig.Text = dt.Rows[0]["strDesignation"].ToString();
            }
            else
            {
                txtUnit.Text = "";
                txtJobS.Text = "";
                txtDept.Text = "";
                txtDesig.Text = "";
            }

        }
        protected void ddlCertificateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDispatchType.SelectedValue.ToString() == "1")
            {                
                txtSearchAssignedTo.Text = "";
            }
            else
            {                
                txtSearchAssignedTo.Text = "";                
            }
        }
        #endregion =====================================================================================
        #region ===== Search Employee ==================================================================
        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Global_BLL objAutoSearch_BLL = new Global_BLL();
            return objAutoSearch_BLL.AutoSearchEmpList(intUnit.ToString(), prefixText);
        }
        #endregion =====================================================================================














    }
}