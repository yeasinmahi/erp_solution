
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;

namespace UI.AEFPS
{
    public partial class BlockItem : System.Web.UI.Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();
        int _intEnroll=369116;
        DataTable _dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //_intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadWh();
                LoadInActiveGridView();
            }
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            if (!string.IsNullOrWhiteSpace(itemName))
            {
                string itemNameFull = txtItemName.Text;
                int itemId = Utility.Common.GetIdFromString(itemNameFull);
                int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
                
                LoadGrid(itemId,whId);
                txtItemName.Text = string.Empty;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Item name can not be blank');", true);
                return;
            }

        }
        private void LoadWh()
        {
            ddlWh.DataSource = _bll.DataView(1, "", 0, 0, DateTime.Now, _intEnroll);
            ddlWh.DataTextField = "strName";
            ddlWh.DataValueField = "Id";
            ddlWh.DataBind();
        }
        [WebMethod]
        public static List<string> GetItem(string prefix)
        {
            return Receive_BLL.GetItem(prefix);
        }

        protected void activeItemGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _dt = (DataTable)ViewState["grid"];
            if (_dt.Rows.Count > 0)
            {
                _dt.Rows.RemoveAt(e.RowIndex);
                activeItemGridView.DataSource = _dt;
                activeItemGridView.DataBind();
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
        }
        public void LoadGrid(int itemId,int whId)
        {
            _dt = _bll.GetActiveItemInfo(itemId, whId);
            if (_dt.Rows.Count<1)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "alert('This items is not in stock or already inactive.')", true);
                return;
            }
            DataTable viewStateData = (DataTable) ViewState["grid"];
            if (viewStateData !=null && viewStateData.Rows.Count>0)
            {
                foreach (DataRow dr in viewStateData.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
            }
            activeItemGridView.DataSource = _dt;
            activeItemGridView.DataBind();
            ViewState["grid"] = _dt;


        }

        protected void btnInActive_OnClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "javascript:if(confirm('Are you sure you want to delete?') == false) return false;", true);

            int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            foreach (GridViewRow row in activeItemGridView.Rows)
            {
                string remarks = ((TextBox)row.FindControl("txtRemarks")).Text;
                if (!string.IsNullOrWhiteSpace(remarks))
                {
                    int itemId = Convert.ToInt32(((Label)row.FindControl("lblItemid")).Text);
                    if (_bll.InactiveItem(remarks, itemId, whId) == null)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showPanel();", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Can not In-Active "+itemId+" ItemId');", true);
                        return;
                    }
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "show", "showPanel();", true);
                    //btnInActive.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Remarks can not be blank');", true);
                    return;
                }
            }

            //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "ShowHideGridviewPanels();", true);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Successfully In-Activated all items.');", true);
            LoadInActiveGridView();
            ViewState["grid"] = null;
            activeItemGridView.DataSource = null;
            activeItemGridView.DataBind();
        }

        protected void InActiveItemGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            int itemId = Convert.ToInt32(((Label) InActiveItemGridView.Rows[e.RowIndex].FindControl("lblItemid")).Text);
            if (_bll.ActiveItem(itemId, whId)!=null)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Successfully Activated item "+itemId+"');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Startup", "alert('Somethings Error occured.');", true);
            }
            LoadInActiveGridView();
        }

        private void LoadInActiveGridView()
        {
            int whId = Convert.ToInt32(ddlWh.SelectedItem.Value);
            InActiveItemGridView.DataSource = _bll.GetInActiveItemInfo(whId);
            InActiveItemGridView.DataBind();
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
            activeItemGridView.DataSource = null;
            activeItemGridView.DataBind();
            ViewState["grid"] = null;
        }
    }
}