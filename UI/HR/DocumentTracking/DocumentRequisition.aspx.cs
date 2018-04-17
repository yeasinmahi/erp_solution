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
    public partial class DocumentRequisition : BasePage
    {
        DocumentTrackingBLL obj = new DocumentTrackingBLL(); DataTable dt;

        int intPart, intID, intDocRegID, intApprovedBy, intRequiredBy; int intIssuedBy;
        string strSearch, strRequiredType;
        DateTime dteFromDate, dteRequiredDate, dteToDate, dteReturnDate; bool ysnApproved, ysnReturnable, ysnIssued;
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            
            if (!IsPostBack)
            {
                chkDate.Checked = false;
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                lblToDate.Visible = false;
                txtToDate.Visible = false;
               
                
            }
            
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            
            intPart = int.Parse(ddlSearchType.SelectedValue.ToString());
            strSearch = txtSearch.Text;

            if (txtFromDate.Text == "")
            {
                dteFromDate = DateTime.Parse("2017-10-01");
            }
            else
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
            }

            if (txtToDate.Text == "")
            {
                dteToDate = DateTime.Parse(DateTime.Now.ToString());
            }
            else
            {
                dteToDate = DateTime.Parse(txtToDate.Text);
            }
            
                try
                {           
                    dt = new DataTable();
                    dt = obj.GetDTSReport(intPart, strSearch, dteFromDate, dteToDate);
                    dgvDocReq.DataSource = dt;
                    dgvDocReq.DataBind();
                }
                catch { }
        }

        protected void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked == true)
            {
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                lblToDate.Visible = true;
                txtToDate.Visible = true;
            }
            else
            {
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                lblToDate.Visible = false;
                txtToDate.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '^' };
            string temp1 = ((Button)sender).CommandArgument.ToString();
            string temp = temp1.Replace("'", " ");
            string[] searchKey = temp.Split(delimiterChars);
            intDocRegID =int.Parse( searchKey[0]);

            intPart = 1;
            intRequiredBy = int.Parse(hdnEnroll.Value);
            if(ddlReturnable.SelectedItem.ToString() == "Yes")
            {
                ysnReturnable = true;
            }
            else
            {
                ysnReturnable = false;
            }
            
            strRequiredType = ddlRequire.SelectedItem.ToString();
            dteRequiredDate = DateTime.Parse(txtReqDate.Text.ToString());

            obj.InsertUpdateRequisition(intPart, intDocRegID, intID, intRequiredBy, ysnReturnable, strRequiredType, dteRequiredDate, ysnApproved, intApprovedBy, ysnIssued, intIssuedBy, dteReturnDate);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Requisition Submitted.');", true);
        }











    }
}