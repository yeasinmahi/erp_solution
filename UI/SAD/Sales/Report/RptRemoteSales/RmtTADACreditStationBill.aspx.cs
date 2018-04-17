using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class RmtTADACreditStationBill : System.Web.UI.Page
    {

        char[] delimiterChars = { '[', ']' }; string[] arrayKey;
        int jobstation;
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        DataTable dtTopsh = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //pnlUpperControl.DataBind();
            hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
            hdnstation.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            loadgrid();
        }
      
        private void loadgrid()
        {
           
            int unitid = int.Parse(drdlUnit.SelectedValue.ToString());
            int jobstation = int.Parse(ddlJobStation.SelectedValue.ToString());
            int rptTypeid = int.Parse(drdlReportType.SelectedValue.ToString());
           
            int FuelStationid = int.Parse(drdlSupplierName.SelectedValue.ToString());
            

            if (rptTypeid == 16)               //Credit station vs Employee cost
            {
                string strSearchKey = txtEmployeeSearch.Text;
                arrayKey = strSearchKey.Split(delimiterChars);
                string code = arrayKey[1].ToString();
                string strCustname = strSearchKey;
                int enrol = int.Parse(code);
               
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtTo.Text).Value;
                dt = bll.GetCreditstationvsEmployeecost(dteFromDate, dteToDate, enrol, rptTypeid);

                if (dt.Rows.Count > 0)
                    {
                    grdvStationvsAllunit.DataSource = null;
                    grdvStationvsAllunit.DataBind();
                    grdvFuelCreditStationbillvsEmployee.DataSource = dt;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                      

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }

                }

                else  if (rptTypeid == 1025 || rptTypeid == 1026 || rptTypeid == 1028)               //Station vs All unit  //Station vs Specific job station//Station vs Specific Unit
            {
                
                
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFrom.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtTo.Text).Value;
                dt = bll.GetCreditstationvsJobstation(dteFromDate, dteToDate, unitid, jobstation, rptTypeid, FuelStationid);

                if (dt.Rows.Count > 0)
                    {

                    grdvFuelCreditStationbillvsEmployee.DataSource = null;
                    grdvFuelCreditStationbillvsEmployee.DataBind();
                    grdvStationvsAllunit.DataSource = dt;
                    grdvStationvsAllunit.DataBind();
                    decimal totalbill = dt.AsEnumerable().Sum(row => row.Field<decimal>("decbill"));
                    grdvStationvsAllunit.FooterRow.Cells[1].Text = "Total";
                    grdvStationvsAllunit.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    grdvStationvsAllunit.FooterRow.Cells[5].Text = totalbill.ToString("N2");
                    

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
       

        protected void drdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}