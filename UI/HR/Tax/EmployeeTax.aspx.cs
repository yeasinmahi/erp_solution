using HR_BLL.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.HR.Tax
{
    public partial class EmployeeTax : BasePage
    {
        AbsentReport rpt = new AbsentReport();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind(); btnRequest.Enabled = false;
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = rpt.GetTaxAbleEmployee(int.Parse(ddlUnit.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    dgvtax.Columns[5].FooterText = dt.AsEnumerable().Select(x => x.Field<decimal>("monTaxAmount")).Sum().ToString("0.00");
                    dgvtax.DataSource = dt; dgvtax.DataBind();
                }
                else
                {
                    dgvtax.DataSource = null; dgvtax.DataBind();
                }
            }
            catch { }
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            if (hdnconfirm.Value == "1")
            {
                try
                {
                    int rowCount = dgvtax.Rows.Count; bool ysnChecked;
                    for (int i = 0; i < rowCount; i++)
                    {
                        ysnChecked = ((CheckBox)dgvtax.Rows[i].Cells[0].Controls[0]).Checked;
                        if (ysnChecked)
                        {
                            int usrid = int.Parse(Session[SessionParams.USER_ID].ToString());
                            int selectedenrollid = int.Parse(((HiddenField)dgvtax.Rows[i].FindControl("hdnenroll")).Value.ToString());
                            rpt.UpdatePaidRequestForTax(usrid, selectedenrollid);
                        }
                    }
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('This request has been submitted successfully.');", true);
                    LoadGrid();
                    chkAll.Checked = false;
                }
                catch
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Sorry for this request.');", true); }
            }
        }

        #region  ------------------ DataBound and IndexChange Event Handaler ---------
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                int rowCount = dgvtax.Rows.Count;
                if (rowCount > 0)
                {
                    btnRequest.Enabled = true;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvtax.Rows[i].Cells[0].Controls[0]).Checked = true; }
                        catch { }
                    }
                }
                else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "Status", "alert('There are no data records to select. !!!');", true); }
            }

            else
            {
                int rowCount = dgvtax.Rows.Count;
                if (rowCount > 0)
                {
                    btnRequest.Enabled = false;
                    for (int i = 0; i < rowCount; i++)
                    {
                        try { ((CheckBox)dgvtax.Rows[i].Cells[0].Controls[0]).Checked = false; }
                        catch { }
                    }
                }
            }
        }
        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            LoadGrid();
        }
        protected void ddlUnit_DataBound(object sender, EventArgs e)
        {
            Session[SessionParams.CURRENT_UNIT] = ddlUnit.SelectedValue;
            LoadGrid();
        }

        #endregion
    }
}