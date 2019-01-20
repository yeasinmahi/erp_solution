﻿using System;
using System.Data;
using SCM_BLL;
using UI.ClassFiles;
using Utility;

namespace UI.PaymentModule
{
    public partial class BillUpdate : BasePage
    {
        private DataTable _dt = new DataTable();
        private readonly Billing_BLL _bll = new Billing_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlUpperControl.DataBind();
                try
                {
                    _dt = _bll.GetAllUnit(Enroll);
                    Common.LoadDropDown(ddlUnit, _dt, "intUnitID", "strUnit");
                    _dt.Clear();
                    DateTime now = DateTime.Now;
                    var dte = new DateTime(now.Year, now.Month, 1);
                    txtFromDate.Text = dte.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");

                    ApproveLavel();
                    if (hdnLevel.Value == "0")
                    {
                        Toaster(Message.PermissionDenied.ToFriendlyString(), Common.TosterType.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Toaster(ex.Message, Common.TosterType.Error);
                }
            }
        }

        public void ApproveLavel()
        {
            hdnLevel.Value = "0";
            _dt = _bll.GetUserInfoForAudit(Enroll);
            if (bool.Parse(_dt.Rows[0]["ysnAudit2"].ToString()) == true)
            {
                hdnLevel.Value = "2";
            }
            else if (bool.Parse(_dt.Rows[0]["ysnAudit1"].ToString()) == true)
            {
                hdnLevel.Value = "1";
            }
            
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            int intUnitid = int.Parse(ddlUnit.SelectedValue);
            DateTime dteFDate = DateTime.Parse(txtFromDate.Text);
            DateTime dteTDate = DateTime.Parse(txtToDate.Text);
            int intAction = int.Parse(ddlAction.SelectedValue);
            int intEntryType = 1;
            int intLevel = int.Parse(hdnLevel.Value);

            _dt = _bll.GetPaymentApprovalSummaryAllUnitForWeb(intUnitid, dteFDate, dteTDate, intAction, intEntryType, intLevel);
            if (_dt.Rows.Count > 0)
            {
                grid.DataSource = _dt;
                grid.DataBind();
            }
            else
            {
                Toaster(Message.NoFound.ToFriendlyString(),Common.TosterType.Warning);
            }
            

            //if (hdnLevel.Value == "1")
            //{
            //    grid.Columns[12].Visible = true;
            //    grid.Columns[1].Visible = true;
            //    grid.Columns[7].Visible = true;
            //    grid.Columns[8].Visible = true;
            //    grid.Columns[11].Visible = false;
            //}
            //else
            //{
            //    grid.Columns[12].Visible = false;
            //    grid.Columns[1].Visible = false;
            //    grid.Columns[7].Visible = false;
            //    grid.Columns[8].Visible = false;
            //    grid.Columns[11].Visible = true;
            //}
        }
        protected void btnBillRegister_OnClick(object sender, EventArgs e)
        {
            try
            {
                string strReffNo = txtBillReg.Text;
                _dt = _bll.GetBillInfoByBillReg(Enroll, strReffNo);
                if (_dt.Rows.Count > 0)
                {
                    grid.DataSource = _dt;
                    grid.DataBind();
                }
                else
                {
                    Toaster(Message.NoFound.ToFriendlyString(), Common.TosterType.Warning);
                }
                
            }
            catch (Exception ex)
            {
                Toaster(ex.Message,Common.TosterType.Error);
            }
        }

        
    }
}