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
    public partial class InternalTReportForAccounts : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intWork; DateTime dteFromDate; DateTime dteToDate; int intShipPoint; int intFuelStationid;
        int intUnitID; int intReportType; int intBillStatus; int intEnroll; int intReportCategory;
        string strVehicleNo;


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
                    lblReportName.Text = "Trip Cost Summary Report";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 14;
                    dt = new DataTable();
                    dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                    dgvTopSheet.DataSource = dt;
                    dgvTopSheet.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
                    }
                    else
                    {
                        dgvTopSheet.DataSource = "";
                        dgvTopSheet.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 2)
                {
                    Label7.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label8.Text = "Fuel Station Wise Top Sheet";
                    Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 15;
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

            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected void rdoComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoComplete.Checked == true) { rdoPending.Checked = false; btnBillSubmit.Visible = false; }
            else { rdoComplete.Checked = true; }

            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
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

            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
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
        protected void dgvTopSheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalmillage1 += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblMillage1")).Text);
                    totalfuelcost += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblTotalFuelCost")).Text);
                    totaladministrativecost += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblAdministrativeCost")).Text);
                    totaldriverexp += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblDriverExp")).Text);
                    totaltotalRouteexp1 += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblTotalRouteEXP")).Text);
                    totaltotaltripfare1 += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblTotalTripFare")).Text);
                    totalnetincome1 += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblNetIncome1")).Text);
                    totalTotalDTFareCash += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblTotalDownTripFareCash1")).Text);
                    totalTotalFuelCredit += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblTotalFuelCredit1")).Text);
                    totalnetpayable1 += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblNetPayable1")).Text);
                }

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
                        hdnTopSheetCount.Value = dgvTopSheet.Rows.Count.ToString();
                        if (int.Parse(hdnTopSheetCount.Value) > 0)
                        {
                            intEnroll = int.Parse(hdnEnroll.Value);
                            intWork = 16;
                            dt = new DataTable();
                            dt = obj.GetDateWiseCompleteReport(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, intReportCategory);
                            dgvTopSheet.DataSource = "";
                            dgvTopSheet.DataBind();
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
                            intWork = 17;
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
                        hdnTopSheetCount.Value = dgvTopSheet.Rows.Count.ToString();
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
            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
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
                    lblReportName.Text = "Trip Cost Summary Report";
                    lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvFuelStationWiseBill.DataSource = "";
                    dgvFuelStationWiseBill.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 14;
                    dt = new DataTable();
                    dt = obj.GetCompleteReportVehicleSearch(intWork, intShipPoint, dteFromDate, dteToDate, intFuelStationid, intBillStatus, intEnroll, strVehicleNo, intReportCategory);
                    dgvTopSheet.DataSource = dt;
                    dgvTopSheet.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
                    }
                    else
                    {
                        dgvTopSheet.DataSource = "";
                        dgvTopSheet.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 2)
                {
                    Label7.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label8.Text = "Fuel Station Wise Top Sheet";
                    Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dgvTopSheet.DataSource = "";
                    dgvTopSheet.DataBind();

                    if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }
                    intEnroll = 0;

                    intWork = 15;
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

                if (rdoPending.Checked == true) { btnBillSubmit.Visible = true;} 
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

            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
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

            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
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

            dgvTopSheet.DataSource = "";
            dgvTopSheet.DataBind();
            dgvFuelStationWiseBill.DataSource = "";
            dgvFuelStationWiseBill.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }





    }
}