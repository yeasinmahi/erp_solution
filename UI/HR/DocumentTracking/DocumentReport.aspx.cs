using HR_BLL.DocumentTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;

namespace UI.HR.DocumentTracking
{
    public partial class DocumentReport : System.Web.UI.Page
    {
        DocumentTrackingBLL obj = new DocumentTrackingBLL(); DataTable dt;
        int intJobStationID;
        int intPart, intID, intDocRegID, intApprovedBy, intRequiredBy, intIssuedBy;
        string strSearch, strRequiredType;
        DateTime dteFromDate, dteRequiredDate, dteToDate, dteReturnDate; bool ysnApproved, ysnReturnable, ysnIssued;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();

            if (!IsPostBack)
            {
                //LoadGrid();
            }
        }
        protected void btnReminder_Click(object sender, EventArgs e)
        {
            //char[] delimiterChars = { '^' };
            //string temp1 = ((Button)sender).CommandArgument.ToString();
            //string temp = temp1.Replace("'", " ");
            //string[] searchKey = temp.Split(delimiterChars);
            //intID = int.Parse(searchKey[0]);
            //intPart = 3;
            //intIssuedBy = int.Parse(hdnEnroll.Value);
            //ysnIssued = true;

            //obj.InsertUpdateRequisition(intPart, intDocRegID, intID, intRequiredBy, ysnReturnable, strRequiredType, dteRequiredDate, ysnApproved, intApprovedBy, ysnIssued, intIssuedBy, dteReturnDate);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Requisition Issued.');", true);

            //LoadGrid();
        }

        protected void btnPendingReport_Click(object sender, EventArgs e)
        {
            intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
            LoadGridPending();
        }
        private void LoadGridPending()
        {
            try
            {
                dgvAllReport.Visible = false;
                dgvDocPending.Visible = true;
                dt = new DataTable();
                dt = obj.GetPendingList(intJobStationID);
                dgvDocPending.DataSource = dt;
                dgvDocPending.DataBind();
            }
            catch { }
        }

        protected void bltAllReport_Click(object sender, EventArgs e)
        {
            intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
            LoadGridAll();
        }
        private void LoadGridAll()
        {
            try
            {
                dgvDocPending.Visible = false;
                dgvAllReport.Visible = true;
                dt = new DataTable();
                dt = obj.GetAllReport(intJobStationID);
                dgvAllReport.DataSource = dt;
                dgvAllReport.DataBind();
            }
            catch { }
        }














    }
}