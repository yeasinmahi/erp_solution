using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using HR_BLL.Global;
namespace UI.Inventory
{
    public partial class RequisitionView : BasePage
    {
        DateTime fdate, tdate;
        DaysOfWeek obj = new DaysOfWeek();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //hdnpoint.Value = HttpContext.Current.Session[SessionParams.JOBSTATION_ID].ToString();
                //if ((int.Parse(hdnpoint.Value) >= 1 && int.Parse(hdnpoint.Value) <= 22)) { if (hdnpoint.Value == "2") { hdntype.Value = "0"; } else { hdntype.Value = "1"; } }
                //else { hdntype.Value = "0"; }
                pnlUpperControl.DataBind();
                //hdnwh.Value = ddlWH.SelectedValue.ToString();
                
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "loadIframe('frame', 'https://report.akij.net/reports/report/Ruhul/Binti/RequisitionById?rs:Embed=true');", true);

        }
        //protected void btnShow_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();
        //    hdnwh.Value = ddlWH.SelectedValue.ToString();
        //    int intWhid = Convert.ToInt32(hdnwh.Value);
        //    fdate = DateTime.Parse(txtFormDate.Text);
        //    tdate = DateTime.Parse(txtToDate.Text);
        //    dt = obj.GetRequisitionById(intWhid, fdate,tdate);
        //    if(dt.Rows.Count>0)
        //    {
        //        GvList.DataSource = dt;
        //        GvList.DataBind();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Data is not Found');", true);
        //        GvList.DataSource = dt;
        //        GvList.DataBind();
        //    }
            

        //}

        //protected void Dtls_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        char[] delimiterChars = { '^' };
        //        string temp = ((Button)sender).CommandArgument.ToString();
        //        string[] datas = temp.Split(delimiterChars);
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "Viewdetails('" + datas[0].ToString() + "');", true);
        //    }
        //    catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        //}
        //protected void ddlWH_DataBound(object sender, EventArgs e)
        //{
        //    //hdnwh.Value = ddlWH.SelectedValue.ToString();
        //    try
        //    {
        //        hdnwh.Value = ddlWH.SelectedValue.ToString();
        //        Session["WareID"] = hdnwh.Value;
        //    }
        //    catch { }

        //}

       

        ////protected void GvList_RowCommand(object sender, GridViewCommandEventArgs e)
        ////{
            
        ////        if (e.CommandName != "GV") return;
        ////    int index = Convert.ToInt32(e.CommandArgument);
        ////    GridViewRow row = GvList.Rows[index];
        ////    string reqid = Convert.ToString((row.FindControl("code") as Label).Text);

        ////}

        //protected void ddlWH_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // hdnwh.Value = ddlWH.SelectedValue.ToString();
        //    try
        //    {
        //        hdnwh.Value = ddlWH.SelectedValue.ToString();
        //        Session["WareID"] = hdnwh.Value;
        //    }
        //    catch { }
        //    //File.Delete(xmlpath); LoadXml();
        //}























    }
}