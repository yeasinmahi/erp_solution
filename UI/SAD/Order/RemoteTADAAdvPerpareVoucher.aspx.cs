using SAD_BLL.Customer.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Order
{
    public partial class RemoteTADAAdvPerpareVoucher : BasePage
    {
        int intApplicationID; string strPayTo; decimal monAmount; DateTime dteInstrumentDate; DateTime dteTourstart;
        string strMassage; int intUser;
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new StatementC();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                try
                {
                   

                    hdnAreamanagerEnrol.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch { }
                ////-----**----------//
            }
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExportToExcels);
 }

        protected void btnShow_Click(object sender, EventArgs e)
        {
           int intReportType = int.Parse(ddlAccountReportType.SelectedValue.ToString());
            DateTime dteFromDate = DateTime.Parse(txtFromDate.Text);
            DateTime dteToDate = DateTime.Parse(txtToDate.Text);
            int intUnitID = int.Parse(drdlUnit.SelectedValue.ToString());
            int intBankID = int.Parse(ddlPaymentFor.SelectedValue.ToString());
            if (intReportType == 1)
            {
                loadgrid();
            }
            else if (intReportType == 3)
            {

                dt = new DataTable();
                dt = bll.getTADAAdvanceDetaills(dteFromDate, dteToDate, intUnitID, intReportType);
                grdvTADAAdvanceDetaills.DataSource = dt;
                grdvTADAAdvanceDetaills.DataBind();

            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('There is no data aganist your Querry');", true);
            }

        }

        private void loadgrid()
        {
            
             DateTime   dteFromDate = DateTime.Parse(txtFromDate.Text);
             DateTime dteToDate = DateTime.Parse(txtToDate.Text);
             int intUnitID = int.Parse(drdlUnit.SelectedValue.ToString());
            int  intBankID = int.Parse(ddlPaymentFor.SelectedValue.ToString());
           
            dt = new DataTable();
            dt = bll.getDataForCreateVoucherForTADAAdvance(dteFromDate, dteToDate, intUnitID, intBankID);
            dvgReport.DataSource = dt;
            dvgReport.DataBind();


        }




        protected void dgvReportForPrepareVoucher_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected decimal grandtotal = 0;
        protected void dvgReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                grandtotal += decimal.Parse(((Label)e.Row.Cells[9].FindControl("lblGrandTotal")).Text);
                Decimal CellValueCoaID = Convert.ToDecimal(e.Row.Cells[9].Text);

           if (CellValueCoaID > 0)
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Green;
                }

                else
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
            }


          


        }

    

        protected void PrepareVoucher_Click1(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                intApplicationID = int.Parse(searchKey[0].ToString());
                strPayTo = searchKey[1].ToString();
                monAmount = decimal.Parse(searchKey[2].ToString());
                intUser = int.Parse(searchKey[4].ToString());
                string strDetaills = searchKey[5].ToString();
                int insertby = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dteInstrumentDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtInstrumentDate.Text).Value;
                dteTourstart = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtInstrumentDate.Text).Value;
                int ModeofPayment = 1;
                strMassage = bll.InsertTADAAdvanceVoucher(intApplicationID, strPayTo, ModeofPayment, monAmount, intUser, dteInstrumentDate, dteTourstart, insertby, strDetaills);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strMassage + "');", true);
                loadgrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + strMassage + "');", true);
            }
               

        }

        protected void grdvTADAAdvanceDetaills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void btnExportToExcels_Click(object sender, EventArgs e)
        {
            try {
                grdvTADAAdvanceDetaills.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("EmployeeProfile.xls", grdvTADAAdvanceDetaills);
            }
            catch {}
        }

        protected void drdlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }










    }
}