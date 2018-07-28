using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL.Asset;

namespace UI.Asset
{
    public partial class CorrectiveRequestUserPopUP :BasePage
    {
        AssetMaintenance objUserRequest = new AssetMaintenance(); 
        DataTable dt = new DataTable(); 
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Mnumber = int.Parse(Request.QueryString["ID"].ToString());
                //int Mnumber = 159933;
                dt = objUserRequest.CorrectiveUserRequestDetalisView(63, Mnumber, 0, 0, 0);//51 was before
                dgvView.DataSource = dt;
                dgvView.DataBind();
                dt.Clear();
            }

        }
    }
}