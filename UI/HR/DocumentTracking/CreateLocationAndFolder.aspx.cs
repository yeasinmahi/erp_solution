using HR_BLL.DocumentTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.DocumentTracking
{
    public partial class CreateLocationAndFolder : System.Web.UI.Page
    {
        DocumentTrackingBLL obj = new DocumentTrackingBLL(); DataTable dt;
        int intPart, intDivisionID, intDeptID, intLocation, intInsertBy, intType;
        string strDivision, strDepartment, strSection, strLocation, strFolder;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
           
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                LoadData();
                try
                {
                    dt = new DataTable();
                    dt = obj.GetLocationData();
                    ddlLocation.DataTextField = "strLocation";
                    ddlLocation.DataValueField = "intLocationID";
                    ddlLocation.DataSource = dt;
                    ddlLocation.DataBind();
                }
                catch { }
                
            }
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            intDeptID = int.Parse(ddlDepartment.SelectedValue.ToString());

            dt = new DataTable();
            dt = obj.GetSectionData(intDeptID);
            ddlSection.DataTextField = "strSection";
            ddlSection.DataValueField = "intSectionID";
            ddlSection.DataSource = dt;
            ddlSection.DataBind();
        }

        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            intDivisionID = int.Parse(ddlDivision.SelectedValue.ToString());

            dt = new DataTable();
            dt = obj.GetDeptData(intDivisionID);
            ddlDepartment.DataTextField = "strDepartment";
            ddlDepartment.DataValueField = "intDeptID";
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataBind();
        }
        
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();

            try
            {
                dt = new DataTable();
                dt = obj.GetDivisionData();
                ddlDivision.DataTextField = "strDivision";
                ddlDivision.DataValueField = "intDivisionID";
                ddlDivision.DataSource = dt;
                ddlDivision.DataBind();
            }
            catch { }

            try
            {
                intDivisionID = int.Parse(ddlDivision.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetDeptData(intDivisionID);
                ddlDepartment.DataTextField = "strDepartment";
                ddlDepartment.DataValueField = "intDeptID";
                ddlDepartment.DataSource = dt;
                ddlDepartment.DataBind();
            }
            catch { }

            try
            {
                intDeptID = int.Parse(ddlDepartment.SelectedValue.ToString());

                dt = new DataTable();
                dt = obj.GetSectionData(intDeptID);
                ddlSection.DataTextField = "strSection";
                ddlSection.DataValueField = "intSectionID";
                ddlSection.DataSource = dt;
                ddlSection.DataBind();
            }
            catch { }

            try
            {
                dt = new DataTable();
                dt = obj.GetLocationData();
                ddlLocation.DataTextField = "strLocation";
                ddlLocation.DataValueField = "intLocationID";
                ddlLocation.DataSource = dt;
                ddlLocation.DataBind();
            }
            catch { }
        }

        private void LoadData()
        {
            try
            {
                lblLocation.Visible = false;
                ddlLocation.Visible = false;
                lblSection.Visible = false;
                ddlSection.Visible = false;
                lblDepartment.Visible = false;
                ddlDepartment.Visible = false;
                lblDivision.Visible = false;
                ddlDivision.Visible = false;

                intType = int.Parse(ddlType.SelectedValue);

                if (intType == 1)
                {
                    lblParam.Text = "Division:";

                }
                else if (intType == 2)
                {
                    lblDivision.Visible = true;
                    ddlDivision.Visible = true;
                    lblParam.Text = "Department:";
                }
                else if (intType == 3)
                {                    
                    lblDepartment.Visible = true;
                    ddlDepartment.Visible = true;
                    lblDivision.Visible = true;
                    ddlDivision.Visible = true;
                    lblParam.Text = "Section:";

                }
                else if (intType == 4)
                {
                    lblParam.Text = "Location:";
                }
                else if (intType == 5)
                {
                    lblLocation.Visible = true;
                    ddlLocation.Visible = true;
                    lblParam.Text = "Folder:";
                }

                //dt = objAprval.WHbyUnitID(intType);
                //ddlwh.DataSource = dt;
                //ddlwh.DataTextField = "strWareHoseName";
                //ddlwh.DataValueField = "intWHID";
                //ddlwh.DataBind();

                //dt = objAprval.CostCenterByUnit(unit);
                //ddlCostCenter.DataSource = dt;
                //ddlCostCenter.DataTextField = "strCCName";
                //ddlCostCenter.DataValueField = "intCostCenterID";
                //ddlCostCenter.DataBind();
            }
            catch { }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                intPart = int.Parse(ddlType.SelectedValue.ToString());

                if (intPart == 1)
                {
                    strDivision = txtParam.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);
                }
                else if (intPart == 2)
                {
                    intDivisionID = int.Parse(ddlDivision.SelectedValue.ToString());
                    strDepartment = txtParam.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);
                }
                else if (intPart == 3)
                {
                    intDeptID = int.Parse(ddlDepartment.SelectedValue.ToString());
                    strSection = txtParam.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);
                }
                else if (intPart == 4)
                {
                    strLocation = txtParam.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);
                }
                else if (intPart == 5)
                {
                    intLocation = int.Parse(ddlLocation.SelectedValue.ToString());
                    strFolder = txtParam.Text;
                    intInsertBy = int.Parse(hdnEnroll.Value);
                }

                //Final In Insert                        
                string message = obj.InsertDTS(intPart, intDivisionID, strDivision, intDeptID, strDepartment, strSection, intLocation, strLocation, strFolder, intInsertBy);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + message + "');", true);
                txtParam.Text = "";
            }
            catch { }
        }











    }
}