using BLL.Accounts.Approval;
using Flogging.Core;
using GLOBAL_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.ClassFiles;

namespace UI.Accounts.Approval
{
    public partial class IndentApproval_UI : BasePage
    {
        IndentApporval_BLL objAprval = new IndentApporval_BLL();
        DataTable dt = new DataTable();

        int unit, wh, enroll, costcenter, jobstation, intCOA, intCOS, intyear, intmonth; DateTime fdate, todate;
        decimal totalbudget, totalamount, remain;

        SeriLog log = new SeriLog();
        string location = "Accounts";
        string start = "starting Accounts\\Approval\\IndentApproval_UI";
        string stop = "stopping Accounts\\Approval\\IndentApproval_UI";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fd = log.GetFlogDetail(start, location, "Show", null);
                Flogger.WriteDiagnostic(fd);

                // starting performance tracker
                var tracker = new PerfTracker("Performance on Accounts\\Approval\\IndentApproval_UI  Indent Approval _UI", "", fd.UserName, fd.Location,
                    fd.Product, fd.Layer);
                try
                {
                    enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
                    #region ************************ Unit by User*****************
                    radPending.Checked = true;
                    dt = objAprval.UserbyUnitList(enroll);
                    ddlunit.DataSource = dt;
                    ddlunit.DataTextField = "strUnit";
                    ddlunit.DataValueField = "intUnitID";
                    ddlunit.DataBind();
                    #endregion

                    #region ************************ WH by User*****************
                    unit = int.Parse(ddlunit.SelectedValue);
                    dt = objAprval.WHbyUnitID(unit);
                    ddlwh.DataSource = dt;
                    ddlwh.DataTextField = "strWareHoseName";
                    ddlwh.DataValueField = "intWHID";
                    ddlwh.DataBind();
                    #endregion

                    #region ************************ WH by User*****************
                    dt = objAprval.CostCenterByUnit(unit);
                    ddlCostCenter.DataSource = dt;
                    ddlCostCenter.DataTextField = "strCCName";
                    ddlCostCenter.DataValueField = "intCostCenterID";
                    ddlCostCenter.DataBind();

                    dt = objAprval.ChartofAccountName(108);
                    ddlCOA.DataSource = dt;
                    ddlCOA.DataTextField = "strAccName";
                    ddlCOA.DataValueField = "intAccID";
                    ddlCOA.DataBind();
                    #endregion

                    pnlUpperControl.DataBind();
                }
                catch (Exception ex)
                {
                    var efd = log.GetFlogDetail(stop, location, "Show", ex);
                    Flogger.WriteError(efd);
                }



                fd = log.GetFlogDetail(stop, location, "Show", null);
                Flogger.WriteDiagnostic(fd);
                // ends
                tracker.Stop();


            }
        }

        protected void radApprove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.DataSource = "";
                dgvIndent.DataBind();
            }
            catch { }
        }

        protected void radPending_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dgvIndent.DataSource = "";
                dgvIndent.DataBind();
            }
            catch { }
        }

        protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region ************************ WH by User*****************
                unit = int.Parse(ddlunit.SelectedValue);
                dt = objAprval.WHbyUnitID(unit);
                ddlwh.DataSource = dt;
                ddlwh.DataTextField = "strWareHoseName";
                ddlwh.DataValueField = "intWHID";
                ddlwh.DataBind();
                #endregion
                dt = objAprval.CostCenterByUnit(unit);
                ddlCostCenter.DataSource = dt;
                ddlCostCenter.DataTextField = "strCCName";
                ddlCostCenter.DataValueField = "intCostCenterID";
                ddlCostCenter.DataBind();
            }
            catch { }
        }
        protected void ddlCostcenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TotalbudgetwithRemaining();


            }
            catch { }
        }
        protected void ddlCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TotalbudgetwithRemaining();
            }
            catch { }
        }
        #region ************************ Pending View & Approve View*****************
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                fdate = DateTime.Parse(txtFdate.Text);
                todate = DateTime.Parse(txtTodate.Text);
                wh = int.Parse(ddlwh.SelectedValue);
                if (radPending.Checked == true)
                {
                    dt = objAprval.IndentPendingView(wh, fdate, todate);
                    if (dt.Rows.Count > 0)
                    {
                        dgvIndent.DataSource = dt;
                        dgvIndent.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found');", true);
                    }

                }

                else
                {
                    dt = objAprval.IndentApprovedView(wh, fdate, todate);

                    if (dt.Rows.Count > 0)
                    {
                        dgvIndent.DataSource = dt;
                        dgvIndent.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('No Data Found');", true);
                    }
                }
            }
            catch { }

        }
        #endregion
        protected void btnApproved_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Approval\\IndentApproval_UI  btnApproved_Click", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {
                enroll = int.Parse(Session[SessionParams.USER_ID].ToString());
              
                int intCOS = int.Parse(ddlCostCenter.SelectedValue);
                int intCOA = int.Parse(ddlCOA.SelectedValue);
                string narration = txtNarration.Text.ToString();

                int indent = int.Parse(hdnIndent.Value);
                objAprval.IndentapprovedbyUser(enroll, intCOS, intCOA, narration, indent);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "StartupScript", "alert('Approved Sucessfully');", true);

                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);

                wh = int.Parse(ddlwh.SelectedValue);
                fdate = DateTime.Parse(txtFdate.Text);
                todate = DateTime.Parse(txtTodate.Text);

                if (radPending.Checked == true)
                {
                    dt = objAprval.IndentPendingView(wh, fdate, todate);
                    if (dt.Rows.Count > 0)
                    {
                        dgvIndent.DataSource = dt;
                        dgvIndent.DataBind();
                    }

                }

                else
                {
                        dt = objAprval.IndentApprovedView(wh, fdate, todate);
                        dgvIndent.DataSource = dt;
                        dgvIndent.DataBind();
                    
                }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "Submit", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "Submit", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }
        protected void btnDivClose_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "close", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Approval\\IndentApproval_UI Div Cloe", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "ClosehdnDivision();", true);
            fdate = DateTime.Parse(txtFdate.Text);
            todate = DateTime.Parse(txtTodate.Text);
            wh = int.Parse(ddlwh.SelectedValue);
            if (radPending.Checked == true)
            {
                dt = objAprval.IndentPendingView(wh, fdate, todate);
                if (dt.Rows.Count > 0)
                {
                    dgvIndent.DataSource = dt;
                    dgvIndent.DataBind();
                }
               
            }
            else
            {
                dt = objAprval.IndentApprovedView(wh, fdate, todate);
                dgvIndent.DataSource = dt;
                dgvIndent.DataBind();

                


            }
            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "close", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "close", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();

        }

        public string GetJSFunctionString(object intIndentID, object dteBudgetMonth,object intGlobalCOA,object intCostCenter)
        {
            string str = "";
            str = intIndentID.ToString() + ',' + dteBudgetMonth.ToString()+','+ intGlobalCOA.ToString()+ ',' + intCostCenter.ToString();
            return str;
        }
        protected void btnIndentDetalis_Click(object sender, EventArgs e)
        {
            var fd = log.GetFlogDetail(start, location, "close", null);
            Flogger.WriteDiagnostic(fd);

            // starting performance tracker
            var tracker = new PerfTracker("Performance on Accounts\\Approval\\IndentApproval_UI Div Cloe", "", fd.UserName, fd.Location,
                fd.Product, fd.Layer);
            try
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);
                dgvIndent.DataSource = "";
                dgvIndent.DataBind();
                char[] delimiterChars = { ',' };
                string temp = ((Button)sender).CommandArgument.ToString();
                string[] datas = temp.Split(delimiterChars);

                string indentno = datas[0].ToString();
                DateTime dtebudgetdate = DateTime.Parse(datas[1].ToString());
                intCOA = int.Parse(datas[2].ToString());
                intCOS = int.Parse(datas[3].ToString());
                int intmonth = dtebudgetdate.Month;
                int intyear = dtebudgetdate.Year;
                unit = int.Parse(ddlunit.SelectedValue);


                int indentid = int.Parse(indentno.ToString());
                hdnIndent.Value = indentid.ToString();
                hdnCOS.Value = intCOS.ToString();
                hdnCOA.Value = intCOA.ToString();
                hdnIntMonth.Value = intmonth.ToString();
                hdnintYear.Value = intyear.ToString();

                lbldetalis.Text = "Indent Number:" + indentid.ToString();
                dt = objAprval.IndentDetalisView(indentid);
                dgvDetalis.DataSource = dt;
                dgvDetalis.DataBind();

                decimal pricetotal = dt.AsEnumerable().Sum(row => row.Field<decimal>("LastPrice"));
               
                dgvDetalis.FooterRow.Cells[2].Text = "Total";
                dgvDetalis.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
               
                dgvDetalis.FooterRow.Cells[3].Text = pricetotal.ToString("N2");
              
                TotalbudgetwithRemaining();

            }
            catch (Exception ex)
            {
                var efd = log.GetFlogDetail(stop, location, "close", ex);
                Flogger.WriteError(efd);
            }



            fd = log.GetFlogDetail(stop, location, "close", null);
            Flogger.WriteDiagnostic(fd);
            // ends
            tracker.Stop();



        }

        private void TotalbudgetwithRemaining()
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "OpenHdnDiv();", true);

            int indentid = int.Parse(hdnIndent.Value.ToString());
            if (radPending.Checked==true)
            {

                ddlCostCenter.Enabled = true; ddlCOA.Enabled = true;
                unit = int.Parse(ddlunit.SelectedValue);
                intCOS = int.Parse(ddlCostCenter.SelectedValue);
                intCOA = int.Parse(ddlCOA.SelectedValue);
                intyear = int.Parse(hdnintYear.Value.ToString());
                intmonth = int.Parse(hdnIntMonth.Value.ToString());
               
               
               

                dt = objAprval.TotalBudgetView(unit, intCOS, intCOA, intyear, intmonth);
                if (dt.Rows.Count > 0) { totalbudget = Decimal.Parse(dt.Rows[0]["monBudget"].ToString()); }

                dt = objAprval.TotalAmountView(intyear, intmonth, intCOS, intCOA);
                if (dt.Rows.Count > 0) { totalamount = Decimal.Parse(dt.Rows[0]["monBudget"].ToString()); }

                try { remain = (totalbudget - totalamount); } catch { remain = 0; };
                txtBudget.Text = totalbudget.ToString();
                txtRemaing.Text = remain.ToString();

                btnApproved.Visible = true;

            }
            else
            {
                btnApproved.Visible = false;
                unit = int.Parse(ddlunit.SelectedValue);
                intCOS = int.Parse(hdnCOS.Value.ToString());
                intCOA = int.Parse(hdnCOA.Value.ToString());
                intyear = int.Parse(hdnintYear.Value.ToString());
                intmonth = int.Parse(hdnIntMonth.Value.ToString());

                dt = objAprval.TotalBudgetView(unit, intCOS, intCOA, intyear, intmonth);
                if (dt.Rows.Count > 0) { totalbudget = Decimal.Parse(dt.Rows[0]["monBudget"].ToString()); }

                dt = objAprval.TotalAmountView(intyear, intmonth, intCOS, intCOA);
                if (dt.Rows.Count > 0) { totalamount = Decimal.Parse(dt.Rows[0]["monBudget"].ToString()); }

                try { remain = (totalbudget - totalamount); } catch { remain = 0; };
                txtBudget.Text = totalbudget.ToString();
                txtRemaing.Text = remain.ToString();
                try { ddlCostCenter.SelectedValue = intCOS.ToString(); }
                catch { }
                try { ddlCOA.SelectedValue = intCOA.ToString(); }
                catch { }
                ddlCostCenter.Enabled = false; ddlCOA.Enabled = false;


            }
        }
    }
}