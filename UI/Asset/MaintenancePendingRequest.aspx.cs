using Purchase_BLL.Asset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class MaintenanceServiceRequest : System.Web.UI.Page
    {
        Report_BLL objReport = new Report_BLL();
        DataTable dt = new DataTable(); int intEnroll;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                pnlUpperControl.DataBind();
                intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                
                dt = objReport.GetData(4, "", 0, 0, DateTime.Now, DateTime.Now, 0, intEnroll); //change in loginProcess
                ddlJobStation.DataSource = dt;
                ddlJobStation.DataTextField = "strName";
                ddlJobStation.DataValueField = "Id";
                ddlJobStation.DataBind();
            }            

        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            intEnroll = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
            int jobstation = int.Parse(ddlJobStation.SelectedItem.Value.ToString());
            string strJobStation = ddlJobStation.SelectedItem.Text;
            DateTime fromdate = DateTime.Parse(txtFormDate.Text);
            DateTime toDate = DateTime.Parse(txtToDate.Text);
            lbldate.Text = "From "+ DateTime.Parse(txtFormDate.Text).ToString("yyyy-MM-dd")+ " To "+ DateTime.Parse(txtToDate.Text).ToString("yyyy-MM-dd"); ;
            dt = objReport.GetData(6, "", 4, jobstation, fromdate, toDate, 0, intEnroll);
            GVMaintenanceReport.DataSource = dt;
            GVMaintenanceReport.DataBind();
        }
    }
}