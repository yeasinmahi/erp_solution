using HR_BLL.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL;
using HR_BLL.BulkSMS;
using SAD_BLL.AutoChallanBll;



namespace UI.SAD.AutoChallan
{
    public partial class IncentiveReport : System.Web.UI.Page
    {
        DataTable dtReport = new DataTable();
        challanandPending Report = new challanandPending(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlSo_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int numbers = int.Parse("1");
           // string dtedates = txtFrom.Text.ToString();
           // DateTime dtedate = DateTime.Parse(dtedates.ToString());
            DateTime dtedate = Convert.ToDateTime("2016-6-30".ToString());
           
            dtReport = Report.getincetiveReport(dtedate, numbers);

            GridView1.DataSource = dtReport;
            GridView1.DataBind();
            

        }
        protected double IncAmountTotal = 0; protected double TotalQtytotal = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((Label)e.Row.Cells[7].FindControl("lblqty")).Text == "")
                {
                    IncAmountTotal += 0;
                }
                else
                {
                    IncAmountTotal += double.Parse(((Label)e.Row.Cells[7].FindControl("lblqty")).Text);
                }


            }

        }

        protected void ddlShip_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            DataTable DtReport = new DataTable();
            int numbers = int.Parse("2");
           // string dtedate = Convert.ToString(txtFrom.Text.ToString());
            DateTime dtedate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
            dtReport = Report.getincetiveReport(dtedate, numbers);
            decimal monIncentiveTotal=decimal.Parse(DtReport.Rows[0]["SalesAmount"].ToString());
            string months = (DtReport.Rows[0]["months"].ToString());

            string narrations = "Being Incentime Amount :" + monIncentiveTotal + "For The month of " + months;
            GridView1.DataSource = dtReport;
            GridView1.DataBind();

            DtReport = new DataTable();
            DtReport = Report.getJvReport(narrations, monIncentiveTotal);
            string JVnumbers = DtReport.Rows[0]["JVNumber"].ToString();



            if (GridView1.Rows.Count > 0)
            {
                for (int index = 0; index < GridView1.Rows.Count; index++)
                {

                    string intCustid = ((Label)GridView1.Rows[index].FindControl("lblCustid")).Text.ToString();
                    decimal intAccountid = decimal.Parse(((Label)GridView1.Rows[index].FindControl("lblintAccID")).Text.ToString());

                    decimal amount = decimal.Parse(((TextBox)GridView1.Rows[index].FindControl("lblqty")).Text.ToString());
                    

                    string strAccName = ((Label)GridView1.Rows[index].FindControl("lblstrAccName")).Text.ToString();
                    string strmonth = ((Label)GridView1.Rows[index].FindControl("lblmonth")).Text.ToString();
                 
                    string strnarations="Distributor Incentive Amount"+Convert.ToString(amount)+"Tk. for the Month of "+strmonth;
                    Report.getinsertJv(JVnumbers, intAccountid, strnarations, amount, strAccName);



              
                    
                }
               
                Report.getJVInsertTotalAmount(JVnumbers, narrations, monIncentiveTotal);

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);
                GridView1.DataBind();
               

            }
            
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
          //  Response.Redirect("RiverAndHillBill.aspx");
            DateTime dtedate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;



            dtReport = Report.getDamageforAccounts(dtedate);
            GridView2.DataSource = dtReport;
            GridView2.DataBind();

        }
        protected double AmountGrandtotal = 0; protected double Damage_AmountGrandtotal = 0;
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Mlqctotal += int.Parse(((Label)e.Row.Cells[1].FindControl("lblMlqc")).Text);

                if (((Label)e.Row.Cells[1].FindControl("lblAmount")).Text == "")
                {
                    AmountGrandtotal += 0;
                }
                else
                {
                    AmountGrandtotal += double.Parse(((Label)e.Row.Cells[1].FindControl("lblAmount")).Text);
                }

                if (((Label)e.Row.Cells[2].FindControl("lblDamage_Amount")).Text == "")
                {
                    Damage_AmountGrandtotal += 0;
                }
                else
                {
                    Damage_AmountGrandtotal += double.Parse(((Label)e.Row.Cells[2].FindControl("lblDamage_Amount")).Text);
                }

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataTable DtReport = new DataTable();
            int numbers = int.Parse("2");
            // string dtedate = Convert.ToString(txtFrom.Text.ToString());
            DateTime dtedate = CommonClass.GetDateAtSQLDateFormat(txtFrom.Text).Date;
            DtReport = Report.getDamageAmount(dtedate);
            decimal monDamageeTotal = decimal.Parse(DtReport.Rows[0]["Amounts"].ToString());
            string months = (DtReport.Rows[0]["Months"].ToString());

            string narrations = "Being Damage Amount :" + monDamageeTotal + "For The month of " + months;
            GridView1.DataSource = dtReport;
            GridView1.DataBind();

            DtReport = new DataTable();
            DtReport = Report.getJvReport(narrations, monDamageeTotal);
            string JVnumbers = DtReport.Rows[0]["JVNumber"].ToString();




            if (GridView2.Rows.Count > 0)
            {
                for (int index = 0; index < GridView2.Rows.Count; index++)
                {

                    string intCustid = ((Label)GridView2.Rows[index].FindControl("lblcustids")).Text.ToString();
                    decimal intAccountid = decimal.Parse(((Label)GridView2.Rows[index].FindControl("lblintAccID")).Text.ToString());

                    decimal Liftingamount = decimal.Parse(((Label)GridView2.Rows[index].FindControl("lblAmount")).Text.ToString());

                    decimal amount = decimal.Parse(((Label)GridView2.Rows[index].FindControl("lblDamage_Amount")).Text.ToString());


                    string strAccName = ((Label)GridView2.Rows[index].FindControl("lblstrAccName")).Text.ToString();
                    string strmonth = ((Label)GridView2.Rows[index].FindControl("lblmonths")).Text.ToString();

                    string strnarations = "Distributor Incentive Amount" + Convert.ToString(amount) + "Tk. for the Month of " + strmonth;
                    Report.getinsertJvdamageentry(JVnumbers, intAccountid, strnarations, amount, strAccName);





                }

                Report.getJVInsertDamageTotalAmount(JVnumbers, narrations, monDamageeTotal);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Successfully !');", true);

                GridView2.DataBind();


                Report.getDamageBillupdateDairy(dtedate);
            }
        }
       
    }
}