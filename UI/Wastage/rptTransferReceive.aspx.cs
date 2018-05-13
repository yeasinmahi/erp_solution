using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;

namespace UI.Wastage
{
    public partial class rptTransferReceive : BasePage
    {

        #region ===== Variable Decliaration ===================================================================
        WastageBLL obj = new WastageBLL();
        DataTable dt;
        int  intwork;
        int?  intTransferJobStationID = null;
           
        #endregion ============================================================================================

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();
                    WHlist();
                  
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
       
        private void WHlist()
        {
            dt = obj.getWHbyUnit(int.Parse(Session[SessionParams.UNIT_ID].ToString()));
            ddlWHName.DataTextField = "strWastageWareHouseName";
            ddlWHName.DataValueField = "intWastageWareHouseID";
            ddlWHName.DataSource = dt;
            ddlWHName.DataBind();
          
        }  
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
                intwork = 2;
                dt = obj.getReportForTransfer(intwork, txtSODate.Text, txtToDate.Text, int.Parse(Session[SessionParams.UNIT_ID].ToString()), int.Parse(ddlWHName.SelectedValue), intTransferJobStationID);
                dgvReportDetails.DataSource = dt;
                dgvReportDetails.DataBind();
                lblHeder.Text = "Transfer Details Report From " + DateTime.Parse(txtSODate.Text).ToString("dd/MM/yyyy") + " To " + DateTime.Parse(txtToDate.Text).ToString("dd/MM/yyyy");
            

        }
        protected decimal stotalQty = 0;
        protected decimal totalvalue = 0;
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    stotalQty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblQty")).Text);
                    totalvalue += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblValue")).Text);
                }
            }
            catch { }
        }

        protected void btnReceive_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            string strSearchKey = senderdata;
            string[] searchKey = Regex.Split(strSearchKey, ",");
            int   id = int.Parse(searchKey[0].ToString());
            int  intEntryid = int.Parse(Session[SessionParams.USER_ID].ToString());


        }
    }
}