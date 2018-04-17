using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
namespace UI.Transport
{
    public partial class InternalTVehicleMovementReport : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        DateTime dteFDate; DateTime dteTDate; int intShipPointid, intReportType, intWork, intunitid, intID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intunitid = int.Parse(ddlUnit.SelectedValue.ToString());
                    dt = obj.GetShipPointList(intunitid);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();
                }
                catch { }
            }
        }

        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();

            dgvReport2.DataSource = "";
            dgvReport2.DataBind();
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReport.DataSource = "";
            dgvReport.DataBind();

            dgvReport2.DataSource = "";
            dgvReport2.DataBind();

            lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intunitid = int.Parse(ddlUnit.SelectedValue.ToString());
                dt = obj.GetShipPointList(intunitid);
                ddlShipPoint.DataTextField = "strName";
                ddlShipPoint.DataValueField = "intId";
                ddlShipPoint.DataSource = dt;
                ddlShipPoint.DataBind();

                dgvReport.DataSource = "";
                dgvReport.DataBind();

                dgvReport2.DataSource = "";
                dgvReport2.DataBind();

                lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
            }
            catch { }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                dteFDate = DateTime.Parse(txtFromDate.Text);
                HttpContext.Current.Session["dteFDate"] = DateTime.Parse(txtFromDate.Text);
                dteTDate = DateTime.Parse(txtToDate.Text);
                HttpContext.Current.Session["dteTDate"] = DateTime.Parse(txtToDate.Text);
                intShipPointid = int.Parse(ddlShipPoint.SelectedValue.ToString());
                HttpContext.Current.Session["intShipPointid"] = intShipPointid.ToString();
                intReportType = int.Parse(ddlReportType.SelectedValue.ToString());
                lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                if (intReportType == 1)
                {
                    intWork = 1; lblReportName.Text = "Vehicle Movement Report";
                    dt = new DataTable();
                    dt = obj.GetReportData(intWork, dteFDate, dteTDate, intShipPointid, intID);
                    dgvReport2.DataSource = "";
                    dgvReport2.DataBind();
                    dgvReport.DataSource = dt;
                    dgvReport.DataBind();
                }
                else if (intReportType == 2)
                {
                    intWork = 2; lblReportName.Text = "Vehicle Operation Cost Analysis Report";
                    dt = new DataTable();
                    dt = obj.GetReportData(intWork, dteFDate, dteTDate, intShipPointid, intID);
                    dgvReport.DataSource = "";
                    dgvReport.DataBind();
                    dgvReport2.DataSource = dt;
                    dgvReport2.DataBind();
                }
            }
            catch { }
        }

        protected void TripDetails_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TripDetails('" + senderdata + "');", true);            
        }






        }
    }