using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using SAD_BLL.AEFPS;

namespace UI.AEFPS
{
    public partial class BlockItem : System.Web.UI.Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();
        int _intEnroll=369116;
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

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            if (!string.IsNullOrWhiteSpace(itemName))
            {
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
    }
}