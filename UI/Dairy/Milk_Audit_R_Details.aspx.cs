using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using HR_BLL.Employee;
using System.Text.RegularExpressions;
using System.Data;
using HR_BLL.Loan;
using HR_BLL.Global;
using UI.ClassFiles;
using Projects_BLL;
using System.IO;
using System.Xml;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Dairy
{
    public partial class Milk_Audit_R_Details : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Dairy";
        string start = "starting Dairy/Milk_Audit_R_Details.aspx";
        string stop = "stopping Dairy/Milk_Audit_R_Details.aspx";

        Project_Class obj = new Project_Class();
        DataTable dt;

        int intMRRID;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Audit_R_Details.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);


            if (!IsPostBack)
            {
                intMRRID = int.Parse(Request.QueryString["intID"]);
                LoadGrid();
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Dairy/Milk_Audit_R_Details.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {                
                dt = new DataTable();
                dt = obj.GetMRRDetailsForAudit(intMRRID);
                dgvAuditAppDetails.DataSource = dt;
                dgvAuditAppDetails.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        protected decimal totalmrrqty = 0;
        protected decimal totaldedqtyamou = 0;
        protected decimal totaldedfatamou = 0;
        protected decimal totalmrramou = 0;
        protected decimal totalbonusamou = 0;
        protected decimal totalpayableamou = 0;
        protected decimal totalchallanqty = 0;
        protected decimal totalchallanamou = 0;
        protected void dgvAuditAppDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalmrrqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblMRRQty")).Text);
                    totaldedqtyamou += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblDeductQtyAmount")).Text);
                    totaldedfatamou += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblDeductFatPer")).Text);
                    totalmrramou += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblAmount")).Text);
                    totalbonusamou += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblBonusAmount")).Text);
                    totalpayableamou += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblPayableAmount")).Text);
                    totalchallanqty += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblChallanQty")).Text);
                    totalchallanamou += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblChallanAmount")).Text);

                }
            }
            catch { }
        }
















































    }
}