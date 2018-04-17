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
    public partial class InternalTForTransportDept : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intWork; DateTime dteFromDate; DateTime dteToDate; int intShipPoint; int intFuelStationid;
        int intUnitID; int intReportType; int intBillStatus; int intEnroll; int intReportCategory;
        string strVehicleNo; int intDoct;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetShipPointList(intUnitID);
                    ddlShipPoint.DataTextField = "strName";
                    ddlShipPoint.DataValueField = "intId";
                    ddlShipPoint.DataSource = dt;
                    ddlShipPoint.DataBind();

                    btnBillSubmit.Visible = true;
                    rdoPending.Checked = true;
                    rdoComplete.Checked = false;
                }
                catch
                { }
            }
        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
                dteToDate = DateTime.Parse(txtToDate.Text);
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

                if (rdoAll.Checked == true) 
                { 
                    intReportCategory = 1;
                    if (rdoPending.Checked == true) { btnBillSubmit.Visible = true; }
                    else { btnBillSubmit.Visible = false; }
                }
                else if (rdoAutoEntry.Checked == true) { intReportCategory = 2; btnBillSubmit.Visible = false; }
                else if (rdoManualEntry.Checked == true) { intReportCategory = 3; btnBillSubmit.Visible = false; } 
               
                if (intReportType == 1)
                {
                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Trip Wise Details Report For Bill";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 18;
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
                    Label7.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label8.Text = "Fuel Station Wise Top Sheet";
                    Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 19;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvFuelStationWiseBill.DataSource = dt;
                    dgvFuelStationWiseBill.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
                    }
                    else
                    {
                        dgvFuelStationWiseBill.DataSource = "";
                        dgvFuelStationWiseBill.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
            }
            catch { }

        }
        protected void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPending.Checked == true)
            {
                rdoComplete.Checked = false;
                btnBillSubmit.Visible = true;
                //if (intReportType == 1 || intReportType == 2)
                //{ btnBillSubmit.Visible = true; }
                //else { btnBillSubmit.Visible = false; }
            }
            else { rdoPending.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected void rdoComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoComplete.Checked == true) { rdoPending.Checked = false; btnBillSubmit.Visible = false; }
            else { rdoComplete.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
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
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
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

        protected void btnBillSubmit_Click(object sender, EventArgs e)
        {
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
                    if (intReportType == 1)
                    {
                        hdnTopSheetCount.Value = dgvReportVehicleNDateWise.Rows.Count.ToString();
                        if (int.Parse(hdnTopSheetCount.Value) > 0)
                        {
                            intEnroll = int.Parse(hdnEnroll.Value);
                            intWork = 20;
                            dt = new DataTable();
                            dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                            dgvReportVehicleNDateWise.DataSource = "";
                            dgvReportVehicleNDateWise.DataBind();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "BillSubmitOfVehicleCost();", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true); }
                    }
                    else if (intReportType == 2)
                    {
                        hdnFuelCostCount.Value = dgvFuelStationWiseBill.Rows.Count.ToString();
                        if (int.Parse(hdnFuelCostCount.Value) > 0)
                        {
                            intEnroll = int.Parse(hdnEnroll.Value);
                            intWork = 21;
                            dt = new DataTable();
                            dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                            dgvFuelStationWiseBill.DataSource = "";
                            dgvFuelStationWiseBill.DataBind();
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "BillSubmitOfFuelCost();", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true); }
                    }
                }
                else
                {
                    if (intReportType == 1)
                    {
                        hdnTopSheetCount.Value = dgvReportVehicleNDateWise.Rows.Count.ToString();
                        if (int.Parse(hdnTopSheetCount.Value) == 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true); }
                    }
                    else if (intReportType == 2)
                    {
                        hdnFuelCostCount.Value = dgvFuelStationWiseBill.Rows.Count.ToString();
                        if (int.Parse(hdnFuelCostCount.Value) == 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                        }
                        else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true); }
                    }
                }
            }
            catch { }
        }
        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());
            lblBill.Visible = true;
            rdoPending.Visible = true;
            rdoComplete.Visible = true;

            if (rdoPending.Checked == true)
            {
                btnBillSubmit.Visible = true;
                //if (intReportType == 3 || intReportType == 5)
                //{ btnBillSubmit.Visible = true; }
                //else { btnBillSubmit.Visible = false; }
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }

        protected void btnSearchV_Click(object sender, EventArgs e)
        {
            try
            {
                dteFromDate = DateTime.Parse(txtFromDate.Text);
                dteToDate = DateTime.Parse(txtToDate.Text);
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intReportType = int.Parse(ddlReportType.SelectedValue.ToString());
                strVehicleNo = txtSearchVehicle.Text;

                btnBillSubmit.Visible = false;

                if (rdoAll.Checked == true) { intReportCategory = 1; }
                else if (rdoAutoEntry.Checked == true) { intReportCategory = 2; }
                else if (rdoManualEntry.Checked == true) { intReportCategory = 3; }

                if (intReportType == 1)
                {
                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Trip Wise Details Report For Bill";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 18;
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
                    Label7.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label8.Text = "Fuel Station Wise Top Sheet";
                    Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvReportVehicleNDateWise.DataSource = "";
                    dgvReportVehicleNDateWise.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 19;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvFuelStationWiseBill.DataSource = dt;
                    dgvFuelStationWiseBill.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
                    }
                    else
                    {
                        dgvFuelStationWiseBill.DataSource = "";
                        dgvFuelStationWiseBill.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
            }
            catch { }
        }
        protected void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            if (rdoAll.Checked == true)
            {
                rdoAutoEntry.Checked = false;
                rdoManualEntry.Checked = false;

                if (rdoPending.Checked == true)
                {
                    btnBillSubmit.Visible = true;
                    //if (intReportType == 3 || intReportType == 5)
                    //{ btnBillSubmit.Visible = true; }
                    //else { btnBillSubmit.Visible = false; }
                }
                else { btnBillSubmit.Visible = false; }

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
            else { rdoAll.Checked = true; }

            dgvReportVehicleNDateWise.DataSource = "";
            dgvReportVehicleNDateWise.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

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
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

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
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }

        protected void TripDetails_Click(object sender, EventArgs e)
        {
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

            //    intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            //    if (intReportType == 1)
            //    {
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
            //    }
            //    else if (intReportType == 2)
            //    {
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
            //    }
            //}

        }
        protected void btnDslVew_Click(object sender, CommandEventArgs e)
        {

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

            //    intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

            //    if (intReportType == 1)
            //    {
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
            //    }
            //    else if (intReportType == 2)
            //    {
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
            //    }
            //}            
        }

        //protected void TripDetails_Click(object sender, EventArgs e)
        //{
        //    string senderdata = ((Button)sender).CommandArgument.ToString();
        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TripDetails('" + senderdata + "');", true);
        //    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAllForDetails();", true);
        //    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAllForDetails();", true); 

        //    intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

        //    if (intReportType == 1)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
        //    }
        //    else if (intReportType == 2)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
        //    }

        //}
        //protected void btnDocVew_Click(object sender, EventArgs e)
        //{
        //    string senderdata = ((Button)sender).CommandArgument.ToString();
        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);

        //    //string Id;

        //    //Session["controlID"] = "Id";
        //    //return "ViewDocList('" + Id + "')";


        //    intReportType = int.Parse(ddlReportType.SelectedValue.ToString());

        //    if (intReportType == 1)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
        //    }
        //    else if (intReportType == 2)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
        //    }
        //}


    }
}