using SAD_BLL.AEFPS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Utility;

namespace UI.AEFPS
{
    public partial class DamageEntry : Page
    {
        private readonly Receive_BLL _bll = new Receive_BLL();

        private int _intEnroll;

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
        public void LoadGrid(int itemId, int whId)
        {
            _dt = _bll.GetActiveItemInfo(itemId, whId);
            if (_dt.Rows.Count < 1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "alert('This items is not in stock')", true);
                return;
            }
            DataTable viewStateData = (DataTable)ViewState["grid"];
            if (viewStateData != null && viewStateData.Rows.Count > 0)
            {
                foreach (DataRow dr in viewStateData.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }

            }
            gvDamageEntry.DataSource = _dt;
            gvDamageEntry.DataBind();
            ViewState["grid"] = _dt;

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
                int itemId = Common.GetIdFromString(itemNameFull);
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
            _dt = (DataTable)ViewState["grid"];
            if (_dt.Rows.Count <= 0) return;
            _dt.Rows.RemoveAt(e.RowIndex);
            gvDamageEntry.DataSource = _dt;
            gvDamageEntry.DataBind();
            ViewState["grid"] = _dt;
            if (_dt.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "hidePanel", "hidePanel();", true);
            }
        }

        protected void txtDamageQty_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            GridViewRow row = GridViewUtil.GetCurrentGridViewRowOnTextboxChanged(sender);
            double.TryParse((((TextBox) row.FindControl("txtDamageQty")).Text),out double damageQty);
            if (damageQty.Equals(0))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Aleart", "alert('Damage Quantity can not blank or 0')", true);
                return;
            }
            double stockQty = Convert.ToDouble(((Label)row.FindControl("lblStock")).Text);
            if (damageQty <= stockQty)
            {
                double damageAmount =Convert.ToDouble(((Label) row.FindControl("lblRate")).Text) *
                                     damageQty;
                ((Label)row.FindControl("lblDamageAmount")).Text = damageAmount.ToString(CultureInfo.InvariantCulture);
                
            }
            else
            {
                ((TextBox)row.FindControl("txtDamageQty")).Text = string.Empty;
                ((Label)row.FindControl("lblDamageAmount")).Text = string.Empty;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Aleart", "alert('Damage Quantity can not be greater than stock quantity')", true);
            }
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            int intWhId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            foreach (GridViewRow row in gvDamageEntry.Rows)
            {
                string remarks = ((TextBox)row.FindControl("txtRemarks")).Text;
                if (!string.IsNullOrWhiteSpace(remarks))
                {
                    string damageQuantitytxt = ((TextBox) row.FindControl("txtDamageQty")).Text;
                    string damageAmounttxt = ((Label)row.FindControl("lblDamageAmount")).Text;
                    if (!string.IsNullOrWhiteSpace(damageQuantitytxt) && !string.IsNullOrWhiteSpace(damageAmounttxt))
                    {
                        try
                        {
                            double numDamageQuantity = Convert.ToDouble(damageQuantitytxt);
                            double monDamageAmount = Convert.ToDouble(damageAmounttxt);

                            double monRate = Convert.ToDouble(((Label)row.FindControl("lblRate")).Text);
                            int itemId = Convert.ToInt32(((Label)row.FindControl("lblItemID")).Text);
                            string strRemarks = ((TextBox)row.FindControl("txtRemarks")).Text;

                            string xml = GetXml(itemId, intWhId, strRemarks, numDamageQuantity, monRate, monDamageAmount,
                                _intEnroll, out string message);
                            if (_bll.DamageItem(xml) == null)
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup",
                                    "alert('Can not entry as damage " + itemId + " ItemId');", true);
                                return;
                            }
                        }
                        catch (Exception exception)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Something Error Occured');", true);
                            return;
                        }
                        
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Damage Quantity and amount can not be blank');", true);
                        return;
                    }
                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Remarks can not be blank');", true);
                    return;
                }
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Successfully entry damage items.');", true);
            
            ViewState["grid"] = null;
            gvDamageEntry.DataSource = null;
            gvDamageEntry.DataBind();
        }
        private string GetXml(int intItemId, int intWhId, string strRemarks,double numDamageQuantity,double monRate,double monDamageAmount, int intActionBy,out string message)
        {
            dynamic obj = new
            {
                intItemId,
                intWhId,
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