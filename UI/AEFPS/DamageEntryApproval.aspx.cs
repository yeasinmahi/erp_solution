using SAD_BLL.AEFPS;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class DamageEntryApproval : Page
    {
        private readonly Receive_BLL _bll = new Receive_BLL();

        private int _intEnroll;
        private int _whId;
        private double _totalDamageAmount;
        private DataTable _dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            _intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadWh();
            }
        }
        private void LoadWh()
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
            _whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            _dt = _bll.GetDamageItemList(_whId);
            if (_dt.Rows.Count > 0)
            {
                gvDamageEntryApproval.DataSource = _dt;
                gvDamageEntryApproval.DataBind();

                for (int index = 0; index < _dt.Rows.Count; index++)
                {
                    _totalDamageAmount += Convert.ToDouble((gvDamageEntryApproval.Rows[index].FindControl("lblDamageAmount") as Label)?.Text);
                }

                txtTotalDamageAmount.Text = _totalDamageAmount.ToString(CultureInfo.InvariantCulture);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            }
            else
            {
                gvDamageEntryApproval.DataSource = "";
                gvDamageEntryApproval.DataBind();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "hidePanel();", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('Data Not Found.');", true);
            }
        }
        
        protected void btnReject_Click(object sender, EventArgs e)
        {
            //if (hdnconfirm.Value == "1")
            //{
            //   // try
            //    //{
            //    //    Button btn = (Button)sender;
            //    //    int MRRID, ItemID, WHID;
            //    //    string[] CommandArgument = btn.CommandArgument.Split(',');
            //    //    MRRID =Convert.ToInt32( CommandArgument[0]);
            //    //    ItemID = Convert.ToInt32(CommandArgument[1]);
            //    //    WHID = Convert.ToInt32(CommandArgument[2]);

            //    //    string msg = _bll.UpdateRejectedDamageItemList(ItemID, WHID, MRRID);
            //    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            //    //    LoadGrid();
            //    //}
            //    //catch { }
            //}
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string voucherCode = ((Label)row.FindControl("lblVoucherCode")).Text;

            if (_bll.DamageApprovedReject(2, voucherCode) == null)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something Error in rejection');", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your selected item is successfully rejected');", true);

        }

        protected void btnApprove_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string voucherCode = ((Label)row.FindControl("lblVoucherCode")).Text;

            if (_bll.DamageApprovedReject(1, voucherCode) == null)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Something Error in approved');", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Your selected item is successfully approved');", true);
            //string mac = Utility.Common.GetMacAddress();
            //string ip = Utility.Common.GetIpAddress();
        }

    }
}