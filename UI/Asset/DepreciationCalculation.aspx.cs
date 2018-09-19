using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Purchase_BLL.Asset;
using System.Xml;
using UI.ClassFiles;
using System.Drawing;
using System.Data;
using System;
using System.IO;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.Asset
{
    public partial class DepreciationCalculation :BasePage
    {

        AssetMaintenance objDepCal = new AssetMaintenance();
        AssetMaintenance rpt = new AssetMaintenance();
        DataTable dt = new DataTable();
        SeriLog log = new SeriLog();
        string location = "Asset";
        string start = "starting Asset\\DepreciationCalculation";
        string stop = "stopping Asset\\DepreciationCalculation";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                dt = new DataTable();
                dt = objDepCal.UnitName();
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "Name";
                ddlUnit.DataValueField = "ID";
                ddlUnit.DataBind();
                pnlUpperControl.DataBind();

            }
        }

        protected void BtnShow_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Asset\\DepreciationCalculation Show", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                DateTime dtestart = DateTime.Parse(TxtDteStart.Text);
                DateTime dtesend = DateTime.Parse(TxtDteEnd.Text);
                int unitid = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = new DataTable();
             
                dt = objDepCal.DepreciationView(9, "", dtestart, dtesend, unitid, 0);
                if(dt.Rows.Count>0)
                {
                    dgvGridView.DataSource = dt;
                    dgvGridView.DataBind();
                }
                else
                {                   
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found');", true);
                    dgvGridView.DataSource = ""; dgvGridView.DataBind();
                }

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();
        }

        #region=============RowData Bound ===========================
        protected void OnDataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "Heads of Accounts";
            cell.ColumnSpan = 3;
            row.Controls.Add(cell);
           

            cell = new TableHeaderCell();
            cell.ColumnSpan = 6;
            cell.Text = "Asset";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.ColumnSpan = 5;
            cell.Text = "Depreciation";
            row.Controls.Add(cell);


            row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            dgvGridView.HeaderRow.Parent.Controls.AddAt(0, row);

            //for (int i = subTotalRowIndex; i < dgvGridView.Rows.Count; i++)
            //{
            //    subTotal += Convert.ToDecimal(dgvGridView.Rows[i].Cells[2].Text);
            //}
            //this.AddTotalRow("Sub Total", subTotal.ToString("N2"));
            //this.AddTotalRow("Total", total.ToString("N2"));
        }

        #endregion==========Close====================================

        protected void BtnSumbit_Click(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvGridView.DataSource = ""; dgvGridView.DataBind();
            }
            catch { }
        }

       
    }
}