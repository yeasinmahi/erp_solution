using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;


namespace UI.Transport
{
    public partial class Utility_ReportForSubmit : BasePage
    {
        InternalTransportBLL obj = new InternalTransportBLL(); Utility_BLL objut = new Utility_BLL();
        DataTable dt;

        int intWork; int intUnitID; DateTime dteFromDate; DateTime dteToDate; int intUtilityID;
        string strServiceName; int intReg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitListForTransport(int.Parse(hdnEnroll.Value));
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    dt = objut.GetServiceList();
                    ddlServiceList.DataTextField = "strServiceName";
                    //ddlServiceList.DataValueField = "intID";
                    ddlServiceList.DataSource = dt;
                    ddlServiceList.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());                                      

                    LoadGrid();                    
                }
                catch
                { } 
            }
            else
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                HttpContext.Current.Session["intUnitID"] = intUnitID.ToString();
                HttpContext.Current.Session["dteFromDate"] = txtFromDate.Text;
                HttpContext.Current.Session["dteToDate"] = txtToDate.Text;                               
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                try
                {
                    txtFromDate.Text = HttpContext.Current.Session["dteFromDate"].ToString();
                    txtToDate.Text = HttpContext.Current.Session["dteToDate"].ToString();
                }
                catch { }

                dteFromDate = DateTime.Parse(HttpContext.Current.Session["dteFromDate"].ToString());
                dteToDate = DateTime.Parse(HttpContext.Current.Session["dteToDate"].ToString());
                intUnitID = int.Parse(HttpContext.Current.Session["intUnitID"].ToString());
                                
                ddlUnit.SelectedValue = intUnitID.ToString();
                strServiceName = ddlServiceList.SelectedItem.ToString();
                intReg = 0;
               
                intUtilityID = 0;

                intWork = 2;
                dt = new DataTable();
                dt = objut.GetUtilityProfile(intWork, intUnitID, dteFromDate, dteToDate, intUtilityID, strServiceName, intReg);
                dgvReport.DataSource = dt;
                dgvReport.DataBind();
            }
            catch
            { }
        }

        protected decimal totalgovfee = 0;
        protected decimal totalincidentalcost = 0;
        protected decimal totalcost = 0;
        protected void dgvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalgovfee += decimal.Parse(((Label)e.Row.Cells[13].FindControl("lblGovFee")).Text);
                    totalincidentalcost += decimal.Parse(((Label)e.Row.Cells[14].FindControl("lblIncidentalCost")).Text);
                    totalcost += decimal.Parse(((Label)e.Row.Cells[15].FindControl("lblTotalCost")).Text);
                }

            }
            catch { }
        }

        protected void btnAction_Click(object sender, EventArgs e)  
        {
            intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
            HttpContext.Current.Session["intUnitID"] = intUnitID.ToString();
            HttpContext.Current.Session["dteFromDate"] = txtFromDate.Text;
            HttpContext.Current.Session["dteToDate"] = txtToDate.Text;

            string senderdata = ((Button)sender).CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ReportForSubmit('" + senderdata + "');", true);
           
        }









    }
}