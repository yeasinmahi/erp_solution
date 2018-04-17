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
    public partial class InternalTPaymentHisory : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;
        int intWork; DateTime dteFDate; DateTime dteTDate; int intShipPoint; int intUnitID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    ////pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    try
                    {
                        dt = obj.GetVehicleSupplierList(intUnitID);
                        ddlVehicleSupplier.DataTextField = "strName";
                        ddlVehicleSupplier.DataValueField = "intCOAid";
                        ddlVehicleSupplier.DataSource = dt;
                        ddlVehicleSupplier.DataBind();

                        lblVehicleSupplier.Visible = false; ddlVehicleSupplier.Visible = false;
                    }
                    catch { }

                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();
                }
                catch
                { }
            }
        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1500);
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                intWork = 1;
                dteFDate = DateTime.Parse(txtFromDate.Text);
                dteTDate = DateTime.Parse(txtToDate.Text);
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());

                if (ddlReportType.SelectedValue.ToString() == "1")
                {
                    lblUnitN.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Payment Hisory";
                    lblFromTo.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dt = new DataTable();
                    dt = obj.GetInternalTAuditAnalysisReport(intWork, intShipPoint, dteFDate, dteTDate);

                    dgvPaymentHisory.DataSource = "";
                    dgvPaymentHisory.DataBind();

                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        dgvPaymentHisory.DataSource = dt;
                        dgvPaymentHisory.DataBind();

                        lblUnitN.Visible = true;
                        lblReportName.Visible = true;
                        lblFromTo.Visible = true;
                    }
                    else
                    {
                        lblUnitN.Visible = false;
                        lblReportName.Visible = false;
                        lblFromTo.Visible = false;

                        dgvPaymentHisory.DataSource = "";
                        dgvPaymentHisory.DataBind();
                    }
                }
                else if (ddlReportType.SelectedValue.ToString() == "2")
                {
                    Label20.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label21.Text = ddlVehicleSupplier.SelectedItem.ToString();
                    Label22.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvPaymentHisory.DataSource = "";
                    dgvPaymentHisory.DataBind();
                    
                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    int intReportCategory = 0;
                    int intBillStatus = 0;
                    int intEnroll = 0;
                    int intFuelStationid = int.Parse(ddlVehicleSupplier.SelectedValue.ToString());
                    intWork = 26;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFDate, dteTDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvVendorsTReport.DataSource = dt;
                    dgvVendorsTReport.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
                    }
                    else
                    {
                        dgvVendorsTReport.DataSource = "";
                        dgvVendorsTReport.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
            }
            catch { }
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPaymentHisory.DataSource = "";
            dgvPaymentHisory.DataBind();

            dgvVendorsTReport.DataSource = "";
            dgvVendorsTReport.DataBind();

            if (ddlReportType.SelectedValue.ToString() == "2")
            {
                lblVehicleSupplier.Visible = true; ddlVehicleSupplier.Visible = true;
            }
            else
            {
                lblVehicleSupplier.Visible = false; ddlVehicleSupplier.Visible = false;
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected void ddlVehicleSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label21.Text = ddlVehicleSupplier.SelectedItem.ToString();

            dgvPaymentHisory.DataSource = "";
            dgvPaymentHisory.DataBind();

            dgvVendorsTReport.DataSource = "";
            dgvVendorsTReport.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected decimal totalqty = 0;
        protected decimal totaltfvt = 0;
        protected decimal totalspf = 0;
        protected decimal totaladf = 0;
        protected decimal totalcmd = 0;
        protected decimal totalpd = 0;
        protected decimal totalntp = 0;
        protected void dgvVendorsTReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalqty += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblQuantity")).Text);
                    totaltfvt += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblTripFareVT")).Text);
                    totalspf += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblSpecialFare")).Text);
                    totaladf += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblAdditionalFare")).Text);
                    totalcmd += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblCompanyDem")).Text);
                    totalpd += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblPartyDem")).Text);
                    totalntp += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblNetPayable10")).Text);
                }

            }
            catch { }
        }

        protected decimal totalmillage1 = 0;
        protected decimal totalfuelcost = 0;
        protected decimal totaladministrativecost = 0;
        protected decimal totaldriverexp = 0;
        protected decimal totaltotalRouteexp1 = 0;
        protected decimal totaltotaltripfare1 = 0;
        protected decimal totalnetincome1 = 0;
        protected decimal totalTotalDTFareCash = 0;        
        protected decimal totalTotalFuelCash = 0;
        protected decimal totalothers = 0;
        protected decimal totalTotalFuelCredit = 0;
        protected decimal totalnetpayable1 = 0;
        protected decimal totaltripfare1 = 0;
        protected decimal totaladdtripfare1 = 0;
        protected decimal totaladdAndtripfare1 = 0;
        protected decimal totalTotalDTFareCredit = 0;
        protected decimal totalmilla1 = 0;
        protected decimal totaladdmilla1 = 0;
        protected void dgvPaymentHisory_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalmilla1 += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblMilla1")).Text);
                    totalTotalFuelCash += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblTotalFuelCash")).Text);
                    totalTotalFuelCredit += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblTotalFuelCredit1")).Text);
                    totalfuelcost += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblTotalFuelCost")).Text);
                    totalothers += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblOthers")).Text);
                    totaltotalRouteexp1 += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblTotalRouteEXP")).Text);
                    totaltripfare1 += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblTripFare")).Text);
                    totaladdtripfare1 += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblAddTripFare")).Text);
                    totalTotalDTFareCash += decimal.Parse(((Label)e.Row.Cells[13].FindControl("lblTotalDownTripFareCash1")).Text);
                    totalTotalDTFareCredit += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblTotalDownTripFarecred")).Text);
                    totaltotaltripfare1 += decimal.Parse(((Label)e.Row.Cells[15].FindControl("lblTotalTripFare")).Text);
                    totalnetpayable1 += decimal.Parse(((Label)e.Row.Cells[16].FindControl("lblNetPayable1")).Text);                                        
                }
            }
            catch { }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = obj.GetShipPointList(intUnitID);
            ddlShipPoint.DataTextField = "strName";
            ddlShipPoint.DataValueField = "intId";
            ddlShipPoint.DataSource = dt;
            ddlShipPoint.DataBind();

            dgvPaymentHisory.DataSource = "";
            dgvPaymentHisory.DataBind();

            lblUnitN.Visible = false;
            lblReportName.Visible = false;
            lblFromTo.Visible = false;
        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPaymentHisory.DataSource = "";
            dgvPaymentHisory.DataBind();

            lblUnitN.Visible = false;
            lblReportName.Visible = false;
            lblFromTo.Visible = false;
        }








    }
}