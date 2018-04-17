using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.Corporate_Sales;
using UI.ClassFiles;
using System.Data;
using System.Xml;
using System.IO;
using SAD_BLL.Corporate_sales;



namespace UI.SAD.Corporate_sales
{
    public partial class SalesOrderReport : System.Web.UI.Page
    {
        Bridge obj = new Bridge(); DataTable dtarea = new DataTable(); DataTable dtterritory = new DataTable(); DataTable dtpoint= new DataTable();
        DataTable dttotal = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Int32 enroll = Convert.ToInt32(Session["employeeenroll"].ToString());
               // Int32 enroll = Convert.ToInt32("241991".ToString());  

               

            
            }

        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnAreanumber.Value = "1";
            try
            {
                dtarea = obj.getareaname();
                ddlarea.DataSource = dtarea;
                ddlarea.DataTextField = "area";
                ddlarea.DataValueField = "areaenroll";
                ddlarea.DataBind();
            }
            
            catch
            { 

            }
       
           
        }
     
        protected void ddlarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            hdnAreanumber.Value = "2";
            try
            {
            int area = Convert.ToInt16(ddlarea.SelectedItem.Value);
            dtterritory = obj.gettername(area);
            ddlTerritory.DataSource = dtterritory;
            ddlTerritory.DataTextField = "strterritory";
            ddlTerritory.DataValueField = "intterritoryenroll";
            ddlTerritory.DataBind();
            }
            
            catch
            { 

            }

        }


        protected void ddlTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnAreanumber.Value = "3";
            try
            {
            int territory = Convert.ToInt32(ddlTerritory.SelectedItem.Value);
            dtpoint = obj.getpopint(territory);
            ddlpoint.DataSource = dtpoint;
            ddlpoint.DataTextField = "strpoint";
            ddlpoint.DataValueField = "intcustid";
          
            ddlpoint.DataBind();

            }

            catch
            {

            }

            
        }

        protected void ddlpoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnAreanumber.Value = "4";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            int areanumber = int.Parse(hdnAreanumber.Value.ToString());
            int datesales = int.Parse(hdnDatewise.Value.ToString());
          
           int ReportCategoryid = int.Parse(ddlcategory.SelectedValue.ToString());
           DateTime fromdate = Convert.ToDateTime(txtfromdate.Text);
           DateTime todate = Convert.ToDateTime(txttodate.Text);
           
            if ((rbntdaily.Checked ==true) || (rbntdatewise.Checked ==true))
            {
               

           try
           {
               if (datesales == 1)  //Daily or datewise ---- daily=1 datewise=2
               {
                   //if (areanumber == 1) //region area territory point
                   //{

                   //}
                   if (areanumber == 2) //region area territory point
                   {
                       DataTable dtareareport = new DataTable();
                       dtareareport = obj.getareasales(fromdate, todate, ReportCategoryid);
                       dgvtrgtArea.DataSource = dtareareport;
                       dgvtrgtArea.DataBind();
                       dgvtrgtArea.Visible = true;
                       dgvTerritory.Visible = false;
                       dgvNational.Visible = false;
                       dgvdate.Visible = false;

                   }
                   else if (areanumber == 3) //region area territory point
                   {
                       DataTable dtterr = new DataTable();
                       dtterr = obj.getterritorysales(fromdate, todate, ReportCategoryid);
                       dgvTerritory.DataSource = dtterr;
                       dgvTerritory.DataBind();
                       dgvtrgtArea.Visible = false;
                       dgvTerritory.Visible = true;
                       dgvNational.Visible = false;
                       dgvdate.Visible = false;

                   }

                   else if (areanumber == 4) //region area territory point
                   {
                        dttotal = obj.getAllSalesInInstitute(fromdate, todate, ReportCategoryid);
                       dgvNational.DataSource = dttotal;
                       dgvNational.DataBind();

                       dgvtrgtArea.Visible = false;
                       dgvTerritory.Visible = false;
                       dgvNational.Visible = true;
                       dgvdate.Visible = false;
                   }
                   else { }
               }


               else //if (datesales == 2) Daily or datewise ---- daily=1 datewise=2
               {
                   //if (areanumber == 1) //region area territory point
                   //{

                   //    dttotal = obj.getAllSalesInInstitutedate(fromdate, todate);
                   //    dgvdate.DataSource = dttotal;
                   //    dgvdate.DataBind();

                   //}
                    if (areanumber == 2) //region area territory point
                   {
                       DataTable dtareareport = new DataTable();
                       dtareareport = obj.getareasalesdate(fromdate, todate);
                       dgvdate.DataSource = dtareareport;
                       dgvdate.DataBind();
                       dgvtrgtArea.Visible = false;
                       dgvTerritory.Visible = false;
                       dgvNational.Visible = false;
                       dgvdate.Visible = true;


                   }
                   else if (areanumber == 3) //region area territory point
                   {
                       DataTable dtterr = new DataTable();
                       int territory = Convert.ToInt32(ddlTerritory.SelectedItem.Value);
                       dtterr = obj.getterritorysalesdate(fromdate, todate, territory);
                       dgvdate.DataSource = dtterr;
                       dgvdate.DataBind();
                       dgvtrgtArea.Visible = false;
                       dgvTerritory.Visible = false;
                       dgvNational.Visible = false;
                       dgvdate.Visible = true;

                   }

                   else if (areanumber == 4) //region area territory point
                   {
                       DataTable point = new DataTable();
                       int pointid = Convert.ToInt32(ddlpoint.SelectedItem.Value);
                       point = obj.getpointsalesdate(fromdate, todate, pointid);
                       dgvdate.DataSource = point;
                       dgvdate.DataBind();
                       dgvtrgtArea.Visible = false;
                       dgvTerritory.Visible = false;
                       dgvNational.Visible = false;
                       dgvdate.Visible = true;
                   }
                   else { }



               }
           }

           catch
           { 
           }


            }


            else { 
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Check Daily Sales or Datewise Sales');", true);
            }
              
            
            }
             

        protected void rbntdaily_CheckedChanged(object sender, EventArgs e)
        {
            hdnDatewise.Value = "1";
        }

        protected void rbntdatewise_CheckedChanged(object sender, EventArgs e)
        {
            hdnDatewise.Value = "2";
        }

       

        
    }
}