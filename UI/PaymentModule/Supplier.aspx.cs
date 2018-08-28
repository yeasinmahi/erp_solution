using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using SCM_BLL;
using System.Data;

namespace UI.PaymentModule
{
    public partial class Supplier : BasePage
    {
        Billing_BLL obj = new Billing_BLL();
        DataTable dt = new DataTable(); string[] arrayKey; char[] delimiterChars = { '[', ']' };
        decimal billAmount = 0, ApproveAmount = 0, totalbill = 0, totalapprove = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { pnlUpperControl.DataBind(); Page.Header.DataBind();
                lblhead.Visible = false;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DateTime fdate = DateTime.Parse(txtdteFrom.Text);
            DateTime tdate = DateTime.Parse(txtdteTo.Text);
            arrayKey = txtSupplier.Text.Split(delimiterChars);
            string item = ""; 
            if (arrayKey.Length > 0)
            { item = arrayKey[0].ToString(); }
            int poNo = 0;
            if (!String.IsNullOrWhiteSpace(txtPoNo.Text))
            {
                int.TryParse(txtPoNo.Text,out poNo);
            }
            dt=obj.GetPartyWiseBillList(fdate, tdate, item, poNo);
            
            if(dt.Rows.Count>0)
            {
                lblhead.Visible = true;
                GVList.DataSource = dt;
                GVList.DataBind();
            }
            else
            {
                lblhead.Visible = false;
                GVList.DataSource = dt;
                GVList.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data Not Found');", true);
            }
            
            
        }

        #region=======================Auto Search=========================

        [WebMethod]
        [ScriptMethod]
        public static string[] GetMasterSupplierSearch(string prefixText)
        {
            return DataTableLoad.objPos.AutoSearchMasterSupplier(prefixText, "Local Purchase");
        }


        #endregion====================Close===============================

        protected void GVList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (DataBinder.Eval(e.Row.DataItem, "monBillAmount").ToString() == string.Empty) { billAmount = 0; }
                else { billAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monBillAmount")); }
                if (DataBinder.Eval(e.Row.DataItem, "monApproveAmount").ToString() == string.Empty) { ApproveAmount = 0; }
                else { ApproveAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "monApproveAmount")); }

                totalbill += billAmount;
                totalapprove += ApproveAmount;
                
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label billLabel = e.Row.FindControl("lblmonBillAmount") as Label;
                Label approveLabel = e.Row.FindControl("lblmonApproveAmount") as Label;
               
                if (billLabel != null)
                {
                    billLabel.Text = totalbill.ToString();
                }
                if (approveLabel != null)
                {
                    approveLabel.Text = totalapprove.ToString();
                }
            }
        }
    }
}