using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

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
            dmgAmount.Text = Damage_Amount.ToString(CultureInfo.InvariantCulture);
            //if (ViewState["grid"] != null)
            //{
            //    dt = (DataTable)ViewState["grid"];
            //    dt.Columns.Add(new DataColumn("DamageQuantity", typeof(string)));
            //    dt.Columns.Add(new DataColumn("DamageAmount", typeof(string)));

            //    dt.Rows[dt.Rows.Count]["DamageQuantity"] = Convert.ToDouble(DamageQty.Text);
            //    dt.Rows[dt.Rows.Count]["DamageAmount"] = Damage_Amount;
            //    ViewState["grid"] = dt;
            //}
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            int intWhId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            foreach (GridViewRow row in gvDamageEntry.Rows)
            {
                string remarks = ((TextBox)row.FindControl("txtRemarks")).Text;
                if (!string.IsNullOrWhiteSpace(remarks))
                {
                    int itemId = Convert.ToInt32(((Label)row.FindControl("lblItemID")).Text);
                    int intMrrId = 0;
                    string strRemarks = ((TextBox)row.FindControl("txtRemarks")).Text;
                    double numDamageQuantity = Convert.ToDouble(((TextBox)row.FindControl("txtDamageQty")).Text);
                    double monRate = Convert.ToDouble(((Label)row.FindControl("lblRate")).Text);
                    double monDamageAmount = Convert.ToDouble(((Label)row.FindControl("lblDamageAmount")).Text);
                    string xml = CreateXml(itemId, intWhId, intMrrId, strRemarks, numDamageQuantity, monRate, monDamageAmount,_intEnroll,out string message);
                    if (_bll.DamageItem(xml) != null)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Can not In-Active " + itemId + " ItemId');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Remarks can not be blank');", true);
                    return;
                }
            }

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "ShowHideGridviewPanels();", true);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Successfully In-Activated all items.');", true);
            
            ViewState["grid"] = null;
            gvDamageEntry.DataSource = null;
            gvDamageEntry.DataBind();
        }
        private string CreateXml(int intItemId, int intWhId, int intMrrId, string strRemarks,double numDamageQuantity,double monRate,double monDamageAmount, int intActionBy,out string message)
        {
            dynamic obj = new
            {
                intItemId,
                intWhId,
                intMrrId,
                strRemarks,
                numDamageQuantity,
                monRate,
                monDamageAmount,
                intActionBy

            };
            return XmlParser.GetXml("DamageEntry", "items", obj, out message);

        }
    }
}