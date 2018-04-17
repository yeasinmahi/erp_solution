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
using System.IO;
using System.Xml;
using SAD_BLL.Corporate_sales;

namespace UI.Dairy_HO
{
    public partial class AllAchievementReportHo : System.Web.UI.Page
    {
        DataTable Dtlogin = new DataTable();
        DataTable ddlTerritory = new DataTable();
        Int32 permissionnumber; Int32 strlines;
        orderInputClass newreport = new orderInputClass();
        orderInputClass Report = new orderInputClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Int32 enroll = Convert.ToInt32(Session["employeeenroll"].ToString());
                Int32 enroll = Convert.ToInt32("1355");
                Session["enroll"] = enroll;
                Label1.Visible = false;
                Label1.Text = "0";
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                 Session["enroll"] = enroll;

                DataTable dtPermission = new DataTable();

                  Int32 enrollnumber = Convert.ToInt32(enroll.ToString());


                dtPermission = Report.getPermission(enrollnumber);
                Int32 Permission = int.Parse(dtPermission.Rows[0]["Numbers"].ToString());
                Session["Permission"] = Permission;

                    DataTable dtArea = new DataTable();
                    DataTable dtTerritory = new DataTable();

                    dtArea = Report.getareas();
                    DropDownList1.DataTextField = "Area";
                    DropDownList1.DataSource = dtArea;
                    DropDownList1.DataBind();

              
             

            }
          //  Int32 intenroll = Convert.ToInt32(Session["employeeenroll"].ToString());
            Int32 intenroll = int.Parse(Session["enroll"].ToString());
            string softwareReport = "Achievement Details";
            
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            strlines = Convert.ToInt32("1");
            Label1.Text = Convert.ToString(strlines);


           // hdnAreanumber.Value = "2";
            if ((Convert.ToInt32(Session["Permission"]) == 1) || (Convert.ToInt32(Session["Permission"]) == 2))
            {
                DataTable dtTerritoryhead = new DataTable();
                string Area = DropDownList1.SelectedItem.ToString();
                dtTerritoryhead = Report.getTerritoryHead(Area);
                DropDownList2.DataTextField = "Territory";
                DropDownList2.DataSource = dtTerritoryhead;
                DropDownList2.DataBind();
            }
          

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            strlines = Convert.ToInt32("2");
            Label1.Text = Convert.ToString(strlines);

         

            DataTable dtPoint = new DataTable();
            if (Convert.ToInt32(Session["Permission"]) == 1)
            {

                string area = DropDownList1.SelectedItem.ToString();
                string territory = DropDownList2.SelectedItem.ToString();
                dtPoint = Report.getPoint(area, territory);
                DropDownList3.DataTextField = "point";

                DropDownList3.DataSource = dtPoint;
                DropDownList3.DataBind();
            }
           
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            strlines = Convert.ToInt32("3");
            Label1.Text = Convert.ToString(strlines);
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            orderInputClass newreport = new orderInputClass();
            string totalwd; string uptowd; string monthfromdate; string monthtodate;
        

            Calendar2.Visible = false;
            TextBox2.Text = Calendar2.SelectedDate.ToShortDateString();
            //-----Secondary----date
            string fromdate = Calendar1.SelectedDate.ToShortDateString();
            string todate = Calendar2.SelectedDate.ToShortDateString();
            DateTime dtfromdate = Convert.ToDateTime(fromdate);
            DateTime dttodate = Convert.ToDateTime(todate);
            DateTime primarydttodate = Convert.ToDateTime(todate);



            //Setting Start Date Month

            dt = newreport.getwoeks(dtfromdate, dttodate);


            totalwd = Convert.ToString(dt.Rows[0]["twd"].ToString());
            uptowd = dt.Rows[0]["utwd"].ToString();
            //----target date--------//
            monthfromdate = dt.Rows[0]["fromdate"].ToString();
            monthtodate = dt.Rows[0]["todatet"].ToString();
            //decimal.Round( Argument, Digits );
            decimal ach = decimal.Round(Convert.ToDecimal(uptowd) / Convert.ToDecimal(totalwd) * 100, 0);


            Int32 requartwd = Convert.ToInt32(totalwd) - Convert.ToInt32(uptowd);
            string targetachment = Convert.ToString(ach).ToString() + '%';
            TextBox3.Text = totalwd;
            TextBox4.Text = uptowd;
            TextBox5.Text = targetachment;
            TextBox6.Text = Convert.ToString(requartwd);

            Session["primarydttodate"] = primarydttodate;
            Session["monthfromdate"] = monthfromdate;
            Session["monthtodate"] = monthtodate;
            Session["totalwd"] = totalwd;
            Session["uptowd"] = uptowd;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            DataTable dtdetails = new DataTable();
            int permissionnumber = int.Parse(Session["Permission"].ToString());
            int enroll = int.Parse(Session["enroll"].ToString());
            if (TextBox2.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Select Date!');", true);

            }
            else
            {


                string fromdt = Calendar1.SelectedDate.ToShortDateString();
                DateTime fromdate = Convert.ToDateTime(fromdt);
                string todt = Calendar2.SelectedDate.ToShortDateString();
                DateTime todate = Convert.ToDateTime(todt);

                Session["fromdate"] = fromdate;
                Session["todate"] = todate;

                     string area = DropDownList1.SelectedItem.Text;
                string territory;
                string point;
               

                Session["sarea"] = area;
               // Session["sterritory"] = territory;
              //  Session["spoint"] = point;
            



                if (Label1.Text == "")
                {
                    Label1.Text = Convert.ToString("0");
                }
                else
                {
                    strlines = Convert.ToInt32(Label1.Text.ToString());
                }
                Session["num"] = strlines;

                Int32 part = 1;
                Int32 number = 3;
                Session["part"] = part;
                Session["numbers"] = Session["num"];
                int numbers = int.Parse(strlines.ToString());
                DateTime monthfromdate = Convert.ToDateTime(Session["monthfromdate"]);
                DateTime monthtodate = Convert.ToDateTime(Session["monthtodate"]);
                DateTime primarydttodate = Convert.ToDateTime(Session["primarydttodate"]);
                Int32 totalwd = Convert.ToInt32(Session["totalwd"]);
                Int32 uptowd = Convert.ToInt32(Session["totalwd"]);
                string location ;

                //dtdetails = newreport.getdetails(fromdate, todate, monthfromdate, monthtodate, enroll, primarydttodate, strregion, totalwd, uptowd, part, number, strline, strarea, strterritory, strpoints, strsection);
                //  GridView1.DataSource = dtdetails;
                // GridView1.DataBind();
                if (permissionnumber == 1)
                {
                    if (numbers == 1)
                    {
                        location = DropDownList1.SelectedItem.ToString();
                        territory = "0";
                        point = "0";
                        number = 2;
                        part = 1;
                        dtdetails = Report.getdetails(fromdate, todate,part,location);
                        GridView1.DataSource = dtdetails;
                        GridView1.DataBind();
                    }
                    else if (numbers == 2)
                    {
                        location = DropDownList2.SelectedItem.ToString();
                        point = "0";
                        territory = DropDownList2.SelectedItem.Text;
                         number = 3;
                        part = 1;
                        dtdetails = Report.getdetails(fromdate, todate, part, location);
                        GridView1.DataSource = dtdetails;
                        GridView1.DataBind();
                    }
                    else if (numbers == 3)
                    {
                        location = DropDownList2.SelectedItem.ToString();
                         number = 4;
                        part = 1;
                        dtdetails = Report.getdetails(fromdate, todate, part, location);
                        GridView1.DataSource = dtdetails;
                        GridView1.DataBind();
                    }
                  
                   

                }


               
            }


        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            strlines = Convert.ToInt32("1");
            Label1.Text = Convert.ToString(strlines);


            // hdnAreanumber.Value = "2";
               DataTable dtTerritoryhead = new DataTable();
                string Area = DropDownList1.SelectedItem.ToString();
                dtTerritoryhead = Report.getTerritoryHead(Area);
                DropDownList2.DataTextField = "Territory";
                DropDownList2.DataSource = dtTerritoryhead;
                DropDownList2.DataBind();
       
           


        }

        protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            strlines = Convert.ToInt32("2");
            Label1.Text = Convert.ToString(strlines);



            DataTable dtPoint = new DataTable();
           

                string area = DropDownList1.SelectedItem.ToString();
                string territory = DropDownList2.SelectedItem.ToString();
                dtPoint = Report.getPoint(area, territory);
                DropDownList3.DataTextField = "point";

                DropDownList3.DataSource = dtPoint;
                DropDownList3.DataBind();
           
          
        }

        protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
        {
            strlines = Convert.ToInt32("3");
            Label1.Text = Convert.ToString(strlines);
        }
    }
}