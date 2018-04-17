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
    public partial class DocumentApproval : BasePage
    {
        DocumentTrackingBLL obj = new DocumentTrackingBLL(); DataTable dt;

        int intPart, intID, intDocRegID, intApprovedBy, intRequiredBy, intIssuedBy;
        string strSearch, strRequiredType;
        DateTime dteFromDate, dteRequiredDate, dteToDate, dteReturnDate; bool ysnApproved, ysnReturnable, ysnIssued;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            intApprovedBy = int.Parse(hdnEnroll.Value);
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            try
            {
                intPart = 1;
                dt = new DataTable();
                dt = obj.GetDTSReport(intPart, intApprovedBy);
                dgvDocApproval.DataSource = dt;
                dgvDocApproval.DataBind();
            }
            catch { }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            intID = int.Parse(searchKey[0]);
            intPart = 2;
            ysnApproved = true;
            
            obj.InsertUpdateRequisition(intPart, intDocRegID, intID, intRequiredBy, ysnReturnable, strRequiredType, dteRequiredDate, ysnApproved, intApprovedBy, ysnIssued, intIssuedBy, dteReturnDate);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Requisition Apporoved.');", true);

            LoadGrid();
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            intID = int.Parse(searchKey[0]);
            intPart = 2;
            intApprovedBy = int.Parse(hdnEnroll.Value);
            ysnApproved = false;

            obj.InsertUpdateRequisition(intPart, intDocRegID, intID, intRequiredBy, ysnReturnable, strRequiredType, dteRequiredDate, ysnApproved, intApprovedBy, ysnIssued, intIssuedBy, dteReturnDate);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Requisition Apporoved.');", true);

            LoadGrid();
        }




    }
}