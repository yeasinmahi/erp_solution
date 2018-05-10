using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Purchase_BLL.Asset;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Asset
{
    public partial class MaintenanceReport : BasePage
    {
        Report_BLL objReport = new Report_BLL();
        DataTable dt = new DataTable();int intEnroll;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                intEnroll= int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objReport.GetData(4, "", 0, 0, DateTime.Now, DateTime.Now, 0, intEnroll);
                ddlJobStation.DataSource = dt;
                ddlJobStation.DataTextField = "strName";
                ddlJobStation.DataValueField = "Id";
                ddlJobStation.DataBind();
            }
        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromdate = DateTime.Parse(txtDteFrom.Text);
                DateTime todate = DateTime.Parse(TxtdteTo.Text);
                int intJobId = int.Parse(ddlJobStation.SelectedValue);
                int type = int.Parse(ddlType.SelectedValue);
                DateTime dteFrom = DateTime.Parse(txtDteFrom.Text.ToString());
                DateTime dteTo = DateTime.Parse(TxtdteTo.Text.ToString());

                if(type==1) //Top Sheet
                {
                    dgview.Visible = true;
                    dt = objReport.GetData(1, "", 0, intJobId, dteFrom, dteTo, type, intEnroll);
                    dgview.DataSource = dt;
                    dgview.DataBind();
                    dgvMaterial.Visible = false;
                    dgvServiceCost.Visible = false;
                }
                else if (type == 2)//Material
                {
                    dgvMaterial.Visible = true;
                    dt = objReport.GetData(2, "", 0, intJobId, dteFrom, dteTo, type, intEnroll);
                    dgvMaterial.DataSource = dt;
                    dgvMaterial.DataBind();
                    dgview.Visible = false;
                    dgvServiceCost.Visible = false;
                }
                else //service Cost
                {
                    dgvServiceCost.Visible = true;
                    dt = objReport.GetData(3, "", 0, intJobId, dteFrom, dteTo, type, intEnroll);
                    dgvServiceCost.DataSource = dt;
                    dgvServiceCost.DataBind();
                    dgvMaterial.Visible = false;
                    dgview.Visible = false;
                }
               
            }
            catch { }
        }
        protected void BtnMDetalis_Click(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);  
                Session["intMaintenanceNo"] = searchKey[0].ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ReportDetalis('AssetReportDetalis_UI.aspx');", true);

            }
            catch { }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgview.DataSource = "";
                dgview.DataBind();
                dgvMaterial.DataSource = "";
                dgvMaterial.DataBind();
                dgvServiceCost.DataSource = "";
                dgvServiceCost.DataBind();
            }
            catch { }
        }
    }
}