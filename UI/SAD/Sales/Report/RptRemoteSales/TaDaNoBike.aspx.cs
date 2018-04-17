using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.SAD.Sales.Report.RptRemoteSales
{
    public partial class TaDaNoBike : BasePage
    {
        DataTable dt = new DataTable();
        SAD_BLL.Customer.Report.StatementC bll = new SAD_BLL.Customer.Report.StatementC();
        DataTable dtTopsh = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now.AddDays(-1));
                txtToDate.Text = CommonClass.GetShortDateAtLocalDateFormat(DateTime.Now);
                //pnlUpperControl.DataBind();
                hdnenroll.Value = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                hdnDepartment.Value = HttpContext.Current.Session[SessionParams.DEPT_ID].ToString();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadgrid();
        }
        private void loadgrid()
        {
            int intDeptid = int.Parse(HttpContext.Current.Session[SessionParams.DEPT_ID].ToString());
            int userTypeid = int.Parse(ddlUserType.SelectedValue.ToString());
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            int deptid = int.Parse(hdnDepartment.Value);
            int jobstation = int.Parse(HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString());
            if (rptTypeid == 1 && userTypeid == 2)               //Detaills report None car user  
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                    int enr = int.Parse(hdnenrol);

                    string hdnunit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

                    int unit = int.Parse(hdnunit);



                    dt = bll.getRptTADANoneCarUserDetaills(dteFromDate, dteToDate, enr, unit, userTypeid);
                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {
                    grdvBikeCarUserDetaills.DataSource = null;

                    grdvBikeCarUserDetaills.DataBind();

                    grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;

                    grdvRptRemoteTADABikeCarUserTopsheet.DataBind();
                    grdvEmployeevsSupervisorWithBillAmount.DataSource = null;

                    grdvEmployeevsSupervisorWithBillAmount.DataBind();

                    GridViewNonCarTopsheet.DataSource = null;
                    GridViewNonCarTopsheet.DataBind();

                    grdvPaytocompany.DataSource = null;
                    grdvPaytocompany.DataBind();
                    grdvAllunitTADAExporttoExcel.DataSource = null;
                    grdvAllunitTADAExporttoExcel.DataBind();
                    grdvAdvanceSTATUS.DataSource = null;
                    grdvAdvanceSTATUS.DataBind();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();



                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 2 && userTypeid == 2)                  // Topsheet report None car user 
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    int usertype = 2;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                    int enr = int.Parse(hdnenrol);
                    string hdnunit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();

                    int unit = int.Parse(hdnunit);

                    dtTopsh = bll.getRptTADANoneCarUserTopSheet(dteFromDate, dteToDate, enr, unit, usertype);
                }

                catch
                {

                }

                if (dtTopsh.Rows.Count > 0)
                {



                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    grdvBikeCarUserDetaills.DataSource = null;

                    grdvBikeCarUserDetaills.DataBind();

                    grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;

                    grdvRptRemoteTADABikeCarUserTopsheet.DataBind();
                    grdvEmployeevsSupervisorWithBillAmount.DataSource = null;

                    grdvEmployeevsSupervisorWithBillAmount.DataBind();
                    grdvPaytocompany.DataSource = null;
                    grdvPaytocompany.DataBind();
                    grdvAllunitTADAExporttoExcel.DataSource = null;
                    grdvAllunitTADAExporttoExcel.DataBind();
                    grdvAdvanceSTATUS.DataSource = null;
                    grdvAdvanceSTATUS.DataBind();
                    GridViewNonCarTopsheet.DataSource = dtTopsh;
                    GridViewNonCarTopsheet.DataBind();






                }



                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 1 && userTypeid == 1)               //Detaills report Bike car user  
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                    int enr = int.Parse(hdnenrol);
                    string Unit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                    int unit = int.Parse(Unit);


                    dt = bll.getRptTADABikeAndCarUserDetaillsGB(dteFromDate, dteToDate, enr, unit, rptTypeid);

                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {

                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    GridViewNonCarTopsheet.DataSource = null;
                    GridViewNonCarTopsheet.DataBind();

                    grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;

                    grdvRptRemoteTADABikeCarUserTopsheet.DataBind();

                    grdvEmployeevsSupervisorWithBillAmount.DataSource = null;

                    grdvEmployeevsSupervisorWithBillAmount.DataBind();
                    grdvPaytocompany.DataSource = null;
                    grdvPaytocompany.DataBind();
                    grdvAllunitTADAExporttoExcel.DataSource = null;
                    grdvAllunitTADAExporttoExcel.DataBind();
                    grdvAdvanceSTATUS.DataSource = null;
                    grdvAdvanceSTATUS.DataBind();
                    grdvBikeCarUserDetaills.DataSource = dt;
                    grdvBikeCarUserDetaills.DataBind();



                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 2 && userTypeid == 1)               //TopSheet report Bike car user  
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                    int enr = int.Parse(hdnenrol);
                    string Unit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                    int unit = int.Parse(Unit);


                    dt = bll.getRptTADABikeAndCarUserDetaillsGB(dteFromDate, dteToDate, enr, unit, rptTypeid);

                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {

                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    GridViewNonCarTopsheet.DataSource = null;
                    GridViewNonCarTopsheet.DataBind();


                    grdvBikeCarUserDetaills.DataSource = null;
                    grdvBikeCarUserDetaills.DataBind();
                    grdvEmployeevsSupervisorWithBillAmount.DataSource = null;

                    grdvEmployeevsSupervisorWithBillAmount.DataBind();
                    grdvPaytocompany.DataSource = null;
                    grdvPaytocompany.DataBind();
                    grdvAllunitTADAExporttoExcel.DataSource = null;
                    grdvAllunitTADAExporttoExcel.DataBind();
                    grdvAdvanceSTATUS.DataSource = null;
                    grdvAdvanceSTATUS.DataBind();
                    grdvRptRemoteTADABikeCarUserTopsheet.DataSource = dt;

                    grdvRptRemoteTADABikeCarUserTopsheet.DataBind();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 7 )               //Employee vs Supervisor status
            {

                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;

                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                    dt = bll.getSupervisorvsEmployeeWithBillStatus(dteFromDate, dteToDate, unit, rptTypeid, enr);

                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {

                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    GridViewNonCarTopsheet.DataSource = null;
                    GridViewNonCarTopsheet.DataBind();


                    grdvBikeCarUserDetaills.DataSource = null;

                    grdvBikeCarUserDetaills.DataBind();

                    grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;

                    grdvRptRemoteTADABikeCarUserTopsheet.DataBind();
                    grdvPaytocompany.DataSource = null;
                    grdvPaytocompany.DataBind();
                    grdvAllunitTADAExporttoExcel.DataSource = null;
                    grdvAllunitTADAExporttoExcel.DataBind();
                    grdvAdvanceSTATUS.DataSource = null;
                    grdvAdvanceSTATUS.DataBind();
                    grdvEmployeevsSupervisorWithBillAmount.DataSource = dt;
                    grdvEmployeevsSupervisorWithBillAmount.DataBind();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                }


            }

            else if (rptTypeid == 13 )               //Own bill approve status monitor with personal cost
            {
                
                    if (rptTypeid == 13)
                    {
                        try
                        {
                            DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                            DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                            string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                            int enrol = int.Parse(hdnenrol);
                             string Unit = HttpContext.Current.Session[SessionParams.UNIT_ID].ToString();
                             int unit = int.Parse(Unit);
                             dt = bll.getRptPaytocompany(dteFromDate, dteToDate, rptTypeid, unit, enrol);

                        }

                        catch
                        {

                        }
                    }

                   



                    if (dt.Rows.Count > 0)
                    {

                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        GridViewNonCarTopsheet.DataSource = null;
                        GridViewNonCarTopsheet.DataBind();
                        grdvBikeCarUserDetaills.DataSource = null;
                        grdvBikeCarUserDetaills.DataBind();
                        grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;
                        grdvRptRemoteTADABikeCarUserTopsheet.DataBind();
                        grdvPaytocompany.DataSource = null;
                        grdvPaytocompany.DataBind();
                        grdvAllunitTADAExporttoExcel.DataSource = null;
                        grdvAllunitTADAExporttoExcel.DataBind();
                        grdvAdvanceSTATUS.DataSource = null;
                        grdvAdvanceSTATUS.DataBind();
                        grdvEmployeevsSupervisorWithBillAmount.DataSource = dt;
                        grdvEmployeevsSupervisorWithBillAmount.DataBind();
                    }
                
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }

                
            }

            else if (rptTypeid == 1017)               //Payable Report 
            {

                if (intDeptid == 3 || intDeptid == 14 || intDeptid == 21 || intDeptid == 8 || intDeptid == 5)
                {
                try
                {
                    DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                    DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                    string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                    int enr = int.Parse(hdnenrol);
                    string Unit = (drdlUnitName.SelectedValue.ToString());
                    int unit = int.Parse(Unit);
                  

                    dt = bll.getRptPaytocompany(dteFromDate, dteToDate,rptTypeid, unit,0);

                }

                catch
                {

                }

                if (dt.Rows.Count > 0)
                {

                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    GridViewNonCarTopsheet.DataSource = null;
                    GridViewNonCarTopsheet.DataBind();
                    grdvBikeCarUserDetaills.DataSource = null;
                    grdvBikeCarUserDetaills.DataBind();
                    grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;
                    grdvRptRemoteTADABikeCarUserTopsheet.DataBind();
                    grdvEmployeevsSupervisorWithBillAmount.DataSource = null;
                    grdvEmployeevsSupervisorWithBillAmount.DataBind();
                    grdvAllunitTADAExporttoExcel.DataSource = null;
                    grdvAllunitTADAExporttoExcel.DataBind();
                    grdvAdvanceSTATUS.DataSource = null;
                    grdvAdvanceSTATUS.DataBind();
                    grdvPaytocompany.DataSource = dt;
                    grdvPaytocompany.DataBind();
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


            else if (rptTypeid == 5)               //All Area Bill unit basis
            {
                string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();

                int enr = int.Parse(hdnenrol);
                if (intDeptid == 3 || intDeptid == 14 || intDeptid == 21 || intDeptid == 8 || intDeptid == 5)
                {
                    try
                    {
                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                       
                        string Unit = (drdlUnitName.SelectedValue.ToString());
                        int unit = int.Parse(Unit);


                        dt = bll.getRptPaytocompany(dteFromDate, dteToDate, rptTypeid, unit, 0);

                    }

                    catch
                    {

                    }

                    if (dt.Rows.Count > 0)
                    {

                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        GridViewNonCarTopsheet.DataSource = null;
                        GridViewNonCarTopsheet.DataBind();
                        grdvBikeCarUserDetaills.DataSource = null;
                        grdvBikeCarUserDetaills.DataBind();
                        grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;
                        grdvRptRemoteTADABikeCarUserTopsheet.DataBind();
                        grdvEmployeevsSupervisorWithBillAmount.DataSource = null;
                        grdvEmployeevsSupervisorWithBillAmount.DataBind();
                        grdvPaytocompany.DataSource = null;
                        grdvPaytocompany.DataBind();
                        grdvAdvanceSTATUS.DataSource = null;
                        grdvAdvanceSTATUS.DataBind();
                        grdvAllunitTADAExporttoExcel.DataSource = dt;
                        grdvAllunitTADAExporttoExcel.DataBind();
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

            else if (rptTypeid == 1018)               //Advance Approve Report 
            {

               
                    try
                    {
                        DateTime dteFromDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtFromDate.Text).Value;
                        DateTime dteToDate = GLOBAL_BLL.DateFormat.GetDateAtSQLDateFormat(txtToDate.Text).Value;
                        string hdnenrol = HttpContext.Current.Session[SessionParams.USER_ID].ToString();
                        int enr = int.Parse(hdnenrol);
                        string Unit = (drdlUnitName.SelectedValue.ToString());
                        int unit = int.Parse(Unit);


                        dt = bll.getRptTADAAdvanceAprvStatus(enr, 0, unit, 1018, dteFromDate, dteToDate);

                    }

                    catch
                    {

                    }

                    if (dt.Rows.Count > 0)
                    {

                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        GridViewNonCarTopsheet.DataSource = null;
                        GridViewNonCarTopsheet.DataBind();
                        grdvBikeCarUserDetaills.DataSource = null;
                        grdvBikeCarUserDetaills.DataBind();
                        grdvRptRemoteTADABikeCarUserTopsheet.DataSource = null;
                        grdvRptRemoteTADABikeCarUserTopsheet.DataBind();
                        grdvEmployeevsSupervisorWithBillAmount.DataSource = null;
                        grdvEmployeevsSupervisorWithBillAmount.DataBind();
                        grdvAllunitTADAExporttoExcel.DataSource = null;
                        grdvAllunitTADAExporttoExcel.DataBind();
                        grdvPaytocompany.DataSource = null;
                        grdvPaytocompany.DataBind();

                        grdvAdvanceSTATUS.DataSource = dt;
                        grdvAdvanceSTATUS.DataBind();
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry! There is no data against your query.');", true);
                    }
                }

            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void GridViewNonCarTopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewNonCarTopsheet.PageIndex = e.NewPageIndex;
            loadgrid();

        }

        protected void grdvBikeCarUserDetaills_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void grdvRptRemoteTADABikeCarUserTopsheet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvRptRemoteTADABikeCarUserTopsheet.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvBikeCarUserDetaills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvBikeCarUserDetaills.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void grdvEmployeevsSupervisorWithBillAmount_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Decimal CellValueaudit = Convert.ToDecimal(e.Row.Cells[5].Text);
                Decimal CellValueApplicant = Convert.ToDecimal(e.Row.Cells[6].Text);
                e.Row.Attributes.Add("onmouseover",
       "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValueaudit > CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Green;
                }
                else if (CellValueaudit < CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Red;

                }
                else
                    e.Row.Cells[7].BackColor = System.Drawing.Color.GreenYellow;

            }


        }

        protected void grdvPaytocompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvPaytocompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            int rptTypeid = int.Parse(ddlReportType.SelectedValue.ToString());
            if (rptTypeid == 1017)
            {
                try
                {
                    grdvPaytocompany.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("TADApay.xls", grdvPaytocompany);
                }
                catch { }
            }

            else if (rptTypeid == 5)
            {
                try
                {
                    grdvAllunitTADAExporttoExcel.AllowPaging = false;
                    SAD_BLL.Customer.Report.ExportClass.Export("TADA.xls", grdvAllunitTADAExporttoExcel);
                }
                catch { }
            }

        }

        protected void grdvpayreportforunitbasis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvpayreportforunitbasis_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvAdvanceSTATUS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdvAdvanceSTATUS_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdvAllunitTADAExporttoExcel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

              
                Decimal CellValueApplicant = Convert.ToDecimal(e.Row.Cells[5].Text);
                Decimal CellValueSupervisore = Convert.ToDecimal(e.Row.Cells[6].Text);
                e.Row.Attributes.Add("onmouseover",
                "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


                if (CellValueSupervisore > CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                }
                else if (CellValueSupervisore < CellValueApplicant)
                {
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Green;

                }
                else
                    e.Row.Cells[6].BackColor = System.Drawing.Color.GreenYellow;

            }
        }

        protected void drdlUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}