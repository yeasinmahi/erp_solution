using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class PurchaseReturnApproval : BasePage
    {
        private readonly Receive_BLL _bll = new Receive_BLL();
        private int _intEnroll = 0,intWHID;
        private DataTable _dt = new DataTable();
        private decimal _totalAmount;
        string message = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
            }

            _intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            LoadWh(_intEnroll);
        }
        private void LoadWh(int _intEnroll)
        {
            ddlWh.DataSource = _bll.DataView(1, "", 0, 0, DateTime.Now, _intEnroll);
            ddlWh.DataTextField = "strName";
            ddlWh.DataValueField = "Id";
            ddlWh.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            intWHID = Convert.ToInt32(ddlWh.SelectedItem.Value);
            _dt=_bll.GetPurchase(3, string.Empty, intWHID, 0, out message);
            if(_dt.Rows.Count>0)
            {
                gvDamageEntryApproval.DataSource = _dt;
                gvDamageEntryApproval.DataBind();
            }
            else
            {
                gvDamageEntryApproval.DataSource = null;
                gvDamageEntryApproval.DataBind();
            }
           
        }

        protected void btnApprove_OnClick(object sender, EventArgs e)
        {           
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string voucherCode = ((Label)row.FindControl("lblReturnNo")).Text;
            if (_bll.ApproveRejectPurchaseReturn(1, voucherCode) == null)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something Error in approved');", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your selected item is successfully approved');", true);
        }

        protected void btnReject_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string voucherCode = ((Label)row.FindControl("lblReturnNo")).Text;

            if (_bll.ApproveRejectPurchaseReturn(2, voucherCode) == null)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something Error in rejection');", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your selected item is successfully rejected');", true);

        }
    }
}