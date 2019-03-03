using SAD_BLL.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class RmtTADARptNoEmailEmployee : System.Web.UI.Page
    {
        char[] delimiterChars = { '[',']' }; string[] arrayKey;
        
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        SalesView bllanother = new SalesView();
        DataTable dtTopsh = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlUpperControl.DataBind();
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            loadgrid();
        }
        private void loadgrid()
        {
            int areaID = int.Parse(drdlArea.SelectedValue.ToString());
            int unitid = int.Parse(drdlUnit.SelectedValue.ToString());
            int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
            int jobstationid = int.Parse(hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            int FuelStationid = int.Parse(drdlSupplierName.SelectedValue.ToString());
            string strSearchKey = txtFullName.Text;
            arrayKey = strSearchKey.Split(delimiterChars);
            string code = arrayKey[1].ToString();
            string strCustname = strSearchKey;
            int enrol = int.Parse(code);
            if (rptTypeid == 1)               //Detaills report for None email individual
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;


                    dt = bll.getReportForNoEmailAddressEmployee(dteFromDate, dteToDate, areaID, unitid, rptTypeid, enrol);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {

                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;

                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                   
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvForNoofficeEmailDetaills.DataSource = dt;
                    grdvForNoofficeEmailDetaills.DataBind();

                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("decRowTotalT"));
                    grdvForNoofficeEmailDetaills.FooterRow.Cells[3].Text = "Total";
                    grdvForNoofficeEmailDetaills.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    grdvForNoofficeEmailDetaills.FooterRow.Cells[21].Text = total.ToString("N2");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 2)               //Topsheet report all no email employees
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    dt = bll.getReportForNoEmailAddressEmployee(dteFromDate, dteToDate, areaID, unitid, rptTypeid, enrol);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                   
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvTopsheetallEmploye.DataSource = dt;
                    grdvTopsheetallEmploye.DataBind();


                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }


            else if (rptTypeid == 5)               //Employees vs GrandTotal
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    dt = bll.getReportForNoEmailAddressEmployee(dteFromDate, dteToDate, areaID, unitid, rptTypeid, enrol);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                   
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = dt;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();


                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }

            }
            else if (rptTypeid == 8)               //Transport Date Basis Report
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    dt = bll.getRptStandVheicleDateBasis(dteFromDate, dteToDate, enrol, rptTypeid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = dt;
                    grdvRptStandVheicleDayBasis.DataBind();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 12)               //standvheiclle Summery report
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    dt = bll.getRptStandVheicleDateBasis(dteFromDate, dteToDate, enrol, rptTypeid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvRptStandVheicleSummery.DataSource = dt;
                    grdvRptStandVheicleSummery.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 10)               //standvheiclle oil report
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    dt = bll.getRptStandVheicleDateBasis(dteFromDate, dteToDate, enrol, rptTypeid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvOnlyOilReport.DataSource = dt;
                    grdvOnlyOilReport.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }


            else if (rptTypeid == 11)               //standvheiclle Only Gas report
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    dt = bll.getRptStandVheicleDateBasis(dteFromDate, dteToDate, enrol, rptTypeid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                   
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvRptOnlyCNG.DataSource = dt;
                    grdvRptOnlyCNG.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 9)               //Credit station bill without stand by vheicle report
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    strSearchKey = txtFullName.Text;
                    arrayKey = strSearchKey.Split(delimiterChars);
                    code = arrayKey[1].ToString();
                    strCustname = strSearchKey;
                    enrol = int.Parse(code);
                    dt = bll.getRptCreditStationCNGBill(dteFromDate, dteToDate, enrol, jobstationid, unitid, FuelStationid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = dt;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    decimal tdecTotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("decTotal"));
                    grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[6].Text = "Total";
                    grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                    grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[7].Text = tdecTotal.ToString("N2");

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 16)               //Credit station vs Employee cost 
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    //dt = bll.GetCreditstationvsEmployeecost(dteFromDate, dteToDate, enrol, rptTypeid);

                    if (dt.Rows.Count > 0)
                    {
                       
                        grdvForNoofficeEmailDetaills.DataSource = null;
                        grdvForNoofficeEmailDetaills.DataBind();
                        grdvTopsheetallEmploye.DataSource = null;
                        grdvTopsheetallEmploye.DataBind();
                        grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                        grdvNameVsTotalBillforNOemailemployee.DataBind();
                        grdvRptStandVheicleDayBasis.DataSource = null;
                        grdvRptStandVheicleDayBasis.DataBind();
                        grdvRptStandVheicleSummery.DataSource = null;
                        grdvRptStandVheicleSummery.DataBind();
                        grdvOnlyOilReport.DataSource = null;
                        grdvOnlyOilReport.DataBind();
                        grdvRptOnlyCNG.DataSource = null;
                        grdvRptOnlyCNG.DataBind();
                        grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                        grdvCreditStationBillWithoutStandVheicle.DataBind();
                        grdvOnlyCreditStationBill.DataSource = null;
                        grdvOnlyCreditStationBill.DataBind();
                        grdvCreditstationbillEmployeebase.DataSource = null;
                        grdvCreditstationbillEmployeebase.DataBind();
                        grdvFuelCreditStationbillvsEmployee.DataSource = dt;
                        grdvFuelCreditStationbillvsEmployee.DataBind();
                        //decimal totalGas = dt.AsEnumerable().Sum(row => row.Field<decimal>("GasTotal"));
                        //grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[6].Text = "Total";
                        //grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                        //grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[7].Text = totalGas.ToString("N2");
                        //decimal totaloil = dt.AsEnumerable().Sum(row => row.Field<decimal>("decOilamount"));
                        //grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[9].Text = totaloil.ToString("N2");
                        //decimal GrandTotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("GrandTotal"));
                        //grdvFuelCreditStationbillvsEmployee.FooterRow.Cells[10].Text = GrandTotal.ToString("N2");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }

                }

                catch
                {

                }
            


            


            }



            else if (rptTypeid == 15)               //Credit station bill vs Employee Enrol report
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    dt = bll.getRptCreditStationVSEmployee(dteFromDate, dteToDate, jobstationid, unitid, rptTypeid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    grdvOnlyCreditStationBill.DataSource = dt;
                    grdvOnlyCreditStationBill.DataBind();
                    decimal totalCNGOILAmount = dt.AsEnumerable().Sum(row => row.Field<decimal>("decCNGOILAmount"));
                    grdvOnlyCreditStationBill.FooterRow.Cells[1].Text = "Total";
                    grdvOnlyCreditStationBill.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    grdvOnlyCreditStationBill.FooterRow.Cells[2].Text = totalCNGOILAmount.ToString("N2");
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 1027 || rptTypeid == 1026 || rptTypeid == 1025)               //Credit station bill vs Employee Enrol report
            {
              
                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    dt = bll.getrptforTADACreditstation(dteFromDate, dteToDate, jobstationid, unitid, rptTypeid, areaID, FuelStationid, enrol);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();
                    
                    grdvCreditstationbillEmployeebase.DataSource = dt;
                    grdvCreditstationbillEmployeebase.DataBind();
                    decimal totalcngcredit = dt.AsEnumerable().Sum(row => row.Field<decimal>("totalcngcredit1"));
                    grdvCreditstationbillEmployeebase.FooterRow.Cells[3].Text = "Total";
                    grdvCreditstationbillEmployeebase.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    grdvCreditstationbillEmployeebase.FooterRow.Cells[4].Text = totalcngcredit.ToString("N2");


                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }
            else if (rptTypeid == 1033)               //Credit station bill vs Employee Enrol report
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    dt = bll.getrptforTADAPersonalBreakge(dteFromDate, dteToDate, unitid, rptTypeid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    grdvForNoofficeEmailDetaills.DataSource = null;
                    grdvForNoofficeEmailDetaills.DataBind();
                    grdvTopsheetallEmploye.DataSource = null;
                    grdvTopsheetallEmploye.DataBind();
                    grdvNameVsTotalBillforNOemailemployee.DataSource = null;
                    grdvNameVsTotalBillforNOemailemployee.DataBind();
                    grdvRptStandVheicleDayBasis.DataSource = null;
                    grdvRptStandVheicleDayBasis.DataBind();
                    grdvRptStandVheicleSummery.DataSource = null;
                    grdvRptStandVheicleSummery.DataBind();
                    grdvOnlyOilReport.DataSource = null;
                    grdvOnlyOilReport.DataBind();
                    grdvRptOnlyCNG.DataSource = null;
                    grdvRptOnlyCNG.DataBind();
                    grdvCreditStationBillWithoutStandVheicle.DataSource = null;
                    grdvCreditStationBillWithoutStandVheicle.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvOnlyCreditStationBill.DataSource = null;
                    grdvOnlyCreditStationBill.DataBind();

                    grdvCreditstationbillEmployeebase.DataSource = null;
                    grdvCreditstationbillEmployeebase.DataBind();
                    dgvPerkiloMlgAnalysis.DataSource = dt;
                    dgvPerkiloMlgAnalysis.DataBind();
                   


                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }





            else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }









            }
        

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }

        protected void grdvForNoofficeEmailDetaills_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvForNoofficeEmailDetaills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvForNoofficeEmailDetaills.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvRptStandVheicleDayBasis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvRptStandVheicleDayBasis.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvRptStandVheicleDayBasis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void grdvTopsheetallEmploye_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvTopsheetallEmploye_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvTopsheetallEmploye.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvNameVsTotalBillforNOemailemployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvNameVsTotalBillforNOemailemployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvNameVsTotalBillforNOemailemployee.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvRptStandVheicleDayBasis_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdvRptStandVheicleDayBasis.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvRptStandVheicleDayBasis_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvRptStandVheicleSummery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvRptStandVheicleSummery.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvRptStandVheicleSummery_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOnlyOilReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvOnlyOilReport.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvOnlyOilReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvRptOnlyCNG_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvRptOnlyCNG.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvRptOnlyCNG_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvCreditStationBillWithoutStandVheicle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvCreditStationBillWithoutStandVheicle.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvCreditStationBillWithoutStandVheicle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvFuelCreditStationbillvsEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvFuelCreditStationbillvsEmployee.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvFuelCreditStationbillvsEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvOnlyCreditStationBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvOnlyCreditStationBill.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvOnlyCreditStationBill_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void drdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdvCreditstationbillEmployeebase_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvCreditstationbillEmployeebase.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvCreditstationbillEmployeebase_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvEntryByAnotherBikeCarUserDetaills_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvEntryByAnotherBikeCarUserDetaills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dgvPerkiloMlgAnalysis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}