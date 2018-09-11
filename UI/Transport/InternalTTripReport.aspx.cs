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
using GLOBAL_BLL;
using Flogging.Core;


namespace UI.Transport
{
    public partial class InternalTTripReport : BasePage
    {
        SeriLog log = new SeriLog();
        string location = "Transport";
        string start = "starting Transport/InternalTTripReport.aspx";
        string stop = "stopping Transport/InternalTTripReport.aspx";

        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intWork; DateTime dteFromDate; DateTime dteToDate; int intShipPoint; int intFuelStationid;
        int intUnitID; int intReportType; int intBillStatus; int intEnroll;
        string strVehicleNo; int intReportCategory; int intDoct; int intCheckDocList;

        protected void Page_Load(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();
                    pnlUpperControl.DataBind();
                    
                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetVehicleSupplierList(intUnitID);
                    ddlVehicleSupplier.DataTextField = "strName";
                    ddlVehicleSupplier.DataValueField = "intCOAid";
                    ddlVehicleSupplier.DataSource = dt;
                    ddlVehicleSupplier.DataBind();

                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();

                    dt = new DataTable();
                    dt = obj.GetFuelStationList();
                    ddlFuelStation.DataTextField = "strPartyName";
                    ddlFuelStation.DataValueField = "intPartyID";
                    ddlFuelStation.DataSource = dt;
                    ddlFuelStation.DataBind();

                    lblFuelStation.Visible = false;
                    ddlFuelStation.Visible = false;
                    btnBillSubmit.Visible = false;
                    rdoPending.Checked = true;
                    rdoComplete.Checked = false;
                    lblVehicleSupplier.Visible = false;
                    ddlVehicleSupplier.Visible = false;
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }
            }
            //else
            //{
            //    if (hdnconfirm.Value == "4") { DocCheck(); }
            //}

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
                dteToDate = DateTime.Parse(txtToDate.Text);
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intReportType = int.Parse(ddlReportType.SelectedValue.ToString());
                intFuelStationid = int.Parse(ddlFuelStation.SelectedValue.ToString());

                if (intReportType == 2 || intReportType == 5)
                {
                    if (rdoPending.Checked == true) { btnBillSubmit.Visible = true; }
                    else { btnBillSubmit.Visible = false; }
                }
                else { btnBillSubmit.Visible = false; }

                if (rdoAll.Checked == true) 
                { 
                    intReportCategory = 1;                    
                }
                else if (rdoAutoEntry.Checked == true) { intReportCategory = 2; btnBillSubmit.Visible = false; }
                else if (rdoManualEntry.Checked == true) { intReportCategory = 3; btnBillSubmit.Visible = false; }   
                
                if (intReportType == 1)
                {
                    //DateTime.ParseExact(dteFromDate.Text, "M/d/yyyy", CultureInfo.InvariantCulture);

                    dgvReportVehicleNDateWise.Columns[3].Visible = false;
                    dgvReportVehicleNDateWise.Columns[4].Visible = false;
                    dgvReportVehicleNDateWise.Columns[5].Visible = false;
                    dgvReportVehicleNDateWise.Columns[6].Visible = false;
                    dgvReportVehicleNDateWise.Columns[7].Visible = false;
                    dgvReportVehicleNDateWise.Columns[9].Visible = false;
                    dgvReportVehicleNDateWise.Columns[16].Visible = false;
                    dgvReportVehicleNDateWise.Columns[20].Visible = false;
                    dgvReportVehicleNDateWise.Columns[30].Visible = false;
                    dgvReportVehicleNDateWise.Columns[40].Visible = false;
                    dgvReportVehicleNDateWise.Columns[41].Visible = false;

                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Vehicle Wise Details Report";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 1;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvReportVehicleNDateWise.DataSource = dt;
                    dgvReportVehicleNDateWise.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
                    }
                    else
                    {
                        dgvReportVehicleNDateWise.DataSource = "";
                        dgvReportVehicleNDateWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 2)
                {
                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Trip Wise Details Report For Bill";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 2;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvReportVehicleNDateWise.DataSource = dt;
                    dgvReportVehicleNDateWise.DataBind();
                    
                    dgvReportVehicleNDateWise.Columns[3].Visible = true;
                    dgvReportVehicleNDateWise.Columns[4].Visible = true;
                    dgvReportVehicleNDateWise.Columns[5].Visible = true;
                    dgvReportVehicleNDateWise.Columns[6].Visible = true;
                    dgvReportVehicleNDateWise.Columns[7].Visible = true;
                    dgvReportVehicleNDateWise.Columns[9].Visible = true;
                    dgvReportVehicleNDateWise.Columns[16].Visible = true;
                    dgvReportVehicleNDateWise.Columns[20].Visible = true;
                    dgvReportVehicleNDateWise.Columns[30].Visible = true;
                    dgvReportVehicleNDateWise.Columns[40].Visible = true;
                    dgvReportVehicleNDateWise.Columns[41].Visible = true;

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
                    }
                    else
                    {
                        dgvReportVehicleNDateWise.DataSource = "";
                        dgvReportVehicleNDateWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 3)
                {
                    Label1.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label2.Text = "Summary Report For Vehicle Trip Cost";
                    Label3.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 3;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvTopSheet.DataSource = dt;
                    dgvTopSheet.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid3();", true);
                    }
                    else
                    {
                        dgvTopSheet.DataSource = "";
                        dgvTopSheet.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 4)
                {
                    Label4.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label5.Text = "Fuel Station Wise Details Report";
                    Label6.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 4;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvFuelStationWise.DataSource = dt;
                    dgvFuelStationWise.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid4();", true);
                    }
                    else
                    {
                        dgvFuelStationWise.DataSource = "";
                        dgvFuelStationWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 5)
                {
                    Label7.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label8.Text = "Fuel Station Wise Top Sheet For Fuel Bill";
                    Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();
                    
                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 5;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvFuelStationWiseBill.DataSource = dt;
                    dgvFuelStationWiseBill.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid5();", true);
                    }
                    else
                    {
                        dgvFuelStationWiseBill.DataSource = "";
                        dgvFuelStationWiseBill.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 6)
                {
                    Label10.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label11.Text = "Vehicle Wise Fuel Credit Report";
                    Label12.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();
                    
                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 6;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvVehicleWiseFuelCredit.DataSource = dt;
                    dgvVehicleWiseFuelCredit.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid6();", true);
                    }
                    else
                    {
                        dgvVehicleWiseFuelCredit.DataSource = "";
                        dgvVehicleWiseFuelCredit.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 7)
                {
                    Label13.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label14.Text = "Vehicle Wise Down Trip Credit Report";
                    Label15.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 7;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvDownTripCreditR.DataSource = dt;
                    dgvDownTripCreditR.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid7();", true);
                    }
                    else
                    {
                        dgvDownTripCreditR.DataSource = "";
                        dgvDownTripCreditR.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 8)
                {
                    Label17.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label18.Text = "Unit Wise Down Trip Credit Report";
                    Label19.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();
                    
                    dgvVendorsTReport.DataSource = "";
                    dgvVendorsTReport.DataBind();
                    
                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 22;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvDownTripCreditRUnitWise.DataSource = dt;
                    dgvDownTripCreditRUnitWise.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid8();", true);
                    }
                    else
                    {
                        dgvDownTripCreditRUnitWise.DataSource = "";
                        dgvDownTripCreditRUnitWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 9)
                {
                    Label20.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label21.Text = ddlVehicleSupplier.SelectedItem.ToString();
                    Label22.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    dgvDownTripCreditRUnitWise.DataSource = "";
                    dgvDownTripCreditRUnitWise.DataBind();

                    ////if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = int.Parse(ddlVehicleSupplier.SelectedValue.ToString());

                    intWork = 23;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvVendorsTReport.DataSource = dt;
                    dgvVendorsTReport.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid9();", true);
                    }
                    else
                    {
                        dgvVendorsTReport.DataSource = "";
                        dgvVendorsTReport.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
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
        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();
            dgvVendorsTReport.DataSource = "";
            dgvVendorsTReport.DataBind();

            lblBill.Visible = true;
            rdoPending.Visible = true;
            rdoComplete.Visible = true;
            Label16.Visible = true;
            rdoAll.Visible = true;
            rdoManualEntry.Visible = true;
            rdoAutoEntry.Visible = true;
            lblSearchVehicle.Visible = true;
            txtSearchVehicle.Visible = true;
            btnSearchV.Visible = true;

            lblFuelStation.Visible = false;
            ddlFuelStation.Visible = false;

            lblVehicleSupplier.Visible = false;
            ddlVehicleSupplier.Visible = false;
            
            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            lblBill.Visible = true;
            rdoPending.Visible = true;
            rdoComplete.Visible = true;

            if (intReportType == 4)
            {
                lblFuelStation.Visible = true;
                ddlFuelStation.Visible = true;
            }
            else if (intReportType == 7)
            {
                lblBill.Visible = false;
                rdoPending.Visible = false;
                rdoComplete.Visible = false;
            }
            else if (intReportType == 9)
            {
                lblVehicleSupplier.Visible = true;
                ddlVehicleSupplier.Visible = true;

                lblBill.Visible = false;
                rdoPending.Visible = false;
                rdoComplete.Visible = false;
                Label16.Visible = false;
                rdoAll.Visible = false;
                rdoManualEntry.Visible = false;
                rdoAutoEntry.Visible = false;
                lblSearchVehicle.Visible = false;
                txtSearchVehicle.Visible = false;
                btnSearchV.Visible = false;
                

                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = obj.GetVehicleSupplierList(intUnitID);
                ddlVehicleSupplier.DataTextField = "strName";
                ddlVehicleSupplier.DataValueField = "intCOAid";
                ddlVehicleSupplier.DataSource = dt;
                ddlVehicleSupplier.DataBind();
            }
            
            if (rdoPending.Checked == true)
            {
                if (hdnJobStation.Value != "1" && hdnJobStation.Value != "3" && hdnJobStation.Value != "4" &&
                    hdnJobStation.Value != "5" && hdnJobStation.Value != "6" && hdnJobStation.Value != "7" &&
                    hdnJobStation.Value != "8" && hdnJobStation.Value != "9" && hdnJobStation.Value != "10" &&
                    hdnJobStation.Value != "11" && hdnJobStation.Value != "12" && hdnJobStation.Value != "13" &&
                    hdnJobStation.Value != "14" && hdnJobStation.Value != "15" && hdnJobStation.Value != "16" &&
                    hdnJobStation.Value != "17" && hdnJobStation.Value != "18" && hdnJobStation.Value != "19" &&
                    hdnJobStation.Value != "22" && hdnJobStation.Value != "88" && hdnJobStation.Value != "125" &&
                    hdnJobStation.Value != "131" && hdnJobStation.Value != "422" && hdnJobStation.Value != "1216" &&
                    hdnJobStation.Value != "1254" && hdnJobStation.Value != "1257" && hdnJobStation.Value != "1258" &&
                    hdnJobStation.Value != "1259" && hdnJobStation.Value != "1260")
                {
                    if (intReportType == 2 || intReportType == 5)
                    { btnBillSubmit.Visible = true; }
                    else { btnBillSubmit.Visible = false; }
                }
                else { btnBillSubmit.Visible = false; }
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);            

            //if (intReportType == 3)
            //{
            //    hdnTopSheetCount.Value = dgvTopSheet.Rows.Count.ToString();
            //    if (int.Parse(hdnTopSheetCount.Value) > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Blank1();", true);
            //    }
            //}
            //else if (intReportType == 5)
            //{
            //    hdnFuelCostCount.Value = dgvFuelStationWiseBill.Rows.Count.ToString();
            //    if (int.Parse(hdnFuelCostCount.Value) == 0)
            //    {
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Blank2();", true);
            //    }
            //}
                        
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

        protected decimal millage = 0;
        protected decimal almillage = 0; 
        protected decimal totalmillage = 0;
        protected decimal totaldieseltk = 0;
        protected decimal totalcngtk = 0;
        protected decimal totalferry = 0;
        protected decimal totalbridge = 0;
        protected decimal totalmaintenance = 0;
        protected decimal totalpolice = 0;
        protected decimal totallabour = 0;
        protected decimal totalOther = 0;
        protected decimal totalmillageallow = 0;
        protected decimal totaldtripallow = 0;
        protected decimal totaldailyallow = 0;
        protected decimal totaltripbonus = 0;
        protected decimal totaltimeallow = 0;
        protected decimal totalfuelcash = 0;
        protected decimal totalrouteexp = 0;
        protected decimal totaltripfare = 0;
        protected decimal totaladitionalfare = 0;
        protected decimal totaldtfcash = 0;
        protected decimal totaldtfcredit = 0;
        protected decimal totalTotaltripfare = 0;
        protected decimal totaldieseltotalcredit = 0;
        protected decimal totalcngtotalcredit = 0;
        protected decimal totalnetincome = 0;
        protected decimal totalnetpayable = 0;
        protected decimal totalfareaditionalfare = 0;          
        protected void dgvReportVehicleNDateWise_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    millage += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblMillagekm")).Text);
                    almillage += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblAMillage")).Text);
                    totalmillage += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblMillage")).Text);
                    
                    //totaldieseltk += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblDieselTk")).Text);
                    totaldieseltk += decimal.Parse(((Button)e.Row.Cells[12].FindControl("btnDslVew")).Text);

                    totalcngtk += decimal.Parse(((Button)e.Row.Cells[13].FindControl("btnCngVew")).Text);
                    
                    totalferry += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblFerryExp")).Text);
                    totalbridge += decimal.Parse(((Label)e.Row.Cells[15].FindControl("lblBridgeExp")).Text);

                    totalmaintenance += decimal.Parse(((Button)e.Row.Cells[17].FindControl("btnMaintananceVew")).Text);
                    
                    totalpolice += decimal.Parse(((Label)e.Row.Cells[18].FindControl("lblpolice")).Text);
                    totallabour += decimal.Parse(((Label)e.Row.Cells[19].FindControl("lblLabour")).Text);

                    totalOther += decimal.Parse(((Button)e.Row.Cells[21].FindControl("btnOtherVew")).Text);
                    
                    totalmillageallow += decimal.Parse(((Label)e.Row.Cells[22].FindControl("lblMillageAllow")).Text);
                    totaldtripallow += decimal.Parse(((Label)e.Row.Cells[23].FindControl("lblDTripAllow")).Text);
                    totaldailyallow += decimal.Parse(((Label)e.Row.Cells[24].FindControl("lblDailyAllow")).Text);
                    totaltripbonus += decimal.Parse(((Label)e.Row.Cells[25].FindControl("lblTripBonus")).Text);
                    totaltimeallow += decimal.Parse(((Label)e.Row.Cells[26].FindControl("lblTimeAllow")).Text);
                    totalfuelcash += decimal.Parse(((Label)e.Row.Cells[27].FindControl("lblFuelCash")).Text);
                    totalrouteexp += decimal.Parse(((Label)e.Row.Cells[28].FindControl("lblTotalRouteExp")).Text);
                    totaltripfare += decimal.Parse(((Label)e.Row.Cells[29].FindControl("lblTripFare")).Text);
                    totaladitionalfare += decimal.Parse(((Label)e.Row.Cells[31].FindControl("lblAdditionalFare")).Text);
                    totalfareaditionalfare += decimal.Parse(((Label)e.Row.Cells[32].FindControl("lblFareAdditionalFare")).Text);
                    totaldtfcash += decimal.Parse(((Label)e.Row.Cells[33].FindControl("lblDTFCash")).Text);
                    totaldtfcredit += decimal.Parse(((Label)e.Row.Cells[34].FindControl("lblDTFCredit")).Text);
                    totalTotaltripfare += decimal.Parse(((Label)e.Row.Cells[35].FindControl("lblTotalTripFare")).Text);
                    totaldieseltotalcredit += decimal.Parse(((Label)e.Row.Cells[36].FindControl("lblDieselTotalCredit")).Text);
                    totalcngtotalcredit += decimal.Parse(((Label)e.Row.Cells[37].FindControl("lblCNGTotalCredit")).Text);
                    totalnetincome += decimal.Parse(((Label)e.Row.Cells[38].FindControl("lblNetIncome")).Text);
                    totalnetpayable += decimal.Parse(((Label)e.Row.Cells[39].FindControl("lblNetPayable")).Text);
                }
                //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true); }
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

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();
            dgvVendorsTReport.DataSource = "";
            dgvVendorsTReport.DataBind();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);            
        }

        protected decimal totalmillage1 = 0;
        protected decimal totalfuelcost = 0;
        protected decimal totaladministrativecost = 0;
        protected decimal totaldriverexp = 0;
        protected decimal totaltotalRouteexp1 = 0;
        protected decimal totaltotaltripfare1 = 0;
        protected decimal totalnetincome1 = 0;        
        protected decimal totalTotalDTFareCash = 0;
        protected decimal totalTotalFuelCredit = 0;
        protected decimal totalnetpayable1 = 0;
        protected decimal totaltripfare1 = 0;
        protected decimal totaladdtripfare1 = 0;
        protected decimal totaladdAndtripfare1 = 0;
        protected decimal totalTotalDTFareCredit = 0;
        protected decimal totalmilla1 = 0;
        protected decimal totaladdmilla1 = 0;
        protected void dgvTopSheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalmilla1 += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblMilla1")).Text);
                    totaladdmilla1 += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblAddMillage1")).Text);
                    totalmillage1 += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblMillage1")).Text);
                    totalfuelcost += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblTotalFuelCost")).Text);
                    totaladministrativecost += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblAdministrativeCost")).Text);
                    totaldriverexp += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblDriverExp")).Text);
                    totaltotalRouteexp1 += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblTotalRouteEXP")).Text);
                    totaltripfare1 += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblTripFare")).Text);
                    totaladdtripfare1 += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblAddTripFare")).Text);
                    totaladdAndtripfare1 += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblAddAndTripFare")).Text);
                    totalTotalDTFareCash += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblTotalDownTripFareCash1")).Text);
                    totalTotalDTFareCredit += decimal.Parse(((Label)e.Row.Cells[13].FindControl("lblTotalDownTripFarecred")).Text);
                    totaltotaltripfare1 += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblTotalTripFare")).Text);
                    totalnetincome1 += decimal.Parse(((Label)e.Row.Cells[15].FindControl("lblNetIncome1")).Text);                    
                    totalTotalFuelCredit += decimal.Parse(((Label)e.Row.Cells[16].FindControl("lblTotalFuelCredit1")).Text);
                    totalnetpayable1 += decimal.Parse(((Label)e.Row.Cells[17].FindControl("lblNetPayable1")).Text);
                }                
            }
            catch { }
        }

        protected decimal totaldieselttk = 0;
        protected decimal totalcngtotalc = 0;
        protected decimal totaldieselc = 0;
        protected decimal totalcngc = 0;
        protected decimal totaltotalc = 0;
        protected void dgvFuelStationWise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totaldieselttk += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblDieselTotalCost")).Text);
                    totalcngtotalc += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblCNGTotalCost")).Text);
                    totaldieselc += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblDieselCredit")).Text);
                    totalcngc += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblCNGC")).Text);
                    totaltotalc += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblTotalCredit")).Text);                    
                }
                
            }
            catch { }
        }

        protected decimal totaldieselc1 = 0;
        protected decimal totalcngc1 = 0;
        protected decimal totaltotalc1 = 0;
        protected void dgvFuelStationWiseBill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totaldieselc1 += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblDieselCredit1")).Text);
                    totalcngc1 += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblCNGC1")).Text);
                    totaltotalc1 += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblTotalCredit1")).Text);                    
                }
                
            }
            catch { }
        }
        protected void dgvVehicleWiseFuelCredit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "Sub Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.Font.Bold = true;

                }
                if (e.Row.Cells[1].Text == "Grand Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                    e.Row.Font.Bold = true;
                }
            }
            
        }
        protected void dgvDownTripCreditR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "Sub Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.Font.Bold = true;
                    e.Row.Cells[0].Text = "";
                }
                if (e.Row.Cells[2].Text == "Grand Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                    e.Row.Font.Bold = true;
                    e.Row.Cells[0].Text = "";
                }
                if (e.Row.Cells[1].Text == "zzzzzz")
                {
                    e.Row.Cells[1].Text = "";
                }
                if (e.Row.Cells[0].Text == "zzzzzz")
                {
                    e.Row.Cells[0].Text = "";
                }
            }
           
        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();
            dgvVendorsTReport.DataSource = "";
            dgvVendorsTReport.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);            
        }
        protected void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            if (rdoPending.Checked == true) 
            { rdoComplete.Checked = false;

                if (hdnJobStation.Value != "1" && hdnJobStation.Value != "3" && hdnJobStation.Value != "4" &&
                    hdnJobStation.Value != "5" && hdnJobStation.Value != "6" && hdnJobStation.Value != "7" &&
                    hdnJobStation.Value != "8" && hdnJobStation.Value != "9" && hdnJobStation.Value != "10" &&
                    hdnJobStation.Value != "11" && hdnJobStation.Value != "12" && hdnJobStation.Value != "13" &&
                    hdnJobStation.Value != "14" && hdnJobStation.Value != "15" && hdnJobStation.Value != "16" &&
                    hdnJobStation.Value != "17" && hdnJobStation.Value != "18" && hdnJobStation.Value != "19" &&
                    hdnJobStation.Value != "22" && hdnJobStation.Value != "88" && hdnJobStation.Value != "125" &&
                    hdnJobStation.Value != "131" && hdnJobStation.Value != "422" && hdnJobStation.Value != "1216" &&
                    hdnJobStation.Value != "1254" && hdnJobStation.Value != "1257" && hdnJobStation.Value != "1258" &&
                    hdnJobStation.Value != "1259" && hdnJobStation.Value != "1260")
                {
                    if (intReportType == 2 || intReportType == 5)
                    { btnBillSubmit.Visible = true; }
                    else { btnBillSubmit.Visible = false; }
                }
                else { btnBillSubmit.Visible = false; }
            }
            else { rdoPending.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();
            
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true); 
        }
        protected void rdoComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoComplete.Checked == true) { rdoPending.Checked = false; btnBillSubmit.Visible = false; }
            else { rdoComplete.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();

            //lblFuelStation.Visible = false;
            //ddlFuelStation.Visible = false;

            //intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            //if (intReportType == 4)
            //{
            //    lblFuelStation.Visible = true;
            //    ddlFuelStation.Visible = true;
            //}

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);   
        }
        protected void btnBillSubmit_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
                dteToDate = DateTime.Parse(txtToDate.Text);
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intFuelStationid = 0;
                intBillStatus = 0;
                intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

                if (rdoAll.Checked == true) { intReportCategory = 1; }
                else if (rdoAutoEntry.Checked == true) { intReportCategory = 2; }
                else if (rdoManualEntry.Checked == true) { intReportCategory = 3; } 
                
               
                if (hdnconfirm.Value == "1")
                {
                    if (intReportType == 2)
                    {
                        hdnTopSheetCount.Value = dgvReportVehicleNDateWise.Rows.Count.ToString();
                        if (int.Parse(hdnTopSheetCount.Value) > 0)
                        {
                            intEnroll = int.Parse(hdnEnroll.Value);
                            intWork = 8;
                            dt = new DataTable();
                            dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                            dgvReportVehicleNDateWise.DataSource = "";
                            dgvReportVehicleNDateWise.DataBind();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "BillSubmitOfVehicleCost();", true);
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Bill Submit Successfully.');", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true); }
                    }
                    else if (intReportType == 5)
                    {
                        hdnFuelCostCount.Value = dgvFuelStationWiseBill.Rows.Count.ToString();
                        if (int.Parse(hdnFuelCostCount.Value) > 0)
                        {
                            intEnroll = int.Parse(hdnEnroll.Value);
                            intWork = 9;
                            dt = new DataTable();
                            dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                            dgvFuelStationWiseBill.DataSource = "";
                            dgvFuelStationWiseBill.DataBind();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "BillSubmitOfFuelCost();", true);
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Bill Submit Successfully.');", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true); }
                    }
                }
                else
                {
                    if (intReportType == 2)
                    {
                        hdnTopSheetCount.Value = dgvReportVehicleNDateWise.Rows.Count.ToString();
                        if (int.Parse(hdnTopSheetCount.Value) == 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Blank1();", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Blank3();", true); }
                    }
                    else if (intReportType == 5)
                    {
                        hdnFuelCostCount.Value = dgvFuelStationWiseBill.Rows.Count.ToString();
                        if (int.Parse(hdnFuelCostCount.Value) == 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Blank2();", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Blank3();", true); }
                    }
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
        protected void btnSearchV_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
                dteToDate = DateTime.Parse(txtToDate.Text);
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intReportType = int.Parse(ddlReportType.SelectedValue.ToString());
                intFuelStationid = int.Parse(ddlFuelStation.SelectedValue.ToString());
                strVehicleNo = txtSearchVehicle.Text;

                btnBillSubmit.Visible = false;

                if (rdoAll.Checked == true) { intReportCategory = 1; } 
                else if(rdoAutoEntry.Checked == true) { intReportCategory = 2; }
                else if (rdoManualEntry.Checked == true) { intReportCategory = 3; }

                dgvReportVehicleNDateWise.Columns[3].Visible = false;
                dgvReportVehicleNDateWise.Columns[4].Visible = false;
                dgvReportVehicleNDateWise.Columns[5].Visible = false;
                dgvReportVehicleNDateWise.Columns[6].Visible = false;
                dgvReportVehicleNDateWise.Columns[7].Visible = false;
                dgvReportVehicleNDateWise.Columns[9].Visible = false;
                dgvReportVehicleNDateWise.Columns[16].Visible = false;
                dgvReportVehicleNDateWise.Columns[20].Visible = false;
                dgvReportVehicleNDateWise.Columns[30].Visible = false;
                dgvReportVehicleNDateWise.Columns[40].Visible = false;
                dgvReportVehicleNDateWise.Columns[41].Visible = false;

                if (intReportType == 1)
                {
                    //DateTime.ParseExact(dteFromDate.Text, "M/d/yyyy", CultureInfo.InvariantCulture);

                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Vehicle Wise Details Report";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }                    
                    intEnroll = 0;

                    intWork = 1;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvReportVehicleNDateWise.DataSource = dt;
                    dgvReportVehicleNDateWise.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
                    }
                    else
                    {
                        dgvReportVehicleNDateWise.DataSource = "";
                        dgvReportVehicleNDateWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 2)
                {
                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Trip Wise Details Report For Bill";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 2;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvReportVehicleNDateWise.DataSource = dt;
                    dgvReportVehicleNDateWise.DataBind();

                    dgvReportVehicleNDateWise.Columns[3].Visible = true;
                    dgvReportVehicleNDateWise.Columns[4].Visible = true;
                    dgvReportVehicleNDateWise.Columns[5].Visible = true;
                    dgvReportVehicleNDateWise.Columns[6].Visible = true;
                    dgvReportVehicleNDateWise.Columns[7].Visible = true;
                    dgvReportVehicleNDateWise.Columns[9].Visible = true;
                    dgvReportVehicleNDateWise.Columns[16].Visible = true;
                    dgvReportVehicleNDateWise.Columns[20].Visible = true;
                    dgvReportVehicleNDateWise.Columns[30].Visible = true;
                    dgvReportVehicleNDateWise.Columns[40].Visible = true;
                    dgvReportVehicleNDateWise.Columns[41].Visible = true;

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
                    }
                    else
                    {
                        dgvReportVehicleNDateWise.DataSource = "";
                        dgvReportVehicleNDateWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 3)
                {
                    Label1.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label2.Text = "Summary Report For Vehicle Trip Cost";
                    Label3.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 3;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvTopSheet.DataSource = dt;
                    dgvTopSheet.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid3();", true);
                    }
                    else
                    {
                        dgvTopSheet.DataSource = "";
                        dgvTopSheet.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 4)
                {
                    Label4.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label5.Text = "Fuel Station Wise Details Report";
                    Label6.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 4;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvFuelStationWise.DataSource = dt;
                    dgvFuelStationWise.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid4();", true);
                    }
                    else
                    {
                        dgvFuelStationWise.DataSource = "";
                        dgvFuelStationWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 5)
                {
                    Label7.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label8.Text = "Fuel Station Wise Top Sheet For Fuel Bill";
                    Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 5;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvFuelStationWiseBill.DataSource = dt;
                    dgvFuelStationWiseBill.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid5();", true);
                    }
                    else
                    {
                        dgvFuelStationWiseBill.DataSource = "";
                        dgvFuelStationWiseBill.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 6)
                {
                    Label10.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label11.Text = "Vehicle Wise Fuel Credit Report";
                    Label12.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 6;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvVehicleWiseFuelCredit.DataSource = dt;
                    dgvVehicleWiseFuelCredit.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid6();", true);
                    }
                    else
                    {
                        dgvVehicleWiseFuelCredit.DataSource = "";
                        dgvVehicleWiseFuelCredit.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 7)
                {
                    Label13.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label14.Text = "Vehicle Wise Down Trip Credit Report";
                    Label15.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 7;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvDownTripCreditR.DataSource = dt;
                    dgvDownTripCreditR.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid7();", true);
                    }
                    else
                    {
                        dgvDownTripCreditR.DataSource = "";
                        dgvDownTripCreditR.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 8)
                {
                    Label17.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label18.Text = "Unit Wise Down Trip Credit Report";
                    Label19.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    dgvFuelStationWise.DataSource = "";
                    dgvFuelStationWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    dgvVehicleWiseFuelCredit.DataSource = "";
                    dgvVehicleWiseFuelCredit.DataBind();

                    dgvDownTripCreditR.DataSource = "";
                    dgvDownTripCreditR.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 22;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvDownTripCreditRUnitWise.DataSource = dt;
                    dgvDownTripCreditRUnitWise.DataBind();
                    
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid8();", true);
                    }
                    else
                    {
                        dgvDownTripCreditRUnitWise.DataSource = "";
                        dgvDownTripCreditRUnitWise.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
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
        protected void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            if (rdoAll.Checked == true)
            {
                rdoAutoEntry.Checked = false;
                rdoManualEntry.Checked = false;
                
                if (hdnJobStation.Value != "1" && hdnJobStation.Value != "3" && hdnJobStation.Value != "4" &&
                    hdnJobStation.Value != "5" && hdnJobStation.Value != "6" && hdnJobStation.Value != "7" &&
                    hdnJobStation.Value != "8" && hdnJobStation.Value != "9" && hdnJobStation.Value != "10" &&
                    hdnJobStation.Value != "11" && hdnJobStation.Value != "12" && hdnJobStation.Value != "13" &&
                    hdnJobStation.Value != "14" && hdnJobStation.Value != "15" && hdnJobStation.Value != "16" &&
                    hdnJobStation.Value != "17" && hdnJobStation.Value != "18" && hdnJobStation.Value != "19" &&
                    hdnJobStation.Value != "22" && hdnJobStation.Value != "88" && hdnJobStation.Value != "125" &&
                    hdnJobStation.Value != "131" && hdnJobStation.Value != "422" && hdnJobStation.Value != "1216" &&
                    hdnJobStation.Value != "1254" && hdnJobStation.Value != "1257" && hdnJobStation.Value != "1258" &&
                    hdnJobStation.Value != "1259" && hdnJobStation.Value != "1260")
                {
                if (intReportType == 2 || intReportType == 5)
                {
                    if (rdoPending.Checked == true)
                    {
                        btnBillSubmit.Visible = true;
                    }
                    else { btnBillSubmit.Visible = false; }
                }
                else { btnBillSubmit.Visible = false; }
                }
                else { btnBillSubmit.Visible = false; }
            }
            else { rdoAll.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();
                        
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);   
        }
        protected void rdoAutoEntry_CheckedChanged(object sender, EventArgs e)
        {
            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            if (rdoAutoEntry.Checked == true)
            {
                rdoAll.Checked = false;
                rdoManualEntry.Checked = false;
                btnBillSubmit.Visible = false;

                //if (hdnJobStation.Value != "1" && hdnJobStation.Value != "3" && hdnJobStation.Value != "4" &&
                //    hdnJobStation.Value != "5" && hdnJobStation.Value != "6" && hdnJobStation.Value != "7" &&
                //    hdnJobStation.Value != "8" && hdnJobStation.Value != "9" && hdnJobStation.Value != "10" &&
                //    hdnJobStation.Value != "11" && hdnJobStation.Value != "12" && hdnJobStation.Value != "13" &&
                //    hdnJobStation.Value != "14" && hdnJobStation.Value != "15" && hdnJobStation.Value != "16" &&
                //    hdnJobStation.Value != "17" && hdnJobStation.Value != "18" && hdnJobStation.Value != "19" &&
                //    hdnJobStation.Value != "22" && hdnJobStation.Value != "88" && hdnJobStation.Value != "125" &&
                //    hdnJobStation.Value != "131" && hdnJobStation.Value != "422" && hdnJobStation.Value != "1216" &&
                //    hdnJobStation.Value != "1254" && hdnJobStation.Value != "1257" && hdnJobStation.Value != "1258" &&
                //    hdnJobStation.Value != "1259" && hdnJobStation.Value != "1260")
                //{
                //    if (intReportType == 3 || intReportType == 5)
                //    { btnBillSubmit.Visible = true; }
                //    else { btnBillSubmit.Visible = false; }
                //}
                //else { btnBillSubmit.Visible = false; }
            }
            else { rdoAutoEntry.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);  
        }
        protected void rdoManualEntry_CheckedChanged(object sender, EventArgs e)
        {
            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            if (rdoManualEntry.Checked == true)
            { 
                rdoAll.Checked = false;
                rdoAutoEntry.Checked = false;
                btnBillSubmit.Visible = false;

                //if (hdnJobStation.Value != "1" && hdnJobStation.Value != "3" && hdnJobStation.Value != "4" &&
                //    hdnJobStation.Value != "5" && hdnJobStation.Value != "6" && hdnJobStation.Value != "7" &&
                //    hdnJobStation.Value != "8" && hdnJobStation.Value != "9" && hdnJobStation.Value != "10" &&
                //    hdnJobStation.Value != "11" && hdnJobStation.Value != "12" && hdnJobStation.Value != "13" &&
                //    hdnJobStation.Value != "14" && hdnJobStation.Value != "15" && hdnJobStation.Value != "16" &&
                //    hdnJobStation.Value != "17" && hdnJobStation.Value != "18" && hdnJobStation.Value != "19" &&
                //    hdnJobStation.Value != "22" && hdnJobStation.Value != "88" && hdnJobStation.Value != "125" &&
                //    hdnJobStation.Value != "131" && hdnJobStation.Value != "422" && hdnJobStation.Value != "1216" &&
                //    hdnJobStation.Value != "1254" && hdnJobStation.Value != "1257" && hdnJobStation.Value != "1258" &&
                //    hdnJobStation.Value != "1259" && hdnJobStation.Value != "1260")
                //{
                //    if (intReportType == 3 || intReportType == 5)
                //    { btnBillSubmit.Visible = true; }
                //    else { btnBillSubmit.Visible = false; }
                //}
                //else { btnBillSubmit.Visible = false; }
            }
            else { rdoManualEntry.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWise.DataSource = "";
            dgvFuelStationWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();
            dgvVehicleWiseFuelCredit.DataSource = "";
            dgvVehicleWiseFuelCredit.DataBind();
            dgvDownTripCreditR.DataSource = "";
            dgvDownTripCreditR.DataBind();
            dgvDownTripCreditRUnitWise.DataSource = "";
            dgvDownTripCreditRUnitWise.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);  
        }

        protected void dgvDownTripCreditRUnitWise_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "Sub Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.Font.Bold = true;
                    e.Row.Cells[0].Text = "";
                }
                if (e.Row.Cells[2].Text == "Grand Total")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                    e.Row.Font.Bold = true;
                    e.Row.Cells[0].Text = "";
                }
                if (e.Row.Cells[1].Text == "zzzzzz")
                {
                    e.Row.Cells[1].Text = "";
                }
                if (e.Row.Cells[0].Text == "zzzzzz")
                {
                    e.Row.Cells[0].Text = "";
                }
            }

        }
        protected void TripDetails_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            string senderdata = ((Button)sender).CommandArgument.ToString();            
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TripDetails('" + senderdata + "');", true);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAllForDetails();", true);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAllForDetails();", true); 

            //intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            //if (intReportType == 1)
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
            //}
            //else if (intReportType == 2)
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
            //}

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        protected void btnDocVew_Click(object sender, EventArgs e)
        {
            intDoct = 0;
            HttpContext.Current.Session["intDoct"] = intDoct.ToString();

            string senderdata = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);
            //try
            //{
            //    dt = new DataTable();
            //    dt = obj.GetDocPathListExistCheck(int.Parse(senderdata.ToString()));
            //    intCheckDocList = int.Parse(dt.Rows[0]["doccount"].ToString());
            //}
            //catch { intCheckDocList = 0; }

            //if (intCheckDocList == 0)
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocMsg();", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);

            //    //intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            //    //if (intReportType == 1)
            //    //{
            //    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
            //    //}
            //    //else if (intReportType == 2)
            //    //{
            //    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
            //    //}
            //}

        }
        protected void btnDslVew_Click(object sender, CommandEventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Transport/InternalTransportRouteExpIn.aspx Show", "", fd.UserName, fd.Location,
            fd.Product, fd.Layer);

            if (e.CommandName.Equals("cng") || e.CommandName.Equals("diesel"))
            {
                intDoct = 1;
                HttpContext.Current.Session["intDoct"] = intDoct.ToString();
            }
            else if (e.CommandName.Equals("mainttk"))
            {
                intDoct = 2;
                HttpContext.Current.Session["intDoct"] = intDoct.ToString();
            }
            else if (e.CommandName.Equals("othertk"))
            {
                intDoct = 5;
                HttpContext.Current.Session["intDoct"] = intDoct.ToString();
            }

            string senderdata = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);

            //try
            //{
            //    dt = new DataTable();
            //    dt = obj.GetDocPathListExistCheckTypeWise(int.Parse(senderdata.ToString()), intDoct);
            //    intCheckDocList = int.Parse(dt.Rows[0]["doccount"].ToString());
            //}
            //catch { intCheckDocList = 0; }

            //if (intCheckDocList == 0)
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocMsg();", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);

            //    //intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            //    //if (intReportType == 1)
            //    //{
            //    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
            //    //}
            //    //else if (intReportType == 2)
            //    //{
            //    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
            //    //}
            //}

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void ddlVehicleSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label21.Text = ddlVehicleSupplier.SelectedItem.ToString();
        }

        //public string ViewDocListSingle(string Id, string docid, string confid)  
        //{
        //    docid = "1";
        //    confid = "0";
        //    Session["controlID"] = "Id";
        //    return "ViewDocListSingle('" + Id + "','" + docid + "','" + confid + "')"; 
        //}

        //private void DocCheck()
        //{
        //    try
        //    {
        //        dt = new DataTable();
        //        dt = obj.GetDocPathListExistCheck(int.Parse(hdnRefidDocV.Value));
        //        intCheckDocList = int.Parse(dt.Rows[0]["doccount"].ToString());
        //    }
        //    catch { intCheckDocList = 0; }

        //    if(intCheckDocList == 0)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "DocMsg();", true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + hdnRefidDocV.Value + "');", true);
        //    }
        //}






    }
}