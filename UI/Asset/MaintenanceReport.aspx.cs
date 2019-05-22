using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Purchase_BLL.Asset;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Flogging.Core;
using System.Globalization;

namespace UI.Asset
{
    public partial class MaintenanceReport : BasePage
    {
        Report_BLL objReport = new Report_BLL();
        DataTable dt = new DataTable();int intEnroll;
        protected void Page_Load(object sender, EventArgs e)
        {
			var fd = GetFlogDetail("starting Asset\\MaintenanceReport Page_Load", null);

			Flogger.WriteDiagnostic(fd);

			// starting performance tracker
			var tracker = new PerfTracker("Asset\\MaintenanceReport Page_Load", "", fd.UserName, fd.Location,
				fd.Product, fd.Layer);
			//

			if (!IsPostBack)
            {
                intEnroll= int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objReport.GetData(4, "", 0, 0, DateTime.Now, DateTime.Now, 0, intEnroll);
                ddlJobStation.DataSource = dt;
                ddlJobStation.DataTextField = "strName";
                ddlJobStation.DataValueField = "Id";
                ddlJobStation.DataBind();
            }

			fd = GetFlogDetail("stopping Asset\\MaintenanceReport Page_Load", null);
			Flogger.WriteDiagnostic(fd);
			// ends
			tracker.Stop();

			//int a = 30;
		}

        protected void BtnShow_Click(object sender, EventArgs e)
        {
			var fd = GetFlogDetail("starting SCM\\BillForwardToBillingRpt Show", null);

			Flogger.WriteDiagnostic(fd);

			// starting performance tracker
			var tracker = new PerfTracker("Asset\\MaintenanceReport Show", "", fd.UserName, fd.Location,
				fd.Product, fd.Layer);

			try
            {
               

                string fromdate =txtDteFrom.Text.ToString();
                string todate = TxtdteTo.Text.ToString();
                int intJobId = int.Parse(ddlJobStation.SelectedValue);
                int type = int.Parse(ddlType.SelectedValue);
              
                string xml = "<voucher><voucherentry dteFrom=" + '"' + fromdate + '"' + " dteTo=" + '"' + todate + '"' + "/></voucher>".ToString();
                if (type==1) //Top Sheet
                {
                    dgview.Visible = true;
                    dt = objReport.GetData(1, xml, 0, intJobId, DateTime.Now, DateTime.Now, type, intEnroll);
                    dgview.DataSource = dt;
                    dgview.DataBind();
                    dgvMaterial.Visible = false;
                    dgvServiceCost.Visible = false;

                    decimal MaterialT = dt.AsEnumerable().Sum(row => row.Field<decimal>("monMaterial"));
                    decimal ServiceT = dt.AsEnumerable().Sum(row => row.Field<decimal>("monService"));
                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("monTotal"));
                  
                    dgview.FooterRow.Cells[9].Text = "Ground Total";
                    dgview.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                    dgview.FooterRow.Cells[10].Text = MaterialT.ToString("N2");
                    dgview.FooterRow.Cells[11].Text = ServiceT.ToString("N2");
                    dgview.FooterRow.Cells[12].Text = total.ToString("N2");
                }
                else if (type == 2)//Material
                {
                    dgvMaterial.Visible = true;
                    dt = objReport.GetData(2, "", 0, intJobId, DateTime.Parse(fromdate.ToString()), DateTime.Parse(todate), type, intEnroll);
                    dgvMaterial.DataSource = dt;
                    dgvMaterial.DataBind();
                    dgview.Visible = false;
                    dgvServiceCost.Visible = false;
                }
                else //service Cost
                {
                    dgvServiceCost.Visible = true;
                    dt = objReport.GetData(3, "", 0, intJobId, DateTime.Parse(fromdate.ToString()), DateTime.Parse(todate), type, intEnroll);
                    dgvServiceCost.DataSource = dt;
                    dgvServiceCost.DataBind();
                    dgvMaterial.Visible = false;
                    dgview.Visible = false;
                }
               
            }
			catch (Exception ex)
			{
				var efd = GetFlogDetail("", ex);
				Flogger.WriteError(efd);
			}

			fd = GetFlogDetail("stopping Asset\\MaintenanceReport Show", null);
			Flogger.WriteDiagnostic(fd);
			// ends
			tracker.Stop();

			int a = 30;

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
			catch (Exception ex)
			{
				var efd = GetFlogDetail("", ex);
				Flogger.WriteError(efd);
			}
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
            catch(Exception ex)
			{
				var efd = GetFlogDetail("", ex);
				Flogger.WriteError(efd);
			}
        }

		private FlogDetail GetFlogDetail(string message, Exception ex)
		{
			return new FlogDetail
			{
				Product = "ERP",
				Location = "Asset",
				Layer = "MaintainenanceReport\\Show",
				UserName = Environment.UserName,
				Hostname = Environment.MachineName,
				Message = message,
				Exception = ex
			};
		}

        protected void lblJobCardTwo_Click(object sender, EventArgs e)
        {
            string jobcard="";
            try
            {
                GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                jobcard = (row.FindControl("lblJobCardTwo") as LinkButton).Text;

            }
            catch (Exception ex) { ex.Message.ToString(); }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "window.open('https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Asset_Module/Estimation_Report_Job_Card_Report" + "&intJobCard=" + jobcard + "&rc:LinkTarget=_self','details','left=220,top=160,width=950,height=480,addressbar=no,status=no,menubar=no,toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes');", true); 
        }

        protected void lblJobCardOne_Click(object sender, EventArgs e)
        {
            string jobcard = "";
            try
            {
                GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                jobcard = (row.FindControl("lblJobCardOne") as LinkButton).Text;

            }
            catch (Exception ex) { ex.Message.ToString(); }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "window.open('https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Asset_Module/Estimation_Report_Job_Card_Report" + "&intJobCard=" + jobcard + "&rc:LinkTarget=_self','details','left=220,top=160,width=950,height=480,addressbar=no,status=no,menubar=no,toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes');", true);

        }

        protected void lblJobCardThree_Click(object sender, EventArgs e)
        {
            string jobcard = "";
            try
            {
                GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
                jobcard = (row.FindControl("lblJobCardThree") as LinkButton).Text;
                
            }
            catch (Exception ex) { ex.Message.ToString(); }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "window.open('https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Asset_Module/Estimation_Report_Job_Card_Report" + "&intJobCard=" + jobcard + "&rc:LinkTarget=_self','details','left=220,top=160,width=950,height=480,addressbar=no,status=no,menubar=no,toolbar=no,location=no,directories=no,status=no,scrollbars=no,resizable=yes');", true);

        }

       
    }
}