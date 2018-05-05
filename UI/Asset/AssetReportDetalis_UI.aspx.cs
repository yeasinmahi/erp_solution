using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Data;
using UI.ClassFiles;
using System.IO;

namespace UI.Asset
{
    public partial class AssetReportDetalis_UI : BasePage
    {
        AssetMaintenance objDetalis = new AssetMaintenance();
        DataTable dt = new DataTable();
        Report_BLL objReport = new Report_BLL();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int Mnumber = int.Parse(Session["intMaintenanceNo"].ToString());
                int intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                int intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                int intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                pnlUpperControl.DataBind();
                
                dt = objDetalis.ReportDetalisParts(58, Mnumber, intenroll, intjobid, intdept);
                dgvPartsView.DataSource=dt;
                dgvPartsView.DataBind();
               
                if (dt.Rows.Count > 0)
                {
                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("monValue"));
                    //dt.Compute("SUM(Salary)", "EmployeeId > 2")); 
                    dgvPartsView.FooterRow.Cells[3].Text = "Ground Total";
                    dgvPartsView.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    dgvPartsView.FooterRow.Cells[4].Text = total.ToString("N2");
                }

                
             
                dt = objDetalis.ReportDetalisPerformer(59, Mnumber, intenroll, intjobid, intdept);
                DgvPerformer.DataSource = dt;
                DgvPerformer.DataBind();

                
                dt = objReport.GetData(5, "", 0, 0, DateTime.Now, DateTime.Now, Mnumber, intenroll);
                dgvService.DataSource = dt;
                dgvService.DataBind();

            }

        }
    }
}