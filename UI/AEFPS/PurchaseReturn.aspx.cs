using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class PurchaseReturn : Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();
        int _intEnroll;
        DataTable dt = new DataTable();
        decimal totalAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            _intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            LoadWh();
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            string mrrNumber = txtMrrNumber.Text;
            dt = _bll.GetPurchase(1,Convert.ToInt32(mrrNumber));
            if(dt.Rows.Count>0)
            {
                txtSupplierName.Text = dt.Rows[0]["strSupplierName"].ToString();
            }
            else
            {
                txtSupplierName.Text = "";
            }
            
            if (!string.IsNullOrWhiteSpace(mrrNumber))
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('MRR can not be blank');", true);
            }
            dt = _bll.GetPurchase(2, Convert.ToInt32(mrrNumber));
            if (dt.Rows.Count > 0)
            {
                gridView.DataSource = dt;
                gridView.DataBind();
            }
            else
            {
                gridView.DataSource = "";
                gridView.DataBind();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Data Not Found');", true);
            }

        }
        private void LoadWh()
        {

            ddlWh.DataSource = _bll.DataView(1, "", 0, 0, DateTime.Now, _intEnroll);
            ddlWh.DataTextField = "strName";
            ddlWh.DataValueField = "Id";
            ddlWh.DataBind();
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
           
           
           
        }

        protected void txtReturnQty_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            Label lblMrrQty = (Label)row.FindControl("lblMrrQty");
            Label lblRate = (Label)row.FindControl("lblRate");
            TextBox rtnQty = (TextBox)row.FindControl("txtReturnQty"); 
            Label lblCostAmount = (Label)row.FindControl("lblCostAmount");
            decimal costAmount = Convert.ToDecimal(lblCostAmount.Text);
            decimal mrr = Convert.ToDecimal(lblMrrQty.Text);
            decimal returnQty = Convert.ToDecimal(rtnQty.Text);
            
            if(mrr>=returnQty && costAmount>=returnQty)
            {
                int ReturnQuantity = Convert.ToInt32(mrr - returnQty);
                decimal rate = Convert.ToDecimal(lblRate.Text);
                decimal ReturnAmount = rate * ReturnQuantity;
                Label lblReturnAmount = (Label)row.FindControl("lblReturnAmount");
                lblReturnAmount.Text = ReturnAmount.ToString();
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Return quantity should be less than MRR quantity and closing stock');", true);
            }
            

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);


        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    totalAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "lblReturnAmount"));
            //}
            //txtTotalPurchaseReturnAmount.Text = totalAmount.ToString();

        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}