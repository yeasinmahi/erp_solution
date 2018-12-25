using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.AEFPS
{
    public partial class DamageEntry : System.Web.UI.Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();

        int _intEnroll=373605; //------------=========------------------ VULE GELE HOBENA---------------==========------------//

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
        public void LoadGrid(int itemId, int whId)
        {
            dt = _bll.GetActiveItemInfo(itemId, whId);
            DataTable viewStateData = (DataTable)ViewState["grid"];
            if (viewStateData != null && viewStateData.Rows.Count > 0)
            {
                foreach (DataRow dr in viewStateData.Rows)
                {
                    dt.Rows.Add(dr.ItemArray);
                }

            }
            gvDamageEntry.DataSource = dt;
            gvDamageEntry.DataBind();
            ViewState["grid"] = dt;

        }
        [WebMethod]
        public static List<string> GetItem(string prefix)
        {
            return Receive_BLL.GetItem(prefix);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            if (!string.IsNullOrWhiteSpace(itemName))
            {
                string itemNameFull = txtItemName.Text;
                int itemId = Utility.Common.GetIdFromString(itemNameFull);
                int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);

                LoadGrid(itemId, whId);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Item name can not be blank');", true);
                return;
            }
        }

        protected void gvDamageEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt = (DataTable)ViewState["grid"];
            if (dt.Rows.Count > 0)
            {
                dt.Rows.RemoveAt(e.RowIndex);
                gvDamageEntry.DataSource = dt;
                gvDamageEntry.DataBind();
                ViewState["grid"] = dt;
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "hidePanel", "hidePanel();", true);
                }
            }
        }

        protected void txtDamageQty_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            Label rate = (Label)row.FindControl("lblRate");
            Label stocklQty = (Label)row.FindControl("lblStock");
            TextBox DamageQty = (TextBox)row.FindControl("txtDamageQty");
            double Rate, Damage_qty=0,Damage_Amount=0,stock_qty=0;
            if(Damage_qty<=stock_qty)
            {
                Damage_Amount = Convert.ToDouble(rate.Text) * Convert.ToDouble(DamageQty.Text);
            }
            
            Label dmgAmount = (Label)row.FindControl("lblDamageAmount");
            dmgAmount.Text = Damage_Amount.ToString();

        }
    }
}