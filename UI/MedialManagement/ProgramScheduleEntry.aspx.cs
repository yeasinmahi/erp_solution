using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;
using Purchase_BLL;

namespace UI.MedialManagement
{
    public partial class ProgramScheduleEntry : System.Web.UI.Page
    {
        DataTable dt; Media bll = new Media();
        int intEnroll, intProgramType, intUnitID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
                    hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
                    intEnroll = int.Parse(hdnEnroll.Value);
                    dt = new DataTable();
                    dt = bll.GetUnit(intEnroll);
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataBind();

                    InitializeControl();
                }
                catch
                { }
            }
        }

        private void InitializeControl()
        {
            try
            {
                dt = new DataTable();
                dt = bll.GetProgramType();
                ddlProgramType.DataSource = dt;
                ddlProgramType.DataTextField = "strProgramType";
                ddlProgramType.DataValueField = "intID";
                ddlProgramType.DataBind();

                LoadSupplier();
                LoadProgName();
            }
            catch { }
        }

        private void LoadProgName()
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intProgramType = int.Parse(ddlProgramType.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetProgramName(intUnitID, intProgramType);
                ddlProgramName.DataSource = dt;
                ddlProgramName.DataTextField = "strProgramName";
                ddlProgramName.DataValueField = "intID";
                ddlProgramName.DataBind();

                if (intProgramType == 3)
                {
                    lblDuration.Text = "Height (inch) :";
                    lblAdName.Text = "Width (Col) :";
                    lblCount.Text = "No. of Insertion :";
                    lblstart.Visible = false;
                    lblend.Visible = false;
                    tmStart.Visible = false;
                    tmEnd.Visible = false;
                }
                else
                {
                    lblDuration.Text = "Duration (sec) :";
                    lblAdName.Text = "Ad Name :";
                    lblCount.Text = "Count :";
                    lblstart.Visible = true;
                    lblend.Visible = true;
                    tmStart.Visible = true;
                    tmEnd.Visible = true;
                }
            }
            catch { }
        }

        private void LoadSupplier()
        {
            try
            {
                intProgramType = int.Parse(ddlProgramType.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetSupplier(intProgramType);
                ddlSupplierName.DataSource = dt;
                ddlSupplierName.DataTextField = "strProgramCustName";
                ddlSupplierName.DataValueField = "intID";
                ddlSupplierName.DataBind();
            }
            catch { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void ddlProgramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplier();
            LoadProgName();

        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplier();
            LoadProgName();
        }
    }
}