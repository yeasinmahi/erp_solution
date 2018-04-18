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
    public partial class EntryForm : BasePage
    {
        DataTable dt; Media bll = new Media();
        int intEnroll, intEntryType, intUnitID, intTypeID, intDuration, intProgTypeID, intBrandID;
        string strProgramType, strBrandType, strBrandName, strNewProgramName;
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
                lblBrandType.Visible = false;
                ddlBrandType.Visible = false;
                lblBrandName.Visible = false;
                ddlBrandName.Visible = false;
                lblDuration.Visible = false;
                txtDuration.Visible = false;

                lblEntryName.Text = ddlEntryType.SelectedItem.ToString() + " :";
                intEntryType = int.Parse(ddlEntryType.SelectedValue.ToString());
                if (intEntryType == 3)
                {
                    lblBrandType.Text = "Brand Type :";
                    lblBrandType.Visible = true;
                    ddlBrandType.Visible = true;
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    dt = new DataTable();
                    dt = bll.GetBrandType(intUnitID);
                    ddlBrandType.DataSource = dt;
                    ddlBrandType.DataTextField = "strBrandType";
                    ddlBrandType.DataValueField = "intID";
                    ddlBrandType.DataBind();
                }
                else if (intEntryType == 4)
                {
                    lblBrandType.Visible = true;
                    ddlBrandType.Visible = true;
                    lblBrandName.Visible = true;
                    ddlBrandName.Visible = true;
                    lblDuration.Visible = true;
                    txtDuration.Visible = true;
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    lblBrandType.Text = "Program Type :";
                    dt = new DataTable();
                    dt = bll.GetProgramType();
                    ddlBrandType.DataSource = dt;
                    ddlBrandType.DataTextField = "strProgramType";
                    ddlBrandType.DataValueField = "intID";
                    ddlBrandType.DataBind();

                    dt = new DataTable();
                    dt = bll.GetBrand(intUnitID);
                    ddlBrandName.DataSource = dt;
                    ddlBrandName.DataTextField = "strBrandName";
                    ddlBrandName.DataValueField = "intID";
                    ddlBrandName.DataBind();
                }

            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeControl();
        }

        protected void ddlEntryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeControl();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                intEntryType = int.Parse(ddlEntryType.SelectedValue.ToString());
                if (intEntryType == 1)
                {
                    strProgramType = txtEntry.Text;
                    bll.InsertProgramType(strProgramType);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Program Type Inserted.');", true);
                }
                else if (intEntryType == 2)
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    strBrandType = txtEntry.Text;
                    bll.InsertBrandType(strBrandType, intUnitID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Brand Type Inserted.');", true);
                }
                else if (intEntryType == 3)
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    strBrandName = txtEntry.Text;
                    intTypeID = int.Parse(ddlBrandType.SelectedValue.ToString());
                    bll.InserBrand(strBrandName, intTypeID, intUnitID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Brand Inserted.');", true);
                }
                else if (intEntryType == 4)
                {
                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                    strNewProgramName = txtEntry.Text;
                    intDuration = int.Parse(txtDuration.Text);
                    intProgTypeID = int.Parse(ddlBrandType.SelectedValue.ToString());
                    intBrandID = int.Parse(ddlBrandName.SelectedValue.ToString());
                    bll.InserProgram(strNewProgramName, intDuration, intUnitID, intProgTypeID, intBrandID);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Program Inserted.');", true);
                }
            }
            catch { }
        }
    }
}