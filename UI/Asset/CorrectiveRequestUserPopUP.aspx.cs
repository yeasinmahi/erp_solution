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
    public partial class CorrectiveRequestUserPopUP : System.Web.UI.Page
    {
        AssetMaintenance objUserRequest = new AssetMaintenance();
        DataTable depertmnet = new DataTable();
        DataTable dt = new DataTable();
        DataTable asset = new DataTable();
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 Mnumber = Int32.Parse(Request.QueryString["ID"].ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                //Int32 Mnumber = int.Parse("0".ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                intItem = 51;
                dt = objUserRequest.CorrectiveUserRequestDetalisView(intItem, Mnumber, intenroll, intjobid, intdept);
                dgvView.DataSource = dt;
                dgvView.DataBind();
            }

        }
    }
}