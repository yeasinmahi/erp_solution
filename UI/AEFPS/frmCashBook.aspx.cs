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
using System.Data.SqlClient;
using System.Configuration;

namespace UI.AEFPS
{
    public partial class frmCashBook : BasePage
    {
        int part,intWID,empid,intInsertby;
        DataTable dt;      
        FPSSalesEntryBLL objAEFPS = new FPSSalesEntryBLL();
        DateTime dtefdate, dtetdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                hdnEnroll.Value = (Session[SessionParams.USER_ID].ToString());
                intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());
                dt = objAEFPS.getWH(intInsertby);
                ddlWH.DataTextField = "strName";
                ddlWH.DataValueField = "Id";
                ddlWH.DataSource = dt;
                ddlWH.DataBind();
            }
            else{ }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtfdate.Text != "") || (txttdate.Text != ""))
                {
                    if (ddlReporttype.SelectedValue == "1")
                    {
                        dtefdate = DateTime.Parse(txtfdate.Text.ToString());
                        dtetdate = DateTime.Parse(txttdate.Text.ToString());
                        empid = int.Parse(hdnEnroll.Value.ToString());
                        intWID = int.Parse(ddlWH.SelectedValue);
                        lblfdate.Text = dtefdate.ToString("dd-MM-yyyy");
                        lbltdate.Text = dtetdate.ToString("dd-MM-yyyy");

                        part = 1;
                        dt = objAEFPS.getCashbook(dtefdate, dtetdate, intWID, part);
                        dgvRptTemp.DataSource = dt;
                        dgvRptTemp.DataBind();
                        part = 2;
                        dt = objAEFPS.getCashbook(dtefdate, dtetdate, intWID, part);

                        lblops.Text = Math.Round(decimal.Parse((dt.Rows[0]["ops"].ToString()))).ToString();
                        lblR.Text = Math.Round(decimal.Parse((dt.Rows[0]["Receive"].ToString()))).ToString();
                        lblCost.Text = Math.Round(decimal.Parse((dt.Rows[0]["Cost"].ToString()))).ToString();
                        lblCashinHand.Text = Math.Round(decimal.Parse((dt.Rows[0]["CashInHand"].ToString()))).ToString();
                        intInsertby = int.Parse(Session[SessionParams.USER_ID].ToString());

                        dt = objAEFPS.getWH(intInsertby);
                        ddlWH.DataTextField = "strName";
                        ddlWH.DataValueField = "Id";
                        ddlWH.DataSource = dt;
                        ddlWH.DataBind();
                        Label2.Text = "Cost";

                    }
                    else
                    {
                        intWID = int.Parse(ddlWH.SelectedValue);
                        dtefdate = DateTime.Parse(txtfdate.Text.ToString());
                        dtetdate = DateTime.Parse(txttdate.Text.ToString());
                        part = 1;
                        dt = objAEFPS.getShopLedger(dtefdate, dtetdate, intWID, part);

                        dgvRptTemp.DataSource = dt;
                        dgvRptTemp.DataBind();
                        part = 2;
                        dt = objAEFPS.getShopLedger(dtefdate, dtetdate, intWID, part);
                        if (dt.Rows.Count > 0)
                        {
                            lblR.Text = dt.Rows[0]["mondebit"].ToString();
                            lblCost.Text = dt.Rows[0]["moncredit"].ToString();
                            Label2.Text = "Total Sales";
                        }
                        lblops.Visible = false;
                        lblR.Visible = true;
                        lblCost.Visible = true;
                        lblCashinHand.Visible = false;
                    }
                }
                else
                { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Please Fill-Up Date');", true); }
            }
            catch { }
          }
    }
}