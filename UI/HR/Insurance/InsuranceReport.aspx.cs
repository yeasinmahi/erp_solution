using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using System.Data;
using HR_BLL.Settlement;

namespace UI.HR.Insurance
{
    public partial class InsuranceReport : BasePage
    {
        GlobalClass obj = new GlobalClass();
        DataTable dt;
        string permis;
        int intUnit, intJobSatation,userenrol; bool ysnAll;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {                    
                    //pnlUpperControl.DataBind();
                    userenrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                    obj.GetInsurancePermissionstatus(userenrol, ref permis);
                    if (permis == "Yes" ) { chkValidity.Enabled = true; }
                    else { chkValidity.Enabled = false; }
                    chkValidity.Enabled = true;



                    //if (userenrol == 1056 || userenrol == 1272 || userenrol == 1059 || userenrol == 1447 || userenrol == 118506 || userenrol == 316310 || userenrol == 1050 || userenrol == 1052 || userenrol == 1053 || userenrol == 1054)
                    //{ chkValidity.Enabled = true; }
                    //else { chkValidity.Enabled = false; }
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
                dt = new DataTable();
                intUnit = int.Parse(ddlUnit.SelectedValue.ToString());
                intJobSatation = int.Parse(ddlJobStation.SelectedValue.ToString());
                userenrol = int.Parse(HttpContext.Current.Session[SessionParams.USER_ID].ToString());
                obj.GetInsurancePermissionstatus(userenrol, ref permis);
                if (permis == "Yes" && chk == true) { ysnAll = true; }
                else { ysnAll = false; }

                //if (userenrol == 1056 && chk==true || userenrol == 1272 && chk == true || userenrol == 1059 && chk == true || userenrol == 1447 && chk == true || userenrol == 118506 && chk == true 
                //    || userenrol == 316310 && chk == true || userenrol == 1050 && chk == true || userenrol == 1052 && chk == true || userenrol == 1053 && chk == true || userenrol == 1054 && chk == true)

                //{ ysnAll = true; }
                //else { ysnAll = false;}


                dt = obj.GetInsuranceRData(intUnit, intJobSatation, ysnAll);
                dgvDependant.DataSource = dt;
                dgvDependant.DataBind();
            }
            catch { }
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