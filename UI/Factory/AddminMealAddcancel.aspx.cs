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
    public partial class AddminMealAddcancel : System.Web.UI.Page
    {
        DataTable dtUnitname = new DataTable();
        challanandPending Report = new challanandPending();
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

                //DataTable DtReportCancelReport = new DataTable();
                //DtReportCancelReport = Report.getCancelReport(enroll);
                //GridView1.DataSource = DtReportCancelReport;
                //GridView1.DataBind();

                //DtReportCancelReport = new DataTable();
                DateTime dtedte = DateTime.Now;
                
                // int num = int.Parse("1");
                // DtReportCancelReport = Report.getCanteenReportbyUser(dtedte, num, enroll);
                //GridView2.DataSource = DtReportCancelReport;
                //GridView2.DataBind();

                //DtReportCancelReport = new DataTable();
                //DtReportCancelReport = Report.getApproveMealReport(enroll);
                //GridView3.DataSource = DtReportCancelReport;
                //GridView3.DataBind();

                //DtReportCancelReport = new DataTable();
                //DateTime dtedae = DateTime.Now;
                //string daynames = Convert.ToString((dtedae.DayOfWeek));

                //DtReportCancelReport = Report.getLunchMenu(daynames);

                //GridView4.DataSource = DtReportCancelReport;
                //GridView4.DataBind();
                

              
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void ddlShip_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
           

                int enroll = int.Parse(TextBox1.Text.ToString());
                if (hdnCustomer.Value == "1")
                {

                    DateTime dte = DateTime.Now;
                    DataTable dtcount = new DataTable();

                    dtcount = Report.getcount(enroll, dte);
                    if ((dtcount.Rows[0]["CountsEntryCancel"].ToString()) == "0")
                    {
                        if ((txtFrom.Text != "") && (txtTo.Text != ""))
                        {
                            DateTime dtefromdate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
                            DateTime dteTodate = CommonClass.GetDateAtSQLDateFormat(txtTo.Text).Date;


                            Report.getMealCancel(dtefromdate, dteTodate, enroll);

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);

                            DataTable DtReportCancelReport = new DataTable();
                            DtReportCancelReport = Report.getCancelReport(enroll);
                            GridView1.DataSource = DtReportCancelReport;
                            GridView1.DataBind();
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Date !');", true);
                        }
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Already Cancel !');", true);
                    }
                 
                }
                else if (hdnCustomer.Value == "2")
                {
                    DataTable dtReportsbyUser = new DataTable();
                    enroll =int.Parse(TextBox1.Text.ToString());
                    int meailqty = int.Parse(TextBox2.Text);
                    DateTime dtedates=DateTime.Now;
                    Report.getGustmealIndent(enroll,meailqty,dtedates);
                    dtReportsbyUser = Report.getUserbyReport(enroll);

                    decimal mondiscount = decimal.Parse(dtReportsbyUser.Rows[0]["monDiscountamount"].ToString());
                    decimal monemployeecontribute = decimal.Parse(dtReportsbyUser.Rows[0]["monEmployeeContribute"].ToString());

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);
                    TextBox1.Text = "";
                      TextBox2.Text = "";
                }
                else if (hdnCustomer.Value == "3")
                {
                    DataTable dtReportsbyUser = new DataTable();
                    enroll = int.Parse((TextBox1.Text.ToString()));
                    int meailqty = int.Parse(TextBox2.Text);
                    DateTime dtedates = DateTime.Now;
                    Report.getEntryofrTemporry(enroll, dtedates, meailqty);
                    dtReportsbyUser = Report.getUserbyReport(enroll);

                    decimal mondiscount = decimal.Parse(dtReportsbyUser.Rows[0]["monDiscountamount"].ToString());
                    decimal monemployeecontribute = decimal.Parse(dtReportsbyUser.Rows[0]["monEmployeeContribute"].ToString());
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);

                }

               


            
        }
        protected void Update(object sender, EventArgs e)
        {
            try
            {
                char[] delimiterChars = { '^' };
                string temp1 = ((Button)sender).CommandArgument.ToString();
                string temp = temp1.Replace("'", " ");
                string[] searchKey = temp.Split(delimiterChars);
                Int32 Custid = int.Parse(searchKey[0].ToString());
                Session["Custid"] = Custid;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);


            }
            catch { }


        }

        protected void txtFrom_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void txtTo_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hdnCustomer.Value = "1";
            Label1.Text = "Employee Enroll";
            //TextBox1.Text= (Session[SessionParams.USER_ID].ToString());
            TextBox1.Enabled = true;
            TextBox2.Enabled = false;
            Label2.Enabled = false;


        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hdnCustomer.Value = "2";
            Label1.Text = "Enroll";
            TextBox1.Enabled = true;
            TextBox1.Text = "";
            TextBox2.Enabled = true;
            TextBox2.Text = "";
            Label2.Enabled = true;
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            hdnCustomer.Value = "3";
            Label1.Text = "Enroll";

            TextBox1.Enabled = true;
            TextBox1.Text = "";

            TextBox2.Enabled = true;
            Label2.Enabled = true;
            TextBox2.Text = "";
        }
    }
}