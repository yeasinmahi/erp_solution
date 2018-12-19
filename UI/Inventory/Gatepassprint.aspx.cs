using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Inventory
{
    public partial class Gatepassprint : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DaysOfWeek bll = new DaysOfWeek(); DataTable dtbl = new DataTable();
                string senderdata = Request.QueryString["ID"];
                hdnstatus.Value = Request.QueryString["STS"];
                dtbl = bll.CreateGetpass(2, int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString()), "", int.Parse(senderdata), DateTime.Now, DateTime.Now);
                if (dtbl.Rows.Count > 0)
                {
                    lbladd.Text = dtbl.Rows[0]["Messages"].ToString();
                    lblpoint.Text = HttpContext.Current.Session[SessionParams.JOBSTATION_NAME].ToString();
                    lblCN.Text = dtbl.Rows[0]["Code"].ToString();
                    lbldt.Text = "Date: " + DateTime.Parse(dtbl.Rows[0]["CDate"].ToString()).ToString("yyyy-MM-dd");
                    lblfadd.Text = dtbl.Rows[0]["FAddress"].ToString();//lblpoint.Text;
                    lbltadd.Text = dtbl.Rows[0]["TAddress"].ToString();
                    dgv.DataSource = dtbl; dgv.DataBind();
                    lblDriverName.Text = dtbl.Rows[0]["driverName"].ToString();
                    lblContact.Text = dtbl.Rows[0]["contact"].ToString();
                    lblVehicleNumber.Text = dtbl.Rows[0]["vehicle"].ToString();
                    issby.Text =dtbl.Rows[0]["Status_"].ToString();
                    appby.Text =dtbl.Rows[0]["Print_"].ToString();
                } 
            }
        }


    }
}