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
using System.Text.RegularExpressions;
using System.Text;
namespace UI.Transport
{
    public partial class InternalTLocalAccountsReport : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL();
        DataTable dt;

        int intWork; DateTime dteFromDate; DateTime dteToDate; int intShipPoint; int intFuelStationid;
        int intUnitID; int intReportType; int intBillStatus; int intEnroll; int intReportCategory;
        string strVehicleNo; int ysnWonVehicle; int intReffid; int intInsertBy;
        string dtefrom; string dteTo; bool ysnWonV; decimal monAdvance; int intDoct;
        decimal monPaymentAmount; int intInsertByPayment; decimal NetPayable; decimal PaidAmount;
        int intDrverEnroll; DateTime dteNewFromDate; decimal monCashR; decimal monAddj;
        

        char[] delimiterChars = { '[', ']', '^', ';', '-', '_', '.' }; string[] arrayKey;

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

                    dt = new DataTable();
                    dt = obj.GetDriverList(intUnitID);
                    ddlDriverName.DataTextField = "strEmployeeName";
                    ddlDriverName.DataValueField = "intEmployeeID";
                    ddlDriverName.DataSource = dt;
                    ddlDriverName.DataBind();

                    //btnBillSubmit.Visible = true;
                    //rdoPending.Checked = true;
                    //rdoComplete.Checked = false;

                    lblFromDate.Visible = false;
                    txtFromDate.Visible = false;
                    lblToDate.Visible = false;
                    txtToDate.Visible = false;
                    lblDriver.Visible = false;
                    ddlDriverName.Visible = false;
                    lblSearchEnroll.Visible = false;
                    txtSearchEnroll.Visible = false;
                    lblSearchVehicle.Visible = true;
                    txtSearchVehicle.Visible = true;                    
                    rdo12AM.Checked = true;
                    rdo6PM.Checked = false;
                    rdo12AM.Visible = false;
                    rdo6PM.Visible = false;
                    lblReportType.Visible = false;
                }
                catch
                { }
            }
        }

        //protected void rdoPending_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdoPending.Checked == true)
        //    {
        //        rdoComplete.Checked = false;
        //        //btnBillSubmit.Visible = true;
        //        //if (intReportType == 1 || intReportType == 2)
        //        //{ btnBillSubmit.Visible = true; }
        //        //else { btnBillSubmit.Visible = false; }
        //    }
        //    else { rdoPending.Checked = true; }

        //    dgvFundApproval.DataSource = "";
        //    dgvFundApproval.DataBind();
        //    dgvBillForLocalAccounts.DataSource = "";
        //    dgvBillForLocalAccounts.DataBind();

        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        //}
        //protected void rdoComplete_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdoComplete.Checked == true) { rdoPending.Checked = false; /*btnBillSubmit.Visible = false;*/ }
        //    else { rdoComplete.Checked = true; }

        //    dgvFundApproval.DataSource = "";
        //    dgvFundApproval.DataBind();
        //    dgvBillForLocalAccounts.DataSource = "";
        //    dgvBillForLocalAccounts.DataBind();

        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        //}

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            dt = obj.GetShipPointList(intUnitID);
            ddlShipPoint.DataTextField = "strName";
            ddlShipPoint.DataValueField = "intId";
            ddlShipPoint.DataSource = dt;
            ddlShipPoint.DataBind();

            dt = new DataTable();
            dt = obj.GetDriverList(intUnitID);
            ddlDriverName.DataTextField = "strEmployeeName";
            ddlDriverName.DataValueField = "intEmployeeID";
            ddlDriverName.DataSource = dt;
            ddlDriverName.DataBind();

            dgvFundApproval.DataSource = "";
            dgvFundApproval.DataBind();
            dgvBillForLocalAccounts.DataSource = "";
            dgvBillForLocalAccounts.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected void ddlShipPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFundApproval.DataSource = "";
            dgvFundApproval.DataBind();
            dgvBillForLocalAccounts.DataSource = "";
            dgvBillForLocalAccounts.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
    
        protected decimal totalrouteexp = 0;
        protected decimal totaladvance = 0;
        protected decimal totaladvance1 = 0; 
        
        protected void dgvFundApproval_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalrouteexp += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblTotalRouteExp")).Text);
                    totaladvance += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblAdvance")).Text);
                    totaladvance1 += decimal.Parse(((TextBox)e.Row.Cells[9].FindControl("txtAdvanc1")).Text);                    
                }
            }
            catch { }
        }

        protected void btnSearchV_Click(object sender, EventArgs e)
        {

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {   
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                try
                {
                    dteFromDate = DateTime.Parse(txtFromDate.Text);
                    dteToDate = DateTime.Parse(txtToDate.Text);
                }
                catch { }
                
                intShipPoint = int.Parse(ddlShipPoint.SelectedValue.ToString());
                intReportType = int.Parse(ddlReportType.SelectedValue.ToString());
                strVehicleNo = txtSearchVehicle.Text;
                intReffid = 0;
                intInsertBy = 0;

                intReffid = 0;
                monPaymentAmount = 0;
                intInsertByPayment = 0;

                dgvFundApproval.Columns[8].Visible = false;
                dgvFundApproval.Columns[9].Visible = false;
                dgvFundApproval.Columns[10].Visible = false;
                dgvFundApproval.Columns[11].Visible = false;
                dgvBillForLocalAccounts.Columns[40].Visible = false;
                dgvBillForLocalAccounts.Columns[41].Visible = false;

                lblFromToDate.Visible = false;

                ysnWonVehicle = 1;
                ysnWonV = true;

                if (intReportType == 1)
                {
                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Fund Approval Form";

                    dgvBillForLocalAccounts.DataSource = "";
                    dgvBillForLocalAccounts.DataBind();
                    dgvDriverWiseLB.DataSource = "";
                    dgvDriverWiseLB.DataBind();
                    dgvDriverLBALL.DataSource = "";
                    dgvDriverLBALL.DataBind();

                    //if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }

                    monAdvance = 0;

                    if (txtSearchVehicle.Text == "")
                    {
                        intWork = 1;
                        dt = new DataTable();
                        dt = obj.GetLocalAccountsReportForWH(intWork, intReffid, intShipPoint, ysnWonVehicle, dteFromDate, dteToDate, intInsertBy, monAdvance, strVehicleNo);
                        dgvFundApproval.DataSource = dt;
                        dgvFundApproval.DataBind();
                    }
                    else
                    {
                        intWork = 2;
                        dt = new DataTable();
                        dt = obj.GetLocalAccountsReportForWH(intWork, intReffid, intShipPoint, ysnWonVehicle, dteFromDate, dteToDate, intInsertBy, monAdvance, strVehicleNo);
                        dgvFundApproval.DataSource = dt;
                        dgvFundApproval.DataBind();
                    }
                                        
                    dgvFundApproval.Columns[9].Visible = true;
                    dgvFundApproval.Columns[11].Visible = true;

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
                    }
                    else
                    {
                        dgvFundApproval.DataSource = "";
                        dgvFundApproval.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 2)
                {
                    lblUnitName.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    lblReportName.Text = "Fund Paid Report";

                    dteNewFromDate =  Convert.ToDateTime(DateTime.Parse(txtFromDate.Text).AddDays(-1).ToString("yyyy-MM-dd"));
                    if (rdo12AM.Checked == true) { lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM"; }
                    else { lblFromToDate.Text = "For The Month of " + Convert.ToDateTime(dteNewFromDate.ToString()).ToString("yyyy-MM-dd") + " 6:00 PM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 6:00 PM"; }
                                        
                    lblFromToDate.Visible = true;

                    dgvBillForLocalAccounts.DataSource = "";
                    dgvBillForLocalAccounts.DataBind();
                    dgvDriverWiseLB.DataSource = "";
                    dgvDriverWiseLB.DataBind();
                    dgvDriverLBALL.DataSource = "";
                    dgvDriverLBALL.DataBind();

                    //if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }

                    if (txtSearchVehicle.Text == "")
                    {
                        if (rdo12AM.Checked == true) { intWork = 1;} else { intWork = 10;}   
                        dt = new DataTable();
                        dt = obj.GetLocalAccFundApprovalR(intWork, intShipPoint, dteFromDate, dteToDate, ysnWonVehicle, intReffid, monPaymentAmount, intInsertByPayment, strVehicleNo);
                        dgvFundApproval.DataSource = dt;
                        dgvFundApproval.DataBind();
                    }
                    else
                    {
                        if (rdo12AM.Checked == true) { intWork = 5; } else { intWork = 11; }  
                        dt = new DataTable();
                        dt = obj.GetLocalAccFundApprovalR(intWork, intShipPoint, dteFromDate, dteToDate, ysnWonVehicle, intReffid, monPaymentAmount, intInsertByPayment, strVehicleNo);
                        dgvFundApproval.DataSource = dt;
                        dgvFundApproval.DataBind();
                    }

                    dgvFundApproval.Columns[8].Visible = true;                    
                    dgvFundApproval.Columns[10].Visible = true;                    

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
                    }
                    else
                    {
                        dgvFundApproval.DataSource = "";
                        dgvFundApproval.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 3 || intReportType == 4 || intReportType == 7)
                {
                    Label1.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();                    
                    //Label3.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dteNewFromDate = Convert.ToDateTime(DateTime.Parse(txtFromDate.Text).AddDays(-1).ToString("yyyy-MM-dd"));
                    if (rdo12AM.Checked == true) { Label3.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM"; }
                    else { Label3.Text = "For The Month of " + Convert.ToDateTime(dteNewFromDate.ToString()).ToString("yyyy-MM-dd") + " 6:00 PM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 6:00 PM"; }
                                        
                    
                    dgvFundApproval.DataSource = "";
                    dgvFundApproval.DataBind();
                    dgvDriverWiseLB.DataSource = "";
                    dgvDriverWiseLB.DataBind();
                    dgvDriverLBALL.DataSource = "";
                    dgvDriverLBALL.DataBind();
                    

                    //if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }

                    if (intReportType == 3)
                    {
                        if (txtSearchVehicle.Text == "")
                        {
                            if (rdo12AM.Checked == true) { intWork = 2; } else { intWork = 12; }
                        }
                        else
                        {
                            if (rdo12AM.Checked == true) { intWork = 6; } else { intWork = 13; }
                        }                        
                        
                        Label2.Text = "Trip Wise Details Report of Bills For Payment";
                    }
                    else if (intReportType == 4) 
                    {                         
                        if (txtSearchVehicle.Text == "")
                        {
                            if (rdo12AM.Checked == true) { intWork = 3; } else { intWork = 14; }
                        }
                        else
                        {
                            if (rdo12AM.Checked == true) { intWork = 7; } else { intWork = 15; }
                        }

                        Label2.Text = "Trip Wise Details Bill Payment Report";
                    }
                    else if (intReportType == 7)
                    {
                        if (txtSearchVehicle.Text == "")
                        {
                            if (rdo12AM.Checked == true) { intWork = 22; } else { intWork = 23; }
                        }
                        else
                        {
                            if (rdo12AM.Checked == true) { intWork = 20; } else { intWork = 21; }
                        }

                        Label2.Text = "Trip Wise Details Bill Entry Report";
                    }

                    dt = new DataTable();
                    dt = obj.GetLocalAccFundApprovalR(intWork, intShipPoint, dteFromDate, dteToDate, ysnWonVehicle, intReffid, monPaymentAmount, intInsertByPayment, strVehicleNo);
                    dgvBillForLocalAccounts.DataSource = dt;
                    dgvBillForLocalAccounts.DataBind();

                    dgvBillForLocalAccounts.Columns[40].Visible = false;
                    dgvBillForLocalAccounts.Columns[41].Visible = false;
                    dgvBillForLocalAccounts.Columns[39].Visible = false;
                    dgvBillForLocalAccounts.Columns[42].Visible = false;

                    if (intReportType == 3)
                    {
                        dgvBillForLocalAccounts.Columns[40].Visible = false;
                        dgvBillForLocalAccounts.Columns[41].Visible = false;
                        dgvBillForLocalAccounts.Columns[39].Visible = true;
                        dgvBillForLocalAccounts.Columns[42].Visible = true;
                    }
                    else if(intReportType == 4)
                    {
                        dgvBillForLocalAccounts.Columns[40].Visible = true;
                        dgvBillForLocalAccounts.Columns[41].Visible = true;
                        dgvBillForLocalAccounts.Columns[39].Visible = false;
                        dgvBillForLocalAccounts.Columns[42].Visible = false;
                    }
                    
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid2();", true);
                    }
                    else
                    {
                        dgvFundApproval.DataSource = "";
                        dgvFundApproval.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 5)
                {
                    Label4.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label5.Text = "Driver Ledger " + "(" + ddlDriverName.SelectedItem.ToString() + ")";
                    //Label6.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dteNewFromDate = Convert.ToDateTime(DateTime.Parse(txtFromDate.Text).AddDays(-1).ToString("yyyy-MM-dd"));
                    if (rdo12AM.Checked == true) { Label6.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM"; }
                    else { Label6.Text = "For The Month of " + Convert.ToDateTime(dteNewFromDate.ToString()).ToString("yyyy-MM-dd") + " 6:00 PM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 6:00 PM"; }
                          
                    dgvBillForLocalAccounts.DataSource = "";
                    dgvBillForLocalAccounts.DataBind();
                    dgvFundApproval.DataSource = "";
                    dgvFundApproval.DataBind();
                    dgvDriverLBALL.DataSource = "";
                    dgvDriverLBALL.DataBind();

                    if (txtSearchEnroll.Text == "")
                    {
                        intDrverEnroll = int.Parse(ddlDriverName.SelectedValue.ToString());
                    }
                    else
                    {
                        try 
                        { 
                            intDrverEnroll = int.Parse(txtSearchEnroll.Text);
                            ddlDriverName.SelectedValue = intDrverEnroll.ToString();
                            Label5.Text = "Driver Ledger " + "(" + ddlDriverName.SelectedItem.ToString() + ")";
                        }
                        catch { intDrverEnroll = 0; }
                    }

                    //if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }

                    if (rdo12AM.Checked == true) { intWork = 1; } else { intWork = 2; }

                    dt = new DataTable();
                    dt = obj.GetDriverWiseLedgerBNew(intWork, dteFromDate, dteToDate, intDrverEnroll, intShipPoint);
                    dgvDriverWiseLB.DataSource = dt;
                    dgvDriverWiseLB.DataBind();
                    
                    //dgvFundApproval.Columns[9].Visible = true;
                    //dgvFundApproval.Columns[11].Visible = true;

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid3();", true);
                    }
                    else
                    {
                        dgvDriverWiseLB.DataSource = "";
                        dgvDriverWiseLB.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 6)
                {
                    Label7.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label8.Text = "Accounts Schedule of Driver";
                    //Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dteNewFromDate = Convert.ToDateTime(DateTime.Parse(txtFromDate.Text).AddDays(-1).ToString("yyyy-MM-dd"));
                    if (rdo12AM.Checked == true) { Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM"; }
                    else { Label9.Text = "For The Month of " + Convert.ToDateTime(dteNewFromDate.ToString()).ToString("yyyy-MM-dd") + " 6:00 PM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 6:00 PM"; }
                       
                    dgvBillForLocalAccounts.DataSource = "";
                    dgvBillForLocalAccounts.DataBind();
                    dgvFundApproval.DataSource = "";
                    dgvFundApproval.DataBind();
                    dgvDriverWiseLB.DataSource = "";
                    dgvDriverWiseLB.DataBind();
                    
                    if (txtSearchEnroll.Text == "")
                    {
                        intDrverEnroll = 0;
                        if (rdo12AM.Checked == true) { intWork = 1; } else { intWork = 3; }
                    }
                    else
                    {
                        try { intDrverEnroll = int.Parse(txtSearchEnroll.Text); }
                        catch { intDrverEnroll = 0;}
                        if (rdo12AM.Checked == true) { intWork = 2; } else { intWork = 4; }
                    }

                    //if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }

                    monAdvance = 0;                    
                    dt = new DataTable();
                    dt = obj.GetLedgerBalanceAllNew(intWork, dteFromDate, dteToDate, intShipPoint, intDrverEnroll);
                    dgvDriverLBALL.DataSource = dt;
                    dgvDriverLBALL.DataBind();
                                        
                    //dgvFundApproval.Columns[9].Visible = true;
                    //dgvFundApproval.Columns[11].Visible = true;

                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid4();", true);
                    }
                    else
                    {
                        dgvDriverLBALL.DataSource = "";
                        dgvDriverLBALL.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
                }
                else if (intReportType == 8)
                {
                    Label10.Text = ddlUnit.SelectedItem.ToString() + ", " + ddlShipPoint.SelectedItem.ToString();
                    Label11.Text = "Trip Wise Cash Receive";
                    //Label9.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                    dteNewFromDate = Convert.ToDateTime(DateTime.Parse(txtFromDate.Text).AddDays(-1).ToString("yyyy-MM-dd"));
                    if (rdo12AM.Checked == true) { Label12.Text = "For The Month of " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 12:00 AM"; }
                    else { Label12.Text = "For The Month of " + Convert.ToDateTime(dteNewFromDate.ToString()).ToString("yyyy-MM-dd") + " 6:00 PM To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd") + " 6:00 PM"; }
                       
                    dgvBillForLocalAccounts.DataSource = "";
                    dgvBillForLocalAccounts.DataBind();
                    dgvDriverWiseLB.DataSource = "";
                    dgvDriverWiseLB.DataBind();
                    dgvDriverLBALL.DataSource = "";
                    dgvDriverLBALL.DataBind();

                    //if (rdoComplete.Checked == true) { intBillStatus = 1; } else { intBillStatus = 0; }

                    monAdvance = 0;
                    if (txtSearchVehicle.Text == "") { intWork = 4;} else { intWork = 5;}                    
                        
                    dt = new DataTable();
                    dt = obj.GetLocalAccountsReportForWH(intWork, intReffid, intShipPoint, ysnWonVehicle, dteFromDate, dteToDate, intInsertBy, monAdvance, strVehicleNo);
                    dgvCashReceiveAndAdjustment.DataSource = dt;
                    dgvCashReceiveAndAdjustment.DataBind();
                   
                   
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGrid1();", true);
                    }
                    else
                    {
                        dgvCashReceiveAndAdjustment.DataSource = "";
                        dgvCashReceiveAndAdjustment.DataBind();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
                    }
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
        protected decimal totalrouteexp1 = 0; 
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
        protected decimal totalpayalbe = 0;
        protected decimal totaladvanc = 0;
        protected decimal totalpaidamount = 0;
        protected decimal totalpaidam = 0;
        protected void dgvBillForLocalAccounts_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    millage += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblMillagekm")).Text);
                    almillage += decimal.Parse(((Label)e.Row.Cells[10].FindControl("lblAMillage")).Text);
                    totalmillage += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblMillage")).Text);

                    //totaldieseltk += decimal.Parse(((Label)e.Row.Cells[12].FindControl("lblDieselTk")).Text);
                    totaldieseltk += decimal.Parse(((Label)e.Row.Cells[12].FindControl("btnDslVew")).Text);

                    totalcngtk += decimal.Parse(((Label)e.Row.Cells[13].FindControl("btnCngVew")).Text);

                    totalferry += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblFerryExp")).Text);
                    totalbridge += decimal.Parse(((Label)e.Row.Cells[15].FindControl("lblBridgeExp")).Text);

                    totalmaintenance += decimal.Parse(((Label)e.Row.Cells[16].FindControl("lblMaintanance")).Text);

                    totalpolice += decimal.Parse(((Label)e.Row.Cells[17].FindControl("lblpolice")).Text);
                    totallabour += decimal.Parse(((Label)e.Row.Cells[18].FindControl("lblLabour")).Text);

                    totalOther += decimal.Parse(((Label)e.Row.Cells[19].FindControl("btnOtherVew")).Text);

                    totalmillageallow += decimal.Parse(((Label)e.Row.Cells[20].FindControl("lblMillageAllow")).Text);
                    totaldtripallow += decimal.Parse(((Label)e.Row.Cells[21].FindControl("lblDTripAllow")).Text);
                    totaldailyallow += decimal.Parse(((Label)e.Row.Cells[22].FindControl("lblDailyAllow")).Text);
                    totaltripbonus += decimal.Parse(((Label)e.Row.Cells[23].FindControl("lblTripBonus")).Text);
                    totaltimeallow += decimal.Parse(((Label)e.Row.Cells[24].FindControl("lblTimeAllow")).Text);
                    totalfuelcash += decimal.Parse(((Label)e.Row.Cells[25].FindControl("lblFuelCash")).Text);
                    totalrouteexp1 += decimal.Parse(((Label)e.Row.Cells[26].FindControl("lblTotalRouteExp")).Text);
                    totaltripfare += decimal.Parse(((Label)e.Row.Cells[27].FindControl("lblTripFare")).Text);
                    totaladitionalfare += decimal.Parse(((Label)e.Row.Cells[28].FindControl("lblAdditionalFare")).Text);
                    totalfareaditionalfare += decimal.Parse(((Label)e.Row.Cells[29].FindControl("lblFareAdditionalFare")).Text);
                    totaldtfcash += decimal.Parse(((Label)e.Row.Cells[30].FindControl("lblDTFCash")).Text);
                    totaldtfcredit += decimal.Parse(((Label)e.Row.Cells[31].FindControl("lblDTFCredit")).Text);
                    totalTotaltripfare += decimal.Parse(((Label)e.Row.Cells[32].FindControl("lblTotalTripFare")).Text);
                    totaldieseltotalcredit += decimal.Parse(((Label)e.Row.Cells[33].FindControl("lblDieselTotalCredit")).Text);
                    totalcngtotalcredit += decimal.Parse(((Label)e.Row.Cells[34].FindControl("lblCNGTotalCredit")).Text);
                    totalnetincome += decimal.Parse(((Label)e.Row.Cells[35].FindControl("lblNetIncome")).Text);
                    totalpayalbe += decimal.Parse(((Label)e.Row.Cells[36].FindControl("lblTpayable")).Text);
                    totaladvanc += decimal.Parse(((Label)e.Row.Cells[37].FindControl("lbladvanc")).Text);
                    totalnetpayable += decimal.Parse(((Label)e.Row.Cells[38].FindControl("lblNetPayable")).Text);
                    totalpaidamount += decimal.Parse(((TextBox)e.Row.Cells[39].FindControl("txtPaidAmount")).Text);
                    totalpaidam += decimal.Parse(((Label)e.Row.Cells[40].FindControl("lblPaidAm")).Text);                         
                    
                }
                //else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true); }
            }
            catch { }
        }
        protected void btnBillSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDriver.Visible = false;
            ddlDriverName.Visible = false;
            lblSearchEnroll.Visible = false;
            txtSearchEnroll.Visible = false;
            lblSearchVehicle.Visible = true;
            txtSearchVehicle.Visible = true;

            rdo12AM.Visible = true;
            rdo6PM.Visible = true;
            lblReportType.Visible = true;

            intReportType = int.Parse(ddlReportType.SelectedValue.ToString());
            if (intReportType == 1)
            {
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                lblToDate.Visible = false;
                txtToDate.Visible = false;

                rdo12AM.Visible = false;
                rdo6PM.Visible = false;
                lblReportType.Visible = false;
            }
            else if (intReportType == 2)
            {
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                lblToDate.Visible = true;
                txtToDate.Visible = true;  
              
            }
            else if (intReportType == 3 || intReportType == 4 || intReportType == 7 || intReportType == 8)
            {
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                lblToDate.Visible = true;
                txtToDate.Visible = true;                
            }
            else if (intReportType == 5)
            {
                lblDriver.Visible = true;
                ddlDriverName.Visible = true;
                lblSearchEnroll.Visible = true;
                txtSearchEnroll.Visible = true;
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                lblToDate.Visible = true;
                txtToDate.Visible = true;
                lblSearchVehicle.Visible = false;
                txtSearchVehicle.Visible = false;
            }
            else if (intReportType == 6)
            {
                lblSearchEnroll.Visible = true;
                txtSearchEnroll.Visible = true;
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                lblToDate.Visible = true;
                txtToDate.Visible = true;
                lblSearchVehicle.Visible = false;
                txtSearchVehicle.Visible = false;
            }

            dgvFundApproval.DataSource = "";
            dgvFundApproval.DataBind();
            dgvBillForLocalAccounts.DataSource = "";
            dgvBillForLocalAccounts.DataBind();
            dgvDriverWiseLB.DataSource = "";
            dgvDriverWiseLB.DataBind();
            dgvDriverLBALL.DataSource = dt;
            dgvDriverLBALL.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);

        }
        protected void SubmitAdvance_Click(object sender, EventArgs e) 
        {
            if (hdnconfirm.Value == "1")
            {                 
                string senderdata = ((Button)sender).CommandArgument.ToString();
                string strSearchKey = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = Regex.Split(strSearchKey, ",");                
                string strdex = searchKey[1]; 
                string strReffid = searchKey[0];

                int index = int.Parse(strdex.ToString());
                monAdvance = decimal.Parse(((TextBox)dgvFundApproval.Rows[index].FindControl("txtAdvanc1")).Text.ToString());
                strVehicleNo = "";

                DataSet dsGrid = (DataSet)dgvFundApproval.DataSource;
                //string chek = dsGrid.Tables[0].Rows[e.RowIndex][9].ToString();
                
                //monAdvance = ((Label)e.Row.FindControl("lblSecret"));
                //monAdvance = dsGrid.Tables[9].Rows[dgvFundApproval.Rows[e.RowIndex].DataItemIndex].Delete();
                                
                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                ///ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + senderdata + "');", true); return;
                intReffid = int.Parse(strReffid.ToString());
                intWork = 3;
                dt = new DataTable();
                dt = obj.GetLocalAccountsReportForWH(intWork, intReffid, intShipPoint, ysnWonVehicle, dteFromDate, dteToDate, intInsertBy, monAdvance, strVehicleNo);
                
                LoadGrid();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Submit Successfully.');", true);
            }
        }
        protected void SubmitBillPayment_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                string strSearchKey = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = Regex.Split(strSearchKey, ",");
                string strdex = searchKey[1];
                string strReffid = searchKey[0];
                intReffid = int.Parse(strReffid.ToString());

                int index = int.Parse(strdex.ToString());
                monPaymentAmount = decimal.Parse(((TextBox)dgvBillForLocalAccounts.Rows[index].FindControl("txtPaidAmount")).Text.ToString());

                strVehicleNo = "";

                dt = new DataTable();
                dt = obj.GetPaymentAmountCheck(intReffid);
                if (dt.Rows.Count > 0)
                {
                    NetPayable = decimal.Parse(dt.Rows[0]["monNetPayable"].ToString());
                    PaidAmount = decimal.Parse(dt.Rows[0]["monLocalAccountsBillPayment"].ToString());
                }
                if ((NetPayable > (PaidAmount + monPaymentAmount)) || (NetPayable == (PaidAmount + monPaymentAmount)))
                {
                    intInsertByPayment = int.Parse(Session[SessionParams.USER_ID].ToString());

                    ///ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + senderdata + "');", true); return;
                    intReffid = int.Parse(strReffid.ToString());
                    intWork = 4;
                    dt = new DataTable();
                    dt = dt = obj.GetLocalAccFundApprovalR(intWork, intShipPoint, dteFromDate, dteToDate, ysnWonVehicle, intReffid, monPaymentAmount, intInsertByPayment, strVehicleNo);

                    LoadGrid();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Submit Successfully.');", true);
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Check Payment Amount Check.');", true); return; }
                                
            }
        }
        protected void TripDetails_Click(object sender, EventArgs e)
        {
            string senderdata = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "TripDetails('" + senderdata + "');", true);            
        }
        protected void btnDocVew_Click(object sender, EventArgs e)
        {
            intDoct = 0;
            HttpContext.Current.Session["intDoct"] = intDoct.ToString();

            string senderdata = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ViewDocList('" + senderdata + "');", true);
            

        }

        protected decimal totaldebit = 0;
        protected decimal totalcredit = 0;
        protected decimal totalbalance = 0;

        protected void dgvDriverWiseLB_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totaldebit += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblDebit")).Text);
                    totalcredit += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblCredit")).Text);
                    totalbalance = decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblBalance")).Text);
                }
            }
            catch { }
        }
        
        protected decimal totalOpening = 0;
        protected decimal totaldebit1 = 0;
        protected decimal totalcredit1 = 0;
        protected decimal totalbalance1 = 0;

        protected void dgvDriverLBALL_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalOpening += decimal.Parse(((Label)e.Row.Cells[3].FindControl("lblOpening")).Text);
                    totaldebit1 += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblDebit")).Text);
                    totalcredit1 += decimal.Parse(((Label)e.Row.Cells[5].FindControl("lblCredit")).Text);
                    totalbalance1 += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblBalance")).Text);
                }
            }
            catch { }
        }

        protected void rdo12AM_CheckedChanged(object sender, EventArgs e)
        {

            if (rdo12AM.Checked == true) { rdo6PM.Checked = false; }
            else { rdo12AM.Checked = true; }

            dgvFundApproval.DataSource = "";
            dgvFundApproval.DataBind();
            dgvBillForLocalAccounts.DataSource = "";
            dgvBillForLocalAccounts.DataBind();
            dgvDriverWiseLB.DataSource = "";
            dgvDriverWiseLB.DataBind();
            dgvDriverLBALL.DataSource = "";
            dgvDriverLBALL.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }
        protected void rdo6PM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo6PM.Checked == true) { rdo12AM.Checked = false; }
            else { rdo6PM.Checked = true; }

            dgvFundApproval.DataSource = "";
            dgvFundApproval.DataBind();
            dgvBillForLocalAccounts.DataSource = "";
            dgvBillForLocalAccounts.DataBind();
            dgvDriverWiseLB.DataSource = "";
            dgvDriverWiseLB.DataBind();
            dgvDriverLBALL.DataSource = "";
            dgvDriverLBALL.DataBind();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "hideGridAll();", true);
        }

        protected decimal totalNetP = 0;
        protected decimal totalrec = 0;           
       
        protected void dgvCashReceiveAndAdjustment_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalNetP += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblNetPay")).Text);
                    totalrec += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblCashR")).Text);                            
                }
            }
            catch { }
        }

        protected void SubmitCashRAndAddj_Click(object sender, EventArgs e) 
        {
            if (hdnconfirm.Value == "1")
            {
                string senderdata = ((Button)sender).CommandArgument.ToString();
                string strSearchKey = ((Button)sender).CommandArgument.ToString();
                string[] searchKey = Regex.Split(strSearchKey, ",");
                string strdex = searchKey[1];
                string strReffid = searchKey[0];

                int index = int.Parse(strdex.ToString());
                monCashR = decimal.Parse(((TextBox)dgvCashReceiveAndAdjustment.Rows[index].FindControl("txtCashR")).Text.ToString());               
                strVehicleNo = "";
                monAdvance = monCashR;

                //DataSet dsGrid = (DataSet)dgvCashReceiveAndAdjustment.DataSource;
                //string chek = dsGrid.Tables[0].Rows[e.RowIndex][9].ToString();

                //monAdvance = ((Label)e.Row.FindControl("lblSecret"));
                //monAdvance = dsGrid.Tables[9].Rows[dgvFundApproval.Rows[e.RowIndex].DataItemIndex].Delete();

                intInsertBy = int.Parse(Session[SessionParams.USER_ID].ToString());

                ///ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + senderdata + "');", true); return;
                intReffid = int.Parse(strReffid.ToString());
                intWork = 6;
                dt = new DataTable();
                dt = obj.GetLocalAccountsReportForWH(intWork, intReffid, intShipPoint, ysnWonVehicle, dteFromDate, dteToDate, intInsertBy, monAdvance, strVehicleNo);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Submit Successfully.');", true);
                LoadGrid();                
            }
        }







    }
}