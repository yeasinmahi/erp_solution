using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.AEFPS
{
    public partial class DamageEntryApproval : System.Web.UI.Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();

        int _intEnroll = 373605; //------------=========------------------ VULE GELE HOBENA---------------==========------------//
        int WHId;
        double totalDamageAmount = 0;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //_intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
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
            WHId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            dt = _bll.GetDamageItemList(WHId);
            if (dt.Rows.Count > 0)
            {
                gvDamageEntryApproval.DataSource = dt;
                gvDamageEntryApproval.DataBind();

                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    totalDamageAmount += Convert.ToDouble((gvDamageEntryApproval.Rows[index].FindControl("lblDamageAmount") as Label)?.Text);
                }

                txtTotalDamageAmount.Text = totalDamageAmount.ToString();
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
            if (hdnconfirm.Value == "1")
            {
               // try
                //{
                //    Button btn = (Button)sender;
                //    int MRRID, ItemID, WHID;
                //    string[] CommandArgument = btn.CommandArgument.Split(',');
                //    MRRID =Convert.ToInt32( CommandArgument[0]);
                //    ItemID = Convert.ToInt32(CommandArgument[1]);
                //    WHID = Convert.ToInt32(CommandArgument[2]);

                //    string msg = _bll.UpdateRejectedDamageItemList(ItemID, WHID, MRRID);
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
                //    LoadGrid();
                //}
                //catch { }
            }
        }
    }
}