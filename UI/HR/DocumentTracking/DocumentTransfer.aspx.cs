using HR_BLL.DocumentTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.HR.DocumentTracking
{
    public partial class DocumentTransfer : System.Web.UI.Page
    {
        DocumentTrackingBLL obj = new DocumentTrackingBLL(); DataTable dt;
        int intUnitID, intJobStationID, intDivisionID, intDeptID, intSectionID, intLocationID, intFolderID, intQRCodeID;
        string strDocumentInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                try
                {
                    intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());

                    dt = new DataTable();
                    dt = obj.GetFolderData(intLocationID);
                    ddlFolder.DataTextField = "strFolder";
                    ddlFolder.DataValueField = "intFolderID";
                    ddlFolder.DataSource = dt;
                    ddlFolder.DataBind();
                }
                catch { }

            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                intQRCodeID = int.Parse(txtQRCode.Text);
                dt = new DataTable();
                dt = obj.GetDocInfo(intQRCodeID);
                txtFUnitName.Text = (string) dt.Rows[0]["strUnit"];
                txtFJobStation.Text = (string)dt.Rows[0]["strJobStationName"];
                txtFDivision.Text = (string)dt.Rows[0]["strDivision"];
                txtFDepartment.Text = (string)dt.Rows[0]["strDepartment"];
                txtFSection.Text = (string)dt.Rows[0]["strSection"];
                txtFLocation.Text = (string)dt.Rows[0]["strLocation"];
                txtFFolder.Text = (string)dt.Rows[0]["strFolder"];
                txtFDocInfo.Text = (string)dt.Rows[0]["strDocumentInfo"];

            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found.');", true); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intJobStationID = int.Parse(ddlJobStation.SelectedValue.ToString());
                intDivisionID = int.Parse(ddlDivision.SelectedValue.ToString());
                intDeptID = int.Parse(ddlDepartment.SelectedValue.ToString());
                intSectionID = int.Parse(ddlSection.SelectedValue.ToString());
                intLocationID = int.Parse(ddlLocation.SelectedValue.ToString());
                intFolderID = int.Parse(ddlFolder.SelectedValue.ToString());
                intQRCodeID = int.Parse(txtQRCode.Text.ToString());
                strDocumentInfo = txtTDocInfo.Text;

                if(txtFUnitName.Text == "" || txtFJobStation.Text == "" || txtFDivision.Text == "" || txtFDepartment.Text == "" || txtFSection.Text =="" || txtFFolder.Text == "" || txtFDocInfo.Text == "" || strDocumentInfo == "")
                {
                    return;
                }

                obj.UpdateTransfer(intUnitID, intJobStationID, intDivisionID, intDeptID, intSectionID, intLocationID, intFolderID, strDocumentInfo, intQRCodeID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Updated Successfully.');", true);
                txtFUnitName.Text = "";
                txtFJobStation.Text = "";
                txtFDivision.Text = "";
                txtFDepartment.Text = "";
                txtFSection.Text = "";
                txtFLocation.Text = "";
                txtFFolder.Text = "";
                txtFDocInfo.Text = "";
                txtTDocInfo.Text = "";
            }
            catch { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Updated.');", true); }
        }




    }
}