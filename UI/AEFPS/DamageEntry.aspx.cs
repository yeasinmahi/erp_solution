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
    public partial class DamageEntry : System.Web.UI.Page
    {
        readonly Receive_BLL _bll = new Receive_BLL();

        int _intEnroll=373605; // VULE GELE HOBENA

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
        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}