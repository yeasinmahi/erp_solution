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
using SAD_BLL.Corporate_sales;
using System.Drawing;

namespace UI.SAD.Corporate_sales
{
    public partial class SalesAnalysis : System.Web.UI.Page
    {
        DataTable dtOrderAreaAlalysisReport = new DataTable();
        DataTable dtOrderAlalysisReport = new DataTable();
        int reportnumber;
        DataTable Dtlogin = new DataTable();
        int permissionnumber;
        orderInputClass newreport = new orderInputClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;

                Int32 enroll = Convert.ToInt32("1355".ToString());
                //enroll = Convert.ToInt32("58440");

                Label3.Text = "";
                Label3.Visible = false;
                Label15.Visible = false;
                if (Label3.Text == "")
                {
                    Label3.Text = Convert.ToString("0");
                }
                else
                {
                    reportnumber = Convert.ToInt32(Label3.Text.ToString());
                }


                Dtlogin = newreport.getloginnumber(enroll);
                permissionnumber = Convert.ToInt32(Dtlogin.Rows[0]["number"].ToString());
                Session["permissionnumber"] = permissionnumber;
                Session["stenroll"] = enroll;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 ids = int.Parse(DropDownList1.SelectedValue.ToString());
            if ((ids == 2) || (ids == 7))
            {
                DropDownList2.Visible = true;
                Label1.Visible = true;
                DataTable dtProductReport = new DataTable();
                dtProductReport = newreport.getProductNameReportDairy();
                DropDownList2.DataTextField = "strProductName";
                DropDownList2.DataValueField = "intID";
                DropDownList2.DataSource = dtProductReport;
                DropDownList2.DataBind();
            }
            else
            {
                DropDownList2.Visible = false;
                Label1.Visible = false;
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
          
            string line = "A".ToString();
            Int32 enroll = Convert.ToInt32("1355".ToString());
            Int32 part = int.Parse(Session["permissionnumber"].ToString());
            Int32 number = int.Parse(Label3.Text.ToString());
            reportnumber = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
            if (Convert.ToDecimal(reportnumber.ToString()) == Convert.ToDecimal("3".ToString()))
            {
                if (Convert.ToDecimal(number.ToString()) == Convert.ToDecimal("4".ToString()))
                {
                    DateTime dtefromdate = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                    DateTime dtetodate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                    dtOrderAlalysisReport = newreport.getOrderAnalysisReportDairy(part, number, enroll, dtefromdate, dtetodate, line);
                    dgvtrgt.DataSource = dtOrderAlalysisReport;
                    dgvtrgt.DataBind();
                    dgvtrgt.Visible = true;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = false;
                    GridView7.Visible = false;
                    GridView8.Visible = false;
                }
                else
                {
                    DateTime dtefromdate = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                    DateTime dtetodate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                    dtOrderAreaAlalysisReport = newreport.getOrderAnalysisReportDairy(part, number, enroll, dtefromdate, dtetodate, line);
                    GridView1.DataSource = dtOrderAreaAlalysisReport;
                    GridView1.DataBind();
                    dgvtrgt.Visible = false;
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = false;
                    GridView7.Visible = false;
                    GridView8.Visible = false;


                }
            }
            else if (reportnumber == Convert.ToDecimal("1".ToString()))
            {

                if (Convert.ToDecimal(part) == Convert.ToDecimal("1"))
                {
                    if (number == 4)
                    {

                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse("0");
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);
                        GridView3.DataSource = dtvalueBySales;
                        GridView3.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = true;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                    else
                    {
                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse("0");
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);
                        GridView2.DataSource = dtvalueBySales;
                        GridView2.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                }
                else if (Convert.ToDecimal(part) == Convert.ToDecimal("2"))
                {
                    if (number == 4)
                    {
                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse(DropDownList2.SelectedValue.ToString());
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);
                        GridView3.DataSource = dtvalueBySales;
                        GridView3.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = true;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                    else
                    {
                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse(DropDownList2.SelectedValue.ToString());
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);

                        GridView2.DataSource = dtvalueBySales;
                        GridView2.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                }




            }

            else if (reportnumber == Convert.ToDecimal("2".ToString()))
            {
                if (Convert.ToDecimal(part) == Convert.ToDecimal("1"))
                {
                    if (number == 4)
                    {
                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse(DropDownList2.SelectedValue.ToString());
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);
                        GridView3.DataSource = dtvalueBySales;
                        GridView3.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = true;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                    else
                    {
                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse(DropDownList2.SelectedValue.ToString());
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);
                        GridView2.DataSource = dtvalueBySales;
                        GridView2.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                }
                else if (Convert.ToDecimal(part) == Convert.ToDecimal("2"))
                {
                    if (number == 4)
                    {
                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse(DropDownList2.SelectedValue.ToString());
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);
                        GridView3.DataSource = dtvalueBySales;
                        GridView3.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = true;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                    else
                    {
                        DataTable dtvalueBySales = new DataTable();
                        Int32 productnumber = int.Parse(DropDownList1.SelectedValue.ToString());
                        Int32 productid = int.Parse(DropDownList2.SelectedValue.ToString());
                        DateTime dtefromdate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());
                        dtvalueBySales = newreport.getValuesbySalesdairy(dtefromdate, part, number, enroll, productnumber, productid, line);

                        GridView2.DataSource = dtvalueBySales;
                        GridView2.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                }
            }
            else if (reportnumber == Convert.ToDecimal("4".ToString()))
            {
                DataTable dtmemoReport = new DataTable();
                DateTime dtefromdate = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                DateTime dtetodate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());

                if (part == 1)
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());
                    if (numbers != 4)
                    {
                        Int32 locationid = 1;
                        part = numbers;
                       // dtmemoReport = newreport.getmemoReport(dtefromdate, dtetodate, part, locationid, enroll, line);
                        GridView4.DataSource = dtmemoReport;
                        GridView4.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = true;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                    else
                    {
                        Int32 locationid = 1;
                        part = numbers;
                      //  dtmemoReport = newreport.getmemoReport(dtefromdate, dtetodate, part, locationid, enroll, line);
                        GridView5.DataSource = dtmemoReport;
                        GridView5.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = true;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                }
                else
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());

                    if (numbers != 4)
                    {
                        Int32 locationid = 2;
                        part = numbers;
                      //  dtmemoReport = newreport.getmemoReport(dtefromdate, dtetodate, part, locationid, enroll, line);
                        GridView4.DataSource = dtmemoReport;
                        GridView4.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = true;
                        GridView5.Visible = false;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }
                    else
                    {
                        Int32 locationid = 2;
                        part = numbers;
                     //   dtmemoReport = newreport.getmemoReport(dtefromdate, dtetodate, part, locationid, enroll, line);
                        GridView5.DataSource = dtmemoReport;
                        GridView5.DataBind();

                        dgvtrgt.Visible = false;
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = true;
                        GridView6.Visible = false;
                        GridView7.Visible = false;
                        GridView8.Visible = false;
                    }

                }



            }

            else if (reportnumber == Convert.ToDecimal("5".ToString()))
            {
                DataTable dtEmployeeReport = new DataTable();
                DateTime dtefromdate = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                DateTime dtetodate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());

                if (part == 1)
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());


                    Int32 productNumber = part;
                    part = 1;
                    int productid = 0;
                    dtEmployeeReport = newreport.GetEmployeeReport(dtefromdate, dtetodate, part, numbers, enroll, productNumber, productid, line);
                    GridView6.DataSource = dtEmployeeReport;
                    GridView6.DataBind();

                    dgvtrgt.Visible = false;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = true;
                    GridView7.Visible = false;
                    GridView8.Visible = false;
                }
                else
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());
                    Int32 productNumber = part;

                    part = 1;
                    int productid = 0;
                    dtEmployeeReport = newreport.GetEmployeeReport(dtefromdate, dtetodate, part, numbers, enroll, productNumber, productid, line);
                    GridView6.DataSource = dtEmployeeReport;
                    GridView6.DataBind();

                    dgvtrgt.Visible = false;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = true;
                    GridView7.Visible = false;
                    GridView8.Visible = false;

                }

            }
            else if (reportnumber == Convert.ToDecimal("6".ToString()))
            {
                DataTable dtLoginmonitoringReportsONCheck = new DataTable();
                DateTime dtefromdate = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                DateTime dtetodate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());

                if (part == 1)
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());



                   // dtLoginmonitoringReportsONCheck = newreport.GetLoginMonitoringReportsCheckLogin(dtefromdate, dtetodate, numbers);
                    GridView7.DataSource = dtLoginmonitoringReportsONCheck;
                    GridView7.DataBind();

                    dgvtrgt.Visible = false;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = false;
                    GridView7.Visible = true;
                    GridView8.Visible = false;
                }
                else
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());


                  //  dtLoginmonitoringReportsONCheck = newreport.GetLoginMonitoringReportsCheckLogin(dtefromdate, dtetodate, numbers);
                    GridView7.DataSource = dtLoginmonitoringReportsONCheck;
                    GridView7.DataBind();

                    dgvtrgt.Visible = false;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = false;
                    GridView7.Visible = true;
                    GridView8.Visible = false;

                }

            }
            else if (reportnumber == Convert.ToDecimal("7".ToString()))
            {
                DataTable dtTraderofferDate = new DataTable();
                DateTime dtefromdate = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                DateTime dtetodate = Convert.ToDateTime(Calendar2.SelectedDate.ToShortDateString());

                if (part == 1)
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());
                    Int32 porductid = int.Parse(DropDownList2.SelectedValue.ToString());



                 //   dtTraderofferDate = newreport.GetTraderofferReport(dtefromdate, dtetodate, porductid, line);
                    GridView8.DataSource = dtTraderofferDate;
                    GridView8.DataBind();

                    dgvtrgt.Visible = false;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = false;
                    GridView7.Visible = false;
                    GridView8.Visible = true;
                }
                else
                {
                    Int32 numbers = int.Parse(Label3.Text.ToString());
                    Int32 porductid = int.Parse(DropDownList2.SelectedValue.ToString());

                 //   dtTraderofferDate = newreport.GetTraderofferReport(dtefromdate, dtetodate, porductid, line);
                    GridView8.DataSource = dtTraderofferDate;
                    GridView8.DataBind();

                    dgvtrgt.Visible = false;
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    GridView3.Visible = false;
                    GridView4.Visible = false;
                    GridView5.Visible = false;
                    GridView6.Visible = false;
                    GridView7.Visible = false;
                    GridView8.Visible = true;

                }

            }



        }

        protected void RadioButton2_CheckedChanged1(object sender, EventArgs e)
        {
            reportnumber = Convert.ToInt32("1");
            Label3.Text = Convert.ToString(reportnumber);
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            reportnumber = Convert.ToInt32("2");
            Label3.Text = Convert.ToString(reportnumber);
        }

        protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
        {
            reportnumber = Convert.ToInt32("3");
            Label3.Text = Convert.ToString(reportnumber);
        }

        protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            reportnumber = Convert.ToInt32("4");
            Label3.Text = Convert.ToString(reportnumber);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = false;

            TextBox3.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;

           
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Calendar2.Visible = false;

            TextBox1.Text = Calendar2.SelectedDate.ToShortDateString();
        }
        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                    e.Row.BackColor = Color.FromName("White");
                    //orange
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
                    e.Row.BackColor = Color.FromName("Lightgray");
                }
            }

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                    e.Row.BackColor = Color.FromName("White");
                    //orange
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
                    e.Row.BackColor = Color.FromName("Lightgray");
                }
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                    e.Row.BackColor = Color.FromName("White");
                    //orange
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
                    e.Row.BackColor = Color.FromName("Lightgray");
                }
            }
        }
        protected double TargetQtytotal = 0; protected double Orderqtytotal = 0; protected double Deliveryqtytotal = 0;

        protected double Amounttotal = 0;
        protected double Secondary_Salestotal = 0; protected double SS_FUtotal = 0;
        protected double SS_POtotal = 0; protected double Ss_FUtotal = 0; protected double Fundtotal = 0; protected double POtotal = 0;
        protected double Ss_FUtotals = 0; protected string FFResultPOtotal;




        protected void dgvtrgt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("style", "cursor:help;");
            //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            //{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                //e.Row.BackColor = Color.FromName("White");

                if (((Label)e.Row.Cells[5].FindControl("lblTargetss")).Text == "")
                {
                    TargetQtytotal += 0;
                }
                else
                {
                    TargetQtytotal += double.Parse(((Label)e.Row.Cells[5].FindControl("lblTargetss")).Text);
                }
                if (((Label)e.Row.Cells[6].FindControl("lblOrder12113")).Text == "")
                {
                    Orderqtytotal += 0;
                }
                else
                {
                    Orderqtytotal += double.Parse(((Label)e.Row.Cells[6].FindControl("lblOrder12113")).Text);
                }
                if (((Label)e.Row.Cells[7].FindControl("lblDeliveryqty1")).Text == "")
                {
                    Deliveryqtytotal += 0;
                }
                else
                {
                    Deliveryqtytotal += double.Parse(((Label)e.Row.Cells[7].FindControl("lblDeliveryqty1")).Text);
                }
                if (((Label)e.Row.Cells[9].FindControl("lblAmount122")).Text == "")
                {
                    Amounttotal += 0;
                }
                else
                {
                    Amounttotal += double.Parse(((Label)e.Row.Cells[9].FindControl("lblAmount122")).Text);
                }
                if (((Label)e.Row.Cells[10].FindControl("lblSecondary_Sales1")).Text == "")
                {
                    Secondary_Salestotal += 0;
                }
                else
                {
                    Secondary_Salestotal += double.Parse(((Label)e.Row.Cells[10].FindControl("lblSecondary_Sales1")).Text);
                }

                if (((Label)e.Row.Cells[11].FindControl("lblSS_PO")).Text == "")
                {
                    SS_POtotal += 0;
                }
                else
                {
                    SS_POtotal += double.Parse(((Label)e.Row.Cells[11].FindControl("lblSS_PO")).Text);
                }
                if (((Label)e.Row.Cells[12].FindControl("lblSSFUss")).Text == "")
                {
                    SS_FUtotal += 0;
                }
                else
                {
                    SS_FUtotal += double.Parse(((Label)e.Row.Cells[12].FindControl("lblSSFUss")).Text);
                }
                decimal PercentagePoFF;

                PercentagePoFF = Convert.ToDecimal((Orderqtytotal / TargetQtytotal) * 100);
                PercentagePoFF = Math.Round(PercentagePoFF, 2);
                fun = Convert.ToString(PercentagePoFF) + "%";
                FFResultPOtotal = fun;

            }
            //}
            //else
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
            //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
            //        e.Row.BackColor = Color.FromName("Lightgray");
            //    }
            //}

        }
        protected double sTargetQtytotal = 0; protected double sOrderqtytotal = 0; protected double sDeliveryqtytotal = 0;

        protected double sAmounttotal = 0;
        protected double sSecondary_Salestotal = 0; protected double sSS_FUtotal = 0;
        protected double sSS_POtotal = 0; protected double sSs_FUtotal = 0; protected double sFundtotal = 0; protected double sPOtotal = 0;
        protected double sSs_FUtotals = 0; protected double sFUtotal = 0; protected string ResultFUtotal; string fun; string funss; protected string ResultSStotal;
        string POss; protected string ResultPOtotal;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Attributes.Add("style", "cursor:help;");
            //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            //{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                //e.Row.BackColor = Color.FromName("White");




                if (((Label)e.Row.Cells[2].FindControl("lblTarget25254")).Text == "")
                {
                    sTargetQtytotal += 0;
                }
                else
                {
                    sTargetQtytotal += double.Parse(((Label)e.Row.Cells[2].FindControl("lblTarget25254")).Text);
                }
                if (((Label)e.Row.Cells[3].FindControl("lblOrder25254")).Text == "")
                {
                    sOrderqtytotal += 0;
                }
                else
                {
                    sOrderqtytotal += double.Parse(((Label)e.Row.Cells[3].FindControl("lblOrder25254")).Text);
                }
                if (((Label)e.Row.Cells[4].FindControl("lblsDeliveryqty1")).Text == "")
                {
                    sDeliveryqtytotal += 0;
                }
                else
                {
                    sDeliveryqtytotal += double.Parse(((Label)e.Row.Cells[4].FindControl("lblsDeliveryqty1")).Text);
                }
                //if (((Label)e.Row.Cells[5].FindControl("lblPobill")).Text == "")
                //{
                //    POtotal += 0;
                //}
                //else
                //{
                //    POtotal += double.Parse(((Label)e.Row.Cells[5].FindControl("lblPobill")).Text);
                //}
                if (((Label)e.Row.Cells[5].FindControl("lblFundss")).Text == "")
                {
                    sFundtotal += 0;
                }
                else
                {
                    sFundtotal += double.Parse(((Label)e.Row.Cells[5].FindControl("lblFundss")).Text);
                }

                if (((Label)e.Row.Cells[8].FindControl("lblSecondary_Sales")).Text == "")
                {
                    sSecondary_Salestotal += 0;
                }
                else
                {
                    sSecondary_Salestotal += double.Parse(((Label)e.Row.Cells[8].FindControl("lblSecondary_Sales")).Text);
                }
                if (((Label)e.Row.Cells[10].FindControl("lblSSPOffftes")).Text == "")
                {
                    sSS_POtotal += 0;
                }
                else
                {
                    sSS_POtotal += double.Parse(((Label)e.Row.Cells[10].FindControl("lblSSPOffftes")).Text);
                }
                if (((Label)e.Row.Cells[11].FindControl("lblSSFUsss")).Text == "")
                {
                    SS_FUtotal += 0;
                }
                else
                {
                    SS_FUtotal += double.Parse(((Label)e.Row.Cells[11].FindControl("lblSSFUsss")).Text);
                }
                decimal percentageFU;
                decimal percentageSS;
                decimal percentagePO;
                if (Convert.ToDecimal(sTargetQtytotal) == Convert.ToDecimal("0"))
                {
                    sTargetQtytotal = Convert.ToDouble("1");
                }

                percentageFU = Convert.ToDecimal((sFundtotal / sTargetQtytotal) * 100);
                percentageFU = Math.Round(percentageFU, 2);
                fun = Convert.ToString(percentageFU) + "%";
                ResultFUtotal = fun;

                percentageSS = Convert.ToDecimal((sSecondary_Salestotal / sTargetQtytotal) * 100);
                percentageSS = Math.Round(percentageSS, 2);
                funss = Convert.ToString(percentageSS) + "%";
                ResultSStotal = funss;

                percentagePO = Convert.ToDecimal((sOrderqtytotal / sTargetQtytotal) * 100);
                percentagePO = Math.Round(percentagePO, 2);
                POss = Convert.ToString(percentagePO) + "%";
                ResultPOtotal = POss;



            }

            //}
            //else
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
            //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
            //        e.Row.BackColor = Color.FromName("Lightgray");
            //    }
            //}
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                    e.Row.BackColor = Color.FromName("White");
                    //orange
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
                    e.Row.BackColor = Color.FromName("Lightgray");
                }
            }
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                    e.Row.BackColor = Color.FromName("White");
                    //orange
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
                    e.Row.BackColor = Color.FromName("Lightgray");
                }
            }
        }

        protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                    e.Row.BackColor = Color.FromName("White");
                    //orange
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
                    e.Row.BackColor = Color.FromName("Lightgray");
                }
            }
        }

        protected void GridView8_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "cursor:help;");
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
                    e.Row.BackColor = Color.FromName("White");
                    //orange
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='Green'");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='Lightgray'");
                    e.Row.BackColor = Color.FromName("Lightgray");
                }
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}