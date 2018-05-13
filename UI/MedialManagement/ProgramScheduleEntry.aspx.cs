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
        int intEnroll, intProgramType, intUnitID, intCustID, intProgramID, intProgramCount, intProgramReportID, intDuration, intHeight, intWidth, intPOID; 
        DateTime FDate, TDate, dteDate, FDateTime, TDateTime;
        TimeSpan FTime, TTime; bool ysnScheduleOwn;
        string strNarration, strCustProgramName;
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
                LoadPOList();
                GetDuration();
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
            try
            {
                FDate = DateTime.Parse(txtFromDate.Text);
                TDate = DateTime.Parse(txtToDate.Text);
                intCustID = int.Parse(ddlSupplierName.SelectedValue.ToString());
                intProgramID = int.Parse(ddlProgramName.SelectedValue.ToString());
                intProgramCount = int.Parse(txtCount.Text);
                ysnScheduleOwn = true;
                intProgramType = int.Parse(ddlProgramType.SelectedValue.ToString());
                intProgramReportID = 0;
                strNarration = txtNarration.Text;
                FTime = TimeSpan.Parse(tmStart.Date.ToString("hh:mm:ss"));
                TTime = TimeSpan.Parse(tmEnd.Date.ToString("hh:mm:ss"));
                try
                {
                    intPOID = int.Parse(ddlPO.SelectedValue.ToString());
                }
                catch { intPOID = 0; }

                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                if (intProgramType == 3)
                {
                    intDuration = 0;
                    intHeight = int.Parse(txtDuration.Text);
                    intWidth = int.Parse(txtAdname.Text);
                    strCustProgramName = "Press Media";
                }
                else
                {
                    intDuration = int.Parse(txtDuration.Text);
                    intHeight = 0;
                    intWidth = 0;
                    strCustProgramName = txtAdname.Text;
                }
                    
                for (DateTime date = FDate; date <= TDate; date = date.AddDays(1))
                {
                    FDateTime = FDate.Add(FTime);
                    TDateTime = FDate.Add(TTime);
                    if (intPOID == 0)
                    {
                        bll.InsertProgramScheduleWithoutPO(intCustID, intProgramID, FDateTime, TDateTime, intProgramCount, ysnScheduleOwn, intProgramReportID, intDuration, strNarration, strCustProgramName, intProgramType, intUnitID, intHeight, intWidth);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Schedule Inserted without PO.');", true);
                    }
                    else
                    {
                        bll.InsertProgramScheduleWihtPO(intCustID, intProgramID, FDateTime, TDateTime, intProgramCount, ysnScheduleOwn, intProgramReportID, intDuration, strNarration, strCustProgramName, intProgramType, intUnitID, intHeight, intWidth, intPOID);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Schedule Inserted with PO.');", true);
                    }
                }
            }
            catch { }
        }

        protected void ddlSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPOList();
        }

        private void LoadPOList()
        {
            try
            {
                dteDate = DateTime.Parse(txtFromDate.Text);
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());
                intCustID = int.Parse(ddlSupplierName.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetPOlist(intUnitID, dteDate, intCustID);
                ddlPO.DataSource = dt;
                ddlPO.DataTextField = "intPOID";
                ddlPO.DataValueField = "strPODate";
                ddlPO.DataBind();
            }
            catch { }
        }

        protected void ddlProgramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplier();
            LoadProgName();
            LoadPOList();
            GetDuration();
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSupplier();
            LoadProgName();
            LoadPOList();
            GetDuration();
        }
        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            LoadPOList();
        }
        protected void ddlProgramName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDuration();
        }

        private void GetDuration()
        {
            try
            {
                intProgramID = int.Parse(ddlProgramName.SelectedValue.ToString());
                dt = new DataTable();
                dt = bll.GetDuration(intProgramID);
                if (dt.Rows.Count == 1)
                {
                    txtDuration.Text = dt.Rows[0][0].ToString();
                }
                else { txtDuration.Text = ""; }
            }
            catch { txtDuration.Text = ""; }
        }
    }
}