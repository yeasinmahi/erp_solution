using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAD_BLL.AEFPS;
using System.Data;
using System.Text.RegularExpressions;
using UI.ClassFiles;
using System.Drawing.Printing;
using System.Drawing;

namespace UI.AEFPS
{
    public partial class fpsDueReport : BasePage
    {
        int intWID, intInsertby;
        DataTable dt;
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        DateTime dtefdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                pnlUpperControl.DataBind();
                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());

                dt = objAEFPS.getWH(intInsertby);
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataSource = dt;
                ddlWH.DataBind();

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtfdate.Text != "") )
            {
                dtefdate = DateTime.Parse(txtfdate.Text.ToString());
                lblWHName.Text = ddlWH.SelectedItem.ToString();
                lblHeading.Text = "Employee Due Report";
                lblDate.Text = "AS On Date :" + dtefdate.ToString("dd-MM-yyyy");
              
                intWID = int.Parse(ddlWH.SelectedValue);
                dt = objAEFPS.GetDueReport(dtefdate, intWID);
                if (dt.Rows.Count > 0)
                {
                    dgvRptTemp.DataSource = dt;
                    dgvRptTemp.DataBind();
                }
                else
                {
                dgvRptTemp.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Available Data !');", true); }
                }else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-up Date !');", true);
            }
        }
        protected decimal  TotalAmounts = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                  if (((Label)e.Row.Cells[2].FindControl("lblmonAmount")).Text == "")
                {
                    TotalAmounts += 0;
                }
                else
                {
                    TotalAmounts += decimal.Parse(((Label)e.Row.Cells[2].FindControl("lblmonAmount")).Text);
                }
            }
        }
    }
}