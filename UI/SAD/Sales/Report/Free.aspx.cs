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
using SAD_BLL.Sales;
using GLOBAL_BLL;
using Flogging.Core;

namespace UI.SAD.Sales.Report
{
    public partial class Free : BasePage
    {
        DataTable dtshipingpoint = new DataTable();
        DataTable dtfree = new DataTable();
        SalesByCusPro objfree = new SalesByCusPro();
        Int32 number;
        SeriLog log = new SeriLog();
        string location = "SAD";
        string start = "starting SAD\\Sales\\Report\\Free";
        string stop = "stopping SAD\\Sales\\Report\\Free";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                //Int32 unitid =int.Parse(Session[SessionParams.UNIT_ID].ToString());
                Int32 unitid = 2;
                dtshipingpoint = objfree.getshipingpoints(unitid);
                DropDownList1.DataTextField = "shipname";
                DropDownList1.DataValueField = "shipid";
                DropDownList1.DataSource = dtshipingpoint;
                DropDownList1.DataBind();
            }
        }

        protected void ddlFHour_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTHour_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void txtFrom_TextChanged(object sender, EventArgs e)
        //{

        //}

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Show", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on SAD\\Sales\\Report\\Free Free/Promotion Report", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

           Int32 intreportid;
           Int32 number=Convert.ToInt32(Session["number"]);
           Int32 unitid =int.Parse(Session[SessionParams.UNIT_ID].ToString());
          string  frm = txtFrom.Text + " " + ddlFHour.SelectedValue;
          string  to = txtTo.Text + " " + ddlTHour.SelectedValue;
          if (Convert.ToString(DropDownList1.SelectedItem.ToString())== "--All--")
          {
              intreportid = 1;
          }
          else
          {
          intreportid=2;
          }
            Int32 intshipingid=Convert.ToInt32(DropDownList1.SelectedValue.ToString());
            if (number == 1)
            {
                dtfree = objfree.getfree(intreportid, number, frm, to, intshipingid, unitid);
                GridView1.DataSource = dtfree;
                GridView1.DataBind();
                GridView1.Visible = true;
                dgvReport.Visible = false;
            }
            else
            {
                dtfree = objfree.getfree(intreportid, number, frm, to, intshipingid, unitid);
                dgvReport.DataSource = dtfree;
                dgvReport.DataBind();
                GridView1.Visible = false;
                dgvReport.Visible = true;
            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Show", ex);
                Flogger.WriteError(efd);
            }

            fd = log.GetFlogDetail(stop, location, "Show", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        protected void Productwise_CheckedChanged(object sender, EventArgs e)
        {
            number = 1;
            Session["number"] = number;
        }

        protected void CustWise_CheckedChanged(object sender, EventArgs e)
        {
            number = 2;
            Session["number"] = number;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

       
    }
}