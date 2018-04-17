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
        int intItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Int32 Mnumber = Convert.ToInt32(Session["intMaintenanceNo"].ToString());
                Int32 intenroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                Int32 intdept = int.Parse(Session[SessionParams.DEPT_ID].ToString());
                Int32 intjobid = int.Parse(Session[SessionParams.JOBSTATION_ID].ToString());
                pnlUpperControl.DataBind();
                intItem = 58;
                dt = objDetalis.ReportDetalisParts(intItem, Mnumber, intenroll, intjobid, intdept);
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

                dt = new DataTable();
                intItem = 59;
                dt = objDetalis.ReportDetalisPerformer(intItem, Mnumber, intenroll, intjobid, intdept);
                DgvPerformer.DataSource = dt;
                DgvPerformer.DataBind();

            }

        }
    }
}