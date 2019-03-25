using HR_BLL.Settlement;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Insurance
{
    public partial class InsuranceInformationUpdate : BasePage
    {
        GlobalClass obj = new GlobalClass();
        DataTable dt;
        string permis, medicaltypeid, medicalt;
        int intUnit, pkid, intJobSatation, userenrol,rpttype; bool ysnAll;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //pnlUpperControl.DataBind();
                    userenrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    obj.GetInsurancePermissionstatus(userenrol, ref permis);
                    if (permis == "Yes") { chkValidity.Enabled = true; }
                    else { chkValidity.Enabled = false; }
                    chkValidity.Enabled = true;


                }
                catch
                { }
            }

        }

      

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void ddlJobStation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void LoadGrid()
        {
            try
            {
                permis = "";
                bool chk = chkValidity.Checked;
                pkid = 0;
                medicaltypeid = "";
                userenrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                obj.GetInsurancePermissionstatus(userenrol, ref permis);
                if (permis == "Yes" && chk == true) { rpttype = 3; }
                else { rpttype = 1; }


                //rpttype = int.Parse(drdltype.SelectedValue.ToString());
                dt = new DataTable();
                intUnit = int.Parse(ddlUnit.SelectedValue.ToString());
                intJobSatation = int.Parse(ddlJobStation.SelectedValue.ToString());
                userenrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                dt = obj.GetInsuranceInfoUpdate(pkid, medicaltypeid, rpttype, intUnit, intJobSatation, userenrol);
                dgvDependant.DataSource = dt;
                dgvDependant.DataBind();
            }
            catch { }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

            rpttype = 2;
            
            for (int rowIndex = 0; rowIndex < dgvDependant.Rows.Count; rowIndex++)
            {

                string pkids = ((HiddenField)dgvDependant.Rows[rowIndex].FindControl("hdnintpkid")).Value.ToString();
                pkid = int.Parse(pkids);
               string  medicalt = ((DropDownList)dgvDependant.Rows[rowIndex].Cells[14].FindControl("drdlInsuranceType2")).SelectedItem.Text.ToString();
                dt = obj.GetInsuranceInfoUpdate(pkid, medicalt, rpttype, intUnit, intJobSatation, userenrol);
                break;

               
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully update your information ');", true);
            dgvDependant.DataSource = null;
            dgvDependant.DataBind();
        }
        protected void dgvDependant_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = new DataTable();
                dt = obj.GetInsuranceInTYPE();
                var ddlinstypecatg = (DropDownList)e.Row.FindControl("drdlInsuranceType2");
                ddlinstypecatg.DataSource = dt;
                ddlinstypecatg.DataTextField = "strInsuranceType";
                ddlinstypecatg.DataValueField = "intID";
                ddlinstypecatg.DataBind();
                ddlinstypecatg.Items.Insert(0, new ListItem("--Select type--", "0"));
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDependant.AllowPaging = false;
                SAD_BLL.Customer.Report.ExportClass.Export("Insurance.xls", dgvDependant);
            }
            catch { }
        }
    }
}