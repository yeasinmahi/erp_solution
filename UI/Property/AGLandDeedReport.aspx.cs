using BLL.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Property
{
    public partial class AGLandDeedReport : System.Web.UI.Page
    {
        #region INIT
        PropertyBLL pbll = new PropertyBLL();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownData();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void FillDropDownData()
        {
            DataTable dtUnit = new DataTable();
            DataTable dtMouza = new DataTable();
            DataTable dtPlotType = new DataTable();
            DataTable dtDeedYear = new DataTable();
            try
            {
                dtUnit = pbll.GetAllUnit();
                dtMouza = pbll.GetMouzaForPlot();
                dtPlotType = pbll.GetPlotType();
                dtDeedYear = pbll.GetDeedYear();

                if (dtUnit != null && dtUnit.Rows.Count > 0)
                {
                    ddlUnit.DataSource = dtUnit;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();
                }
                if (dtMouza != null && dtMouza.Rows.Count > 0)
                {
                    ddlMouzaName.DataSource = dtMouza;
                    ddlMouzaName.DataTextField = "MouzaDetail";
                    ddlMouzaName.DataValueField = "intMouzaId";
                    ddlMouzaName.DataBind();
                }
                if (dtPlotType != null && dtPlotType.Rows.Count > 0)
                {
                    ddlPlotType.DataSource = dtPlotType;
                    ddlPlotType.DataTextField = "strPlotType";
                    //ddlPlotType.DataValueField = "intPlotTypeId";
                    ddlPlotType.DataValueField = "strPlotType";
                    ddlPlotType.DataBind();
                }
                if (dtDeedYear != null && dtDeedYear.Rows.Count > 0)
                {
                    ddlDeedYear.DataSource = dtDeedYear;
                    ddlDeedYear.DataTextField = "calcDeadYear";
                    ddlDeedYear.DataValueField = "dYear";
                    ddlDeedYear.DataBind();
                }

                ddlDeedYear.Items.Insert(0, new ListItem("--- Select Year ---", ""));
                ddlUnit.Items.Insert(0, new ListItem("--- Select Unit ---", ""));
                ddlMouzaName.Items.Insert(0, new ListItem("--- Select Mouza ---", ""));
                ddlPlotType.Items.Insert(0, new ListItem("--- Select Plot Type ---", ""));
            }
            catch (Exception ex)
            {
                string msg = "DDL ERROR : " + ex.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + msg + "');", true);
            }
        }

        private void ShowReport()
        {
            string unitId = "0";
            string mouzaId = "0";
            string plotType = "0";
            string deedYear = "0";
            string plotNo = "0";
            string deedNo = "0";

            if (!string.IsNullOrEmpty(ddlUnit.SelectedValue))
                unitId = ddlUnit.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(ddlMouzaName.SelectedValue))
                mouzaId = ddlMouzaName.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(ddlPlotType.SelectedValue))
                plotType = ddlPlotType.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(ddlDeedYear.SelectedValue))
                deedYear = ddlDeedYear.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(txtPlotNo.Text))
                plotNo = txtPlotNo.Text.ToString();
            if (!string.IsNullOrEmpty(txtDeedNo.Text))
                deedNo = txtDeedNo.Text.ToString();

            String url = "https://report.akij.net/ReportServer/Pages/ReportViewer.aspx?/Common_Reports/PlotReport" + "&unitId=" + unitId + "&mouza=" + mouzaId + "&plotType=" + plotType + "&deedYear=" + deedYear + "&plotNo=" + plotNo + "&deedNo=" + deedNo + "&rc:LinkTarget=_self";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', '" + url + "');", true);
        }

        private void ClearAll()
        {
            try
            {
                ddlUnit.Items.Clear();
                ddlMouzaName.Items.Clear();
                ddlPlotType.Items.Clear();
                ddlDeedYear.Items.Clear();
                txtPlotNo.Text = string.Empty;
                txtDeedNo.Text = string.Empty;
                FillDropDownData();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}