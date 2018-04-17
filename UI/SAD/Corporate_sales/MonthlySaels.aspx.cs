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


namespace UI.SAD.Corporate_sales
{
    public partial class MonthlySaels : System.Web.UI.Page
    {
        DataTable dtArea = new DataTable();
        orderInputClass Report = new orderInputClass();
        string location;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtArea = Report.getarea();
                DropDownList1.DataTextField = "Area";
                DropDownList1.DataSource = dtArea;
                DropDownList1.DataBind();
                Calendar1.Visible = false;
                Calendar2.Visible = false;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void ddlarea_SelectedIndexChanged(object sender, EventArgs e)
        {

            hdnAreanumber.Value = "1";
            DataTable dtTerritoryhead = new DataTable();
            string Area = DropDownList1.SelectedItem.ToString();
            dtTerritoryhead = Report.getTerritoryHead(Area);
            ddlTerritory.DataTextField = "Territory";
            ddlTerritory.DataSource = dtTerritoryhead;
            ddlTerritory.DataBind();
        }

        protected void ddlTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnAreanumber.Value = "2";
            DataTable dtPoint = new DataTable();
            string area = DropDownList1.SelectedItem.ToString();
            string territory = ddlTerritory.SelectedItem.ToString();
            dtPoint = Report.getPoint(area, territory);
            ddlCustName.DataTextField = "point";

            ddlCustName.DataSource = dtPoint;
            ddlCustName.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
            txtfromdates.Text = Calendar1.SelectedDate.ToShortDateString();
           
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Calendar2.Visible = false;

            txttodate.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dtReport = new DataTable();
            DateTime dtefromdate =DateTime.Parse(txtfromdates.Text.ToString());
            DateTime dtetodate = DateTime.Parse(txttodate.Text.ToString());
            int part = int.Parse(hdnAreanumber.Value);
           
            if(part==int.Parse("1"))
            {
            location=ddlarea.SelectedItem.ToString();
            }
            else if(part==int.Parse("2"))
            {
            location=ddlTerritory.SelectedItem.ToString();
            }
            else if(part==int.Parse("3"))
            {
            location=ddlCustName.SelectedItem.ToString();
            }
            dtReport = Report.getMonthlyReportCorp(dtefromdate, dtetodate, part, location);

            GridView1.DataSource = dtReport;
            GridView1.DataBind();
        }

        protected void ddlCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnAreanumber.Value = "3";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtCreditLimit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}