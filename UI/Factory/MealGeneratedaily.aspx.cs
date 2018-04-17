using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using SAD_BLL.Customer;
using SAD_BLL.Customer.Report;
using SAD_BLL.Item;
using SAD_BLL.Sales.Report;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;
using UI.ClassFiles;
using SAD_BLL.AutoChallanBll;
using System.Text.RegularExpressions;

namespace UI.Factory
{
    public partial class MealGeneratedaily : System.Web.UI.Page
    {
        DataTable dtReport = new DataTable();
        DataTable dtReports = new DataTable();
        DataTable dtUnitname = new DataTable();
        challanandPending Report = new challanandPending();
        int numbers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdatePanel1.DataBind();
                int enroll = int.Parse((Session[SessionParams.USER_ID].ToString()));
                dtUnitname = Report.getUnitname(enroll);
                string unitname = dtUnitname.Rows[0]["strUnit"].ToString();
                int intUnitID = int.Parse(dtUnitname.Rows[0]["intUnitID"].ToString());
                Session["intUnitID"] = intUnitID;

                ddlShip.DataTextField = "strUnit";
                ddlShip.DataSource = dtUnitname;
                ddlShip.DataBind();

                DataTable dtReportss = new DataTable();
                DateTime dtedate = DateTime.Now;
                dtReportss = Report.getIndent(dtedate);
                GridView2.DataSource = dtReportss;
                GridView2.DataBind();
            }
            
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DateTime dtedate = DateTime.Now;
            DataTable dtMealcheck = new DataTable();

          dtMealcheck= Report.getMealCheckCount(dtedate);

          int Counts = int.Parse(dtMealcheck.Rows[0]["MealCount"].ToString());

          if (Counts <30)
          {
              numbers = int.Parse("1");
              Report.getMealCreate(dtedate, numbers);

              numbers = int.Parse("2");
              dtReports = Report.getmealReport(dtedate, numbers);
              GridView1.DataSource = dtReports;
              GridView1.DataBind();

              numbers = int.Parse("3");
              dtReports = new DataTable();
              dtReports = Report.getmealReport(dtedate, numbers);

              mealtotal.Text = (String.Format(dtReports.Rows[0]["CountsMeal"].ToString(), "{0:00.00}"));
              Label2.Text = (String.Format(dtReports.Rows[0]["Person"].ToString(), "{0:00.00}"));

              numbers = int.Parse("4");

              dtReports = new DataTable();
              dtReports = Report.getmealReport(dtedate, numbers);
              // mealtotal.Text = (String.Format(dtReports.Rows[0]["CancelMeal"].ToString(), "{0:00.00}"));
              Label3.Text = (String.Format(dtReports.Rows[0]["CancelMeal"].ToString(), "{0:00.00}"));
              ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);
          }
          else
          {
              ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Today Meal Already Submited!');", true);
          }
        }

        protected void txtFrom_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void txtTo_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hdnmeal.Value = "1";

            GridView1.Visible = true;
            GridView3.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime dtefromdate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
            DateTime dtedate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
            DateTime dteTodate = CommonClass.GetDateAtSQLDateFormat(txtTo.Text).Date;
           int mealnumber=int.Parse(hdnmeal.Value);
           if (mealnumber == int.Parse("1"))
           {
               dtReport = new DataTable();
               numbers = int.Parse("2");
               dtReports = Report.getmealReport(dtedate, numbers);
               GridView1.DataSource = dtReports;
               GridView1.DataBind();
               GridView1.Visible = true;
               GridView3.Visible = false;

               numbers = int.Parse("3");
               dtReports = new DataTable();
               dtReports = Report.getmealReport(dtedate, numbers);

               mealtotal.Text = (String.Format(dtReports.Rows[0]["CountsMeal"].ToString(), "{0:00.00}"));
               Label2.Text = (String.Format(dtReports.Rows[0]["Person"].ToString(), "{0:00.00}"));

               numbers = int.Parse("4");
               dtReports = new DataTable();
               dtReports = Report.getmealReport(dtedate, numbers);
              // mealtotal.Text = (String.Format(dtReports.Rows[0]["CancelMeal"].ToString(), "{0:00.00}"));
               Label3.Text = (String.Format(dtReports.Rows[0]["CancelMeal"].ToString(), "{0:00.00}"));
           }
           else if (mealnumber == int.Parse("2"))
           {
               numbers = int.Parse("5");
               dtReport = new DataTable();
               dtReports = Report.getmealReport(dtedate, numbers);
               GridView1.DataSource = dtReports;
               GridView1.DataBind();

               GridView1.Visible = true;
               GridView3.Visible = false;
           
           }
           else if (mealnumber == int.Parse("3"))
           {
               numbers = int.Parse("5");
               dtReport = new DataTable();
               dtReports = Report.getmealCancelList(dtedate);
               GridView3.DataSource = dtReports;
               GridView3.DataBind();

               GridView1.Visible = false;
               GridView3.Visible = true;

           }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hdnmeal.Value = "2";

            GridView1.Visible = true;
            GridView3.Visible = false;
        }

        protected void Updates(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                string slipno = Convert.ToString(searchKey[0].ToString());
                Session["slipno"] = slipno;
                int enr=int.Parse(slipno);
                DateTime dtedates =DateTime.Now;
                DataTable dtr = new DataTable();

                DataTable dtReportdailyQty = new DataTable();
                dtReportdailyQty = Report.getDailQty(enr, dtedates);
                int qtys = int.Parse(dtReportdailyQty.Rows[0]["Column1"].ToString());

                dtr = Report.getDatatableIndetn(dtedates,enr);

                decimal qty = decimal.Parse(dtr.Rows[0]["qty"].ToString());
                qty = qty + qtys;
                Report.getUpdateMeal(qty,dtedates, enr);
                Report.getMeailApproved(enr);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);

                DataTable dtReportss = new DataTable();
                DateTime dtedate = DateTime.Now;
                dtReportss = Report.getIndent(dtedate);
                GridView2.DataSource = dtReportss;
                GridView2.DataBind();

               
            }
            catch { }


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('NewEmployeeCreateByMeal.aspx');", true);
        }
        protected double monQtyGrantotal = 0; protected double Discounttotal = 0; protected double lblEmployeeMealCost = 0; protected double EmployeeMealCosttotal = 0;
        protected double TotalMealCosttotal = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[2].FindControl("lblmonQty")).Text == "")
                {
                    monQtyGrantotal += 0;
                }
                else
                {
                    monQtyGrantotal += double.Parse(((Label)e.Row.Cells[2].FindControl("lblmonQty")).Text);
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[4].FindControl("lblDiscountss")).Text == "")
                {
                    Discounttotal += 0;
                }
                else
                {
                    Discounttotal += double.Parse(((Label)e.Row.Cells[4].FindControl("lblDiscountss")).Text);
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[7].FindControl("lblEmployeeMealCost")).Text == "")
                {
                    EmployeeMealCosttotal += 0;
                }
                else
                {
                    EmployeeMealCosttotal += double.Parse(((Label)e.Row.Cells[7].FindControl("lblEmployeeMealCost")).Text);
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[8].FindControl("lblTotalMealCost")).Text == "")
                {
                    TotalMealCosttotal += 0;
                }
                else
                {
                    TotalMealCosttotal += double.Parse(((Label)e.Row.Cells[8].FindControl("lblTotalMealCost")).Text);
                }
            }
            
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Registration('MealMenuAdd.aspx');", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DateTime dtefromdate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
       
            DateTime dteTodate = CommonClass.GetDateAtSQLDateFormat(txtTo.Text).Date;
            int enrollno = int.Parse(txtCancelEmalRollBack.Text.ToString());

            Report.getCancelEnrollRollback(dtefromdate,dteTodate,enrollno);
            txtCancelEmalRollBack.Text = "";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);

            
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            hdnmeal.Value = "3";

            GridView1.Visible = false;
            GridView3.Visible = true;
        }
    }
}