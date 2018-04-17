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
using HR_BLL.Settlement;

namespace UI.Support
{
    public partial class CertificateReceive : System.Web.UI.Page
    {
        Support_BLL.SupportBLL obj = new Support_BLL.SupportBLL();
        DataTable dt;

        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;

        string Unitid, strCerfificate, strCertificateSerialNo, strRegNo, strRollNo;
        int intEnroll, intCertificateType, intInsertBy;
        DateTime dteReceivedDate, dteDeliveryDate;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

            if (!IsPostBack)
            {
                Unitid = Session[SessionParams.UNIT_ID].ToString();
                HttpContext.Current.Session["Unitid"] = Session[SessionParams.UNIT_ID].ToString();

                LoadGrid();
            }

        }

        private void LoadGrid()
        {
            try
            {
                dt = new DataTable();
                dt = obj.GetReceiveReport();
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch { }
        }

        [WebMethod]
        [ScriptMethod]
        public static string[] GetSearchAssignedTo(string prefixText, int count)
        {
            Int32 intUnit = Convert.ToInt32(HttpContext.Current.Session["Unitid"].ToString());
            Support_BLL.SupportBLL objAutoSearch_BLL = new Support_BLL.SupportBLL();
            return objAutoSearch_BLL.AutoSearchEmpListForCertificate(intUnit.ToString(), prefixText);
        }

        protected void txtSearchAssignedTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] ch1 = { '[', ']' };
                string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                intEnroll = int.Parse(temp1[1].ToString());
            }
            catch { intEnroll = 0; }

            Clear();

            try
            {                
                dt = new DataTable();
                dt = obj.GetEmpInfo(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    txtSupervisorName.Text = dt.Rows[0]["strSuperviserName"].ToString();
                    txtSupervisorDesignation.Text = dt.Rows[0]["strSuperviserDesignation"].ToString();
                    txtEmpCode.Text = dt.Rows[0]["strEmployeeCode"].ToString();
                    txtEmpEnroll.Text = dt.Rows[0]["intEmployeeID"].ToString();
                    txtName.Text = dt.Rows[0]["strEmployeeName"].ToString();
                    txtDesignation.Text = dt.Rows[0]["strDesignation"].ToString();
                    txtDept.Text = dt.Rows[0]["strDepatrment"].ToString();
                    txtBasic.Text = Math.Round(decimal.Parse(dt.Rows[0]["monBasic"].ToString()), 0).ToString();
                    txtGross.Text = Math.Round(decimal.Parse(dt.Rows[0]["monSalary"].ToString()), 0).ToString();
                    txtJoiningDate.Text = dt.Rows[0]["dteJoiningDate"].ToString();
                    txtPhoneNo.Text = dt.Rows[0]["strContactNo1"].ToString();
                    txtJobStation.Text = dt.Rows[0]["strJobStationName"].ToString();
                }

                dt = new DataTable();
                dt = obj.GetReceiveInfo(intEnroll);
                if (dt.Rows.Count > 0)
                {
                    ddlCertificateType.SelectedValue = dt.Rows[0]["intCertificateType"].ToString();
                    txtCertificateSerial.Text = dt.Rows[0]["strCertificateSerialNo"].ToString();
                    txtRegNo.Text = dt.Rows[0]["strRegNo"].ToString();
                    txtRollNo.Text = dt.Rows[0]["strRollNo"].ToString();
                    txtRecDate.Text = dt.Rows[0]["dteReceivedDate"].ToString();
                    txtDeliveryDate.Text = dt.Rows[0]["dteDeliveryDate"].ToString();
                }
            }
            catch {  }
            
        }

        private void Clear()
        {
            txtSupervisorName.Text = "";
            txtSupervisorDesignation.Text = "";
            txtEmpCode.Text = "";
            txtEmpEnroll.Text = "";
            txtName.Text = "";
            txtDesignation.Text = "";
            txtDept.Text = "";
            txtBasic.Text = "";
            txtGross.Text = "";
            txtJoiningDate.Text = "";
            txtPhoneNo.Text = "";
            txtJobStation.Text = "";

            ddlCertificateType.SelectedValue = "1";
            txtCertificateSerial.Text = "";
            txtRegNo.Text = "";
            txtRollNo.Text = "";
            txtRecDate.Text = "";
            txtDeliveryDate.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    char[] ch1 = { '[', ']' };
                    string[] temp1 = txtSearchAssignedTo.Text.Split(ch1, StringSplitOptions.RemoveEmptyEntries);
                    intEnroll = int.Parse(temp1[1].ToString());
                }
                catch { intEnroll = 0; }

                if (intEnroll != 0)
                {
                    intCertificateType = int.Parse(ddlCertificateType.SelectedValue.ToString());
                    strCerfificate = ddlCertificateType.SelectedItem.ToString();
                    strCertificateSerialNo = txtCertificateSerial.Text;
                    strRegNo = txtRegNo.Text;
                    strRollNo = txtRollNo.Text;
                    try { dteReceivedDate = DateTime.Parse(txtRecDate.Text); }
                    catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Input Certificate Receive Date.');", true); return; }
                    try { dteDeliveryDate = DateTime.Parse(txtDeliveryDate.Text); }
                    catch { dteDeliveryDate = DateTime.Parse("1900-01-01".ToString()); }
                    intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                    string message = obj.InsertUpdateCertificateInfo(intEnroll, intCertificateType, strCerfificate, strCertificateSerialNo, strRegNo, strRollNo, dteReceivedDate, dteDeliveryDate, intInsertBy);
                    Clear();
                    txtSearchAssignedTo.Text = "";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                    LoadGrid();
                }
                else if(intEnroll == 0)
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Employee.');", true); return; }
            }

        }






    }
}