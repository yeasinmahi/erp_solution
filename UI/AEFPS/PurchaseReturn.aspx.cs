using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class PurchaseReturn : Page
    {
        private readonly Receive_BLL _bll = new Receive_BLL();
        private int _intEnroll;
        private DataTable _dt = new DataTable();
        private decimal _totalAmount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }
            
            _intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            LoadWh();
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            string mrrNumber = txtMrrNumber.Text;
            _dt = _bll.GetPurchase(1,Convert.ToInt32(mrrNumber));
            txtSupplierName.Text = _dt.Rows.Count>0 ? _dt.Rows[0]["strSupplierName"].ToString() : "";
            if (!string.IsNullOrWhiteSpace(mrrNumber))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script","showPanel();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('MRR can not be blank');", true);
                return;
            }
            _dt = _bll.GetPurchase(2, Convert.ToInt32(mrrNumber));
            LoadGrid();
            if (_dt.Rows.Count < 1)
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

        public void LoadGrid()
        {
            ViewState["grid"] = _dt;
            gridView.DataSource = _dt;
            gridView.DataBind();
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
                    int returnQuantity = Convert.ToInt32(mrr - returnQty);
                    decimal rate = Convert.ToDecimal(lblRate.Text);
                    decimal returnAmount = rate * returnQuantity;
                    lblReturnAmount.Text = returnAmount.ToString(CultureInfo.CurrentCulture);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Return quantity should be less than MRR quantity and closing stock');", true);
                }
            }
            else
            {
                lblReturnAmount.Text = @"0.00";
            }
            for (int index = 0; index < gridView.Rows.Count; index++)
            {
                _totalAmount += Convert.ToDecimal((gridView.Rows[index].FindControl("lblReturnAmount") as Label)?.Text);
            }

            txtTotalPurchaseReturnAmount.Text = _totalAmount.ToString(CultureInfo.CurrentCulture);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);


        }
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _dt = (DataTable)ViewState["grid"];
            if (_dt.Rows.Count > 0)
            {
                _dt.Rows.RemoveAt(e.RowIndex);
                gridView.DataSource = _dt;
                gridView.DataBind();
                ViewState["grid"] = _dt;
                if(_dt.Rows.Count>0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "hidePanel", "hidePanel();", true);
                }
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {



        }



    }
}