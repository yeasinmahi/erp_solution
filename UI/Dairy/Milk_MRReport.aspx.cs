using Dairy_BLL;
using SAD_BLL.Transport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UI.ClassFiles;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace UI.Dairy
{
    public partial class Milk_MRReport : BasePage
    {
        InternalTransportBLL objt = new InternalTransportBLL();
        Global_BLL obj = new Global_BLL();
        DataTable dt;

        int intUnitID; int intCCID; DateTime dteFrom; DateTime dteTo; int intWork; int intSuppID; int intMRNo; int intPart;

        string strEmpCode; string strKey;
        char[] delimiterChars = { '[', ']', ';', '-', '_', '.' }; string[] arrayKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnEnroll.Value = Session[SessionParams.USER_ID].ToString();
            hdnUnit.Value = Session[SessionParams.UNIT_ID].ToString();
            hdnJobStation.Value = Session[SessionParams.JOBSTATION_ID].ToString();

            if (!IsPostBack)
            {
                try
                {
                    pnlUpperControl.DataBind();

                    dt = obj.GetUnitList();
                    ddlUnit.DataTextField = "strUnit";
                    ddlUnit.DataValueField = "intUnitID";
                    ddlUnit.DataSource = dt;
                    ddlUnit.DataBind();

                    intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                    dt = obj.GetChillingCenterListWithAll(intUnitID);
                    ddlChillingCenter.DataTextField = "strChillingCenterName";
                    ddlChillingCenter.DataValueField = "intChillingCenterID";
                    ddlChillingCenter.DataSource = dt;
                    ddlChillingCenter.DataBind();
                }
                catch
                { }
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            LoadGrid(); 
        }

        private void LoadGrid()
        {
            try
            {
                lblUnitName.Text = ddlUnit.SelectedItem.ToString();
                lblCCName.Text = ddlChillingCenter.SelectedItem.ToString();
                lblFromToDate.Text = "MR Report As On " + Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd") + " To " + Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");

                intCCID = int.Parse(ddlChillingCenter.SelectedValue.ToString());
                if (intCCID == 0) { intWork = 3; } else { intWork = 1; }

                dteFrom = DateTime.Parse(txtFromDate.Text);
                dteTo = DateTime.Parse(txtToDate.Text);

                intSuppID = 0;
                intMRNo = 0;
                intPart = 0;

                dt = new DataTable();
                dt = obj.GetMilkMRReport(intWork, dteFrom, dteTo, intCCID, intSuppID, intMRNo, intPart); 
                dgvMRReport.DataSource = dt;
                dgvMRReport.DataBind();

                if (dt.Rows.Count > 0)
                {
                    lblUnitName.Visible = true;
                    lblCCName.Visible = true;
                    lblFromToDate.Visible = true;
                }
                else
                {
                    lblUnitName.Visible = false;
                    lblCCName.Visible = false;
                    lblFromToDate.Visible = false;
                }
            }
            catch { }
        }

        protected decimal tmrqty = 0;
        protected decimal tdeducqtyamo = 0;
        protected decimal tdecucfatamo = 0;
        protected decimal tmramo = 0;
        protected decimal tchalanqty = 0;
        protected decimal tchalanamo = 0;
        protected void dgvMRReport_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    tmrqty += decimal.Parse(((Label)e.Row.Cells[4].FindControl("lblMRQty")).Text);
                    tdeducqtyamo += decimal.Parse(((Label)e.Row.Cells[6].FindControl("lblDeductAmou")).Text);
                    tdecucfatamo += decimal.Parse(((Label)e.Row.Cells[7].FindControl("lblDeductFatPAmou")).Text);
                    tmramo += decimal.Parse(((Label)e.Row.Cells[8].FindControl("lblMRAmount")).Text);
                    tchalanqty += decimal.Parse(((Label)e.Row.Cells[11].FindControl("lblChallanQty")).Text);
                    tchalanamo += decimal.Parse(((Label)e.Row.Cells[13].FindControl("lblChallanAmount")).Text);
                }
            }
            catch { }
        }

        protected void ddlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                intUnitID = int.Parse(ddlUnit.SelectedValue.ToString());

                dt = obj.GetChillingCenterListWithAll(intUnitID);
                ddlChillingCenter.DataTextField = "strChillingCenterName";
                ddlChillingCenter.DataValueField = "intChillingCenterID";
                ddlChillingCenter.DataSource = dt;
                ddlChillingCenter.DataBind();

                lblUnitName.Visible = false;
                lblCCName.Visible = false;
                lblFromToDate.Visible = false;

            }
            catch { }

            dgvMRReport.DataSource = "";
            dgvMRReport.DataBind();
        }

        protected void ddlChillingCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMRReport.DataSource = "";
            dgvMRReport.DataBind();

            lblUnitName.Visible = false;
            lblCCName.Visible = false;
            lblFromToDate.Visible = false;
        }

        protected void btnDetails_Click(object sender, EventArgs e) 
        {
            //try
            //{
            string senderdata = ((Button)sender).CommandArgument.ToString();

            string strSearchKey = senderdata;
            string[] searchKey = Regex.Split(strSearchKey, ",");

            string intccid = searchKey[0];
            string intmrrno = searchKey[1];
            string dtemrrdate = searchKey[2];

            Session["UnitName"] = ddlUnit.SelectedItem.ToString();
            Session["CCName"] = ddlChillingCenter.SelectedItem.ToString();

            
            //hdfEmpCode.Value = searchKey[1];
            
            //ImageButton objImage = (ImageButton)sender;

            //string[] commandArgs = objImage.CommandArgument.ToString().Split(new char[] { ',' });
            //string intccid = commandArgs[0];
            //string intmrrno = commandArgs[1];
            //string dtemrrdate = commandArgs[2]; 

            //string intccid, 
            //string intmrrno, 
            //string dtemrrdate


            //dt = objPI.GetPIType(int.Parse(senderdata.ToString()));
            //string PIType = dt.Rows[0]["strPIType"].ToString();

            //    if (PIType == "PI")
            //    {
            ////ScriptManager.RegisterStartupScript(this, this.GetType(), "Clearcontrol", "ViewDocList('" + strDate + "','" + strTodate + "','" + hdUnit + "','" + enrol + "');", true);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "MRDetailsReport('" + intccid + "','" + intmrrno + "','" + dtemrrdate + "');", true);
            //    }
            //    else { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "ContractItemDetails('" + senderdata + "');", true); }
            //}
            //catch (Exception ex) { ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('" + ex.ToString() + "');", true); }
        }    















    }
}