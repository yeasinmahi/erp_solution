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
            ViewState["grid"] = dt;
            gridView.DataSource = dt;
            gridView.DataBind();


            if (dt.Rows.Count < 1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "hidePanel", "hidePanel();", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "dataNotFound", "alert('Data Not Found');", true);
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
           
            Label lblReturnAmount = (Label)row.FindControl("lblReturnAmount");
            if(!string.IsNullOrWhiteSpace(rtnQty.Text))
            {
                decimal returnQty = Convert.ToDecimal(rtnQty.Text);
                if (mrr >= returnQty && costAmount >= returnQty)
                {
                    int ReturnQuantity = Convert.ToInt32(mrr - returnQty);
                    decimal rate = Convert.ToDecimal(lblRate.Text);
                    decimal ReturnAmount = rate * ReturnQuantity;

                    lblReturnAmount.Text = ReturnAmount.ToString();

                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Return quantity should be less than MRR quantity and closing stock');", true);
                }

               
            }
            else
            {

                lblReturnAmount.Text = "0.00";
               
            }
            for (int index = 0; index < gridView.Rows.Count; index++)
            {
                totalAmount += Convert.ToDecimal((gridView.Rows[index].FindControl("lblReturnAmount") as Label).Text);
            }

            txtTotalPurchaseReturnAmount.Text = totalAmount.ToString();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);


        }


        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt = (DataTable)ViewState["grid"];
            if (dt.Rows.Count > 0)
            {
                //dt.Rows[e.RowIndex].Delete();
                dt.Rows.RemoveAt(e.RowIndex);
                gridView.DataSource = dt;
                gridView.DataBind();
                ViewState["grid"] = dt;
                if(dt.Rows.Count>0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "hidePanel", "hidePanel();", true);
                }


            }
          



        }
    }
}